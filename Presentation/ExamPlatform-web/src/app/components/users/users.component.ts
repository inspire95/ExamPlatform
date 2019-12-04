import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';
import { UsersService } from 'src/app/services/users.service';
import { UserNewEditComponent } from '../users/user-new-edit/user-new-edit.component';
import { UserDeleteComponent } from '../users/user-delete/user-delete.component';
import { NavbarService } from '../../services/navbar.service';
import { AlertsService } from 'angular-alert-module';

@Component({
  selector: 'users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})

export class UsersComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  usersList: MatTableDataSource<User>;
  users: Array<User>;
  displayedColumns: string[] = ['FirstName', 'LastName', 'actions'];

  constructor(private _router: Router,
    private usersService: UsersService,
    public dialog: MatDialog,
    public nav: NavbarService,
    private alerts: AlertsService) { }

  ngOnInit() {
    this.users = new Array<User>();
    this.usersList = new MatTableDataSource<User>();
    this.getUsersList();
    this.nav.show();
  }

  private async getUsersList() {
    const usersResponse = await this.usersService.getAllUsers();
    if (!usersResponse.isSuccess) {
      this.showErrorAlert(usersResponse.errorMessage);
    }
    this.users = usersResponse.data.users;
    this.usersList = new MatTableDataSource<User>(this.users);
    this.usersList.paginator = this.paginator
  }

  onAddClick() {
    this.dialog.open(UserNewEditComponent, {
      height: "95%",
      width: "40%"
    });
  }

  onDetailsClick(userId: string) {
    return this._router.navigate(['user-details', userId]);
  }

  onEditClick(userId: string) {
    this.dialog.open(UserNewEditComponent, {
      height: "95%",
      width: "40%",
      data: { userId: userId }
    })
  }

  onDeleteClick(userId: string) {
    this.dialog.open(UserDeleteComponent, {
      height: "40%",
      width: "40%",
      data: { userId: userId }
    })
  }

  showErrorAlert(message: string) {
    this.alerts.setDefaults('timeout', 0);
    this.alerts.setMessage(message, 'error');
  }
}
