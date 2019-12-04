import { Component, OnInit } from '@angular/core';
import { CategoryType } from '../../../models/CategoryType';
import { CategoryTypeService } from '../../../services/categorytypes.service';
import { NavbarService } from '../../../services/navbar.service';

@Component({
  selector: 'app-category-new',
  templateUrl: './category-new.component.html',
  styleUrls: ['./category-new.component.css']
})
export class CategoryNewComponent implements OnInit {

  categoryModel: CategoryType;
  submitted: boolean;

  constructor(private categoryService: CategoryTypeService,
    public nav: NavbarService) { }

  ngOnInit() {
    this.categoryModel = new CategoryType();
    this.categoryModel.name = "";
    this.nav.show();
    this.submitted = false;
  }

  private async createCategory() {
    await this.categoryService.createCategory(this.categoryModel);
  }

  onAddClick() {
    this.createCategory();    
    location.reload();
  }

  setSubmitted() {
    this.submitted = true;
  }
}
