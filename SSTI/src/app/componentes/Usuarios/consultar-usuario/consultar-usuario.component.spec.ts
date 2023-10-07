import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarUsuarioComponent } from './consultar-usuario.component';

describe('ConsultarUsuarioComponent', () => {
  let component: ConsultarUsuarioComponent;
  let fixture: ComponentFixture<ConsultarUsuarioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConsultarUsuarioComponent]
    });
    fixture = TestBed.createComponent(ConsultarUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
