export class Product {
  ProductId: number;
  ProdCatId: number;
  ProdName: string;
  ProdDescription: string;
  ProductCategory: ProductCategory;
}

export class ProductDetail {
  ProductId: number;
  ProdCatId: number;
  ProdName: string;
  ProdDescription: string;
  ProductCategory: ProductCategory;
  ProductAttributesDto: ProductAttribute[];
}

export class ProductCategory {
  ProdCatId: number;
  CategoryName: string;
}
export class ProductAttribute {
  ProductId: number;
  AttributeId: number;
  AttributeName: string;
  AttributeValue: string;
}
