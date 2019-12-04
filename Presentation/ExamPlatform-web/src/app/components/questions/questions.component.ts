import { Component, ViewChild } from '@angular/core';
import { QuestionsService } from 'src/app/services/questions.service';
import { MatTableDataSource, MatPaginator, MatDialog, PageEvent } from '@angular/material';
import { Question } from 'src/app/models/Question';
import { Router } from '@angular/router';
import { QuestionDeleteComponent } from '../questions/question-delete/question-delete.component';
import { QuestionTypeService } from 'src/app/services/questiontypes.service';
import { QuestionType } from 'src/app/models/QuestionType';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})

export class QuestionsComponent {
  constructor(private _router: Router, private questionService: QuestionsService, public dialog: MatDialog,
    private questionTypesService: QuestionTypeService, public nav:NavbarService) { 
      this.getQuestionTypesList();
    }

  displayedColumns: string[] = ['Content', 'QuestionType', 'Points', 'actions'];
  questions: Array<Question>;
  questionsList: MatTableDataSource<Question>;
  questionTypes: Array<QuestionType>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit() {
    this.questionTypes = new Array<QuestionType>();
    this.questions = new Array<Question>();
    this.questionsList = new MatTableDataSource<Question>();    
    this.getQuestionsList();
    this.nav.show();
  }

  private async getQuestionsList() {
    const questionResponse = await this.questionService.getAllQuestions();
    this.questions = questionResponse.data.questions;
    this.questionsList = new MatTableDataSource<Question>(this.questions);
    this.questionsList.paginator = this.paginator;
  }

  private async getQuestionTypesList() {
    const typesResponse = await this.questionTypesService.getQuestionTypes();
    this.questionTypes = typesResponse.data.questionTypes;
  }

  onAddClick() {
    return this._router.navigate(['question-new']);
  }

  onDetailsClick(questionId: number) {
    return this._router.navigate(['question-details', questionId]);
  }

  onEditClick(questionId: number) {
    return this._router.navigate(['question-edit', questionId]);
  }

  onDeleteClick(questionId: number): void {
    this.dialog.open(QuestionDeleteComponent, {
      height: "300px",
      data: { questionId: questionId }
    })
  }
  pageEvent: PageEvent;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  setPageSizeOptions(setPageSizeOptionsInput: string) {
    this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
  }
}