import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicineAvailabilityComponent } from './medicine-availability.component';

describe('MedicineAvailabilityComponent', () => {
  let component: MedicineAvailabilityComponent;
  let fixture: ComponentFixture<MedicineAvailabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicineAvailabilityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MedicineAvailabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
