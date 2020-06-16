import { ProductCategory } from "./../../Models/Product";
import { ProductCategoryService } from "./../../Services/product-category.service";
import { Component, OnInit } from "@angular/core";
import { ProductDetail } from "src/app/Models/product";
import { ProductService } from "src/app/Services/product.service";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs";

@Component({
  selector: "app-product-edit",
  templateUrl: "./product-edit.component.html",
  styleUrls: ["./product-edit.component.css"],
})
export class ProductEditComponent implements OnInit {
  product: ProductDetail = new ProductDetail();
  categories: ProductCategory[];
  productId: any;
  submitted = false;
  selectedcategoryId: number;

  constructor(
    private productService: ProductService,
    private activatedRoute: ActivatedRoute,
    private categoryService: ProductCategoryService,
    private router: Router
  ) {}

  ngOnInit() {
    this.activatedRoute.paramMap.subscribe(
      (p) => (this.productId = p.get("id"))
    );

    this.editProduct();
    this.getCategories();
  }
  editProduct() {
    this.productService.getByProductId(this.productId).subscribe(
      (product) => {
        this.product = product;
      },
      (error) => console.log(error)
    );
  }
  save() {
    this.productService.updateProduct(this.productId, this.product).subscribe(
      (data) => {
        console.log(data), this.gotoList();
      },
      (error) => console.log(error)
    );
    this.product = null;
  }

  updateProduct() {
    this.submitted = true;
    this.save();
  }
  gotoList() {
    this.router.navigate(["/products/getall"]);
  }

  getCategories() {
    this.categoryService.getCategories().subscribe((c) => {
      this.categories = c;
    });
  }
  setCategory(categoryId) {
    var category = new ProductCategory();
    category.CategoryName = this.categories.find(
      (s) => s.ProdCatId == parseInt(categoryId)
    ).CategoryName;
    category.ProdCatId = parseInt(categoryId);
    this.product.ProductCategory = category;
    this.selectedcategoryId = categoryId;
    this.getAttributes();
  }
  get diagnostic() {
    return JSON.stringify(this.product);
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
