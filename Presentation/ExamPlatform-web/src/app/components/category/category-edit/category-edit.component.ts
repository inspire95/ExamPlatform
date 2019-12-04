import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { CategoryType } from '../../../models/CategoryType';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { NavbarService } from '../../../services/navbar.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})

export class CategoryEditComponent implements OnInit {

  categoryTypeId: string;
  categoryModel: CategoryType;
  submitted: boolean;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
   private categoryService: CategoryTypeService,
    public nav: NavbarService) {
    this.categoryTypeId = data.categoryTypeId;
    this.getCategoryDetails();
  }

  ngOnInit() {
    this.categoryModel = new CategoryType();
    this.nav.show();
    this.submitted = false;
  }

  private async getCategoryDetails() {
    const categoryResponse = await this.categoryService.getCategory(this.categoryTypeId);
    this.categoryModel = categoryResponse.data.categoryType;
  }

  private async UpdateCategory() {
    await this.categoryService.updateCategory(this.categoryModel);
    
  }
  
  onEditClick() {
    this.UpdateCategory();
    location.reload();
  }

  setSubmitted() {
    this.submitted = true;
  }
}