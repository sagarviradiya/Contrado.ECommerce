import { environment } from "./../../environments/environment";
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ProductService {
  constructor(private http: HttpClient) {}

  getProducts(): Observable<any> {
    return this.http.get(environment.apiUrl + "products/getall");
  }
  getByProductId(productId): Observable<any> {
    return this.http.get(environment.apiUrl + "products/" + productId);
  }

  createProduct(product: any) {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Accept', 'application/json')
    return this.http.post(
      environment.apiUrl + "products/createproduct",
      product, headers
    );
  }
  updateProduct(productId: number, product: any): Observable<any> {
    return this.http.put(
      environment.apiUrl + "products/updateproduct/" + productId,
      product
    );
  }
  getAttributesByCategory(categoryId: number): Observable<any> {
    return this.http.get(
      environment.apiUrl + "products/productattributes/" + categoryId
    );
  }
}
