import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Subscription } from 'rxjs';
import { TicketService } from 'src/app/servicios/ticket.service';
import Swal from 'sweetalert2';
import { TicketModel } from 'src/app/modelos/ticket.model';
import { animate, style, transition, trigger } from '@angular/animations';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ReporteIngresosService } from 'src/app/servicios/reporteIngresos.service';


@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css'],
  providers: [DatePipe],
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
export class ReportesComponent implements OnInit, OnDestroy, AfterViewInit {

  @ViewChild(MatPaginator) paginator?: MatPaginator;

  isLoading = false
  dataValid = false
  ticketInfo : TicketModel[] = []
  dataSource: MatTableDataSource<TicketModel>;

  displayedColumns: string[] = ['codigoTicket', 'codigoUsuario', 'fechaCreacion', 'estadoTicket', 'codigoPrioridad'];

  private subcription: Subscription[] = [];

  constructor(private ticketService: TicketService, private reporteservice: ReporteIngresosService) {
    this.dataSource = new MatTableDataSource<TicketModel>([]);
  }

  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
    if (this.paginator) {
      this.dataSource.paginator = this.paginator;
    }
  }

  ngOnDestroy(): void {
    this.subcription?.forEach((sub) => {
      sub.unsubscribe();
    })
  }

  range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });


  BuscarInfo() {
    if (this.range.valid) {
      this.subcription.push(
        this.ticketService.ObtenerTicketRangoCreacion(
          this.range.get('start')?.value ?? new Date, this.range.get('end')?.value ?? new Date).subscribe(
            (response) => {
              this.dataSource.data = response 
              if(response.length > 0){
                this.dataValid = true
                this.ticketInfo = response
              }
              
              console.log('respuesta: ' + response.length)
            },
            (error) => {
              this.errorServidor();
            }
          )
      )
    } else {
      this.errorValoresObligatorios();
    }
  }

  GenerarReporte(){
    // let respuesta = this.reporteservice.GenerarArchivo(this.ticketInfo, this.range.value)
  }



  errorValoresObligatorios() {
    this.isLoading = false
    Swal.fire({
      position: 'top-end',
      icon: 'info',
      text: 'Ingresar los valores obligatorios.',
      showConfirmButton: false,
      allowOutsideClick: false,
      timer: 2500
    })
  }

  errorServidor() {
    this.isLoading = false
    Swal.fire({
      position: 'top-end',
      icon: 'error',
      text: 'Ocurrio un error con el servidor.',
      showConfirmButton: false,
      allowOutsideClick: false,
      timer: 2500
    })
  }

}
