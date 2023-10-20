import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSwitch, NgSwitchCase, AsyncPipe } from '@angular/common';
import { Moment } from 'moment';

//importacion de angular material
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatStepperModule } from '@angular/material/stepper';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { NgIf, DatePipe } from '@angular/common';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_FORMATS, DateAdapter } from '@angular/material/core';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';

//componentes
import { AppComponent } from './app.component';
import { LoginComponent } from './componentes/login/login.component';
import { HomeComponent } from './componentes/home/home.component';
import { SideBarComponent } from './componentes/side-bar/side-bar.component';
import { MatSelectModule } from '@angular/material/select';
import { CrearUsuarioComponent } from './componentes/Usuarios/crear-usuario/crear-usuario.component';
import { ActualizarUsuarioComponent } from './componentes/Usuarios/actualizar-usuario/actualizar-usuario.component';
import { ConsultarUsuarioComponent } from './componentes/Usuarios/consultar-usuario/consultar-usuario.component';
import { EliminarUsuarioComponent } from './componentes/Usuarios/eliminar-usuario/eliminar-usuario.component';
import { CambioPasswordComponent } from './componentes/Administracion/cambio-password/cambio-password.component';
import { ReportesComponent } from './componentes/Administracion/reportes/reportes.component';
import { GraficasComponent } from './componentes/Administracion/graficas/graficas.component';
import { CrearTicketComponent } from './componentes/Tickets/crear-ticket/crear-ticket.component';
import { ConsultarTicketComponent } from './componentes/Tickets/consultar-ticket/consultar-ticket.component';
import { ActualizarTicketComponent } from './componentes/Tickets/actualizar-ticket/actualizar-ticket.component';
import { EliminarTicketComponent } from './componentes/Tickets/eliminar-ticket/eliminar-ticket.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    SideBarComponent,
    CrearUsuarioComponent,
    ActualizarUsuarioComponent,
    ConsultarUsuarioComponent,
    EliminarUsuarioComponent,
    CambioPasswordComponent,
    ReportesComponent,
    GraficasComponent,
    CrearTicketComponent,
    ConsultarTicketComponent,
    ActualizarTicketComponent,
    EliminarTicketComponent,

  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    MatTableModule,
    MatInputModule,
    MatFormFieldModule,
    MatSelectModule,
    MatStepperModule,
    ReactiveFormsModule,
    NgSwitch,
    NgSwitchCase,
    FormsModule,
    AsyncPipe,
    MatPaginatorModule,
    NgIf,
    MatProgressSpinnerModule,
    MatSortModule,
    DatePipe,
    MatDatepickerModule,
    MatNativeDateModule,

  ],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    { provide: DateAdapter, useClass: MomentDateAdapter },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
