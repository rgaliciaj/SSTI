import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PrioridadModel } from '../modelos/prioridad.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PrioridadServicioService {

  private apiUrl = environment.apiUrl + 'Prioridad/';

  constructor(private http: HttpClient) { }

  public obtenerPrioridades(): Observable<PrioridadModel[]>{
    return this.http.get<PrioridadModel[]>(this.apiUrl + 'ObtenerListadoPrioridad');
  }

}
