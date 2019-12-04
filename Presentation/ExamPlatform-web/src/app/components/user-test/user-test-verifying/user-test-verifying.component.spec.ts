import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTestVerifyingComponent } from './user-test-verifying.component';

describe('UserTestVerifyingComponent', () => {
  let component: UserTestVerifyingComponent;
  let fixture: ComponentFixture<UserTestVerifyingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserTestVerifyingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserTestVerifyingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
