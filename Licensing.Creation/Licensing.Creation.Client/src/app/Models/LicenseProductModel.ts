export class LicenseProductModel{
    id:number;
    name: string;
    issuedType:string;
    
    constructor(id:number , name:string, issuedType: string) {
        this.id=id;
        this.name=name;
        this.issuedType=issuedType;
    }
}