import { NgFor, ɵnormalizeQueryParams } from '@angular/common';
import { Component, Input } from '@angular/core';


@Component({
  selector: 'app-info-cards',
  standalone: true,
  imports: [NgFor],
  templateUrl: './info-cards.component.html',
  styleUrl: './info-cards.component.css'
})
export class InfoCardsComponent {
  @Input() etiqueta: string = 'Grupo';
  cards = [
    { title: 'Card 1', content: 'Content for card 1' },
    { title: 'Card 2', content: 'Content for card 2' },
    { title: 'Card 3', content: 'Content for card 3' },
    { title: 'Card 4', content: 'Content for card 4' },
    { title: 'Card 5', content: 'Content for card 5' },
    { title: 'Card 6', content: 'Content for card 6' }
  ];
}
