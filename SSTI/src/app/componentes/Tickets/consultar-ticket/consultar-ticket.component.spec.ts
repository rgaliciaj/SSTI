import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultarTicketComponent } from './consultar-ticket.component';

describe('ConsultarTicketComponent', () => {
  let component: ConsultarTicketComponent;
  let fixture: ComponentFixture<ConsultarTicketComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ConsultarTicketComponent]
    });
    fixture = TestBed.createComponent(ConsultarTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
