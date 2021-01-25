import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TenderDispayAllOffersComponent } from './tender-dispay-all-offers.component';

describe('TenderDispayAllOffersComponent', () => {
  let component: TenderDispayAllOffersComponent;
  let fixture: ComponentFixture<TenderDispayAllOffersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TenderDispayAllOffersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TenderDispayAllOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
