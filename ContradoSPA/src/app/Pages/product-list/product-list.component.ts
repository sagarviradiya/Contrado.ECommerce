import { ProductService } from "./../../Services/product.service";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { Product } from "src/app/Models/product";

@Component({
  selector: "app-product-list",
  templateUrl: "./product-list.component.html",
  styleUrls: ["./product-list.component.css"],
})
export class ProductListComponent implements OnInit {
  products: Observable<Product[]>;

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.products = this.productService.getProducts();
  }
  editProduct(productId: number) {
    this.router.navigate(["products/details", productId]);
  }
  createProduct() {
    this.router.navigate(["products/create"]);
  }
}
