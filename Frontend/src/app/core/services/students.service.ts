import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { API_URL } from '../api-url-token';
import { Student } from '../models';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(
    @Inject(API_URL) private apiUrl: string,
    private http: HttpClient
  ) { }

  getAll = (): Observable<Student[]> =>
    this.http.get<Student[]>(`${this.apiUrl}/Students`);

  get = (id: number): Observable<Student> =>
    this.http.get<Student>(`${this.apiUrl}/Students/${id}`);

  remove = (student: Student): Observable<void> =>
    this.http.delete<void>(`${this.apiUrl}/Students/${student.StudentId}`);
    
}
