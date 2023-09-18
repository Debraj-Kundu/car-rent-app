import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RentedCar } from '../Interface/RentedCar.interface';
import { LoginService } from './login.service';
import { environment } from 'src/environments/environment';
import { UserStoreService } from './user-store.service';
import { RentalAgreement } from '../Interface/RentalAgreement.interface';

@Injectable({
  providedIn: 'root'
})
export class BookCarService {
  id!: string;
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
  getRentedCars(): Observable<RentedCar[]> {
    this.getUserId();
    return this.http.get<RentedCar[]>(`${this.apiurl}/${this.id}`);
  }
  bookCar(order:RentalAgreement){
    this.getUserId();
    console.log(this.id);
    order.userId = +this.id;
    return this.http.post(this.apiurl, order);
  }
}
