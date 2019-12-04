import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../models/User';
import { UsersService } from '../../../services/users.service';
import { Role } from 'src/app/models/Role';
import { RolesService } from 'src/app/services/roles.service';
import { TestsService } from '../../../services/tests.service';
import { Test } from '../../../models/Test';
import { UserTest } from '../../../models/UserTest';
import { UserTestService } from '../../../services/usertest.service';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog } from '@angular/material';
import { NavbarService } from 'src/app/services/navbar.service';
import { UserTestVerifyingComponent } from '../../user-test/user-test-verifying/user-test-verifying.component';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})

export class UserDetailsComponent implements OnInit {

  displayedColumns: string[] = ['TestName', 'SummaryType', 'TestStatusName', 'StartDate', 'Actions', 'LinkCopy'];
  userId: string;
  user: User
  roles: Array<Role>;
  tests: Array<Test>;
  userTests: Array<UserTest>;
  userTestModel: UserTest;
  userTestsList: MatTableDataSource<UserTest>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router,
    private activatedRoute: ActivatedRoute,
    private usersService: UsersService,
    private rolesService: RolesService,
    private testService: TestsService,
    private userTestService: UserTestService,
    public nav: NavbarService,
    public dialog: MatDialog,
    private alerts: AlertsService) {
    this.userId = this.activatedRoute.snapshot.paramMap.get('userId');
    this.getRoles();
    this.getUserDetails();
    this.getTests();
  }

  ngOnInit() {
    this.userId = "";
    this.user = new User();
    this.roles = new Array<Role>();
    this.tests = new Array<Test>();
    this.userTestsList = new MatTableDataSource<UserTest>();
    this.userTestModel = new UserTest();
    this.nav.show();
  }
  private async getRoles() {
    const roleResponse = await this.rolesService.getAllRoles();
    this.roles = roleResponse.data.roles;
  }

  private async getUserDetails() {
    const userResponse = await this.usersService.getUser(this.userId);
    if (!userResponse.isSuccess) {
      this.showErrorAlert(userResponse.errorMessage);
    }
    this.user = userResponse.data.user;    
    this.getUserTest(this.user.userId);
  }

  private async getTests() {
    const response = await this.testService.getAllTests();
    this.tests = response.data.tests;
  }

  private assignTestToUser(userId: string, selectedValue: number) {
    this.userTestModel.userId = userId;
    this.userTestModel.testId = selectedValue;
    this.userTestService.createUserTest(this.userTestModel);
  }

  private async getUserTest(UserId: string) {
    const response = await this.userTestService.getAllUserTests(UserId.toString());
    this.userTests = response.data.userTests;
    this.userTestsList = new MatTableDataSource<UserTest>(this.userTests);
    console.log(this.userTests)
    this.userTestsList.paginator = this.paginator
  }

  private getTotalPoints(testId: number) {
    for (let i of this.tests) {
      if (i.testId === testId) {
        return i.totalPointSum;
      }
    }
  }

  onAssignClick(userId: string, selectedValue: number) {
    this.assignTestToUser(userId, selectedValue);    
    location.reload();
  }

  onDetailsClick(userTestId: string) {
    this._router.navigate(['user-test-details', userTestId]);
  }

  toVerifyDialog(userTestId: string) {
    this.dialog.open(UserTestVerifyingComponent, {
      height: "80%",
      width: "50%",
      data: { userTestId: userTestId }
    });
  }

  showErrorAlert(message: string) {
    this.alerts.setDefaults('timeout', 0);
    this.alerts.setMessage(message, 'error');
  }
}




