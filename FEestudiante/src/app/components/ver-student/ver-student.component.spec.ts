import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerStudentComponent } from './ver-student.component';

describe('VerStudentComponent', () => {
  let component: VerStudentComponent;
  let fixture: ComponentFixture<VerStudentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VerStudentComponent]
    });
    fixture = TestBed.createComponent(VerStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
