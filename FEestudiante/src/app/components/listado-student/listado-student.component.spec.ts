import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoStudentComponent } from './listado-student.component';

describe('ListadoStudentComponent', () => {
  let component: ListadoStudentComponent;
  let fixture: ComponentFixture<ListadoStudentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoStudentComponent]
    });
    fixture = TestBed.createComponent(ListadoStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
