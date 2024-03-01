import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { student } from 'src/app/interface/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-ver-student',
  templateUrl: './ver-student.component.html',
  styleUrls: ['./ver-student.component.css']
})
export class VerStudentComponent implements OnInit {
  id: number;
  student!: student;
  loading: boolean = false;


  
  constructor(private _studentServices: StudentService,
              private aRoute: ActivatedRoute ) {
           this.id = +this.aRoute.snapshot.paramMap.get('id')!;
           

  }

  ngOnInit(): void {
      this.obtenerStudent();
  }

  obtenerStudent(){
    this.loading = true;
    this._studentServices.getStudent(this.id).subscribe(data =>{
    this.student = data;
    this.loading = false;
    })
  }
}
