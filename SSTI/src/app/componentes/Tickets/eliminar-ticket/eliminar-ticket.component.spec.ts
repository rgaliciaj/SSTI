import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EliminarTicketComponent } from './eliminar-ticket.component';

describe('EliminarTicketComponent', () => {
  let component: EliminarTicketComponent;
  let fixture: ComponentFixture<EliminarTicketComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EliminarTicketComponent]
    });
    fixture = TestBed.createComponent(EliminarTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
