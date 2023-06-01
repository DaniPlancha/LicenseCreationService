export class SelectedLicenseProduct{
    public id: number;
    public  count: number;
    
    constructor(licenseProductId: number, count: number) {
        this.id=licenseProductId;
        this.count=count;
    }
}