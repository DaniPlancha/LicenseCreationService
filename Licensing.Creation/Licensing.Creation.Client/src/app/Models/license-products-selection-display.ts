import { LicenseProductModel } from "./LicenseProductModel";

export class LicenseProductsSelectionDisplay {
    product: LicenseProductModel;
    selected: boolean;
    count: number;
    constructor(product: LicenseProductModel, selected: boolean,  count: number) {
        this.product = product;
        this.selected = selected;
        this.count = count;
    }
}