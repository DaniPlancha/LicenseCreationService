import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, Inject, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';

import { LicensingSelectionComponent } from '../licensing-selection/licensing-selection.component';
import { FormsModule } from '@angular/forms';
import { LicenseProductModel } from 'src/app/Models/LicenseProductModel';
import { SelectedLicenseProduct } from '../Models/selected-license-product';
@Component({
  selector: 'app-license-create',
  templateUrl: './license-create.component.html',
  styleUrls: ['./license-create.component.css']
})
export class LicenseCreateComponent {
  private headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  private urlInstallationTypes = 'https://localhost:62350/api/installationtypes';
  private urlContractTypes = 'https://localhost:62350/api/contracttypes';
  private urlLicenseCreation = 'https://localhost:62350/api/licensecreation'
  public installationTypes !: Array<{ id: number, name: string, licenseProducts: Array<SelectedLicenseProduct> }>;
  public contractTypes!: Array<{ id: number, name: string }>;
  public selectedInstallationType !: { id: number, name: string, licenseProducts: Array<SelectedLicenseProduct> };
  public selectedContractType !: { id: number, name: string };
  public toggled!:boolean;
  public email!:string;
  public phone!:string;
  public company!:string;
  public version!:string;
  public organizationKey!:string;

  @ViewChild(LicensingSelectionComponent) selectionComponent!: LicensingSelectionComponent;

  constructor(private httpClient: HttpClient) {
    this.GetData(this.urlInstallationTypes).subscribe((installationTypes : any) => {this.installationTypes = installationTypes
    this.toggled=true;
    });
    this.GetData(this.urlContractTypes).subscribe((_contractTypes : any) => this.contractTypes = _contractTypes);
  }

  private GetData(url: any) {
    return this.httpClient.get(url, { headers: this.headers });
  }

  public SubmitData() {
    let licenseToCreate = {
      contractType: this.selectedContractType,
      installationTypeId:this.selectedInstallationType.id,
      allLicenseProducts: this.selectedInstallationType.licenseProducts,
      email:this.email,
      phone:this.phone,
      company:this.company,
      version:this.version,
      organizationKey:this.organizationKey
    }

    console.log(licenseToCreate)

    this.httpClient.post<string>(this.urlLicenseCreation, licenseToCreate, {
        headers: this.headers, responseType: 'text' as 'json'
      })
      .subscribe((_createdLicense) => {
        console.log("submited");

        var blob = new Blob([_createdLicense], { type: 'text/plain' });
        var link = document.createElement('a');
        link.href = window.URL.createObjectURL(blob);
        link.download = 'license.lic';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
      });
  }

  public DisplaySelectedLicenseProducts(installationTypeId : string) {
    this.selectedInstallationType = this.installationTypes.find((a) => a.id == parseInt(installationTypeId))!;
    console.log(this.selectedInstallationType)
    this.selectionComponent.Display(this.selectedInstallationType!.licenseProducts,this.selectedInstallationType!.licenseProducts.map((x) =>x.id));
  }

  public saveSelectedContractType(contractTypeId : string) : void {
    this.selectedContractType = this.contractTypes.find((a) => a.id == parseInt(contractTypeId))!;
    console.log(this.selectedContractType);
  }

  public changeSelectedInstallationTypeProducts(licenseProduct: any): void {
    
    if (licenseProduct.selected) {
      this.selectedInstallationType.licenseProducts.push({
        id : licenseProduct.product.id,
        count : licenseProduct.count
      });
    } else {
      let a = this.selectedInstallationType.licenseProducts.find((x) => x.id == licenseProduct.product.id)!;
      let index : number = this.selectedInstallationType.licenseProducts.indexOf(a);
      this.selectedInstallationType.licenseProducts.splice(index, 1);
    }
    console.log(this.selectedInstallationType);
  }
}
