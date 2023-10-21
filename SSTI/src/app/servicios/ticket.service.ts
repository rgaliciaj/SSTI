import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TicketModel, respuesta } from '../modelos/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  apiUrl = environment.apiUrl + 'Ticket/';

  constructor(private http: HttpClient) { }

  public crearTicket(datos: TicketModel): Observable<respuesta> {
    return this.http.post<respuesta>(this.apiUrl + 'crearTicket', datos);
  }

  public ObtenerListadoTicket(usuario: string): Observable<TicketModel[]> {
    return this.http.get<TicketModel[]>(this.apiUrl + 'obtenerTicketUsuario/' +usuario);
  }

}
