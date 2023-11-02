import { animate, style, transition, trigger } from '@angular/animations';
import { DatePipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ResultaTicketModel, TicketModel } from 'src/app/modelos/ticket.model';
import { TicketService } from 'src/app/servicios/ticket.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-consultar-ticket',
  templateUrl: './consultar-ticket.component.html',
  styleUrls: ['./consultar-ticket.component.css'],
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
export class ConsultarTicketComponent implements OnInit, OnDestroy {
  ticket = ""
  card = false
  ticketNotExist = true;
  isLoading = false;
  ticketList: TicketModel[] = [];
  private subscription?: Subscription[] = [];

  constructor(
    private ticketservice: TicketService,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    window.addEventListener('beforeunload', () => {
      this.isLoading = true;
    });

    this.ObtenerPendientes();
  }

  ObtenerPendientes() {
    this.isLoading = true;
    this.subscription?.push(
      this.ticketservice.ObtenerListadoPendiente('BDABF8C333024813BCDAA7FAFF9BB47F').subscribe(
        (response) => {

          if (response.codigo === '0000') {

            var nuevo = JSON.stringify(response.resultado);

            try {

              if (JSON.parse(nuevo).length > 0) {
                this.isLoading = false
                this.ticketNotExist = false;

                let sortedTickets = this.sortTicketsByDateAndTime(JSON.parse(nuevo));
                this.ticketList = this.sortTicketsByPriority(sortedTickets);

              } else {

                this.noTickets();

              }

            } catch (error) {
              this.isLoading = false;
              console.error('Error al analizar la respuesta JSON:', error);

            }

          } else {
            this.noTickets();
          }

        },
        (error) => {
          this.errorServidor();
        }
      )
    )
  }

  sortTicketsByPriority(tickets: TicketModel[]): TicketModel[] {
    return tickets.sort((a, b) => {
      const priorityOrder = ['ALTA', 'MEDIA', 'BAJA']; // Definir el orden de prioridades
      return priorityOrder.indexOf(a.CODIGO_PRIORIDAD) - priorityOrder.indexOf(b.CODIGO_PRIORIDAD);
    });
  }

  sortTicketsByDateAndTime(tickets: TicketModel[]): TicketModel[] {
    return tickets.sort((a, b) => {
      // Convierte las fechas de creación en objetos Date para facilitar la comparación
      const dateA = new Date(a.FECHA_CREACION);
      const dateB = new Date(b.FECHA_CREACION);

      if (dateA < dateB) {
        return -1; // `dateA` es anterior a `dateB`
      } else if (dateA > dateB) {
        return 1; // `dateA` es posterior a `dateB`
      } else {
        return 0; // Las fechas son iguales
      }
    });
  }


  cerrar() {
    this.card = false
    this.visualizacionGrupo.reset();
  }

  Resuelto(ticket: string) {
    this.isLoading = true
    this.subscription?.push(
      this.ticketservice.Resolver(ticket).subscribe(
        (response) => {
          this.isLoading = false
          this.ticketResuelto(ticket)
        }
      )
    )
  }

  EliminarTicket(ticket: any) {
    this.isLoading = true;
    this.subscription?.push(
      this.ticketservice.CerrarTicket(ticket).subscribe(
        (response) => {
          if (response) {
            this.ticketEliminado(ticket);
          } else {
            this.errorEliminar();
          }
        },
        (error) => {
          this.errorServidor();
        }
      )
    )
  }

  ngOnDestroy(): void {
    this.subscription?.forEach((sub) => {
      sub.unsubscribe();
    })
  }


  //opcion ver
  visualizacionGrupo = this._formBuilder.group({
    usuarioForm: [''],
    creacionForm: [''],
    modificacionForm: [''],
    prioridadForm: [''],
    estadoForm: [''],
    tecnicoForm: [''],
    recursoForm: [''],
    rutaForm: [''],
    descripcionForm: ['']
  });


  ver(ticket: string) {
    this.card = true
    this.ticket = ticket


    this.subscription?.push(
      this.ticketservice.ObtenerTicketID(ticket).subscribe(
        (response) => {
          this.isLoading = false;
          let datePipe = new DatePipe('en-US')

          let creacion = datePipe.transform(response[0].FECHA_CREACION, 'dd-MM-yyyy HH:mm:ss')
          let modificacion = datePipe.transform(response[0].FECHA_MODIFICACION, 'dd-MM-yyyy HH:mm:ss')

          this.visualizacionGrupo.patchValue({
            usuarioForm: response[0].CODIGO_USUARIO,
            creacionForm: creacion,
            modificacionForm: modificacion,
            prioridadForm: response[0].CODIGO_PRIORIDAD,
            estadoForm: response[0].ESTADO_TICKET,
            tecnicoForm: response[0].CODIGO_TECNICO,
            recursoForm: response[0].CODIGO_RECURSO,
            rutaForm: response[0].RUTA,
            descripcionForm: response[0].DESCRIPCION
          })

        },
        (error) => {
          this.errorServidor();
        }
      )
    )
  }

  //Mensajes de alerta
  NoInfo() {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'info',
      text: 'No hay información del ticket seleccionado.',
      showConfirmButton: false,
      allowOutsideClick: false,
      timer: 2500
    })
  }

  ticketResuelto(ticket: string) {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      text: 'Ticket ' + ticket + ' resuelto.',
      showConfirmButton: true,
      allowOutsideClick: false,
    }).then((e) => {
      if (e.isConfirmed) {
        window.location.reload();
      }
    }
    )
  }

  ticketEliminado(ticket: string) {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      text: 'Ticket ' + ticket + ' eliminado exitosamente.',
      showConfirmButton: true,
      allowOutsideClick: false,
    }).then((e) => {
      if (e.isConfirmed) {
        window.location.reload();
      }
    }
    )
  }

  errorEliminar() {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      text: 'Ocurrio un error al eliminar ticket.',
      showConfirmButton: false,
      allowOutsideClick: false,
      timer: 2500
    })
  }

  errorServidor() {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      text: 'Ocurrio un error con el servidor.',
      showConfirmButton: false,
      allowOutsideClick: false,
      timer: 2500
    })
  }

  noTickets() {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      text: 'El usuario no tiene tickets pendientes.',
      showConfirmButton: false,
      allowOutsideClick: false,
      timer: 2500
    })
  }

}
