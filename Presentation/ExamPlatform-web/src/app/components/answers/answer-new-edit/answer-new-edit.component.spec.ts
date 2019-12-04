import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnswerNewEditComponent } from './answer-new-edit.component';

describe('AnswerNewEditComponent', () => {
  let component: AnswerNewEditComponent;
  let fixture: ComponentFixture<AnswerNewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnswerNewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnswerNewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
