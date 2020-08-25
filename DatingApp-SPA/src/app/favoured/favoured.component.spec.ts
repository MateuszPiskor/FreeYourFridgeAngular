/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FavouredComponent } from './favoured.component';

describe('FavouredComponent', () => {
  let component: FavouredComponent;
  let fixture: ComponentFixture<FavouredComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavouredComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
