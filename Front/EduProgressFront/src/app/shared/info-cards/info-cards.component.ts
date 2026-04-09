import { NgFor, NgIf, ɵnormalizeQueryParams } from '@angular/common';
import { Component, Input } from '@angular/core';
import { SharedService } from '../services/shared.service';
import { log } from 'console';
import { Router } from '@angular/router';


@Component({
  selector: 'app-info-cards',
  standalone: true,
  imports: [NgFor,NgIf],
  templateUrl: './info-cards.component.html',
  styleUrl: './info-cards.component.css'
})
export class InfoCardsComponent {
  @Input() etiqueta: string = '';
  @Input() home: boolean=false;
  estudiantesView: boolean=false;
  rol:string=""
  username:string=""
  cards: any[]=[];
  cards2: any[]=[];
  curso:string=""
   constructor(private sharedService:SharedService, private router: Router) {

    }

  ngOnInit(): void {
    this.rol=localStorage.getItem("rol")??""
    this.username=localStorage.getItem("user")??""
    this.getCardsInfo();
    console.log(this.cards)
    console.log(this.cards2)
  }

  clickCardGroup( nombreCurso: string){
    
    if(this.rol=="Profesor"){
      
      this.sharedService.getStudents(nombreCurso)
      .subscribe(responseOk => { 
        this.cards2=responseOk
        this.curso=nombreCurso
      },
        err => {

        })
        this.estudiantesView=true;
      console.log(this.home)
    }else if(this.rol="Estudiante"){
      console.log(nombreCurso +" "+ this.username)
      this.router.navigate(['/estudiante'], {
        queryParams: {
          curso:nombreCurso, 
          stu:this.username
        }
        
      });
     
    }

  }

  clickCardEstu(detalle:string){
    var user=""
    var userinfo=detalle.split('-')
    if(userinfo.length>0){
      user=userinfo[0].trim();
    }
    this.router.navigate(['/estudiante'],  {
      queryParams: {
        curso: this.curso, 
        stu:user
      }
    });
  }

  getCardsInfo(): void {
    this.sharedService.getCourses(this.username, this.rol)
      .subscribe(responseOk => { 
        this.cards=responseOk
      })
  }
}
