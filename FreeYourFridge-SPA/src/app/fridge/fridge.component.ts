import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {Fridge} from 'src/app/_models/fridge';
import {FridgeService} from '../_services/fridge.service';
import { AuthService } from '../_services/auth.service';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-fridge',
  templateUrl: './fridge.component.html',
  styleUrls: ['./fridge.component.scss']
})
export class FridgeComponent implements OnInit {
  public fridge: Fridge;
  state = true;

  constructor(private route: ActivatedRoute, private alertify: AlertifyjsService, private fridgeService: FridgeService, private authService: AuthService, private router: Router) { }

  ngOnInit() {
  this.route.data.subscribe(data =>{
    this.fridge = data['fridge'];
  });
  }
  deleteIngredient(id: number) {
    this.fridgeService.deleteIngredientFromFridge(id).subscribe(next => {
    window.location.reload();
    this.alertify.success('Ingredient delete succesfully');
    }, error => {
      this.alertify.error(error);
    });
  }
  update(){
    this.state = false;
  }
  enableEditMethod(id, amount) {
    var convertAmount = Number(amount);
    this.fridgeService.updateIngredient(id, convertAmount).subscribe(next => {
      window.location.reload();
      this.alertify.success('Ingredient update succesfully');
      }, error => {
        this.alertify.error(error);
      });
  }
  addComponent(){
    this.router.navigateByUrl('addIngredient');
  }
  addIngredient(){
    console.log();
  }
}
