import { Component, OnInit } from '@angular/core';
import { NavbarService} from '../../services/navbar.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { NgForm } from '@angular/forms/src/directives/ng_form';
import { AccountService } from '../../services/account.service';
import { User } from '../../models/User';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Account } from 'src/app/models/Account';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccountService]
})
export class LoginComponent implements OnInit {
    
    

    constructor(
        private accountService : AccountService, 
        public nav: NavbarService,
        private router : Router
    ) {
    }
    data:any;

     ngOnInit() {
        this.accountService.selectedUser = {
          username: '',  
          password: ''
        }
         this.nav.hide()
      }
    
      onSubmit(form : NgForm){
        this.accountService.userAuthentication(form.value).subscribe((data : any) => {
          localStorage.setItem('userToken', data.token);
          this.router.navigate(['/home'])
        });
      }
    
    }
    
    
    