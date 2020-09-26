import { Component, Input, OnInit } from '@angular/core';
import { DailyMealSimpleDto } from 'src/app/_models/dailyMealSimpleDto';
import { ActivatedRoute, Router } from '@angular/router';
import { Data } from "../../data";

@Component({
  selector: 'app-daily-meal-card',
  templateUrl: './daily-meal-card.component.html',
  styleUrls: ['./daily-meal-card.component.css']
})
export class DailyMealCardComponent implements OnInit {
  @Input() dailyMeal:DailyMealSimpleDto;
  private selectedDailyMealId: number;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private data: Data
  ) { }

  ngOnInit(): void {
    this.selectedDailyMealId = +this._route.snapshot.paramMap.get('id');
  }

  viewDetails()
  {
    this.data.storage = this.dailyMeal;
    "['dailymeals/',dailymeal.id]"
    this._router.navigate(['/dailymeals/',this.dailyMeal.spoonacularId]); //wtf??
  }

}
