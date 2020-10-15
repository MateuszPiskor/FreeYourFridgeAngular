import { Component, OnInit } from '@angular/core';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { FavouredService } from 'src/app/_services/favoured.service';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginationResult } from 'src/app/_models/pagination';
import { FilterBarParams } from 'src/app/_models/filterBarParams';

@Component({
  selector: 'app-favoured-list',
  templateUrl: './favoured-list.component.html',
  styleUrls: ['./favoured-list.component.scss'],
})
export class FavouredListComponent implements OnInit {
  favoureds: FavouredDto[];
  pagination: Pagination;
  filterBarParms: FilterBarParams;

  constructor(
    private favouredService: FavouredService,
    private alertify: AlertifyjsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.favoureds = data.favoureds.result;
      this.pagination = data.favoureds.pagination;
    });
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadFavoured();
  }

  loadFavoured(orderBy?) {
    this.favouredService
      .getFavoureds(this.pagination.currentPage, this.pagination.pageSize, orderBy)
      .subscribe(
        (res: PaginationResult<FavouredDto[]>) => {
          this.favoureds = res.result;
          this.pagination = res.pagination;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  removeItem(favoured: FavouredDto) {
    this.favoureds = this.favoureds.filter((item) => item !== favoured);
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
