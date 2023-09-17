import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RentalAgreement } from '../Interface/RentalAgreement.interface';
import { LoginService } from './login.service';
import { UserStoreService } from './user-store.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  id!: string;
  constructor(
    private http: HttpClient,
    private loginService: LoginService,
    private userStore: UserStoreService
  ) {}
  apiurl = `${environment.baseurl}/cart`;

  private getUserId() {
    const nameFormToken = this.loginService.getIdFromToken();
    this.userStore.getIdFormStore().subscribe((val) => {
      this.id = val || nameFormToken;
    });
  }

  getCart(): Observable<RentalAgreement[]> {
    this.getUserId();
    return this.http.get<RentalAgreement[]>(`${this.apiurl}/${this.id}`);
  }
  postCart(cart: any) {
    return this.http.post(this.apiurl, cart);
  }
  deleteCartItem(id: number) {
    return this.http.delete(`${this.apiurl}/${id}`);
  }
}
