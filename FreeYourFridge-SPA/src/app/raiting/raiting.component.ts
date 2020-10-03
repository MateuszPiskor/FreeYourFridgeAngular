import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RatingContentComponent } from '../rating-content/rating-content.component';

@Component({
  selector: 'app-raiting',
  templateUrl: './raiting.component.html',
  styleUrls: ['./raiting.component.css'],
})
export class RaitingComponent implements OnInit {
  currentRate = 0;

  constructor(private modalService: NgbModal) {}

  ngOnInit(): void {}

  openModal() {
    const modalRef = this.modalService.open(RatingContentComponent);
  }
}
