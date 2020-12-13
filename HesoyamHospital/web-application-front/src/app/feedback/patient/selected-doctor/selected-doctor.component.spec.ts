import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedDoctorComponent } from './selected-doctor.component';

describe('SelectedDoctorComponent', () => {
  let component: SelectedDoctorComponent;
  let fixture: ComponentFixture<SelectedDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectedDoctorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectedDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
