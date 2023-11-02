import { Directive, Input, ElementRef, Renderer2, OnInit } from '@angular/core';
import { LoginService } from '../servicios/login.service';
import { RolServiceTsService } from '../servicios/rol.service.ts.service';

@Directive({
  selector: '[appUserRole]'
})
export class UserRoleDirective implements OnInit {

  @Input('appUserRole') allowedRoles: string[] = [];

  constructor(
    private el: ElementRef, 
    private renderer: Renderer2, 
    private loginService: LoginService,
    private rolservicie: RolServiceTsService) {}

  ngOnInit(): void {
    const userRoles = this.rolservicie.ObtenerRoles();

    console.log('userRoles: ' + userRoles)
    // const userRoles = this.loginService.getRoles(); // Supongamos que el servicio proporciona los roles del usuario.
    

    // if (userRoles.some(role => this.allowedRoles.includes(role))) {
    //   this.renderer.removeStyle(this.el.nativeElement, 'display');
    // } else {
    //   this.renderer.setStyle(this.el.nativeElement, 'display', 'none');
    // }
  }

}
