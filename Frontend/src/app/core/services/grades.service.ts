import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../api-url-token';
import { Grade } from '../models';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GradesService {

  constructor(
    @Inject(API_URL) private apiUrl: string,
    private http: HttpClient
  ) { }

  getAll = (count?: number): Observable<Grade[]> =>
    this.http.get<Grade[]>(`${this.apiUrl}/Grades`).pipe(
      map(grades => count 
        ? grades.slice(0, count)
        : grades
      )
    );

  get = (id: number): Observable<Grade> =>
    this.http.get<Grade>(`${this.apiUrl}/Grades/${id}`);

  remove = (grade: Grade): Observable<void> =>
    this.http.delete<void>(`${this.apiUrl}/Grades/${grade.GradeId}`);

}
