import { Component} from '@angular/core';
import { LeftNavBarComponent } from './left-nav-bar/left-nav-bar.component';
import { RightNavBarComponent } from 'src/app/right-nav-bar/right-nav-bar.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'Licensing.Creation.Client';
  isNavbarCreateOpened = false;
  isNavBarAdministrationOpened= false;

  OpenNavBarCreate():void{
    this.isNavbarCreateOpened = true;
    this.isNavBarAdministrationOpened=false;
  }
  OpenNavBarAdministration():void{
     this.isNavBarAdministrationOpened=true;
     this.isNavbarCreateOpened = false;
  }
}
