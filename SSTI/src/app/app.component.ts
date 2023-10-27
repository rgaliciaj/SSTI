import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { UsuarioModel } from './modelos/usuario.model';
import { LoginService } from './servicios/login.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  usuario?: UsuarioModel;

  carga = false;
  loggin = true;
  menu = false;

  constructor(


    public authservice: LoginService,
    private router: Router) { 

      

      console.log("ingreso : usuraio: " + this.usuario)

      

      this.authservice.usuario.subscribe(
        res => {
          this.usuario = res;
          console.log('cambio el objeto: ' + res)
          if(res){
            this.menu = true;
            this.loggin = false;
          }
        }
      )
    }

  ngOnInit(): void {

    window.addEventListener('beforeunload', () => {
      this.carga = true;
    });

  }
} 