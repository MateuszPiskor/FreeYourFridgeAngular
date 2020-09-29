import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {Fridge} from 'src/app/_models/fridge';
import {FridgeService} from '../_services/fridge.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyjsService } from '../_services/alertifyjs.service';

@Component({
  selector: 'app-fridge',
  templateUrl: './fridge.component.html',
  styleUrls: ['./fridge.component.scss']
})
export class FridgeComponent implements OnInit {
  public fridge: Fridge;

  constructor(private route: ActivatedRoute, private alertify: AlertifyjsService, private fridgeService: FridgeService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
  this.route.data.subscribe(data =>{
    this.fridge = data['fridge'];
  });
  }
  deleteIngredient(id: number) {
    this.fridgeService.deleteIngredientFromFridge(id).subscribe(next => {
    this.ngOnInit();
    this.alertify.success('Ingredient delete succesfully');
    }, error => {
      this.alertify.error(error);
    });
  }


}
