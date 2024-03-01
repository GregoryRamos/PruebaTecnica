import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSelectChange } from '@angular/material/select';
import { MatTableDataSource } from '@angular/material/table';
import { attendace } from 'src/app/interface/attendace';
import { AttendanceService } from 'src/app/services/attendance.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-attendace',
  templateUrl: './attendace.component.html',
  styleUrls: ['./attendace.component.css']
})
export class AttendaceComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['studentId', 'name', 'status', 'comment'];
  dataSource = new MatTableDataSource<attendace>();
  loading: boolean = false;
  DateFilter!: Date;
  fechaActual: Date = new Date();
  selecValue: number = 1;
  


  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor( private _attendanceServices: AttendanceService, private datePipe: DatePipe) {
    
   }

  ngOnInit(): void{
    this.getAttendanceList();
    
  }

ngAfterViewInit(){
  this.dataSource.paginator = this.paginator;

 
}
saveAttendance(){
  this.loading = true;
  this._attendanceServices.addAttendance(this.dataSource.data)
  .subscribe(data => {
    this.loading = false;
})
}
getAttendanceList(){
  this.loading = true;
  this._attendanceServices.getAttendanceList(this.selecValue,this.datePipe.transform(this.fechaActual,'yyyy-MM-dd'))
  .subscribe(data => {
    this.loading = false;
    this.dataSource.data = data;
})
}
getSelect(event: any) {
  this.getAttendanceList();
}
}
