import { Component, Input } from '@angular/core';
import { SideBarComponent } from '../../shared/side-bar/side-bar.component';
import { InfoCardsComponent } from "../../shared/info-cards/info-cards.component";
import { ActivatedRoute } from '@angular/router';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [SideBarComponent, InfoCardsComponent,NgFor],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  userName: string | undefined ;
  rol: string | undefined ;
  infoCardsData!: string[]
  menuOptions!: any[]
  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    
    this.route.queryParams.subscribe(params => {
      this.userName = params['userName'];
    });
    this.rol=localStorage.getItem("rol")??""
    this.infoCardsAndMenuLoad();
  }

  infoCardsAndMenuLoad(){
    if(this.rol=="Profesor"){
      this.infoCardsData=["Grupos","Estudiantes"]
      this.menuOptions=[{
        name: 'Gestionar grupos',
        icon: 'uil uil-chart',
        router: ['/', 'gestEqui'],
        query: { userName: this.userName }
      },{
        name: 'Gestionar estudiantes',
        icon: 'uil uil-chart',
        router: ['/', 'gestEst'],
        query: { userName: this.userName }
      }]
    }else if(this.rol=="Estudiante"){
      this.infoCardsData=["Grupos"]
      this.menuOptions=[{
        name: 'Comentarios',
        icon: 'uil uil-chart',
        router: ['/', 'coms'],
        query: { userName: this.userName }
      }]
    }
    console.log(this.infoCardsData)
  }
}
