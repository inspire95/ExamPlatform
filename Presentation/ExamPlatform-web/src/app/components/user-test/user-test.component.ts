import { Component, OnInit } from '@angular/core';
import { Answer } from 'src/app/models/Answer';
import { ActivatedRoute } from '@angular/router';
import { UserTestService } from 'src/app/services/usertest.service';
import { UserTest } from 'src/app/models/UserTest';
import { Test } from 'src/app/models/Test';
import { TestsService } from 'src/app/services/tests.service';
import { QuestionsService } from 'src/app/services/questions.service';
import { Question } from 'src/app/models/Question';
import { AnswersService } from 'src/app/services/answers.service';
import { QuestionTypeService } from 'src/app/services/questiontypes.service';
import { QuestionType } from 'src/app/models/QuestionType';
import { NavbarService } from 'src/app/services/navbar.service';
import { UserTestAnswer } from 'src/app/models/UserTestAnswer';
import { UserTestAnswerService } from 'src/app/services/usertestanswer.service';
import { User } from '../../models/User';
import { UsersService } from '../../services/users.service';
import { CategoryType } from '../../models/CategoryType';

@Component({
  selector: 'user-test',
  templateUrl: './user-test.component.html',
  styleUrls: ['./user-test.component.css']
})
export class UserTestComponent implements OnInit {

  userTestId: string;
  userTest: UserTest;
  user: User;
  test: Test;
  isStarted: boolean;
  isFinished: boolean;
  questionModel: Question;
  questionType: QuestionType;
  answerList: Array<Answer>;

  currentQuestion: number;
  content: string;
  primaryUserAnswers: Array<UserTestAnswer>;
  chosenQuestionAnswerIds: number[];
  answersCouldBeChanged: boolean;
  canBeLoad: boolean;
  isTextBoxQuestion: boolean;

  constructor(private activatedRoute: ActivatedRoute, private userTestService: UserTestService,
    private testService: TestsService, private userService: UsersService,
    private questionService: QuestionsService,
    private answerService: AnswersService, private questionTypesService: QuestionTypeService, public nav: NavbarService,
    private userTestAnswerService: UserTestAnswerService) {
    this.userTestId = this.activatedRoute.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {    
    this.primaryUserAnswers = new Array<UserTestAnswer>();
    this.canBeLoad = true;
    this.answerList = new Array<Answer>();
    this.test = new Test();
    this.user = new User();
    this.test.testQuestionIds = new Array<number>();
    this.userTest = new UserTest();
    this.currentQuestion = 0;
    this.questionModel = new Question();
    this.questionType = new QuestionType();
    this.getUserTest();
    this.isStarted = false;
    this.isFinished = false;
    this.nav.hide();
    this.answersCouldBeChanged = false;
    this.isTextBoxQuestion = false;
  }

  onStartTest() {
    this.canBeLoad = false;
    this.isStarted = true;
    this.userTestService.startUserTest(this.userTestId);
    this.getQuestion(this.test.testQuestionIds[this.currentQuestion]);
  }

  onNextQuestion() {
    this.currentQuestion++;
    this.updateUserAnswers(this.questionModel.questionId);
    this.canBeLoad = false;
    this.getQuestion(this.test.testQuestionIds[this.currentQuestion]);
    this.answersCouldBeChanged = false;
  }

  onBackQuestion() {
    this.currentQuestion--;
    this.updateUserAnswers(this.questionModel.questionId);
    this.canBeLoad = false;
    this.getQuestion(this.test.testQuestionIds[this.currentQuestion]);
    this.answersCouldBeChanged = false;
  }

  onFinishTest() {
    this.updateUserAnswers(this.questionModel.questionId);
    this.answersCouldBeChanged = false;
    this.userTestService.finishUserTest(this.userTestId);
    this.isFinished = true;
  }

  private async getUserTest() {
    const userTestResponse = await this.userTestService.getUserTest(this.userTestId);
    this.userTest = userTestResponse.data.userTest;
    console.log(userTestResponse);
    
    this.getTest(this.userTest.testId);
    this.getUser(this.userTest.userId);
  }

  private async getTest(testId: number) {
    const testResponse = await this.testService.getTest(testId.toString());
    this.test = testResponse.data.test;
  }

  private async getUser(userId: string) {
    const userResponse = await this.userService.getUser(userId.toString());
    this.user = userResponse.data.user;
  }

  private async getQuestion(questionId: number) {
    const questionResponse = await this.questionService.getQuestion(questionId.toString());
    this.questionModel = questionResponse.data.question;
    this.getAnswersToQuestion(this.questionModel.questionId);
    this.getQuestionType();
    this.getPrimaryUserAnswers();
  }

  private async getAnswersToQuestion(questionId: number) {
    const answerResponse = await this.answerService.getAnswersToQuestion(questionId.toString());
    this.answerList = answerResponse.data.answers;
  }

  private async getQuestionType() {
    const questionResponse = await this.questionTypesService.getQuestionType(this.questionModel.questionTypeId);
    this.questionType = questionResponse.data.questionType;
    this.questionType.questionTypeId == 3 ? this.isTextBoxQuestion = true : this.isTextBoxQuestion = false;
  }

  private async getPrimaryUserAnswers() {
    const userAnswersResponse = await this.userTestAnswerService.getUserAnswersToQuestion(this.userTest.userTestId, this.questionModel.questionId);
    this.primaryUserAnswers = userAnswersResponse.data.userTestAnswers;
    this.content = null;
    this.chosenQuestionAnswerIds = [];
    if (this.primaryUserAnswers.length != 0) { ///checking if user fill question by frist time
      if (this.isTextBoxQuestion) {
        this.content = this.primaryUserAnswers[0].content;
      }
      this.primaryUserAnswers.forEach(x => {
        this.chosenQuestionAnswerIds.push(x.answerId);
      });
    }
    this.canBeLoad = true;
  }

  private async updateUserAnswers(questionId: number) {
    if (this.answersCouldBeChanged) {
      await this.userTestAnswerService.deleteUserAnswersByQuestion(this.userTest.userTestId, questionId);
      if (this.isTextBoxQuestion) {
        var newUserAnswer: UserTestAnswer;
        newUserAnswer = {
          userTestAnswerId: null,
          answerId: null,
          content: this.content,
          questionId: questionId,
          userTestId: this.userTest.userTestId,
          pointsForOpenQuestion: 0
        }
        await this.userTestAnswerService.createUserAnswer(newUserAnswer);
      }
      else {
        for (const answer of this.chosenQuestionAnswerIds) {
          await this.userTestAnswerService.createUserAnswer(this.newUserAnswer(answer, questionId));
        }
      }
    }
  }

  setCouldBeChanged() {
    this.answersCouldBeChanged = true;
  }

  setJustOneCorrect(answerId: number) {
    this.answersCouldBeChanged = true;
    this.chosenQuestionAnswerIds = [];
    this.chosenQuestionAnswerIds.push(answerId);
  }

  newUserAnswer(answerId: number, questionId: number): UserTestAnswer {
    var newUserAnswer: UserTestAnswer;
    newUserAnswer = {
      userTestAnswerId: null,
      answerId: answerId,
      content: this.content,
      questionId: questionId,
      userTestId: this.userTest.userTestId,
      pointsForOpenQuestion: 0
    }
    return newUserAnswer;
  }

  private listCategories(categories: CategoryType[]): string {
    var cate = "";
    for (var i = 0; i < categories.length; i++) {
      if (i == 0)
        cate = cate + categories[i].name;
      else
        cate = cate + ", " + categories[i].name;
    }
    return cate;
  }
}
