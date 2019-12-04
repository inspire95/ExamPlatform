import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { TestsService } from '../../../services/tests.service';
import { Test } from 'src/app/models/Test';
import { NavbarService} from '../../../services/navbar.service';

@Component({
  selector: 'app-test-delete',
  templateUrl: './test-delete.component.html',
  styleUrls: ['./test-delete.component.css']
})
export class TestDeleteComponent implements OnInit {

  testId: string;
  test: Test;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private testsService: TestsService, public nav: NavbarService) {
    this.testId = data.testId;
    this.getTestDetails();
  }

  ngOnInit() {
    this.test = new Test();
    this.nav.show();
  }

  onYesClick(){
   this.deleteTest();
   location.reload();
  }

  private async getTestDetails() {
    const testResponse = await this.testsService.getTest(this.testId);
    this.test = testResponse.data.test;   
  }

  private async deleteTest() {
    const testResponse = await this.testsService.deleteTest(this.testId);
  }
}
