import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
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
export class LoginComponent implements OnInit {

  hide = true
  form!: FormGroup;
  passincorrect = false

  constructor(
    private _formBuilder: FormBuilder,
    private aRouter: ActivatedRoute,
    private router: Router

  ) { }

  ngOnInit(): void {
    this.form = this._formBuilder.group({

      usuario: ['RONG1', { updateOn: 'blur', Validators: [Validators.required, Validators.maxLength(36)] }],
      password: ['******', {
        updateOn: 'blur', Validators: [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(30),
          Validators.pattern(regex.password)
        ]
      }]

    })
  }

  onSubmit(): void {
    if (this.form.valid) {



this.router.navigateByUrl('/')

    } else {
      Swal.fire({
        titleText: 'error',
        timerProgressBar: true,
        timer: 2000
      })
    }
  }
}
