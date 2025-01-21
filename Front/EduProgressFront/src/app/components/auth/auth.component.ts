import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { Router, RouterModule } from '@angular/router';
import {  HttpClient, HttpClientModule } from '@angular/common/http';


@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [ReactiveFormsModule,FormsModule, NgIf,RouterModule,HttpClientModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  loginForm: FormGroup;
  errorSession: boolean = false
  constructor(private fb: FormBuilder, private Authservice: AuthService, private router: Router) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    });
  }

  sendLogin(): void {
    const { username, password } = this.loginForm.value
    this.Authservice.sendCredentials(username, password)
      .subscribe(responseOk => { 
        const { estaAutenticado,token,roles } = responseOk
        localStorage.setItem("token", token);  
        localStorage.setItem("user", username); 
        if(estaAutenticado){
          this.router.navigate(['/rol'], { state: { roles } });
        }      
        console.log(token,roles,username);
      },
        err => {//TODO error 400>=
          this.errorSession = true
          setTimeout(() => {
            this.errorSession = false;
          }, 2000);
          
        })

  }
}
