/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { JoiningService } from './joining.service';

describe('Service: Mission', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JoiningService]
    });
  });

  it('should ...', inject([JoiningService], (service: JoiningService) => {
    expect(service).toBeTruthy();
  }));
});
