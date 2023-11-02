import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { regex, regexErrors } from 'src/environments/regex';
import Swal from 'sweetalert2'



@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css'],
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
  ],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RegistrarComponent implements OnInit {

  hide= true
  form!: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,

  ) { }

  ngOnInit(): void {
    this.form = this._formBuilder.group({
      empleado: [null, { updateOn: 'blur', Validators: [Validators.required, Validators.maxLength(36)] }],
      usuario: [null, { updateOn: 'blur', Validators: [Validators.required, Validators.maxLength(36)] }],
      telefono: [null, { updateOn: 'blur', Validators: [Validators.required, Validators.maxLength(10)] }],
      password: [null, {
        updateOn: 'blur', Validators: [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
          Validators.pattern(regex.password)
        ]
      }],
      paswordRepeat: [null, {
        updateOn: 'blur', Validators: [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
          Validators.pattern(regex.password)
        ]
      }]
    }, { validator: this.repeatPasswordValidators})
  }

  private repeatPasswordValidators(group: FormGroup):{[key: string] : boolean } | null{
    const password = group.get('password');
    const passwordRepeat = group.get('paswordRepeat');

    return passwordRepeat?.value && password?.value !== passwordRepeat?.value 
    ? {repeat: true} : null
  }

  email = new FormControl('', [Validators.required, Validators.email]);

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Este campo es obligatorio';
    }

    return this.email.hasError('email') ? 'Correo no válido' : '';
  }

  onSubmit(): void{
    if(this.form.valid){

    } else {
      Swal.fire({
        titleText: 'error',
        timerProgressBar: true,
        timer: 2000
      })
    }
  }

}
