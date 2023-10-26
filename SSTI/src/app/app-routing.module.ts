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

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'crearTicket', component: CrearTicketComponent },
  { path: 'ListadoTicket', component: ConsultarTicketComponent },
  { path: 'EditarTicket/:id', component: CrearTicketComponent },
  { path: 'usuarios/crearUsuario', component: CrearUsuarioComponent },
  { path: 'usuarios/consultarUsuario', component: ConsultarUsuarioComponent },
  { path: 'usuarios/actualizarUsuario', component: ActualizarUsuarioComponent },
  { path: 'usuarios/eliminarUsuario', component: EliminarUsuarioComponent },
  { path: 'cambiopass', component: CambioPasswordComponent },
  { path: 'reporte', component: ReportesComponent },
  { path: 'grafica', component: GraficasComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registrar', component: RegistrarComponent },
  { path: 'side', component:SideBarComponent},
  { path: '**', pathMatch: 'full', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
