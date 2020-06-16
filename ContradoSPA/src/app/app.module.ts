import { ProductCategoryService } from "./Services/product-category.service";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ProductListComponent } from "./Pages/product-list/product-list.component";
import { ProductCreateComponent } from "./Pages/product-create/product-create.component";
import { ProductEditComponent } from "./Pages/product-edit/product-edit.component";
import { ProductService } from "./Services/product.service";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductCreateComponent,
    ProductEditComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [ProductService, ProductCategoryService],
  bootstrap: [AppComponent],
})
export class AppModule {}
