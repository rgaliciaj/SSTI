import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResultadoModel } from '../modelos/resultado.model';
import { LoginModel } from '../modelos/login.model';
import { UsuarioModel } from '../modelos/usuario.model';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  apiUrl = environment.apiUrl;

  private usuarioSubject: BehaviorSubject<UsuarioModel>;
  public usuario: Observable<UsuarioModel>;

  public get usuarioData(): UsuarioModel {
    return this.usuarioSubject.value;
  }

  constructor(private http: HttpClient, private router: Router) {
    var local = localStorage.getItem('usuario')

    var resp = JSON.stringify(local)

    this.usuarioSubject = new BehaviorSubject<UsuarioModel>(JSON.parse(resp))
    this.usuario = this.usuarioSubject.asObservable();


  }

  public login(datos: LoginModel): Observable<ResultadoModel> {
    return this.http.post<ResultadoModel>(this.apiUrl + 'User/AuthUser', datos)
      .pipe(
        map(res => {

          if (res.codigo === '0000') {
            var resultado = res.resultado
            var respuesta = JSON.stringify(resultado)
            const usuario: UsuarioModel = JSON.parse(respuesta);
            localStorage.setItem('rolusuario', usuario.UserPrivilegio)
            localStorage.setItem('usuario', JSON.stringify(usuario));
            this.usuarioSubject.next(usuario);
          }
          return res;
        })
      );
  }


  logout() {
    localStorage.removeItem('usuario');
    localStorage.clear();
    this.usuarioSubject.next(new UsuarioModel());
    this.router.navigate(['/']);
  }
}
