import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
// import { FormsModule } from '@angular/forms';
// import {NgForm} from '@angular/forms';

@Component({
  selector: 'license-product',
  templateUrl: './license-product.component.html',
  styleUrls: ['./license-product.component.css']
})
export class LicenseProductComponent {
  private headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  private urlLicenseProducts = 'https://localhost:62350/api/licenseproducts';
  isLicenseProductsOpen: boolean = false;
  public licenseProducts!: Array<{ id: number, name: string, issuedType: string }>;
  id!: string;
  name!: string;
  issuedType!: string;
  
  constructor(private https: HttpClient) {
    this.GetLicenseProducts();
  }
  private GetLicenseProducts() {
    return this.https.get(this.urlLicenseProducts, { headers: this.headers }).subscribe((models: any) => this.licenseProducts = models);
  }
  public AddData(model: any) {
    this.id = "";
    this.name = "";
    this.issuedType = "";
    return this.https.post(this.urlLicenseProducts, { id: model.id, name: model.name, issuedType: model.issuedType }, { headers: this.headers }).subscribe(model => this.GetLicenseProducts());
  }
  public DeleteContractType(modelId:number){
    console.log(modelId);
    return this.https.delete(this.urlLicenseProducts, {body:modelId}).subscribe(x=>this.GetLicenseProducts());
  }
}
