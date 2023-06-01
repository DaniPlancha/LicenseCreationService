import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LeftNavBarComponent } from './left-nav-bar/left-nav-bar.component';
import { RightNavBarComponent } from 'src/app/right-nav-bar/right-nav-bar.component';


import { FormsModule } from '@angular/forms';
import { ContractTypeComponent } from './contract-type/contract-type.component';


import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LicenseCreateComponent } from './license-create/license-create.component';
import { LicensingSelectionComponent } from './licensing-selection/licensing-selection.component';
import { InstallationTypeComponent } from './installation-type/installation-type.component';
import { LicenseProductComponent } from './license-product/license-product.component';

@NgModule({
  declarations: [
    AppComponent,
    LeftNavBarComponent,
    RightNavBarComponent,
    ContractTypeComponent,
    LicenseProductComponent,
    InstallationTypeComponent,
    LicensingSelectionComponent,
    LicenseCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
