import { TestBed } from '@angular/core/testing';

import { CustomerSvService } from './customer-sv.service';

describe('CustomerSvService', () => {
  let service: CustomerSvService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomerSvService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
