import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { LicenseProductsSelectionDisplay } from 'src/app/Models/license-products-selection-display';
import { LicenseProductModel } from 'src/app/Models/LicenseProductModel';
import { SelectedLicenseProduct } from 'src/app/Models/selected-license-product';
import { LicensingSelectionComponent } from '../licensing-selection/licensing-selection.component';

@Component({
  selector: 'installation-type',
  templateUrl: './installation-type.component.html',
  styleUrls: ['./installation-type.component.css']
})
export class InstallationTypeComponent {

  private headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  private urlInstallationTypes: string = 'https://localhost:62350/api/installationtypes';
  isInstallaionTypesOpen: boolean = false;
  @ViewChild(LicensingSelectionComponent) selectionComponent!: LicensingSelectionComponent;
  id !: string;
  name !: string;
  public installationTypes !: Array<{ id: number, name: string, licenseProducts: Array<SelectedLicenseProduct> }>;
  public selectedInstallationType !: { id: number, name: string, licenseProducts: Array<SelectedLicenseProduct> };
  constructor(private https: HttpClient) {
    this.GetInstallationTypes();
  }

  GetInstallationTypes() {
    return this.https.get(this.urlInstallationTypes, { headers: this.headers })
      .subscribe((models: any) => {
        this.installationTypes = models;
        console.log(this.installationTypes)
      });
  }

  AddInstallationType(model: any) {
    this.id = "";
    this.name = "";
    return this.https.post(this.urlInstallationTypes, { Name: model.name, licenseProducts: Array<{}> }, { headers: this.headers })
      .subscribe(() => {
        console.log("Post successful")
        this.GetInstallationTypes();
      });
  }

  DeleteInstallationType(id: number) {
    return this.https.delete(this.urlInstallationTypes + `/${id}`, { headers: this.headers })
      .subscribe(() => {
        console.log("delete successful");
        this.GetInstallationTypes()
      });
  }

  DisplaySelectedLicenseProducts(installationType: { id: number, name: string, licenseProducts: Array<SelectedLicenseProduct> }) {
    this.selectedInstallationType = installationType;
    this.selectionComponent.Display(installationType.licenseProducts, []);
  }
  UpdateProductSelection(licenseProduct: LicenseProductsSelectionDisplay) {
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
    this.https.put(this.urlInstallationTypes + `/${this.selectedInstallationType.id}`, this.selectedInstallationType)
    .subscribe(() => {
      console.log("put successful");
    });
  }
}
