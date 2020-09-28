import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Fridge} from 'src/app/_models/fridge';
import {FridgeService} from '../_services/fridge.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-fridge',
  templateUrl: './fridge.component.html',
  styleUrls: ['./fridge.component.scss']
})
export class FridgeComponent implements OnInit {
  public fridge: Fridge;

  constructor(private route: ActivatedRoute, private fridgeService: FridgeService, private authService: AuthService) { }

  ngOnInit() {
  this.route.data.subscribe(data =>{
    this.fridge = data['fridge'];
    console.log(this.fridge);
  });
  }

}
