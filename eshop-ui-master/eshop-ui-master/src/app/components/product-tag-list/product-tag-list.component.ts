import { Component, Input, OnInit } from '@angular/core';

import { Product } from '../../models/product';

@Component({
  selector: 'app-product-tag-list',
  templateUrl: './product-tag-list.component.html',
  styleUrls: ['./product-tag-list.component.css']
})
export class ProductTagListComponent implements OnInit {

  @Input()
  product: Product;

  constructor() { }

  ngOnInit() {
  }

}
