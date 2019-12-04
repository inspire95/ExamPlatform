import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { Test } from '../../models/Test';
import { TestsService } from '../../services/tests.service';
import { TestDeleteComponent } from '../tests/test-delete/test-delete.component';
import { TestGenComponent } from '../tests/test-gen/test-gen.component';
import { TestNewComponent } from '../tests/test-new/test-new.component';
import { CategoryType } from '../../models/CategoryType';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})

export class TestComponent implements OnInit {
  test: Test;
  id: number;
  name: string;

  displayedColumns: string[] = ['TestId', 'Name', 'Categories', 'actions'];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  testsList: MatTableDataSource<Test>;
  tests: Array<Test> = [];

  constructor(private _router: Router,
    private testService: TestsService,
    public dialog: MatDialog,
    public nav: NavbarService) { }

  ngOnInit() {
    this.tests = new Array<Test>();
    this.testsList = new MatTableDataSource<Test>();
    this.getTestsList();
    this.nav.show();
  }

  private async getTestsList() {
    const testResponse = await this.testService.getAllTests();
    this.tests = testResponse.data.tests;
    this.testsList = new MatTableDataSource<Test>(this.tests);    
    this.testsList.paginator = this.paginator;
  }

  onAddClick(i: number) {
    switch (i) {
      case 1: this.dialog.open(TestNewComponent, {
        height: "82%",
        width: "50%",
      }); break;
      case 2: this.dialog.open(TestGenComponent, {}); break;
    }
  }

  deleteDialog(testId: number) {
    this.dialog.open(TestDeleteComponent, {
      height: "40%",
      width: "40%",
      data: { testId: testId }
    });
  }

  onDetailsClick(testId: number) {
    return this._router.navigate(['test-details', testId]);
  }

  onEditClick(testId: number) {
    return this._router.navigate(['test-edit', testId]);
  }

  private listCategories(cats: CategoryType[]): string {
    var cate = "";
    for (var i = 0; i < cats.length; i++) {
      if (i == 0)
        cate = cate + cats[i].name;
      else
        cate = cate + ", " + cats[i].name;
    }
    return cate;
  }
}
