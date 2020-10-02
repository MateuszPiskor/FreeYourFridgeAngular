import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyMealDetailsComponent } from './daily-meal-details.component';

describe('DailyMealDetailsComponent', () => {
  let component: DailyMealDetailsComponent;
  let fixture: ComponentFixture<DailyMealDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailyMealDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyMealDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
