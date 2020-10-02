import { Component, OnInit } from '@angular/core';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { FavouredService } from 'src/app/_services/favoured.service';
import { RecipeToDetails } from 'src/app/_models/recipeToDetails';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';

@Component({
  selector: 'app-favoured-list',
  templateUrl: './favoured-list.component.html',
  styleUrls: ['./favoured-list.component.scss']
})
export class FavouredListComponent implements OnInit {
  favoureds: FavouredDto[];
  constructor(private favouredService: FavouredService, private alertify:AlertifyjsService) { }

  ngOnInit() {
    this.loadFavoured();
  }

  loadFavoured(){
    this.favouredService.getFavoureds().subscribe(
      (favoureds: FavouredDto[]) => {
        this.favoureds = favoureds;
      },
    (error) => {
      this.alertify.error(error);
    }
    );
  }

  removeItem(favoured: FavouredDto){
    this.favoureds = this.favoureds.filter(item => item !== favoured);
    this.favouredService.remove(favoured).subscribe(
      () => {
        this.alertify.success('Removed from shoplist');
      },
      (error) => {
        this.alertify.error('Some problem occur');
      }
    );
  }

}
