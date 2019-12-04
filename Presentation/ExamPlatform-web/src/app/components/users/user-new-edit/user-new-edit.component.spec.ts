import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserNewEditComponent } from './user-new-edit.component';

describe('NewUserComponent', () => {
  let component: UserNewEditComponent;
  let fixture: ComponentFixture<UserNewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserNewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserNewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
