import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { student } from '../interface/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private myAppUrl: string = 'https://localhost:44339/'
  private myApiUrl: string = 'api/student/';

  constructor(private http: HttpClient) { }

  getStudents(): Observable<student[]> {
    return this.http.get<student[]>(this.myAppUrl + this.myApiUrl);
  }

  getStudent(id: number): Observable<student> {
    return this.http.get<student>(this.myAppUrl + this.myApiUrl + id);
  }

  deleteStudent(id: number): Observable<void>{
    return this.http.delete<void>(this.myAppUrl + this.myApiUrl + id)
  }

  addStudent(student: student): Observable<student>{
    return this.http.post<student>(this.myAppUrl + this.myApiUrl, student);
  }

}
