import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-rating-content',
  templateUrl: './rating-content.component.html',
  styleUrls: ['./rating-content.component.css'],
})
export class RatingContentComponent implements OnInit {
  @Output() passEntry: EventEmitter<any> = new EventEmitter();

  @Input() public rating;
  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit(): void {
    console.log(this.rating.score);
  }

  passBack(ratingvote) {
    this.activeModal.close(ratingvote);
    this.passEntry.emit(this.rating);
  }
}
