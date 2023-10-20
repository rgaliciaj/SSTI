import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormControl, FormGroup, FormGroupDirective, NgForm } from '@angular/forms';

import { ErrorStateMatcher } from '@angular/material/core';

import Swal from 'sweetalert2';

/** Error cuando un control ha sido modificado, en este caso para validar la selección de tipo cliente */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-crear-ticket',
  templateUrl: './crear-ticket.component.html',
  styleUrls: ['./crear-ticket.component.css']
})
export class CrearTicketComponent implements OnInit {
  matcher = new MyErrorStateMatcher();
  isLoading = false;

  // estadosInfo: estadosmodel[] = [];
  // categoriasInfo: categoriasModel[] = [];

  

  ngOnInit(): void {
    window.addEventListener('beforeunload', () => {
      this.isLoading = true;
    });
  }

  constructor(
    private _formBuilder: FormBuilder,
    private breakpointObserver: BreakpointObserver
  ) { }

  creacionGrupo = this._formBuilder.group({
    usuarioForm: ['RONG1', Validators.required],
    codigoForm: ['821978ED2EAB42F49D53502A64F33A5D', Validators.required],
    prioridadForm: ['', Validators.required],
    recursoForm: ['', Validators.required]
  });
}
