import { ProductCreateComponent } from "./Pages/product-create/product-create.component";
import { ProductEditComponent } from "./Pages/product-edit/product-edit.component";
import { ProductListComponent } from "./Pages/product-list/product-list.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  { path: "", redirectTo: "products", pathMatch: "full" },
  { path: "products", component: ProductListComponent },
  { path: "products/create", component: ProductCreateComponent },
  { path: "products/details/:id", component: ProductEditComponent },
  { path: "**", redirectTo: "products", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
