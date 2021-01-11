import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrgentMedicineProcurementRequestComponent } from './urgent-medicine-procurement-request.component';

describe('UrgentMedicineProcurementRequestComponent', () => {
  let component: UrgentMedicineProcurementRequestComponent;
  let fixture: ComponentFixture<UrgentMedicineProcurementRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrgentMedicineProcurementRequestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UrgentMedicineProcurementRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
