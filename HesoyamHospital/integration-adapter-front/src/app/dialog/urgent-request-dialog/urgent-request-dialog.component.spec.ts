import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrgentRequestDialogComponent } from './urgent-request-dialog.component';

describe('UrgentRequestDialogComponent', () => {
  let component: UrgentRequestDialogComponent;
  let fixture: ComponentFixture<UrgentRequestDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UrgentRequestDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UrgentRequestDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
