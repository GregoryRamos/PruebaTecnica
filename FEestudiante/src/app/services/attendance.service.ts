import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { attendace } from '../interface/attendace';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  private myAppUrl: string = 'https://localhost:44339/'
  private myApiUrl: string = 'api/attendance/';

  constructor(private http: HttpClient) { }

  getAttendanceList(subjectid:number, date: string | null ): Observable<attendace[]> {
    return this.http.get<attendace[]>(this.myAppUrl + this.myApiUrl + '?subjectid=' +subjectid + '&date=' + date);
  }

  addAttendance(attendancelist: attendace[]): Observable<attendace>{
    return this.http.post<attendace>(this.myAppUrl + this.myApiUrl, attendancelist);
  }


}
