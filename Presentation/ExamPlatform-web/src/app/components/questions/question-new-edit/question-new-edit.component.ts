import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent, MatDialog } from '@angular/material';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CategoryType } from '../../../models/CategoryType';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { QuestionTypeService } from 'src/app/services/questiontypes.service';
import { QuestionType } from 'src/app/models/QuestionType';
import { AnswerNewEditComponent } from '../../answers/answer-new-edit/answer-new-edit.component';
import { Answer } from 'src/app/models/Answer';
import { AnswerDeleteComponent } from '../../answers/answer-delete/answer-delete.component';
import { Question } from 'src/app/models/Question';
import { QuestionsService } from 'src/app/services/questions.service';
import { AnswersService } from 'src/app/services/answers.service';
import { ActivatedRoute } from '@angular/router';
import { AttachmentsComponent } from '../../attachments/attachments.component';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'question-new',
  templateUrl: './question-new-edit.component.html',
  styleUrls: ['./question-new-edit.component.css']
})
export class QuestionNewEditComponent implements OnInit {

  @ViewChild('categoryInput') categoryInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;

  questionModel: Question;
  nameFormValidator = new FormControl('', [Validators.required]);
  categoryCtrl = new FormControl();

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;

  separatorKeysCodes: number[] = [ENTER, COMMA];
  categoryTypes: Array<CategoryType> = [];
  filteredCategories: Observable<CategoryType[]> = new Observable<CategoryType[]>();
  selectedCategories: Array<CategoryType>;

  questionTypes: Array<QuestionType>;
  answerList: Answer[];
  answersToDelete: number[];
  isValid: boolean;
  correctAnswers: number;
  incorrectAnswers: number;
  pointsForCorrect: number;

  isNewOrEdit: boolean; // true if New, false if Edit
  questionId: string;
  title: string;
  submitted: boolean;
  isTextBoxQuestion: boolean;
  isRadioButtonQuestion: boolean;
  isCheckBoxQuestion: boolean;

  constructor(private categoryTypeService: CategoryTypeService,
    private questionTypesService: QuestionTypeService,
    private questionService: QuestionsService,
    private answerService: AnswersService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    public nav: NavbarService) {

    this.questionId = this.activatedRoute.snapshot.paramMap.get('id');
    if (this.questionId == null) {
      this.isNewOrEdit = true;
      this.title = "Creating new question";
    }
    else {
      this.isNewOrEdit = false;
      this.title = "Edit question";
      this.getAnswersToQuestion();
      this.getQuestionDetails();
    }

    this.getQuestionTypesList();
    this.getCategoryTypesList();
    this.filteredCategories =
      this.categoryCtrl.valueChanges.pipe(
        startWith(null),
        map((category: CategoryType | null) => category ? this._filter(this.categoryCtrl.value) : this.categoryTypes.slice()))
  }

  ngOnInit(): void {
    this.selectedCategories = new Array<CategoryType>();
    this.questionTypes = new Array<QuestionType>();
    this.categoryTypes = new Array<CategoryType>();
    this.answerList = new Array<Answer>();
    this.answersToDelete = new Array<number>();
    this.questionModel = new Question();

    this.correctAnswers = 0;
    this.incorrectAnswers = 0;
    this.pointsForCorrect = 0;
    this.questionModel.categoryTypeIds = new Array<number>();
    this.questionModel.content = "";
    this.submitted = false;
    this.isValid = false;
    this.nav.show();
    if (this.isNewOrEdit) {
      this.questionModel.pointsSum = 1;
    }
  }

  private async getQuestionTypesList() {
    const typesResponse = await this.questionTypesService.getQuestionTypes();
    this.questionTypes = typesResponse.data.questionTypes;
  }

  private async getCategoryTypesList() {
    const categoryTypeResponse = await this.categoryTypeService.getAllCategoryTypes();
    this.categoryTypes = categoryTypeResponse.data.categoryTypes;
  }

  private async updateAnswers() {
    for (const answerId of this.answersToDelete) {
      await this.answerService.deleteAnswer(answerId);
    }

    for (const answer of this.answerList) {
      if (answer.answerId == null) {
        answer.questionId = parseInt(this.questionId);
        await this.answerService.createAnswer(answer);
      } else {
        answer.questionId = parseInt(this.questionId);
        await this.answerService.updateAnswer(answer);
      }
    }
  }

  private async getAnswersToQuestion() {
    const answerResponse = await this.answerService.getAnswersToQuestion(this.questionId);
    this.answerList = answerResponse.data.answers;
    this.checkValidAndSummary();
  }

  private async getQuestionDetails() {
    const questionResponse = await this.questionService.getQuestion(this.questionId);
    this.questionModel = questionResponse.data.question;   

    this.questionModel.categoryTypeIds.forEach(x => {
      this.selectedCategories.push(this.categoryTypes.find(y => y.categoryTypeId === x));
    })

    if (!this.isNewOrEdit) {
      this.whatQuestionType(this.questionModel.questionTypeId);
    }
  }

  private async onAddQuestionClick() {
    this.questionModel.categoryTypeIds = [];
    this.selectedCategories.forEach(category => {
      this.questionModel.categoryTypeIds.push(category.categoryTypeId);
    })
    const questionResponse = await this.questionService.createQuestion(this.questionModel);
    var questionResponseId = questionResponse.data.question.questionId;

    if (!this.isTextBoxQuestion) {
      for (const answer of this.answerList) {
        answer.questionId = questionResponseId;
        await this.answerService.createAnswer(answer);
      }
    }
    location.reload();
  }

  private async onEditQuestionClick() {
    this.questionModel.categoryTypeIds = [];
    this.selectedCategories.forEach(category => {
      this.questionModel.categoryTypeIds.push(category.categoryTypeId);
    })
    await this.questionService.updateQuestion(this.questionModel);
    if (this.isTextBoxQuestion) {
      for (const answer of this.answerList) {
        await this.answerService.deleteAnswer(answer.answerId);
      }
    }
    else {
      this.updateAnswers();
    }
    location.reload();
  }

  onAddAnswerClick() {
    const dialogRef = this.dialog.open(AnswerNewEditComponent, {
      height: "66%",
      width: "38%"
    });

    dialogRef.afterClosed().subscribe(result => {
      if (dialogRef.componentInstance.closedByButton) {
        var answerModel = dialogRef.componentInstance.answerModel;
        this.answerList.push(answerModel);

        if (this.isRadioButtonQuestion && answerModel.isCorrect == true) {
          this.setJustOneCorrect(answerModel);
        }
        this.checkValidAndSummary();
      }
    });
  }

  onEditAnswerClick(answerId: number) {
    var answerModel = this.answerList[answerId];
    const dialogRef = this.dialog.open(AnswerNewEditComponent, {
      height: "66%",
      width: "38%",
      data: { answerModel: answerModel }
    })

    dialogRef.afterClosed().subscribe(result => {
      if (this.isRadioButtonQuestion && answerModel.isCorrect == true) {
        this.setJustOneCorrect(answerModel);
      }
      this.checkValidAndSummary();
    });
  }

  onDeleteAnswerClick(answerId: number) {
    var answerModel = this.answerList[answerId];
    const dialogRef = this.dialog.open(AnswerDeleteComponent, {
      height: "32%",
      width: "40%",
      data: { answerModel: answerModel }
    })

    dialogRef.afterClosed().subscribe(result => {

      if (dialogRef.componentInstance.closedByButton) {
        this.answersToDelete.push(this.answerList[answerId].answerId);
        this.answerList.splice(answerId, 1);
        this.checkValidAndSummary();
      }
    });
  }

  checkValidAndSummary(): void {
    this.isValid = false;
    this.correctAnswers = 0;
    this.incorrectAnswers = 0;
    this.pointsForCorrect = 0;

    this.answerList.forEach(answer => {

      if (answer.isCorrect == true) {
        this.pointsForCorrect = this.pointsForCorrect + answer.points;
        this.correctAnswers++;
      }
      else this.incorrectAnswers++;
    });

    if (this.answerList.length > 1) {
      if ((this.isCheckBoxQuestion && this.correctAnswers > 0) ||
        (this.isRadioButtonQuestion && this.correctAnswers == 1)) {
        if (this.pointsForCorrect > 0) this.isValid = true;
      }
    }
  }

  setJustOneCorrect(correctAnswer: Answer) {
    this.answerList.forEach(answer => {
      answer.isCorrect = false;
    });
    correctAnswer.isCorrect = true;
  }

  setSubmitted() {
    this.submitted = true;
  }

  onAddAttachmentClick() {
    //TODO method has obly basic funcionality
    this.dialog.open(AttachmentsComponent, {
    });
  }

  isCategoriesValid(): boolean {
    return this.selectedCategories.length > 0;
  }

  isContentValid(): boolean {
    return this.questionModel.content.length > 0;
  }

  whatQuestionType(questionTypeId: number): void {
    this.isCheckBoxQuestion = (questionTypeId == this.questionTypes[0].questionTypeId);
    this.isRadioButtonQuestion = (questionTypeId == this.questionTypes[1].questionTypeId);
    this.isTextBoxQuestion = (questionTypeId == this.questionTypes[2].questionTypeId);
    this.checkValidAndSummary();
  }

  add(event: MatChipInputEvent): void {
    if (!this.matAutocomplete.isOpen) {
      const input = event.input;
      const value = event.value;

      if ((value || '').trim()) {
        for (var i = 0; i < this.categoryTypes.length; i++) {
          if (value.trim() == this.categoryTypes[i].name) {
            this.selectedCategories.push(this.categoryTypes[i]);
            this.categoryTypes.splice(i, 1);
          }
        }
      }
      if (input) { input.value = ''; }
      this.categoryCtrl.setValue(null);
    }
    this.checkValidAndSummary();
  }

  remove(category: CategoryType): void {
    const index = this.selectedCategories.indexOf(category);
    if (index >= 0) {
      this.selectedCategories.splice(index, 1);
      this.categoryTypes.push(category);
    }
    this.checkValidAndSummary();
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    const index = this.categoryTypes.indexOf(event.option.value);
    this.categoryTypes.splice(index, 1);
    this.selectedCategories.push(event.option.value);
    this.checkValidAndSummary();
  }

  private _filter(value: string): Array<CategoryType> {
    var filterValue = '' + value;
    return this.categoryTypes.filter(category => category.name.toLowerCase().indexOf(filterValue.toLowerCase()) === 0);
  }
}