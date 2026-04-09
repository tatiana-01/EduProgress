import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentsServiceService {

  private url="https://localhost:7216/api";
     token = localStorage.getItem("token");
     headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`
    });
  
      constructor(private httpClient:HttpClient) { }
  
      
      getNotas(username: string, curso: string): Observable<any> {
  
        return this.httpClient.get(`${this.url}/Notas/NotassBycouseAndUser?user=${username}&curso=${curso}`, { headers:this.headers });
      }
  
      getStudents( username: string, curso: string): Observable<any> {
        return this.httpClient.get(`${this.url}/Comportamiento/ComportamientosBycouseAndUser?user=${username}&curso=${curso}`, { headers:this.headers })
      }

      postComm(USer: string, Com: string, ComId:number): Observable<any> {
        const body = {
          ComId,
          USer,
          Com
        }
        return this.httpClient.post(`${this.url}/Seguimiento`, body)
      }
    
}
