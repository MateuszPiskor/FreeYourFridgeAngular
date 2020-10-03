/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FavouredCardComponent } from './favoured-card.component';

describe('FavouredCardComponent', () => {
  let component: FavouredCardComponent;
  let fixture: ComponentFixture<FavouredCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavouredCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouredCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
