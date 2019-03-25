import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos: any = [
    {
      EventoId: 1,
      Tema: 'Angular',
      Local: 'Bauru'
    },
    {
      EventoId: 2,
      Tema: 'Migrations',
      Local: 'Bauru'
    },
  ];

  constructor() { }

  ngOnInit() {
  }

}
