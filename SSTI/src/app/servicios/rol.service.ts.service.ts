import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RolesModel } from '../modelos/rol.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RolServiceTsService {

  apiUrl = environment.apiUrl + 'Roles/'

  constructor(private http: HttpClient) { }

  public ObtenerRoles(): Observable<RolesModel[]>{
    return this.http.get<RolesModel[]>(this.apiUrl + 'ObtenerRoles')
  }
}
