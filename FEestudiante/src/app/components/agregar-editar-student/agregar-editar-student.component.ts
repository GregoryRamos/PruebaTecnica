import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';
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
  id: number;
  operacion: string = 'Add Student'
  
  constructor(private fb: FormBuilder,
    private _studentService: StudentService,
    private _snackBar: MatSnackBar,
    private router: Router,
    private aRoute: ActivatedRoute)
    
    {                      

    this.form = this.fb.group({
      name: ['', Validators.required, ],
      gender: ['', Validators.required ],
      birthday: ['', Validators.required ]
    })

    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
    
  }

  ngOnInit(): void {
    if(this.id !=0) {
      this.operacion = "Edit Student"
      this.getStudent(this.id);
    }
  }

agregarEditarstudent(){


//armar objeto
  const Student: student = {
    id: 0,
    name: this.form.value.name,
    gender: Number(this.form.value.gender),
    birthday: this.form.value.birthday
  }

  if(this.id !=0){
    Student.id = this.id;
    this.editarStudent(this.id, Student)
  }else{
    this.agregarStudent(Student)
  }

  }

  editarStudent(id:number, student: student){
    this.loading = true;
    this._studentService.updateStudent( student).subscribe(() =>{
    this.loading = false;
    this.mensajeExito('updated');
    this.router.navigate(['/liststudent']);
    })
  }

  agregarStudent(student: student){
      //enviamos objeto al backend
      this._studentService.addStudent(student).subscribe(data => {
        console.log(data);
        this.mensajeExito('created');
        this.router.navigate(['/liststudent']);
          })
  }

  getStudent(id:number){
    this.loading = true;
      this._studentService.getStudent(id).subscribe(data => {
        this.form.patchValue({
          name: data.name,
          gender: data.gender,
          birthday: data.birthday
        })
    this.loading = false;
      })
  }

  mensajeExito(text: string){
    this._snackBar.open(`Student was ${text}`, '', {
      duration: 3000,
      horizontalPosition: 'right'
    });
  }  

}