import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FavouredService } from 'src/app/_services/favoured.service';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-favoured-card',
  templateUrl: './favoured-card.component.html',
  styleUrls: ['./favoured-card.component.scss'],
})
export class FavouredCardComponent implements OnInit {
  listMode: boolean = true;
  @Input()
  favoured: FavouredDto;

  @Output() passFavoured: EventEmitter<any> = new EventEmitter();
  @Output() uploaded = new EventEmitter<string>();

  constructor(
    private modalService: NgbModal,
    private favouredService: FavouredService,
    private alertifyjs: AlertifyjsService,
    private _router: Router
  ) {}

  ngOnInit() {}

  delete(favoured) {
    this.passFavoured.emit(favoured);
  }

  enableUpdate() {
    this.listMode = false;
  }

  editScore(model) {
    this.favouredService
      .editScore(+model.spoonacularId, +model.score)
      .subscribe(
        () => {
          this.uploaded.emit('complete');
          this.listMode = true;
          this.alertifyjs.success('Score edited');
        },
        (error) => {
          this.alertifyjs.error('Some problem occurs');
        }
      );
  }

  viewDetail(id) {
    this._router.navigate(['/recipes/', id]);
  }
}
