import { ProductAttribute } from "./../../Models/ProductAttribute";
import { ProductCategory } from "./../../Models/Product";
import { ProductCategoryService } from "./../../Services/product-category.service";
import { Component, OnInit } from "@angular/core";
import { ProductDetail } from "src/app/Models/product";
import { ProductService } from "src/app/Services/product.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-product-create",
  templateUrl: "./product-create.component.html",
  styleUrls: ["./product-create.component.css"],
})
export class ProductCreateComponent implements OnInit {
  product: ProductDetail = new ProductDetail();
  categories: ProductCategory[];
  productId: any;
  submitted = false;
  selectedcategoryId: number;

  constructor(
    private productService: ProductService,
    private categoryService: ProductCategoryService,
    private router: Router
  ) {}

  ngOnInit() {
    this.product.ProductAttributesDto = [];
    this.getCategories();
  }

  save() {
    this.productService.createProduct(this.product).subscribe(
      (data) => {
        console.log(data), this.gotoList();
      },
      (error) => console.log(error)
    );
    this.product = null;
  }

  submitProduct() {
    this.submitted = true;
    this.save();
  }
  gotoList() {
    this.router.navigate(["/products/getall"]);
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((c) => {
      this.categories = c;
      this.selectedcategoryId = this.categories[0].ProdCatId;
    });
  }
  setCategory(categoryId) {
    var category = new ProductCategory();
    category.CategoryName = this.categories.find(
      (s) => s.ProdCatId == parseInt(categoryId)
    ).CategoryName;
    category.ProdCatId = parseInt(categoryId);
    ;

    this.product.ProductCategory = category;
    this.selectedcategoryId = categoryId;
  }

  addAttribute() {
    this.product.ProductAttributesDto.push({
      AttributeId: 0,
      AttributeName: "",
      AttributeValue: "",
      ProductId: parseFloat(this.productId),
    });
  }

  removeAttribute(index: number) {
    this.product.ProductAttributesDto.splice(index, 1);
  }

  getAttributes() {
    this.productService
      .getAttributesByCategory(this.selectedcategoryId)
      .subscribe((d) => {
        console.log("attributes", d);
      });
  }
}
