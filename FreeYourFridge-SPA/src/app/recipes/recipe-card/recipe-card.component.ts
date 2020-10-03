import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeToList } from 'src/app/_models/recipeToList';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';
import { RecipesToListDto } from 'src/app/_models/RecipesToListDto';
import { Data } from '../../data';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RatingContentComponent } from 'src/app/rating-content/rating-content.component';
import { FavouredService } from 'src/app/_services/favoured.service';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss'],
})
export class RecipeCardComponent implements OnInit {
  @Input()
  recipeToList: RecipeToList;
  currentRating: RecipesToListDto;

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private data: Data,
    private modalService: NgbModal,
    private favouredService: FavouredService
  ) {}

  ngOnInit() {
    +this._route.snapshot.paramMap.get('id');
  }

  viewDetails() {
    this.data.storage = this.recipeToList;
    ("['/recipes/', recipe.id]");
    this._router.navigate(['/recipes/', this.recipeToList.id]);
  }

  openModal() {
    const favouredDto = new FavouredDto();
    const modalRef = this.modalService.open(RatingContentComponent);
    // modalRef.componentInstance.rating = this.rating;
    modalRef.componentInstance.passEntry.subscribe((receivedEntry) => {
      favouredDto.score = +receivedEntry;
      favouredDto.spoonacularId = +this.recipeToList.id;
      favouredDto.title = this.recipeToList.title;
      favouredDto.image = this.recipeToList.image;
      this.favouredService.addFavoured(favouredDto).subscribe(
        (res) => {
          console.log(res);
        },
        (error) => {
          console.log(error);
        }
      );
    });
  }
}
