import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReporteIngresosService {

  constructor() { }

  // GenerarArchivo(listadoTickets: TicketModel[], fechas: any){//: boolean {

  //   // let workbook = new Excel.Workbook();



    
  //   // const workbook = new Workbook();
  //   // const worksheet = workbook.addWorksheet('Sheet1');

  //   // // Agrega tus datos al archivo Excel (worksheet)
  //   // listadoTickets.forEach((ticket) => {
  //   //   worksheet.addRow([
  //   //     ticket.CODIGO_TICKET,
  //   //     ticket.FECHA_CREACION,
  //   //     ticket.CODIGO_USUARIO,
  //   //     ticket.DESCRIPCION,
  //   //     ticket.ESTADO_TICKET,
  //   //     ticket.CODIGO_PRIORIDAD,
  //   //     ticket.FECHA_MODIFICACION,
  //   //     ticket.CODIGO_TECNICO,
  //   //     ticket.CODIGO_RECURSO,
  //   //     ticket.RUTA
  //   //   ]);
  //   // });

  //   // const fileName = 'prueba.xlsx';

  //   // workbook.xlsx.writeBuffer().then((buffer) => {
  //   //   const blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
  //   //   FileSaver.saveAs(blob, fileName);
  //   // });

  //   // const p = workbook.xlsx.writeBuffer().then((data) => {

  //   //   let blob = new Blob([data], {
  //   //     type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
  //   //   });
  //   //   fs.saveAs(
  //   //     blob,
  //   //     'reporteImpresiones_' + '.xlsx'
  //   //   );
  //   //   return true;

  //   // });
    
  // }

}
