import { Component, OnInit, Inject } from '@angular/core';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { MAT_DIALOG_DATA } from '@angular/material';
import { CategoryType } from '../../../models/CategoryType';
import { NavbarService } from '../../../services/navbar.service';

@Component({
  selector: 'app-category-delete',
  templateUrl: './category-delete.component.html',
  styleUrls: ['./category-delete.component.css']
})

export class CategoryDeleteComponent implements OnInit {

  categoryTypeId: string;
  categoryModel: CategoryType

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private categoryService: CategoryTypeService,
    public nav: NavbarService) {

    this.categoryTypeId = data.categoryTypeId;
    this.getCategoryDetails();
  }

  ngOnInit() {
    this.categoryModel = new CategoryType();
    this.nav.show();
  }

  onYesClick() {
    this.deleteCategory();
    location.reload();
  }
  
  private async getCategoryDetails() {
    const categoryResponse = await this.categoryService.getCategory(this.categoryTypeId);
    this.categoryModel = categoryResponse.data.categoryType
  }

  private async deleteCategory() {
    await this.categoryService.deleteCategory(this.categoryTypeId);
  }
}