import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrescribeTherapyComponent } from './prescribe-therapy.component';

describe('PrescribeTherapyComponent', () => {
  let component: PrescribeTherapyComponent;
  let fixture: ComponentFixture<PrescribeTherapyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrescribeTherapyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrescribeTherapyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
