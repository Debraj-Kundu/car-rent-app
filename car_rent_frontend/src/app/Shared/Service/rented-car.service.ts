import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginService } from './login.service';
import { UserStoreService } from './user-store.service';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RentedCar } from '../Interface/RentedCar.interface';

@Injectable({
  providedIn: 'root',
})
export class RentedCarService {
  id!: string;
  role!: string;
  constructor(
    private http: HttpClient,
    private loginService: LoginService,
    private userStore: UserStoreService
  ) {}
  apiurl = `${environment.baseurl}/rentcar`;

  private getUserId() {
    const nameFormToken = this.loginService.getIdFromToken();
    this.userStore.getIdFormStore().subscribe((val) => {
      this.id = val || nameFormToken;
    });
  }

  private getUserRole() {
    const roleFromToken = this.loginService.getRoleFromToken();
    this.userStore.getRoleFormStore().subscribe((val) => {
      this.role = val || roleFromToken;
    });
  }

  getRentedCars(): Observable<RentedCar[]> {
    this.getUserId();
    this.getUserRole();
    if (this.role === 'Admin')
      return this.http.get<RentedCar[]>(`${this.apiurl}`);
    return this.http.get<RentedCar[]>(`${this.apiurl}/getbyuserid/${this.id}`);
  }
  updateCar(car: any) {
    console.log(car);
    
    return this.http.put(`${this.apiurl}/${car.id}`, car);
  }
  deleteCartItem(id: number) {
    return this.http.delete(`${this.apiurl}/${id}`);
  }
}
