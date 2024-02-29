import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendaceComponent } from './attendace.component';

describe('AttendaceComponent', () => {
  let component: AttendaceComponent;
  let fixture: ComponentFixture<AttendaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AttendaceComponent]
    });
    fixture = TestBed.createComponent(AttendaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
