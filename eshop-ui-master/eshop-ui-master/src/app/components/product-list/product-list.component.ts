import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { NewProduct } from '../../models/new-product';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[];
  errorMessage: string;

  constructor(private productService: ProductService, private router: Router) { }

  // Lifecycle hook that is called after data-bound properties of a component are initialized.
  // Read more: https://angular.io/guide/lifecycle-hooks
  ngOnInit() {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
    }, error => {
      console.error(error);
      this.errorMessage = error.message;
    });
  }

  onAddButtonClick(product: NewProduct) {
    console.log(product);
    this.productService.addProduct(product).subscribe(savedProduct => {
      console.log(savedProduct);
      this.products.push(savedProduct);
    });
  }

  onProductRowClick(product: Product) {
    this.router.navigate(['products', product.id]);
  }

}
