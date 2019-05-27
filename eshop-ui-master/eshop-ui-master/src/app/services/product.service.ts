import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { NewProduct } from '../models/new-product';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly productsApi = `${environment.webApiUrl}/products`;

  private readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productsApi);
  }

  getProduct(productId: string): Observable<Product> {
    return this.http.get<Product>(`${this.productsApi}/${productId}`);
  }

  addProduct(product: NewProduct): Observable<Product> {
    return this.http.post<Product>(this.productsApi, product, this.httpOptions);
  }

}
