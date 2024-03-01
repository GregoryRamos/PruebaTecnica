import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSelectChange } from '@angular/material/select';
import { MatTableDataSource } from '@angular/material/table';
import { attendace } from 'src/app/interface/attendace';
import { AttendanceService } from 'src/app/services/attendance.service';
import { DatePipe } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GradesService } from 'src/app/services/grades.service';
import { grade } from 'src/app/interface/grade';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.css']
})
export class GradesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['studentId', 'name', 'grades', 'literals'];
  dataSource = new MatTableDataSource<grade>();
  loading: boolean = false;
  selecValue: number = 1;
 

  


    @ViewChild(MatPaginator) paginator!: MatPaginator;

    constructor( private _gradesServices: GradesService, private fb: FormBuilder) {

      
    }
 
   ngOnInit(): void{
    this.getGradesList();
     
   }
 
 ngAfterViewInit(){
   this.dataSource.paginator = this.paginator;
 
  
 }
 saveGrade(){
   this.loading = true;
   this._gradesServices.addGrades(this.dataSource.data)
   .subscribe(data => {
     this.loading = false;
 })
 }

 getSelect(event: any) {
  this.getGradesList();
}

getGrade(score: number): string {
  let grade: string;
  switch (true) {
    case score >= 90 && score <= 100:
      grade = 'A';
      break;
    case score >= 80 && score < 90:
      grade = 'B';
      break;
    case score >= 70 && score < 80:
      grade = 'C';
      break;
    default:
      grade = 'F';
      break;
  }
  return grade;
}
onGradeChange(newValue: number, element: any) {
  if (newValue > 100) {
    element.grades = 100; // Assigning the new value to the property in the object
  } else {
    element.grades = newValue; // Assigning the new value to the property in the object
  }
}
removeNonNumeric(event: any) {
  // Obtén el valor actual del input
  let value = event.target.value;

  // Elimina cualquier carácter no numérico usando una expresión regular
  value = value.replace(/[^0-9]/g, '');

  // Asigna el valor modificado de vuelta al input
  event.target.value = value;
}
getGradesList(){
  this.loading = true;
  this._gradesServices.getGradesList(this.selecValue)
  .subscribe(data => {
    this.loading = false;
    this.dataSource.data = data;
})

}

}











