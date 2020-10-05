import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FavouredDto } from 'src/app/_models/Favoured/favouredDto';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FavouredService } from 'src/app/_services/favoured.service';
import { AlertifyjsService } from 'src/app/_services/alertifyjs.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-favoured-card',
  templateUrl: './favoured-card.component.html',
  styleUrls: ['./favoured-card.component.scss'],
})
export class FavouredCardComponent implements OnInit {
  listMode: boolean = true;
  editForm: FormGroup;

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

  ngOnInit() {
    this.editForm = new FormGroup({
      score: new FormControl(this.favoured.score, [Validators.required, Validators.min(1), Validators.max(10)])
    });
  }

  delete(favoured) {
    this.passFavoured.emit(favoured);
  }

  enableUpdate() {
    this.listMode = false;
  }

  editScore() {
    if (this.editForm.valid){
       this.favouredService
      .editScore(+this.favoured.spoonacularId, this.editForm.controls['score'].value)
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
      this.editForm.controls['score'].value
    }
    // this.favouredService
    //   .editScore(+model.spoonacularId, +model.score)
    //   .subscribe(
    //     () => {
    //       this.uploaded.emit('complete');
    //       this.listMode = true;
    //       this.alertifyjs.success('Score edited');
    //     },
    //     (error) => {
    //       this.alertifyjs.error('Some problem occurs');
    //     }
    //   );
    // console.log(this.editForm.value);
  }

  viewDetail(id) {
    this._router.navigate(['/recipes/', id]);
  }
}
