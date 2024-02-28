import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { student } from 'src/app/interface/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-agregar-editar-student',
  templateUrl: './agregar-editar-student.component.html',
  styleUrls: ['./agregar-editar-student.component.css']
})
export class AgregarEditarStudentComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup
  
  constructor(private fb: FormBuilder,
    private _studentService: StudentService){
    this.form = this.fb.group({
      name: ['', Validators.required, ],
      gender: ['', Validators.required ],
      birthday: ['', Validators.required ]
    })
  }

  ngOnInit(): void {
      
  }

agregarstudent(){
//armar objeto
  const Student: student = {
    id: 0,
    name: this.form.value.name,
    gender: Number(this.form.value.gender),
    birthday: this.form.value.birthday
  }
  //enviamos objeto al backend
    this._studentService.addStudent(Student).subscribe(data => {
    console.log(data)
      })
  }
}  


