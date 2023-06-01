import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LicenseProductComponent } from './license-product.component';

describe('LicenseProductComponent', () => {
  let component: LicenseProductComponent;
  let fixture: ComponentFixture<LicenseProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LicenseProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LicenseProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
