import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { student } from 'src/app/interface/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-listado-student',
  templateUrl: './listado-student.component.html',
  styleUrls: ['./listado-student.component.css']
})
export class ListadoStudentComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['name', 'gender', 'birthday', 'acciones'];
  dataSource = new MatTableDataSource<student>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar, private _studentService:StudentService ) { }

    ngOnInit(): void{
      this.obtenerStudent();
    }

  ngAfterViewInit(){
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
   
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerStudent(){
    this.loading = true;
    this._studentService.getStudents().subscribe(data => {
      this.loading = false;
      this.dataSource.data = data;
    })
  }

  eliminarEstudiante(id: number){
    this.loading = true;
    this._studentService.deleteStudent(id).subscribe(() =>{
    this.mensajeExito();
    this.loading = false;
    this.obtenerStudent();  
    });

    this._snackBar.open("Student was deleted", '', {
      duration: 3000,
      horizontalPosition: 'right'
    });
  }

  mensajeExito(){
    this._snackBar.open("Student was deleted", '', {
      duration: 3000,
      horizontalPosition: 'right'
    });
  }
}
  
  
  


  