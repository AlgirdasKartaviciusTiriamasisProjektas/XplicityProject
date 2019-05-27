import { ProductCategory } from './product-category.enum';

export class NewProduct {
  title: string;
  description: string;
  price: number;
  quantity: number;
  category: ProductCategory;
}
