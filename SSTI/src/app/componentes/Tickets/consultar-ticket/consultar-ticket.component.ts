import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
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
  
  ticketNotExist = true;
  isLoading = false;
  ticketList: TicketModel[] = [];
  private subscription?: Subscription[] = [];

  constructor(
    private ticketservice: TicketService
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
      this.ticketservice.ObtenerListadoPendiente('821978ED2EAB42F49D53502A64F33A5D').subscribe(
        (response) => {

          if (response.codigo === '0000') {

            var nuevo = JSON.stringify(response.resultado);

            try {

              if (JSON.parse(nuevo).length > 0) {
                this.isLoading = false
                this.ticketNotExist = false;
                this.ticketList = JSON.parse(nuevo);

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

  ver(ticket: string){
    console.log('nuero de ticket: ['+ticket+']')
  }

  ObtenerTicketID(ticket: string){
    console.log('No. ticket: ['+ticket+']')
    
    this.subscription?.push(
      this.ticketservice.ObtenerTicketID(ticket).subscribe(
        (response) => {
          
        },
        (error) => {
          this.errorServidor();
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

  NoInfo(){
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'info',
      text: 'No hay información del ticket seleccionado.',
      showConfirmButton: false,
      timer: 2500
    })
  }

  ticketEliminado(ticket: string){
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      text: 'Ticket '+ ticket + ' eliminado exitosamente.',
      showConfirmButton: true
    })
  }

  errorEliminar() {
    this.isLoading = false;
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      text: 'Ocurrio un error al eliminar ticket.',
      showConfirmButton: false,
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
      timer: 2500
    })
  }

}
