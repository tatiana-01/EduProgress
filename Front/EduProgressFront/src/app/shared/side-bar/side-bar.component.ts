import { Component, ElementRef, Input, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { NgFor, NgClass } from '@angular/common';

@Component({
    selector: 'app-side-bar',
    templateUrl: './side-bar.component.html',
    styleUrls: ['./side-bar.component.css'],
    standalone: true,
    imports: [NgFor, RouterLink, NgClass]
})
export class SideBarComponent implements OnInit {

   
@Input() mainMenuOptions!: any[];


  ngOnInit(): void {
    console.log(this.mainMenuOptions);
    debugger;
    


  }



  TestClick(test: string): void {
    console.log(test)
  }
}