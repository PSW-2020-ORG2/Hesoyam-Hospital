import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderDisplayComponent } from './tender-display.component';

describe('TenderDisplayComponent', () => {
  let component: TenderDisplayComponent;
  let fixture: ComponentFixture<TenderDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
