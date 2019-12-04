import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CategoryType } from '../../../models/CategoryType';
import { Question } from '../../../models/Question';
import { Test } from '../../../models/Test';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { QuestionsService } from '../../../services/questions.service';
import { TestsService } from '../../../services/tests.service';
import { NavbarService } from 'src/app/services/navbar.service';
import { QuestionType } from '../../../models/QuestionType';
import { QuestionTypeService } from '../../../services/questiontypes.service';

@Component({
  selector: 'app-test-edit',
  templateUrl: './test-edit.component.html',
  styleUrls: ['./test-edit.component.css']
})
export class TestEditComponent implements OnInit {

  testId: any;
  
  openQuestionPoints: number[];
  closeQuestionPoints: number[];

  nameFormValidator = new FormControl('', [Validators.required]);
  categoryCtrl = new FormControl();

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  submitted = false;

  displayedColumns: string[] = ['Question', 'Type', 'Points', 'actions'];
  
  testModel: Test = new Test();
  separatorKeysCodes: number[] = [ENTER, COMMA];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('categoryInput') categoryInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;

  questionsList: MatTableDataSource<Question>;
  questions: Array<Question> = [];
  assignedQuestions: Question[] = [];
  questionShow: Question[] = [];

  categoryTypes: Array<CategoryType> = [];
  filteredCategories: Observable<CategoryType[]> = new Observable<CategoryType[]>();
  selectedCategories: Array<CategoryType> = [];

  questionTypes: Array<QuestionType>;

  constructor(private activatedRoute: ActivatedRoute, private _router: Router, private testService: TestsService, private categoryTypeService: CategoryTypeService,
    private questionService: QuestionsService, private questionTypeService: QuestionTypeService, public nav: NavbarService) {

    this.testId = this.activatedRoute.snapshot.paramMap.get('testId');
    this.filteredCategories =
      this.categoryCtrl.valueChanges.pipe(
        startWith(null),
        map((category: CategoryType | null) => category ? this._filter(this.categoryCtrl.value) : this.categoryTypes.slice()))
    this.getQuestionTypeList();
  }

  ngOnInit() {
    this.questionTypes = new Array<QuestionType>();
    this.openQuestionPoints = [];
    this.closeQuestionPoints = [];
    this.categoryTypes = new Array<CategoryType>();
    this.questions = new Array<Question>();
    this.questionsList = new MatTableDataSource<Question>();
    this.getTest(this.testId);
    this.nav.show();
  }

  private async getTest(testId: number) {
    const testResponse = await this.testService.getTest('' + testId);
    this.testModel = testResponse.data.test;
    this.getCategoryTypesList();
  }

  private async getCategoryTypesList() {
    const categoryTypeResponse = await this.categoryTypeService.getAllCategoryTypes();
    this.categoryTypes = categoryTypeResponse.data.categoryTypes;
    console.log(this.categoryTypes)
    this.getQuestionsList();
  }

  private async getQuestionsList() {
    const questionResponse = await this.questionService.getAllQuestions();
    this.questions = questionResponse.data.questions;
    console.log(this.questions)
    this.questionsList = new MatTableDataSource<Question>(this.questionShow);
    this.questionsList.paginator = this.paginator;
    this.updateSelectedCategories();
    this.updateSummary();
    this.refresh();
  }
  private async getQuestionTypeList() {
    const response = await this.questionTypeService.getQuestionTypes();
    this.questionTypes = response.data.questionTypes;
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
      this.refresh();
    }
  }

  remove(category: CategoryType): void {
    const index = this.selectedCategories.indexOf(category);
    if (index >= 0) {
      this.selectedCategories.splice(index, 1);
      this.categoryTypes.push(category);
      this.refresh();
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    const index = this.categoryTypes.indexOf(event.option.value);
    this.categoryTypes.splice(index, 1);
    this.selectedCategories.push(event.option.value);
    this.refresh();
  }

  private _filter(value: string): Array<CategoryType> {
    var filterValue = '' + value;
    return this.categoryTypes.filter(category => category.name.toLowerCase().indexOf(filterValue.toLowerCase()) === 0);
  }

  private updateTest() {
    this.testModel.testId = this.testId;
    this.testModel.testCategories = this.selectedCategories;
    this.testService.updateTest(this.testModel);

    return this._router.navigate(['tests']);
  }

  private isAssigned(question: Question): boolean {
    return this.testModel.testQuestionIds.includes(question.questionId);
  }

  private assignClick(question: Question) {
    this.testModel.testQuestionIds.push(question.questionId);
    this.updateSummary();
    console.log(this.testModel.testQuestionIds);
  }

  private detachClick(question: Question) {
    var index = this.testModel.testQuestionIds.indexOf(question.questionId);
    this.testModel.testQuestionIds.splice(index, 1);
    this.updateSummary();
    console.log(this.testModel.testQuestionIds);
  }

  private setSubmitted() {
    this.submitted = true;
    this.updateQuestionList();
  }

  private updateQuestionList() {
    var a, b, c;
    this.questionShow = [];
    this.selectedCategories.forEach(x => {
      a = this.questionShow;
      b = this.questions.filter(z => z.categoryTypeIds.includes(x.categoryTypeId) == true);
      c = a.concat(b.filter(function (item) {
        return a.indexOf(item) < 0;
      }));
      this.questionShow = c;
    });
  }

  private refresh() {
    this.updateQuestionList();
    this.questionsList.data = this.questionShow;
    this.updateSelectedCategories();
  }

  private updateSelectedCategories() {

    this.selectedCategories = this.testModel.testCategories;

    for (let element of this.testModel.testCategories) {
      var id = this.categoryTypes.findIndex(x => x.categoryTypeId == element.categoryTypeId);
      this.categoryTypes.splice(id, 1);
    }
  }

  private sumArray(arr: any[]): number {
    var sum = arr.reduce((a, b) => a + b, 0);
    return sum;
  }

  private updateSummary() {
    this.assignedQuestions = [];
    this.openQuestionPoints = [];
    this.closeQuestionPoints = [];

    for (let element of this.testModel.testQuestionIds) {
      this.assignedQuestions.push(this.questions.find(x => x.questionId == element));
    }

    for (let element of this.assignedQuestions) {
      switch (element.questionTypeId) {
        case 1: this.closeQuestionPoints.push(element.pointsSum); break;
        case 2: this.closeQuestionPoints.push(element.pointsSum); break;
        case 3: this.openQuestionPoints.push(element.pointsSum); break;
        default: break;
      }
    }

    this.testModel.totalPointSum = this.sumArray(this.closeQuestionPoints) + this.sumArray(this.openQuestionPoints);
  }
}
