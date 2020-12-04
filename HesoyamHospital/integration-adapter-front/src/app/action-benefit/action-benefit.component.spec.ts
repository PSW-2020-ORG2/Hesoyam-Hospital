import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionBenefitComponent } from './action-benefit.component';

describe('ActionBenefitComponent', () => {
  let component: ActionBenefitComponent;
  let fixture: ComponentFixture<ActionBenefitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionBenefitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionBenefitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
