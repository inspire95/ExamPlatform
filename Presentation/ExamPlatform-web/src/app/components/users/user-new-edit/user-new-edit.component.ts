import { Component, OnInit, Inject } from '@angular/core'
import { RolesService } from 'src/app/services/roles.service'
import { User } from 'src/app/models/User'
import { UsersService } from 'src/app/services/users.service';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Role } from 'src/app/models/Role';
import { NavbarService } from '../../../services/navbar.service';

@Component({
  selector: 'new-user',
  templateUrl: './user-new-edit.component.html',
  styleUrls: ['./user-new-edit.component.css']
})

export class UserNewEditComponent implements OnInit {

  roles: Array<Role>;
  userId: string;
  userModel: User;
  selectItemsIsEmpty: boolean;
  submitted: boolean;
  isNewOrEdit: boolean; // true if New, false if Edit

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private rolesService: RolesService,
    private usersService: UsersService,
    public nav: NavbarService) {
    this.getRoles();
    this.isNewOrEdit = true;
    this.selectItemsIsEmpty = false;
    this.submitted = false;

    if (data != null) {
      this.isNewOrEdit = false;
      this.userId = data.userId;
      this.getUserDetails();
    }
  }

  ngOnInit() {
    this.userModel = new User();
    this.roles = new Array<Role>();
    this.nav.show();
  }

  private async getUserDetails() {
    const userResponse = await this.usersService.getUser(this.userId);
    this.userModel = userResponse.data.user;
  }

  private async getRoles() {
    const roleResponse = await this.rolesService.getAllRoles();
    this.roles = roleResponse.data.roles;
  }

  createUser() {
    var response = this.usersService.createUser(this.userModel);
    console.log(response);
    
    //location.reload();
  }

  editUser() {
    this.usersService.updateUser(this.userModel);
    location.reload();
  }

  isEmpty(value: number): boolean {
    if (value > 0) {
      this.selectItemsIsEmpty = true;
    }
    else {
      this.selectItemsIsEmpty = false;
    }
    return this.selectItemsIsEmpty;
  }

  setSubmitted() {
    this.submitted = true;
  }
}
