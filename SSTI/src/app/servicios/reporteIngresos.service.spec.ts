/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReporteIngresosService } from './reporteIngresos.service';

describe('Service: ReporteIngresos', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReporteIngresosService]
    });
  });

  it('should ...', inject([ReporteIngresosService], (service: ReporteIngresosService) => {
    expect(service).toBeTruthy();
  }));
});
