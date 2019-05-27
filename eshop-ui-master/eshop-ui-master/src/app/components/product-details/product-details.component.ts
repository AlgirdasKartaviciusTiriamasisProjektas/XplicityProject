import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';

import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  product: Product;

  constructor(private route: ActivatedRoute, private router: Router,
     private productService: ProductService) { }

  ngOnInit() {
    this.route.paramMap.pipe( // combines observable functions
      switchMap((params: ParamMap) => { // cancels previous requests
                                        // emits Product observable when parameter map changes
        const id = params.get('id'); // gets id parameter from route parameter array
        return this.productService.getProduct(id); // returns Observable<Product>
      }
    )).subscribe(product => { // subscription to observable
      this.product = product; // assign product we get from observable to the class' variable
    });
  }

  onBackButtonClick() {
    this.router.navigate(['products']);
  }

}
