import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-students-view',
  standalone: true,
  imports: [],
  templateUrl: './students-view.component.html',
  styleUrl: './students-view.component.css'
})
export class StudentsViewComponent {

    constructor(private route: ActivatedRoute) {}
    student :string =""
    curso:string=""
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.curso = params['curso'];
      this.student = params['stu'];
    });
    console.log(this.curso + " " + this.student);
    
  }
}
