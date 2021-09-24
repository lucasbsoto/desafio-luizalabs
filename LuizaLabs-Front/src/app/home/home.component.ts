import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public usuario: any;

  constructor() { }

  ngOnInit(): void {
    let usuarioLs = localStorage.getItem('usuario');
    
    if(usuarioLs){
      this.usuario = JSON.parse(usuarioLs);
    }
  }

}
