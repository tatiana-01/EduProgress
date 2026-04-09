import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rol',
  standalone: true,
  imports: [NgFor],
  templateUrl: './rol.component.html',
  styleUrl: './rol.component.css'
})
export class RolComponent {
  roles!: string[];
  username:string=""
  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    const state = navigation?.extras.state as {  roles: string[] };
    this.roles = state.roles.filter(a => a !== "Persona");
  }

  onRoleSelect(rol:string): void {
    localStorage.setItem("rol",rol);
    this.username=localStorage.getItem("user")??"";
    this.router.navigate(['/', 'home'], {
      queryParams: {
        userName: this.username,
      }
    })
  }

    ngOnInit(): void {
      console.log(this.roles);
    }
}
