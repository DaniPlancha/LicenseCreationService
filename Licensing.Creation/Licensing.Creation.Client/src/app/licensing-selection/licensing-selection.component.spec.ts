import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LicensingSelectionComponent } from './licensing-selection.component';

describe('LicensingSelectionComponent', () => {
  let component: LicensingSelectionComponent;
  let fixture: ComponentFixture<LicensingSelectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LicensingSelectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LicensingSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
