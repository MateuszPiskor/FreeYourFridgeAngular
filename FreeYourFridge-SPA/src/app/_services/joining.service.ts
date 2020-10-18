import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { FilterBarParams } from '../_models/filterBarParams';

@Injectable()
export class JoiningService {

  // Observable string sources
  private announcedSource = new Subject<FilterBarParams>();
  private confirmedSource = new Subject<string>();

  // Observable string streams
  announced$ = this.announcedSource.asObservable();
  confirmed$ = this.confirmedSource.asObservable();

  // Service message commands
  announce(params: FilterBarParams) {
    this.announcedSource.next(params);
  }
}
