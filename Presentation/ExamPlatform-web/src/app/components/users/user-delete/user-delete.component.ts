import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { UsersService } from '../../../services/users.service';
import { User } from 'src/app/models/User';
import { NavbarService} from '../../../services/navbar.service';

@Component({
  selector: 'app-user-delete',
  templateUrl: './user-delete.component.html',
  styleUrls: ['./user-delete.component.css']
})
export class UserDeleteComponent implements OnInit {

  userId: string;
  user: User;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private usersService: UsersService, public nav: NavbarService) {
    this.userId = data.userId;
    this.getUserDetails();
  }

  ngOnInit() {
    this.user = new User();
    this.nav.show();
  }

  onYesClick() {
    this.deleteUser();
    location.reload();
  }

  private async getUserDetails() {
    const userResponse = await this.usersService.getUser(this.userId);
    this.user = userResponse.data.user;
  }

  private async deleteUser() {
    await this.usersService.deleteUser(this.userId);
  }
}
