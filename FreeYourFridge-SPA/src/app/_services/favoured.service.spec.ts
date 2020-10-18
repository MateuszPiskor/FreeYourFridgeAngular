import { TestBed } from '@angular/core/testing';

import { FavouredService } from './favoured.service';

describe('FavouredService', () => {
  let service: FavouredService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FavouredService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
