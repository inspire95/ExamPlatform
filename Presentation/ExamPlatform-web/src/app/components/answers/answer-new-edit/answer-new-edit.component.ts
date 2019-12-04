import { Component, OnInit } from '@angular/core';
import { Answer } from '../../../models/Answer';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Inject } from '@angular/core';
import { NavbarService} from '../../../services/navbar.service';

@Component({
  selector: 'answer-new-edit',
  templateUrl: './answer-new-edit.component.html',
  styleUrls: ['./answer-new-edit.component.css']
})
export class AnswerNewEditComponent implements OnInit {

  answerModel: Answer;
  selectedQuestionType: number;
  closedByButton: boolean;
  submitted: boolean;
  isNewOrEdit: boolean; // true if New, false if Edit

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public nav : NavbarService) {
    this.closedByButton = false;
    this.isNewOrEdit = true;
  }

  ngOnInit() {
    this.submitted = false;
    this.answerModel = new Answer();
    this.answerModel.isCorrect = false;
    this.answerModel.points = 0;
    if (this.data != null) {
      this.answerModel = this.data.answerModel;
      this.isNewOrEdit = false;
      this.nav.show();
    }
  }

  setPoints(isCorrect: boolean) {
    if (isCorrect == false) {
      if (this.answerModel.points < 1 || this.answerModel.points == null) {
        this.answerModel.points = 1;
      }
    }
    else {
      this.answerModel.points = 0;
    }
  }

  updateAnswerList() {
    this.closedByButton = true;
  }

  setSubmitted() {
    this.submitted = true;
  }

  isValid(): boolean {
    if (this.answerModel.isCorrect) {
      return this.answerModel.points > 0;
    }
    else {
      return this.answerModel.points < 1;
    }
  }
}