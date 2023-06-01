import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild, ɵflushModuleScopingQueueAsMuchAsPossible } from '@angular/core';
import { Observable } from 'rxjs';
import { LicenseProductsSelectionDisplay } from 'src/app/Models/license-products-selection-display';
import { LicenseProductModel } from 'src/app/Models/LicenseProductModel';
import { SelectedLicenseProduct } from 'src/app/Models/selected-license-product';
import { InstallationTypeComponent } from '../installation-type/installation-type.component';

@Component({
  selector: 'licensing-selection',
  templateUrl: './licensing-selection.component.html',
  styleUrls: ['./licensing-selection.component.css']
})
export class LicensingSelectionComponent implements OnInit {
  
  
  @Input() public selectedLicenseProducts : Array<SelectedLicenseProduct> = [];
  @Output() productSelectionChangedEvent = new EventEmitter<any>();
  private headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  private urlLicenseProducts = 'https://localhost:62350/api/licenseproducts';
  public lockedLicenseProducts : Array<number> = [];
  private allLicenseProducts !: Array<LicenseProductModel>;
  public displayedLicenseProducts !: Array<LicenseProductsSelectionDisplay>;
  private issuedTypesToBeDisabled: string="Module";
  public startingCounts:Array<number> =[];
  constructor(private https: HttpClient) { }

  ngOnInit() : void {
    this.RetrieveLicenseProducts().subscribe((models: any) => {
      this.allLicenseProducts = models;
      this.displayedLicenseProducts = this.SelectedLicenseProductsToDisplay(this.allLicenseProducts, this.selectedLicenseProducts);
    });
  }
  private SelectedLicenseProductsToDisplay(allLicenseProducts: LicenseProductModel[], selectedLicenseProducts: any) : Array<LicenseProductsSelectionDisplay> {
    
    let displayedLicenseProducts = [];
    for (let licenseProduct of allLicenseProducts) {
      let selectedProduct = selectedLicenseProducts.find((x: any) => licenseProduct.id == x.id);
      let licenseProductSelected = {
        product: licenseProduct,
        selected: selectedProduct != undefined,
        count: selectedProduct?.count ?? 1
      };
      displayedLicenseProducts.push(licenseProductSelected);
      
    }
    return displayedLicenseProducts;
  }
  
  private RetrieveLicenseProducts() : any {
    return this.https.get(this.urlLicenseProducts, { headers: this.headers });
  }

  public Display(selectedLicenseProducts: Array<SelectedLicenseProduct>,lockedLicenseProducts: Array<number>) : void {
    this.selectedLicenseProducts = selectedLicenseProducts;
    this.lockedLicenseProducts=lockedLicenseProducts;
    this.displayedLicenseProducts = this.SelectedLicenseProductsToDisplay(this.allLicenseProducts, this.selectedLicenseProducts);
    for(let p of this.displayedLicenseProducts){
      this.startingCounts.push(p.count);
    }
  }
  public toggleProductSelection(licenseProduct : LicenseProductsSelectionDisplay){
    licenseProduct.selected=!licenseProduct.selected;
    this.productSelectionChangedEvent.emit(licenseProduct);
  }
  public isLocked(licenseProduct:LicenseProductsSelectionDisplay){
    let disabled = this.lockedLicenseProducts.find((x)=>x == licenseProduct.product.id)!=undefined;
    
    return disabled;
  }
  public startingCount(licenseProduct:any):number{
    return this.isLocked(licenseProduct)? this.startingCounts[ this.displayedLicenseProducts.indexOf(licenseProduct)] : 1;
  }
}
