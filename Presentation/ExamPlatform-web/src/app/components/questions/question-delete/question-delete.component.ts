import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { QuestionsService } from 'src/app/services/questions.service';
import { Question } from 'src/app/models/Question';
import { NavbarService} from '../../../services/navbar.service';

@Component({
  selector: 'question-delete',
  templateUrl: './question-delete.component.html',
  styleUrls: ['./question-delete.component.css']
})
export class QuestionDeleteComponent implements OnInit {

  questionId: string;
  questionModel: Question;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private questionService: QuestionsService, public nav: NavbarService) {
    this.questionId = data.questionId;
    this.getQuestionDetails();
  }

  ngOnInit() {
    this.questionModel = new Question();
    this.nav.show();
  }

  onYesClick() {
    this.deleteUser();
    location.reload();
  }

  private async getQuestionDetails() {
    const questionResponse = await this.questionService.getQuestion(this.questionId);
    this.questionModel = questionResponse.data.question;
  }

  private async deleteUser() {
    await this.questionService.deleteQuestion(this.questionId);
  }
}