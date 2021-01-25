import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderDisplayManagerComponent } from './tender-display-manager.component';

describe('TenderDisplayManagerComponent', () => {
  let component: TenderDisplayManagerComponent;
  let fixture: ComponentFixture<TenderDisplayManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderDisplayManagerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderDisplayManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
