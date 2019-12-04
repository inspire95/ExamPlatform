import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent } from '@angular/material';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CategoryType } from '../../../models/CategoryType';
import { Test } from '../../../models/Test';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { TestsService } from '../../../services/tests.service';
import { NavbarService } from 'src/app/services/navbar.service';

@Component({
  selector: 'app-test-new',
  templateUrl: './test-new.component.html',
  styleUrls: ['./test-new.component.css']
})
export class TestNewComponent implements OnInit {

  nameFormValidator = new FormControl('', [Validators.required]);
  categoryCtrl = new FormControl();

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  submitted = false;

  testModel: Test = new Test();
  catIds: number[] = [];
  separatorKeysCodes: number[] = [ENTER, COMMA];

  @ViewChild('categoryInput') categoryInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;


  categoryTypes: Array<CategoryType> = [];
  filteredCategories: Observable<CategoryType[]> = new Observable<CategoryType[]>();
  selectedCategories: Array<CategoryType> = [];

  constructor(private categoryTypeService: CategoryTypeService, private testService: TestsService, public nav: NavbarService) {

    this.categoryTypes = new Array<CategoryType>();
    this.filteredCategories =
      this.categoryCtrl.valueChanges.pipe(
        startWith(null),
        map((category: CategoryType | null) => category ? this._filter(this.categoryCtrl.value) : this.categoryTypes.slice()))
  }

  ngOnInit() {
    this.getCategoryTypesList();
    this.nav.show();
  }


  private async getCategoryTypesList() {
    const categoryTypeResponse = await this.categoryTypeService.getAllCategoryTypes();
    this.categoryTypes = categoryTypeResponse.data.categoryTypes;
  }

  add(event: MatChipInputEvent): void {
    if (!this.matAutocomplete.isOpen) {
      const input = event.input;
      const value = event.value;


      if ((value || '').trim()) {
        for (var i = 0; i < this.categoryTypes.length; i++) {
          if (value.trim() == this.categoryTypes[i].name) {
            this.selectedCategories.push(this.categoryTypes[i]);

            this.categoryTypes.splice(i, 1);
          }
        }
      }
      if (input) { input.value = ''; }
      this.categoryCtrl.setValue(null);
    }
  }

  remove(category: CategoryType): void {
    const index = this.selectedCategories.indexOf(category);
    if (index >= 0) {
      this.selectedCategories.splice(index, 1);
      this.categoryTypes.push(category);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    const index = this.categoryTypes.indexOf(event.option.value);
    this.categoryTypes.splice(index, 1);
    this.selectedCategories.push(event.option.value);
  }

  private _filter(value: string): Array<CategoryType> {
    var filterValue = '' + value;
    return this.categoryTypes.filter(category => category.name.toLowerCase().indexOf(filterValue.toLowerCase()) === 0);
  }

  private addTest() {
    this.testModel.testCategories = this.selectedCategories;
    this.testService.createTest(this.testModel);
    location.reload();
  }

  setSubmitted() {
    this.submitted = true;
  }
}