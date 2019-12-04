import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Question } from '../../../models/Question';
import { UserTestAnswer } from '../../../models/UserTestAnswer';
import { QuestionsService } from '../../../services/questions.service';
import { UserTestAnswerService } from '../../../services/usertestanswer.service';
import { UserTestService } from '../../../services/usertest.service';

@Component({
  selector: 'app-user-test-verifying',
  templateUrl: './user-test-verifying.component.html',
  styleUrls: ['./user-test-verifying.component.css']
})
export class UserTestVerifyingComponent implements OnInit {

  userTestId: string;
  userTestAnswers: UserTestAnswer[];

  allQuestions: Question[];
  answers: Array<string>;

  questionId: number;
  currentQuestion: number;

  quests: Array<string>;

  pointsSum: Array<number>;

  userQuestionAnswerModel: UserAnswerModel;
  openQuestionAnswerList: Array<UserAnswerModel>;

  verifyUserTest: UserTestAnswer;
  couldBeChanged: boolean;

  checkSummaryModel: boolean;
  zmienna: any;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private userTestAnswerService: UserTestAnswerService, private questionService: QuestionsService, private userTestservice: UserTestService) {
    this.userTestId = data.userTestId;
  }

  ngOnInit() {
    this.userQuestionAnswerModel = new UserAnswerModel;
    this.verifyUserTest = new UserTestAnswer;
    this.getUserTestOpenAnswers();
    this.getAllQuestions();

    this.openQuestionAnswerList = new Array<UserAnswerModel>();
    this.userTestAnswers = new Array<UserTestAnswer>();

    this.currentQuestion = 0;
    this.pointsSum = new Array<number>();

    this.couldBeChanged = false;
  }
  private setFlagOnTrue() {
    this.couldBeChanged = true;
  }
  private async getUserTestOpenAnswers() {
    const response = await this.userTestAnswerService.getUserTestOpenAnswers(this.userTestId);
    this.userTestAnswers = response.userTestAnswers;
  }
  private async CheckSummary() {
    await this.userTestservice.CheckSummaryUserTest(this.userTestId.toString());
    location.reload();
  }

  private async getAllQuestions() {
    const response = await this.questionService.getAllQuestions();
    this.allQuestions = response.data.questions;
    this.setOpenQuestinAnswerList();
    this.userQuestionAnswerModel = this.openQuestionAnswerList[this.currentQuestion];
    console.log(this.userQuestionAnswerModel)
  }

  private setOpenQuestinAnswerList() {
    for (let question of this.allQuestions) {
      for (let answer of this.userTestAnswers) {
        if (question.questionId == answer.questionId) {
          var model: UserAnswerModel;
          var points = null;
          if (answer.pointsForOpenQuestion != null) {
            points = answer.pointsForOpenQuestion;
          }
          model = {
            userTestAnswerId: answer.userTestAnswerId,
            answerContent: answer.content,
            questionContent: question.content,
            pointsSum: question.pointsSum,
            aquiredPoints: points,
          }
          this.openQuestionAnswerList.push(model)
        }
      }
    }
  }

  onNextQuestion(userTestAnswerId: number, aquiredPoints: number) {
    console.log(aquiredPoints)
    if (this.couldBeChanged) {
      this.Verifying(userTestAnswerId, aquiredPoints);
    }
    this.currentQuestion++;
    this.userQuestionAnswerModel = this.openQuestionAnswerList[this.currentQuestion];
    this.couldBeChanged = false;
  }

  onBackQuestion(userTestAnswerId: number, aquiredPoints: number) {
    console.log(aquiredPoints)
    if (this.couldBeChanged) {
      this.Verifying(userTestAnswerId, aquiredPoints);
    }
    this.currentQuestion--;
    this.userQuestionAnswerModel = this.openQuestionAnswerList[this.currentQuestion];
    this.couldBeChanged = false;
  }
  onFinish(userTestAnswerId: number, aquiredPoints: number) {
    console.log(aquiredPoints)
    if (this.couldBeChanged) {
      this.Verifying(userTestAnswerId, aquiredPoints);
    }
    this.userQuestionAnswerModel = this.openQuestionAnswerList[this.currentQuestion];
    this.couldBeChanged = false;
    this.CheckSummary();

  }

  private async Verifying(userTestAnswerId: number, aquiredPoints: number) {
    await this.userTestAnswerService.verifyOpenUserAnswer(userTestAnswerId, aquiredPoints);
  }
}

export class UserAnswerModel {
  userTestAnswerId: number;
  questionContent: string;
  answerContent: string;
  aquiredPoints: number;
  pointsSum: number;
}
