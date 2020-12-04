import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardAppointmentComponent } from './standard-appointment.component';

describe('StandardAppointmentComponent', () => {
  let component: StandardAppointmentComponent;
  let fixture: ComponentFixture<StandardAppointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StandardAppointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StandardAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
