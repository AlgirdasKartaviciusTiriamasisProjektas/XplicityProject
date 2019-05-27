import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { NewProduct } from '../../models/new-product';
import { Product } from '../../models/product';
import { ProductCategory } from '../../models/product-category.enum';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-product-input',
  templateUrl: './product-input.component.html',
  styleUrls: ['./product-input.component.css']
})
export class ProductInputComponent implements OnInit {

  // output will be acccessible through: <app-procuct-input (addButtonClick)="someListenerMethod($event)">
  @Output()
  addButtonClick = new EventEmitter<NewProduct>();

  product: NewProduct = new Product(); // data-bound object

  categoryEnum = ProductCategory; // workaround to access ProductCategory emum in the template

  constructor() {
    this.product.category = ProductCategory.NotSpecified;
  }

  ngOnInit() {
  }

  onAddButtonClick() {
    this.addButtonClick.emit(this.product);
  }

  onSubmit(form: NgForm) {
    form.resetForm();
    this.product.category = ProductCategory.NotSpecified;
  }

}
