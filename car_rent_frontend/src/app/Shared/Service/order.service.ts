import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RentedCar } from '../Interface/RentedCar.interface';
import { LoginService } from './login.service';
import { UserStoreService } from './user-store.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  id!: string;
  constructor(
    private http: HttpClient,
    private loginService: LoginService,
    private userStore: UserStoreService
  ) {}
  apiurl = `${environment.baseurl}/order`;

  private getUserId() {
    const nameFormToken = this.loginService.getIdFromToken();
    this.userStore.getIdFormStore().subscribe((val) => {
      this.id = val || nameFormToken;
    });
  }

  getOrder(): Observable<RentedCar[]> {
    this.getUserId();
    return this.http.get<RentedCar[]>(`${this.apiurl}/${this.id}`);
  }

  postOrder(order:any){
    return this.http.post(this.apiurl, order);
  }
}
