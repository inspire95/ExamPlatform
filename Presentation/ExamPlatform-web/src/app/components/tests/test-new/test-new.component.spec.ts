import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestNewComponent } from './test-new.component';

describe('TestNewComponent', () => {
  let component: TestNewComponent;
  let fixture: ComponentFixture<TestNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
