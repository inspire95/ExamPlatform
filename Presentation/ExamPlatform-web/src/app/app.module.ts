import {
  MatAutocompleteModule,
  MatButtonModule,
  MatCardModule,
  MatChipsModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatPaginatorModule,
  MatSelectModule,
  MatRadioModule,
  MatSidenavModule,
  MatSortModule,
  MatTableModule,
  MatToolbarModule

} from '@angular/material';
import { ClipboardModule } from 'ngx-clipboard';
import { LayoutModule } from '@angular/cdk/layout';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatCheckboxModule, MAT_CHECKBOX_CLICK_ACTION } from '@angular/material/checkbox';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { MyDashComponent } from './components/dashboard/my-dash.component';
import { LoginComponent } from './components/login/login.component';
import { MyNavComponent } from './components/nav/my-nav.component';
import { TestGenComponent } from './components/tests/test-gen/test-gen.component';
import { TestNewComponent } from './components/tests/test-new/test-new.component';
import { TestComponent } from './components/tests/test.component';
import { UserDeleteComponent } from './components/users/user-delete/user-delete.component';
import { TestDeleteComponent } from './components/tests/test-delete/test-delete.component';
import { TestEditComponent } from './components/tests/test-edit/test-edit.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { BaseService } from './services/base.service';
import { QuestionNewEditComponent } from './components/questions/question-new-edit/question-new-edit.component'
import { QuestionDetailsComponent } from './components/questions/question-details/question-details.component';
import { UserDetailsComponent } from './components/users/user-details/user-details.component';
import { UserNewEditComponent } from './components/users/user-new-edit/user-new-edit.component';
import { UsersComponent } from './components/users/users.component';
import { AttachmentsComponent } from './components/attachments/attachments.component';
import { CategoryComponent } from './components/category/category.component';
import { CategoryNewComponent } from './components/category/category-new/category-new.component';
import { CategoryDeleteComponent } from './components/category/category-delete/category-delete.component';
import { CategoryEditComponent } from './components/category/category-edit/category-edit.component';
import { AnswerNewEditComponent } from './components/answers/answer-new-edit/answer-new-edit.component';
import { AnswerDeleteComponent } from './components/answers/answer-delete/answer-delete.component';
import { TestDetailsComponent } from './components/tests/test-details/test-details.component';
import { QuestionDeleteComponent } from './components/questions/question-delete/question-delete.component';
import { UserTestComponent } from './components/user-test/user-test.component';
import { NavbarService } from './services/navbar.service';
import { AuthGuard } from './config/auth';
import { AuthInterceptor } from './config/auth.interceptor';
import { AccountService } from './services/account.service';
import { UserTestVerifyingComponent } from './components/user-test/user-test-verifying/user-test-verifying.component';
import { UserTestDetailsComponent } from './components/user-test/user-test-details/user-test-details.component';
import { AlertsModule } from 'angular-alert-module';

const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'home', component: MyDashComponent },
  { path: 'tests', component: TestComponent },
  { path: 'test-new', component: TestNewComponent },
  { path: 'test-gen', component: TestGenComponent },
  { path: 'users', component: UsersComponent },
  { path: 'user-details/:userId', component: UserDetailsComponent },
  { path: 'user-delete:/userId', component: UserDeleteComponent },
  { path: 'question-edit/:id', component: QuestionNewEditComponent },
  { path: 'question-new', component: QuestionNewEditComponent },
  { path: 'questions', component: QuestionsComponent },
  { path: 'question-details/:id', component: QuestionDetailsComponent },
  { path: 'test-edit/:testId', component: TestEditComponent },
  { path: 'test-details/:testId', component: TestDetailsComponent },
  { path: 'test-delete/:id', component: TestDeleteComponent },
  { path: 'user-edit', component: UserNewEditComponent },
  { path: 'attachments', component: AttachmentsComponent },
  { path: 'answer', component: AnswerNewEditComponent },
  { path: 'answer-delete', component: AnswerDeleteComponent },
  { path: 'question-delete', component: QuestionDeleteComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'category-new', component: CategoryNewComponent },
  { path: 'category-delete', component: CategoryDeleteComponent },
  { path: 'category-edit', component: CategoryEditComponent },
  { path: 'answer-new-edit', component: AnswerNewEditComponent },
  { path: 'user-test/:id', component: UserTestComponent },
  { path: 'user-test-verifying', component: UserTestVerifyingComponent },
  { path: 'user-test-details/:userTestId', component: UserTestDetailsComponent }
]

@NgModule({
  declarations: [
    MyDashComponent,
    LoginComponent,
    TestComponent,
    TestNewComponent,
    UsersComponent,
    UserNewEditComponent,
    UserDetailsComponent,
    TestEditComponent,
    TestDeleteComponent,
    QuestionsComponent,
    QuestionNewEditComponent,
    QuestionDetailsComponent,
    UserDeleteComponent,
    AppComponent,
    MyNavComponent,
    TestGenComponent,
    AttachmentsComponent,
    CategoryComponent,
    CategoryNewComponent,
    CategoryDeleteComponent,
    CategoryEditComponent,
    AnswerNewEditComponent,
    AnswerDeleteComponent,
    TestDetailsComponent,
    QuestionDeleteComponent,
    UserTestComponent,
    UserTestVerifyingComponent,
    UserTestDetailsComponent

  ],

  providers: [
    { provide: MAT_CHECKBOX_CLICK_ACTION, useValue: 'check' },
    BaseService,
    NavbarService,
    AccountService,
    AuthGuard, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],

  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    LayoutModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    RouterModule.forRoot(appRoutes),
    HttpModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    ReactiveFormsModule,
    MatDialogModule,
    FormsModule,
    MatAutocompleteModule,
    MatChipsModule,
    HttpClientModule,
    MatCheckboxModule,
    MatRadioModule,
    ClipboardModule,
    AlertsModule.forRoot()

  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
