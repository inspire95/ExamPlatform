import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Question } from '../../../models/Question';
import { UserTest } from '../../../models/UserTest';
import { UserTestAnswer } from '../../../models/UserTestAnswer';
import { AnswersService } from '../../../services/answers.service';
import { QuestionsService } from '../../../services/questions.service';
import { TestsService } from '../../../services/tests.service';
import { UsersService } from '../../../services/users.service';
import { User } from '../../../models/User';
import { Test } from '../../../models/Test';
import { UserTestAnswerService } from 'src/app/services/usertestanswer.service';
import { UserTestService } from 'src/app/services/usertest.service';

@Component({
  selector: 'app-user-test-details',
  templateUrl: './user-test-details.component.html',
  styleUrls: ['./user-test-details.component.css']
})
export class UserTestDetailsComponent implements OnInit {
  userTest: UserTest
  userTestId: string;

  user: User;
  userId: string;

  test: Test;
  testId: number;
  questions: Array<Question>;
  userTestAnswers: Array<UserTestAnswer>;

  constructor(
    public userTestService: UserTestService,
    public testService: TestsService,
    public userService: UsersService,
    public activatedRoute: ActivatedRoute,
    public answerService: AnswersService,
    public questionService: QuestionsService,
    public userTestAnswerService: UserTestAnswerService) {

    this.userTestId = this.activatedRoute.snapshot.paramMap.get('userTestId');
  }

  ngOnInit() {
    this.userTest = new UserTest();
    this.test = new Test();
    this.user = new User();
    this.questions = new Array<Question>();
    this.userTestAnswers = new Array<UserTestAnswer>();
    this.getUserTest();
    this.getAllQuestions();
    this.getQuestionAnswers(this.userTestId);
  }

  private async getAllQuestions() {
    const response = await this.questionService.getAllQuestions();
    this.questions = response.data.questions;
  }
  private async getQuestionAnswers(userTestId: string) {
    const response = await this.userTestAnswerService.getUserAnswers('' + userTestId);
    this.userTestAnswers = response.data.userTestAnswers;
    console.log(this.userTestAnswers)
  }

  private async getUserTest() {
    const response = await this.userTestService.getUserTest(this.userTestId);
    this.userTest = response.data.userTest;
    console.log(this.userTest)
    this.userId = this.userTest.userId;
    this.testId = this.userTest.testId;
    this.getUser(this.userId);
    this.getTest(this.testId);
  }

  private async getUser(userId: string) {
    const userResponse = await this.userService.getUser(userId);
    this.user = userResponse.data.user;
  }

  private async getTest(testId: number) {
    const testResponse = await this.testService.getTest(this.testId.toString());
    this.test = testResponse.data.test;
  }

  //TODO - async problem
  private getCategories() {
    var categories: string;
    categories = "";
    for (let i of this.test.testCategories) {
      categories = i.name + ", " + categories;

    }
    return categories;
  }
}
