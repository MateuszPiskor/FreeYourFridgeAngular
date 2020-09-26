/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FavouredListComponent } from './favoured-list.component';

describe('FavouredListComponent', () => {
  let component: FavouredListComponent;
  let fixture: ComponentFixture<FavouredListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavouredListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouredListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
