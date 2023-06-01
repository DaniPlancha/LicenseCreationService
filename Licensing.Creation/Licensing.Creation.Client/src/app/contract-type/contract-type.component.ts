import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'contract-type',
  templateUrl: './contract-type.component.html',
  styleUrls: ['./contract-type.component.css']
})
export class ContractTypeComponent {

  public isOpen : boolean = false;
  public inputID : string = "";
  public inputName : string = "";
  public contractTypes !: Array<{ id : number, name : string }>;
  private route : string = 'https://localhost:62350/api/contracttypes';

  constructor(private httpClient : HttpClient) {
    this.GetContractTypes();
  }

  private GetContractTypes() : void {
    this.httpClient.get(this.route, {
      headers: {
        'Content-Type': 'application/json'
      }
    }).subscribe((models : any) => {
      this.contractTypes = models;
      console.log(`< get successful ! ${this.contractTypes}>`);
    });
  }

  public SubmitContractType(data : any) : void {
    this.httpClient.post(this.route, {
      ID : data.id,
      Name : data.name
    }, {
      headers: {
        'Content-Type': 'application/json'
      }
    }).subscribe((model : any) => {
      this.inputID = "";
      this.inputName = "";
      this.GetContractTypes();
      console.log(`< post successful ! ${model}>`)
    });
  }

  public DeleteContractType(id : number) : void {
    this.httpClient.delete(this.route + `/${id}`, {
      headers: {
        'Content-Type': 'application/json'
      }
    }).subscribe((model : any) => {
      this.GetContractTypes();
      console.log(`< delete successful ! ${model}>`)
    });
  }

}
