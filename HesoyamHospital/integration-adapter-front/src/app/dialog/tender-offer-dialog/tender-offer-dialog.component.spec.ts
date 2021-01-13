import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderOfferDialogComponent } from './tender-offer-dialog.component';

describe('TenderOfferDialogComponent', () => {
  let component: TenderOfferDialogComponent;
  let fixture: ComponentFixture<TenderOfferDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderOfferDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderOfferDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
