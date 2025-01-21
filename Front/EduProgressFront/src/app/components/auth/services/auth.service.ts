import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private url="https://localhost:7216/api";
  constructor(private httpClient:HttpClient) { }

  
  sendCredentials(username: string, password: string): Observable<any> {
    const body = {
      username,
      password
    }
    return this.httpClient.post(`${this.url}/Usuario/token`, body)
  }


}
