import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { TicketModel } from 'src/app/modelos/ticket.model';
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

    this.subscription?.push(
      this.ticketservice.ObtenerListadoTicket('821978ED2EAB42F49D53502A64F33A5D').subscribe(
        (response) => {
          this.ticketList = response;
        },
        (error) => {
          this.isLoading = false;
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
