import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/servicios/login.service';
import { RolServiceTsService } from 'src/app/servicios/rol.service.ts.service';
import { RolesModel } from 'src/app/modelos/rol.model';
import { Router } from '@angular/router';

declare var $: any;

interface opciones {
  clienteSubmenu: boolean;
  productoSubmenu: boolean;
  ventaSubmenu: boolean;
  notaCreditoSubmenu: boolean;
  entregaPaqueteSubmenu: boolean;
}

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.css']
})
export class SideBarComponent implements OnInit {
  submenuAbierto: string | null = null;
  roles: RolesModel[] = []
  rolactual = "" ?? null
  admin = false
  cliente = false
  tecnico = false

  submenusState: opciones = {
    clienteSubmenu: false,
    productoSubmenu: false,
    ventaSubmenu: false,
    notaCreditoSubmenu: false,
    entregaPaqueteSubmenu: false
  }

  toggleSubmenu(submenuName: keyof opciones) {
    if (this.submenuAbierto === submenuName) {
      this.submenuAbierto = null; //cierra el submenu que esta abierto si es el mismo
      this.submenusState[submenuName] = false;
    } else {
      this.submenusState[submenuName] = true;
      this.submenuAbierto = submenuName;
    }
  }

  constructor(private loginservice: LoginService, private rolservice: RolServiceTsService, private router: Router) {
    this.rolactual = localStorage.getItem('rolusuario') ?? '';

    this.actualizarVista();
  }

  actualizarVista() {
    this.rolservice.ObtenerRoles().subscribe(
      (res) => {
        this.roles = res
        // console.log('INGRESAAAAA' + this.roles)
        this.roles.forEach(e => {
          // console.log('INGRESAAAAA')
          if (this.rolactual === e.CODIGO_ROL_USUARIO) {
            // console.log('ingresa y es tipo: ' + e.NOMBRE_ROL)
            if (e.NOMBRE_ROL === 'CLIENTE') {
              this.cliente = true
              // this.admin = true
              this.router.navigate(['/ListadoTicket'])
            } else if (e.NOMBRE_ROL === 'TECNICO') {
              this.cliente = true
              this.tecnico = true
              this.router.navigate(['/ListadoTicket'])
            } else if (e.NOMBRE_ROL === 'ADMINISTRADOR') {
              this.admin = true
            }
          }
        });
      }
    )
    
  }

  ngOnInit(): void {
    this.initSidebarToggle();
  }

  initSidebarToggle() {
    var fullHeight = function () {

      $('.js-fullheight').css('height', $(window).height());
      $(window).resize(function () {
        $('.js-fullheight').css('height', $(window).height());
      });

    };
    fullHeight();

    $('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
    });
  }

  logout() {
    this.loginservice.logout();
    window.location.reload();
  }
}
