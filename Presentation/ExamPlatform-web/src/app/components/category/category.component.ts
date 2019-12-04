import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialog, MatDialogRef, MatTab } from '@angular/material';
import { CategoryType } from '../../models/CategoryType';
import { CategoryTypeService } from '../../services/categorytypes.service';
import { CategoryNewComponent } from './category-new/category-new.component';
import { CategoryDeleteComponent } from './category-delete/category-delete.component';
import { CategoryEditComponent } from './category-edit/category-edit.component';
import { NavbarService } from '../../services/navbar.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  displayedColumns: string[] = ['name', 'actions'];
  categoryList = new MatTableDataSource<CategoryType>();
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  categories: Array<CategoryType>;

  constructor(private catTypesService: CategoryTypeService,
    public dialog: MatDialog,
    public nav: NavbarService) {
  }

  ngOnInit() {
    this.categories = new Array<CategoryType>();
    this.categoryList = new MatTableDataSource<CategoryType>();
    this.getCategoryTypesList();
    this.nav.show();
  }

  private async getCategoryTypesList() {
    const categoryResponse = await this.catTypesService.getAllCategoryTypes();
    this.categories = categoryResponse.data.categoryTypes;
    this.categoryList = new MatTableDataSource<CategoryType>(this.categories);
    this.categoryList.paginator = this.paginator
  }

  onNewCategoryClick() {
    this.dialog.open(CategoryNewComponent, { 
      height: "34%",
      width : "25%"
    });
  }

  onEditClick(categoryTypeId: string) {
    this.dialog.open(CategoryEditComponent, {
      height: "34%",
      width : "25%",
      data: { categoryTypeId: categoryTypeId }
    });
  }

  onDeleteClick(categoryTypeId: string) {
    this.dialog.open(CategoryDeleteComponent, {
      height: "45%",
      width : "40%",
      data: { categoryTypeId: categoryTypeId }
    });
  }
}