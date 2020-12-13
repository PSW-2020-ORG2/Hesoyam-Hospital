import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseSchedulingTypeComponent } from './choose-scheduling-type.component';

describe('ChooseSchedulingTypeComponent', () => {
  let component: ChooseSchedulingTypeComponent;
  let fixture: ComponentFixture<ChooseSchedulingTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChooseSchedulingTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseSchedulingTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
