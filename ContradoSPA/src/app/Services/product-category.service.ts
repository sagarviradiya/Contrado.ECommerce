import { environment } from "./../../environments/environment";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ProductCategoryService {
  constructor(private http: HttpClient) {}

  getCategories(): Observable<any> {
    return this.http.get(environment.apiUrl + "productcategories");
  }


}
