import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './componentes/login/login.component';
import { HomeComponent } from './componentes/home/home.component';
import { CrearUsuarioComponent } from './componentes/Usuarios/crear-usuario/crear-usuario.component';
import { ConsultarUsuarioComponent } from './componentes/Usuarios/consultar-usuario/consultar-usuario.component';
import { ActualizarUsuarioComponent } from './componentes/Usuarios/actualizar-usuario/actualizar-usuario.component';
import { EliminarUsuarioComponent } from './componentes/Usuarios/eliminar-usuario/eliminar-usuario.component';
import { CambioPasswordComponent } from './componentes/Administracion/cambio-password/cambio-password.component';
import { ReportesComponent } from './componentes/Administracion/reportes/reportes.component';
import { GraficasComponent } from './componentes/Administracion/graficas/graficas.component';
import { CrearTicketComponent } from './componentes/Tickets/crear-ticket/crear-ticket.component';
import { ConsultarTicketComponent } from './componentes/Tickets/consultar-ticket/consultar-ticket.component';
import { RegistrarComponent } from './componentes/registrar/registrar.component';
import { SideBarComponent } from './componentes/side-bar/side-bar.component';
import { AuthGuard } from './componentes/security/Auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'crearTicket', component: CrearTicketComponent, canActivate: [AuthGuard] },
  { path: 'ListadoTicket', component: ConsultarTicketComponent, canActivate: [AuthGuard] },
  { path: 'EditarTicket/:id', component: CrearTicketComponent, canActivate: [AuthGuard] },
  { path: 'ActualizarUsuario', component: CrearUsuarioComponent, canActivate: [AuthGuard] },
  // { path: 'consultarUsuario', component: ConsultarUsuarioComponent, canActivate: [AuthGuard] },
  // { path: 'actualizarUsuario', component: ActualizarUsuarioComponent, canActivate: [AuthGuard] },
  // { path: 'eliminarUsuario', component: EliminarUsuarioComponent, canActivate: [AuthGuard] },
  { path: 'cambiopass', component: CambioPasswordComponent,  },
  { path: 'reporte', component: ReportesComponent, canActivate: [AuthGuard] },
  { path: 'grafica', component: GraficasComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'registrar', component: RegistrarComponent },
  { path: 'side', component:SideBarComponent, canActivate: [AuthGuard]},
  { path: '**', pathMatch: 'full', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
