import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentRecommendationComponent } from './appointment-recommendation.component';

describe('AppointmentRecommendationComponent', () => {
  let component: AppointmentRecommendationComponent;
  let fixture: ComponentFixture<AppointmentRecommendationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppointmentRecommendationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentRecommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
