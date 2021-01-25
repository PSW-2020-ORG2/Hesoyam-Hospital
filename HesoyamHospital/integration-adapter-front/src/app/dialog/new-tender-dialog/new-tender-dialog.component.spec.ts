import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTenderDialogComponent } from './new-tender-dialog.component';

describe('NewTenderDialogComponent', () => {
  let component: NewTenderDialogComponent;
  let fixture: ComponentFixture<NewTenderDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewTenderDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewTenderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
