import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, Inject, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';

import { LicensingSelectionComponent } from '../licensing-selection/licensing-selection.component';
import { FormsModule } from '@angular/forms';
import { LicenseProductModel } from 'src/app/Models/LicenseProductModel';
import { SelectedLicenseProduct } from '../Models/selected-license-product';
@Component({
  selector: 'left-nav-bar',
  templateUrl: './left-nav-bar.component.html',
  styleUrls: ['./left-nav-bar.component.css']
})
export class LeftNavBarComponent {
  @Input() isOpened: boolean = false;
  @Output() isOpenedChange = new EventEmitter<boolean>();

  public Close(): void {
    this.isOpened = false;
    this.isOpenedChange.emit(false);
  }
}
