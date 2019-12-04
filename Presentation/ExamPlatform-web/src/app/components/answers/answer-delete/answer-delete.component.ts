import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Answer } from 'src/app/models/Answer';
import { NavbarService} from '../../../services/navbar.service';

@Component({
  selector: 'answer-delete',
  templateUrl: './answer-delete.component.html',
  styleUrls: ['./answer-delete.component.css']
})
export class AnswerDeleteComponent implements OnInit {

  answerModel: Answer;
  closedByButton : boolean;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public nav : NavbarService) {
  }

  ngOnInit(): void {
    this.answerModel = this.data.answerModel;
    this.closedByButton = false;
    this.nav.show();
  }

  onYesClick() {
    this.closedByButton = true;
  }
}