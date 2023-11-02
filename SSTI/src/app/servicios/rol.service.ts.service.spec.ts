import { TestBed } from '@angular/core/testing';

import { RolServiceTsService } from './rol.service.ts.service';

describe('RolServiceTsService', () => {
  let service: RolServiceTsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RolServiceTsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
