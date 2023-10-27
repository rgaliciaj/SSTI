import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoginModel } from 'src/app/modelos/login.model';
import { LoginService } from 'src/app/servicios/login.service';
import { regex } from 'src/environments/regex';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
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
export class LoginComponent implements OnInit, OnDestroy {

  hide = true
  form!: FormGroup;
  passincorrect = false
  datosLogin?: LoginModel
  isLoading = false;

  private subscription?: Subscription[] = [];

  constructor(
    private _formBuilder: FormBuilder,
    private aRouter: ActivatedRoute,
    private router: Router,
    private loginservice: LoginService
  ) {

    window.addEventListener('beforeunload', () => {
      this.isLoading = true;
    });
    
    console.log("ingres usuariodata: ["+this.loginservice.usuarioData+"]")
    
    if(this.loginservice.usuarioData !== null){
      this.router.navigate(['/']);
    }

  }

  ngOnInit(): void {
    window.addEventListener('beforeunload', () => {
      this.isLoading = true;
    });

    this.form = this._formBuilder.group({

      usuario: ['jron', { updateOn: 'blur', Validators: [Validators.required, Validators.maxLength(36)] }],
      password: ['a', {
        updateOn: 'blur', Validators: [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
          Validators.pattern(regex.password)
        ]
      }]

    })
  }

  ngOnDestroy(): void {
    this.subscription?.forEach((sub) => sub.unsubscribe());
  }

  onSubmit(): void {
    if (this.form.valid) {

      this.login();

      // this.router.navigateByUrl('/side')

    } else {
      Swal.fire({
        titleText: 'error',
        timerProgressBar: true,
        timer: 2000
      })
    }
  }

  login() {
    this.isLoading = true
    console.log('INGESA AL LOGIN')
    this.datosLogin = new LoginModel();
    this.datosLogin.usuario = this.form.get('usuario')?.value;
    this.datosLogin.password = this.form.get('password')?.value;


    this.subscription?.push(
      this.loginservice.login(this.datosLogin).subscribe(
        (response) => {
          console.log('RESPUESTA: ' + response.codigo)
          if (response.codigo === '0000') {
            this.isLoading = false
            this.router.navigate(['/']);
          } else {
            this.passIncorrect();
          }
        },
        (error) => {
          this.errorServidor();
        }
      )
    )

  }

  passIncorrect() {
    this.isLoading = false
    Swal.fire({
      position: 'top-end',
      icon: 'info',
      text: 'Código o contraseña incorrecto.',
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
