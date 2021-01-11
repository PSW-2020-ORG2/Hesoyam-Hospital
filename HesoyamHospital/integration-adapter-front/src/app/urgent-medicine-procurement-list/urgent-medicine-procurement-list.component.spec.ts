import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrgentMedicineProcurementListComponent } from './urgent-medicine-procurement-list.component';

describe('UrgentMedicineProcurementListComponent', () => {
  let component: UrgentMedicineProcurementListComponent;
  let fixture: ComponentFixture<UrgentMedicineProcurementListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrgentMedicineProcurementListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UrgentMedicineProcurementListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
