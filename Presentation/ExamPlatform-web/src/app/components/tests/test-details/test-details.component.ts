import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestsService } from '../../../services/tests.service';
import { CategoryType } from '../../../models/CategoryType';
import { Question } from '../../../models/Question';
import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { Test } from '../../../models/Test';
import { QuestionsService } from '../../../services/questions.service';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'app-test-details',
  templateUrl: './test-details.component.html',
  styleUrls: ['./test-details.component.css']
})
export class TestDetailsComponent implements OnInit {

  testModel: Test;
  
  openQuestionPoints: number[] = [];
  closeQuestionPoints: number[] = [];

  testId: any;
  questionsList: MatTableDataSource<Question>;
  questions: Array<Question> = [];
  assignedQuestions: Question[] = [];

  selectedCategories: Array<CategoryType> = [];

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  
  displayedColumns: string[] = ['Question', 'Type', 'Categories', 'Points', 'actions'];

  constructor(private activatedRoute: ActivatedRoute, private testService: TestsService, private categoryTypeService: CategoryTypeService,
     private questionService: QuestionsService, public nav: NavbarService) {


    this.testId = this.activatedRoute.snapshot.paramMap.get('testId');
    this.questions = new Array<Question>();
    this.assignedQuestions = new Array<Question>();
  }

  ngOnInit() {
    this.getTest(this.testId);
    this.questionsList = new MatTableDataSource<Question>();
    this.questionsList.paginator = this.paginator;
    this.nav.show();
  }

  private async getTest(testId: any) {
    const testResponse = await this.testService.getTest('' + testId);
    this.testModel = testResponse.data.test;
    this.selectedCategories = this.testModel.testCategories;
    this.getQuestionsList();
  }

  private async getQuestionsList() {
    const questionResponse = await this.questionService.getAllQuestions();
    this.questions = questionResponse.data.questions;
    this.testModel.testQuestionIds.forEach(x => {
      var a = this.questions.find(y => y.questionId == x);
      this.assignedQuestions.push(a);
      console.log(this.assignedQuestions);
    })

    this.questionsList = new MatTableDataSource<Question>(this.assignedQuestions);
    this.updateSummary();
  }

  private listCategories(cats: Question): string {
    var cate = "";
    for (var i = 0; i < cats.categoryTypeIds.length; i++) {
      if (i == 0)
        cate = cate + cats.categoryTypeIds[i];
      else
        cate = cate + ", " + cats.categoryTypeIds[i];
    }
    return cate;
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
