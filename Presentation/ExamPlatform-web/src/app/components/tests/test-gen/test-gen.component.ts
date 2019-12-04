import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { CategoryType } from '../../../models/CategoryType'
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent } from '@angular/material';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { NavbarService } from '../../../services/navbar.service';
import { TestsService } from '../../../services/tests.service';
import { CategoryTypeService } from '../../../services/categorytypes.service'
import { GeneratedTest } from 'src/app/models/GeneratedTest';
import { Test } from 'src/app/models/Test';

@Component({
  selector: 'test-gen',
  templateUrl: './test-gen.component.html',
  styleUrls: ['./test-gen.component.css']
})

export class TestGenComponent implements OnInit {

  nameFormValidator = new FormControl('', [Validators.required]);
  categoryCtrl = new FormControl();

  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  submitted = false;
  testModel: GeneratedTest = new GeneratedTest;
  catIds: number[] = [];
  myForm:number;
  separatorKeysCodes: number[] = [ENTER, COMMA];

  @ViewChild('categoryInput') categoryInput: ElementRef<HTMLInputElement>;
  @ViewChild('auto') matAutocomplete: MatAutocomplete;

  categoryTypes: Array<CategoryType>;
  filteredCategories: Observable<CategoryType[]> = new Observable<CategoryType[]>();
  selectedCategories: Array<CategoryType>;
  constructor(
    private categoryTypeService: CategoryTypeService, private testService: TestsService, public nav: NavbarService) {
    this.categoryTypes = new Array<CategoryType>();
    this.filteredCategories =
      this.categoryCtrl.valueChanges.pipe(
        startWith(null),
        map((category: CategoryType | null) => category ? this._filter(this.categoryCtrl.value) : this.categoryTypes.slice()));
  }

  ngOnInit(): void {
    this.selectedCategories= new Array<CategoryType>();
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
    console.log(event.option.value);
    this.selectedCategories.push(event.option.value);
    console.log(this.selectedCategories);
  }

  private _filter(value: string): Array<CategoryType> {
    var filterValue = '' + value;
    return this.categoryTypes.filter(category => category.name.toLowerCase().indexOf(filterValue.toLowerCase()) === 0);
  }

  addTest() {
    this.testModel.testCategories = this.selectedCategories;
    this.testService.generateTest(this.testModel);
    location.reload();
  }

  setSubmitted() {
    this.submitted = true;
  }
}