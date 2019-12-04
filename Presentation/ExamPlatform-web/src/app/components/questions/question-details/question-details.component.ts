import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Question } from 'src/app/models/Question';
import { Answer } from 'src/app/models/Answer';
import { QuestionsService } from 'src/app/services/questions.service';
import { AnswersService } from 'src/app/services/answers.service';
import { QuestionTypeService } from 'src/app/services/questiontypes.service';
import { CategoryTypeService } from 'src/app/services/categorytypes.service';
import { QuestionType } from 'src/app/models/QuestionType';
import { CategoryType } from 'src/app/models/CategoryType';
import { NavbarService} from '../../../services/navbar.service';

@Component({
  selector: 'question-details',
  templateUrl: './question-details.component.html',
  styleUrls: ['./question-details.component.css']
})
export class QuestionDetailsComponent implements OnInit {

  questionModel: Question;
  questionId: string;
  answersList: Array<Answer>;
  questionType: QuestionType;
  categoryTypes: Array<CategoryType>;

  constructor(private activatedRoute: ActivatedRoute, private questionService: QuestionsService,
    private answerService: AnswersService, private questionTypesService: QuestionTypeService,
    private categoryTypeService: CategoryTypeService, public nav: NavbarService) {
    this.questionId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getAnswersToQuestion();
  }

  ngOnInit(): void {
    this.getQuestionDetails();
    this.categoryTypes = new Array<CategoryType>();
    this.questionType = new QuestionType();
    this.questionModel = new Question();
    this.answersList = new Array<Answer>();
    this.nav.show();
  }

  private async getQuestionDetails() {
    this.getCategoryTypesList();
    const questionResponse = await this.questionService.getQuestion(this.questionId);
    this.questionModel = questionResponse.data.question;
    this.getQuestionType();
  }

  private async getAnswersToQuestion() {
    const answerResponse = await this.answerService.getAnswersToQuestion(this.questionId);
    this.answersList = answerResponse.data.answers;
  }

  private async getQuestionType() {
    const questionRseponse = await this.questionTypesService.getQuestionType(this.questionModel.questionTypeId);
    this.questionType = questionRseponse.data.questionType;
  }

  private async getCategoryTypesList() {
    const categoryTypeResponse = await this.categoryTypeService.getAllCategoryTypes();
    this.categoryTypes = categoryTypeResponse.data.categoryTypes;
  }
}