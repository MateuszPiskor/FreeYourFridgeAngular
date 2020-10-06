import { Component, OnInit } from '@angular/core';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { FavouredService } from 'src/app/_services/favoured.service';
import { RecipeToDetails } from 'src/app/_models/recipeToDetails';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginationResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-favoured-list',
  templateUrl: './favoured-list.component.html',
  styleUrls: ['./favoured-list.component.scss']
})
export class FavouredListComponent implements OnInit {
  favoureds: FavouredDto[];
  pagination: Pagination;

  constructor(private favouredService: FavouredService, private alertify: AlertifyjsService, private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.favoureds = data.favoureds.result;
      this.pagination = data.favoureds.pagination;
    });

    // this.route.data.subscribe(data = > this.favoureds = data.favoureds);
    // this.loadFavoured();
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    console.log(this.pagination.currentPage);
    this.loadFavoured();
  }

  loadFavoured() {
    this.favouredService.getFavoureds(this.pagination.currentPage, this.pagination.itemsPerPage)
     .subscribe((res: PaginationResult<FavouredDto[]>) => {
      this.favoureds = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }


  // loadFavoured(){
  //   this.favouredService.getFavoureds().subscribe(
  //     (favoureds: FavouredDto[]) => {
  //       this.favoureds = favoureds;
  //     },
  //   (error) => {
  //     this.alertify.error(error);
  //   }
  //   );
  // }

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
