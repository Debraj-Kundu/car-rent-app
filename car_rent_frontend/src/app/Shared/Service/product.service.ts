import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Car } from '../Interface/Car.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private http: HttpClient) {}
  apiurl = `${environment.baseurl}/car`;

  getAllProducts(): Observable<Car[]> {
    return this.http.get<Car[]>(this.apiurl);
  }
  getProductById(id: string | null): Observable<Car> {
    return this.http.get<Car>(`${this.apiurl}/${id}`);
  }
  deleteProduct(id: string) {
    return this.http.delete(`${this.apiurl}/${id}`);
  }
  postProduct(product: Car) {
    let formData = new FormData();
    formData.append("maker", product.maker);
    formData.append("model", product.model);
    formData.append("rentalPrice", ''+product.rentalPrice);
    formData.append("availableStatus", ''+product.availabilityStatus);
    formData.append("carImage", product.carImage);
    formData.append("imageFile", product.imageFile??"");

    return this.http.post(this.apiurl, formData);
  }

  updateProduct(id: string, product: Car) {
    let formData = new FormData();
    formData.append("id", ''+product.id);
    formData.append("maker", product.maker);
    formData.append("model", product.model);
    formData.append("rentalPrice", ''+product.rentalPrice);
    formData.append("availableStatus", ''+product.availabilityStatus);
    formData.append("carImage", product.carImage);
    formData.append("imageFile", product.imageFile??"");
    return this.http.put(`${this.apiurl}/${id}`, formData);
  }
}
