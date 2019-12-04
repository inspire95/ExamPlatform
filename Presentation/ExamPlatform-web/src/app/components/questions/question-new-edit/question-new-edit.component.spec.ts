import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { QuestionNewEditComponent } from './question-new-edit.component';

describe('QuestionNewEditComponent', () => {
  let component: QuestionNewEditComponent;
  let fixture: ComponentFixture<QuestionNewEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionNewEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionNewEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
