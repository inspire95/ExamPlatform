import { Component, OnInit } from '@angular/core';
import { NavbarService} from '../../services/navbar.service';

@Component({
  selector: 'my-dash',
  templateUrl: './my-dash.component.html',
  styleUrls: ['./my-dash.component.css']
})
export class MyDashComponent implements OnInit{
  constructor(public nav: NavbarService){}
  
  ngOnInit(){
    this.nav.show();
  }
  cards = [
    { title: 'Card 1', cols: 2, rows: 1 },
    { title: 'Card 2', cols: 1, rows: 1 },
    { title: 'Card 3', cols: 1, rows: 2 },
    { title: 'Card 4', cols: 1, rows: 1 }
  ];
}
