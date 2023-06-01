import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
@Component({
  selector: 'right-nav-bar',
  templateUrl: './right-nav-bar.component.html',
  styleUrls: ['./right-nav-bar.component.css']
})
export class RightNavBarComponent  {
  @Input() isOpenedAdministration : boolean = false;
  @Output() isOpenedAdministrationChange = new EventEmitter<boolean>();

  constructor() { }

  public Close() : void{
    this.isOpenedAdministration = false;
    this.isOpenedAdministrationChange.emit(false);
  }
}
