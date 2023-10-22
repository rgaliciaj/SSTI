import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TicketModel, ResultaTicketModel } from '../modelos/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  apiUrl = environment.apiUrl + 'Ticket/';

  constructor(private http: HttpClient) { }

  public crearTicket(datos: TicketModel): Observable<ResultaTicketModel> {
    return this.http.post<ResultaTicketModel>(this.apiUrl + 'crearTicket', datos);
  }

  public ObtenerListadoTicket(usuario: string): Observable<ResultaTicketModel> {
    return this.http.get<ResultaTicketModel>(this.apiUrl + 'obtenerTicketUsuario/' +usuario);
  }

  public ObtenerListadoPendiente(usuario: string): Observable<ResultaTicketModel> {
    return this.http.get<ResultaTicketModel>(this.apiUrl + 'obtenerPendienteUsuario/' +usuario);
  }

  public CerrarTicket(ticket: string):Observable<any>{
    return this.http.put(this.apiUrl + 'CambioEstadoCerrado/' + ticket, ticket);
  }

  public ObtenerTicketID(ticket: string):Observable<TicketModel[]> {
    console.log('ticket: ' + ticket)
    return this.http.get<TicketModel[]>(this.apiUrl + 'obtenerTicketId/' + ticket)
  }

  public EditarTicketID(datos: TicketModel):Observable<ResultaTicketModel> {
    return this.http.put<ResultaTicketModel>(this.apiUrl + 'ActualizarTicket', datos);
  }
}
