import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { PrioridadModel } from 'src/app/modelos/prioridad.model';
import { RecursoModel } from 'src/app/modelos/recurso.model';
import { TicketModel, ResultaTicketModel } from 'src/app/modelos/ticket.model';
import { PrioridadServicioService } from 'src/app/servicios/prioridad-servicio.service';
import { RecursosService } from 'src/app/servicios/recursos.service';
import { TicketService } from 'src/app/servicios/ticket.service';

import Swal from 'sweetalert2';

/** Error cuando un control ha sido modificado, en este caso para validar la selección de tipo cliente */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-crear-ticket',
  templateUrl: './crear-ticket.component.html',
  styleUrls: ['./crear-ticket.component.css'],
  animations: [
    trigger(
      'inOutAnimation',
      [
        transition(
          ':enter',
          [
            style({ height: '*', opacity: 0 }),
            animate('500ms ease-in-out')
          ]
        ),

      ]
    )
  ]
})
export class CrearTicketComponent implements OnInit, OnDestroy {

  private subscription?: Subscription[] = [];

  titulo = 'Creación de ticket'
  boton = 'Crear ticket'
  id: string | null;
  matcher = new MyErrorStateMatcher();
  isLoading = false;
  prioridadInfo: PrioridadModel[] = [];
  recursosInfo: RecursoModel[] = [];
  datosTicket?: TicketModel;
  datosRecibidos?: ResultaTicketModel;

  constructor(
    private _formBuilder: FormBuilder,
    private router: Router,
    private prioridadservice: PrioridadServicioService,
    private recursoservice: RecursosService,
    private ticketservice: TicketService,
    private aroute: ActivatedRoute
  ) {
    this.id = this.aroute.snapshot.paramMap.get('id')
  }

  ngOnInit(): void {
    window.addEventListener('beforeunload', () => {
      this.isLoading = true;
    });

    this.esEditar();

    this.ObtenerPrioridad();

    this.ObtenerRecurso();

  }

  ngOnDestroy(): void {
    this.subscription?.forEach((sub) => sub.unsubscribe());
  }

  creacionGrupo = this._formBuilder.group({
    usuarioForm: ['RONG1'],
    codigoUserForm: ['821978ED2EAB42F49D53502A64F33A5D', Validators.required],
    prioridadForm: ['', Validators.required],
    recursoForm: ['', Validators.required],
    descripcionForm: ['', Validators.required]
  });

  ObtenerPrioridad() {
    this.subscription?.push(
      this.prioridadservice.obtenerPrioridades().subscribe(
        (response) => {
          this.isLoading = false;
          this.prioridadInfo = response;
          localStorage.setItem("prioridad", JSON.stringify(this.prioridadInfo))
        },
        (error) => {
          this.isLoading = false;
          this.errorServidor();
        }
      )
    )
  }

  ObtenerRecurso() {
    this.subscription?.push(
      this.recursoservice.obtenerListadoRecursos().subscribe(
        (response) => {
          this.isLoading = false;
          this.recursosInfo = response;
          localStorage.setItem("recursos", JSON.stringify(this.recursosInfo))
        },
        (error) => {
          this.isLoading = false;
          this.errorServidor();
        }
      )
    )
  }

  esEditar() {
    if (this.id !== null) {
      this.isLoading = true;
      this.titulo = 'Editar ticket';
      this.boton = 'Editar ticket';
      this.subscription?.push(
        this.ticketservice.ObtenerTicketID(this.id).subscribe(
          (response) => {

            var prioridad = "";
            var recurso = "";

            let prioridades: PrioridadModel[] = JSON.parse(localStorage.getItem("prioridad") ?? '');
            let recursos: RecursoModel[] = JSON.parse(localStorage.getItem("recursos") ?? '');

            prioridades.forEach(e => {
              if (e.NOMBRE_PRIORIDAD === response[0].CODIGO_PRIORIDAD) {
                prioridad = e.CODIGO_PRIORIDAD
              }
            });

            recursos.forEach(e => {
              if (e.DESCRIPCION_RECURSO === response[0].CODIGO_RECURSO) {
                recurso = e.CODIGO_RECURSO
              }
            });

            this.isLoading = false;
            this.creacionGrupo.patchValue({
              usuarioForm: response[0].CODIGO_USUARIO,
              codigoUserForm: '821978ED2EAB42F49D53502A64F33A5D',
              prioridadForm: prioridad,
              recursoForm: recurso,
              descripcionForm: response[0].DESCRIPCION
            })
          },
          (error) => {
            this.errorServidor();
          }
        )
      )
    }
  }

  crearTicket() {
    this.isLoading = true;
    if (this.creacionGrupo.valid) {

      // const TICKET: Ticketodel = {
      //   CODIGO_TICKET: '',
      //   CODIGO_USUARIO: this.creacionGrupo.get('codigoUserForm')?.value ?? '',
      //   FECHA_CREACION: new Date,
      //   DESCRIPCION: this.creacionGrupo.get('descripcionForm')?.value ?? '',
      //   ESTADO_TICKET: '',
      //   CODIGO_PRIORIDAD: this.creacionGrupo.get('prioridadForm')?.value ?? '',
      //   FECHA_MODIFICACION: new Date,
      //   CODIGO_TECNICO: '',
      //   CODIGO_RECURSO: this.creacionGrupo.get('recursoForm')?.value ?? '',
      //   RUTA: '',
      // }

      this.datosTicket = new TicketModel;

      this.datosTicket.CODIGO_USUARIO = this.creacionGrupo.get('codigoUserForm')?.value ?? ''
      this.datosTicket.DESCRIPCION = this.creacionGrupo.get('descripcionForm')?.value ?? ''
      this.datosTicket.CODIGO_PRIORIDAD = this.creacionGrupo.get('prioridadForm')?.value ?? ''
      this.datosTicket.CODIGO_RECURSO = this.creacionGrupo.get('recursoForm')?.value ?? ''
      this.datosTicket.FECHA_CREACION = new Date
      this.datosTicket.FECHA_MODIFICACION = new Date

      console.log(this.datosTicket)

      if (this.id !== null) {
        //aca se crea
        this.subscription?.push(
          this.ticketservice.crearTicket(this.datosTicket).subscribe(
            (response) => {
              this.isLoading = false;
              this.datosRecibidos = response;

              if (this.datosRecibidos.resultado) {
                this.ticketCreado(this.datosRecibidos.codigo);
              } else {
                this.errorCreacionTicket(this.datosRecibidos.mensaje);
              }
            },
            (error) => {
              this.isLoading = false;
              this.errorServidor();
            }
          )
        )
      } else {
        //aca se edita
        this.subscription?.push(
          this.ticketservice.EditarTicketID(this.datosTicket).subscribe(
            (response) => {
              this.isLoading = false;
              this.datosRecibidos = response;

              if (this.datosRecibidos.resultado) {
                this.ticketActualizado(this.datosRecibidos.codigo);
              } else {
                this.errorCreacionTicket(this.datosRecibidos.mensaje);
              }
            },
            (error) =>{
              this.isLoading = false;
              this.errorServidor();
            }
          )
        )
      }

    } else {
      this.isLoading = false;
      this.errorValoresObligatorios();
    }
  }

  resertForms() {
    this.creacionGrupo.reset();
  }

  ticketCreado(ticketnum: string) {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Número de ticket: ' + ticketnum,
      showConfirmButton: true
    })
    this.resertForms();
    this.router.navigate(['/ListadoTicket']);
  }

  ticketActualizado(ticketnum: string) {
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Número de ticket: ' + ticketnum +' actualizado.',
      showConfirmButton: true
    })
    this.resertForms();
    this.router.navigate(['/ListadoTicket']);
  }

  errorCreacionTicket(msg: string) {
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      text: msg,
      showConfirmButton: false,
      timer: 3500
    })
  }

  errorValoresObligatorios() {
    Swal.fire({
      position: 'top-end',
      icon: 'info',
      text: 'Ingresar los valores obligatorios.',
      showConfirmButton: false,
      timer: 2500
    })
  }

  errorServidor() {
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      text: 'Ocurrio un error con el servidor.',
      showConfirmButton: false,
      timer: 2500
    })
  }
}
