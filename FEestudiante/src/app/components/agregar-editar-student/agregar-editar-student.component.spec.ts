import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarEditarStudentComponent } from './agregar-editar-student.component';

describe('AgregarEditarStudentComponent', () => {
  let component: AgregarEditarStudentComponent;
  let fixture: ComponentFixture<AgregarEditarStudentComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgregarEditarStudentComponent]
    });
    fixture = TestBed.createComponent(AgregarEditarStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
