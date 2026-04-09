import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentsServiceService } from './services/students-service.service';
import { NgFor, NgIf } from '@angular/common';
import { Comentario } from '../../models/comentario.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-students-view',
  standalone: true,
  imports: [ReactiveFormsModule,NgFor,NgIf],
  templateUrl: './students-view.component.html',
  styleUrl: './students-view.component.css'
})
export class StudentsViewComponent {

  ComForm: FormGroup;
    constructor(private fb: FormBuilder,private route: ActivatedRoute,private Stuservice:StudentsServiceService ) {
       this.ComForm = this.fb.group({
        comentario: ['', [Validators.required]]
          });
    }
    student :string =""
    curso:string=""
    notas!:any[]
    coms!:Comentario[]
    userLogin:string ="";
    errorCom:boolean=false
    sucessfullCom:boolean=false
    
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.curso = params['curso'];
      this.student = params['stu'];
    });
    this.userLogin=localStorage.getItem("user")??"";
    this.GetNotas();
    this.getComments();
    console.log(this.curso + " " + this.student);
    
  }

  GetNotas(){
    this.Stuservice.getNotas(this.student, this.curso)
      .subscribe(responseOk => { 
        this.notas=responseOk
      })

  }



  getComments(){
    this.Stuservice.getStudents(this.student, this.curso)
      .subscribe(responseOk => { 
        this.coms=responseOk
      })
  }

  GuardarComen(comId:number){
    const { comentario } = this.ComForm.value
    this.Stuservice.postComm(this.userLogin, comentario,comId)
      .subscribe(() => { 
        this.sucessfullCom=true;
        setTimeout(() => {
          window.location.reload();
      }, 2000);
      },
      err => {//TODO error 400>=
        this.errorCom = true
        setTimeout(() => {
          this.errorCom = false;
        }, 2000);
        
      })

  }
}
