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
import { EliminarTicketComponent } from './componentes/Tickets/eliminar-ticket/eliminar-ticket.component';
import { ActualizarTicketComponent } from './componentes/Tickets/actualizar-ticket/actualizar-ticket.component';
import { ConsultarTicketComponent } from './componentes/Tickets/consultar-ticket/consultar-ticket.component';

const routes: Routes = [
  { path: '', component:HomeComponent},
  { path: 'login', component:LoginComponent},
  { path: 'home', component:HomeComponent},
  { path: 'crearTicket', component:CrearTicketComponent},
  { path: 'consultarTicket', component:ConsultarTicketComponent},
  { path: 'actualizarTicket', component:ActualizarTicketComponent},
  { path: 'eliminarTicket', component:EliminarTicketComponent},
  { path: 'usuarios/crearUsuario', component:CrearUsuarioComponent},
  { path: 'usuarios/consultarUsuario', component:ConsultarUsuarioComponent},
  { path: 'usuarios/actualizarUsuario', component:ActualizarUsuarioComponent},
  { path: 'usuarios/eliminarUsuario', component:EliminarUsuarioComponent},
  { path: 'cambiopass', component: CambioPasswordComponent},
  { path: 'reporte', component: ReportesComponent},
  { path: 'grafica', component: GraficasComponent},

  // { path: '**', pathMatch: 'full', component:HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
