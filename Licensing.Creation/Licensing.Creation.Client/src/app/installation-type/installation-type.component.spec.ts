import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InstallationTypeComponent } from './installation-type.component';

describe('InstallationTypeComponent', () => {
  let component: InstallationTypeComponent;
  let fixture: ComponentFixture<InstallationTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InstallationTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InstallationTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
