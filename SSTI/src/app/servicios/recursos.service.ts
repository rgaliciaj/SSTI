import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RecursoModel } from '../modelos/recurso.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecursosService {

  urlApi = environment.apiUrl + 'Recurso/';

  constructor(private http: HttpClient) { }

  public obtenerListadoRecursos(): Observable<RecursoModel[]>{
    return this.http.get<RecursoModel[]>(this.urlApi + 'ObtenerListadoRecursos');
  }
}
