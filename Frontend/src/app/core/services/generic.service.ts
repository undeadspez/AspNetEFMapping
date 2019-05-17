import { Injectable, Inject } from '@angular/core';
import { API_URL } from '../api-url-token';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenericService<T, P extends { collection: string }> {

  constructor(
    @Inject(API_URL) private apiUrl: string,
    private http: HttpClient
  ) { }

}
