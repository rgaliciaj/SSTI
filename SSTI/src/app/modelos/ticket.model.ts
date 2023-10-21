export class TicketModel {
    CODIGO_TICKET: string = '';
    CODIGO_USUARIO: string = ''
    FECHA_CREACION: Date = new Date()
    DESCRIPCION: string = ''
    ESTADO_TICKET: string = ''
    CODIGO_PRIORIDAD: string = ''
    FECHA_MODIFICACION: Date = new Date()
    CODIGO_TECNICO = ''
    CODIGO_RECURSO = ''
    RUTA = ''
}

export class respuesta{
    codigo: string = ''
    mensaje: string = ''
    resultado: string = ''
}