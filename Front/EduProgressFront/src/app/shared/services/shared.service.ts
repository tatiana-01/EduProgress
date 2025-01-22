import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private url="https://localhost:7216/api";
   token = localStorage.getItem("token");
   headers = new HttpHeaders({
    'Authorization': `Bearer ${this.token}`
  });

    constructor(private httpClient:HttpClient) { }

    
    getCourses(username: string, rol: string): Observable<any> {

      return this.httpClient.get(`${this.url}/Curso?user=${username}&rol=${rol}`, { headers:this.headers });
    }

    getStudents( curso: string): Observable<any> {
      return this.httpClient.get(`${this.url}/Persona?curso=${curso}`, { headers:this.headers })
    }
}
