import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { grade } from '../interface/grade';

@Injectable({
  providedIn: 'root'
})
export class GradesService {  private myAppUrl: string = 'https://localhost:44339/'
private myApiUrl: string = 'api/Grades/';

constructor(private http: HttpClient) { }

addGrades(grade: grade[]): Observable<grade[]>{
  return this.http.post<grade[]>(this.myAppUrl + this.myApiUrl, grade);
}

getGradesList(subjectid:number ): Observable<grade[]> {
  return this.http.get<grade[]>(this.myAppUrl + this.myApiUrl +subjectid );
}

}