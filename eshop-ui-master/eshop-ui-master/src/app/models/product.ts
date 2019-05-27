import { NewProduct } from './new-product';
import { Tag } from './tag';

export class Product extends NewProduct {
  id: number;
  lastModified: Date;
  created: Date;
  tags: Tag[];
}
