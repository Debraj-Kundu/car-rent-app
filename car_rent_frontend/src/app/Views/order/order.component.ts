import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable, Subscription } from 'rxjs';
import { RentedCar } from 'src/app/Shared/Interface/RentedCar.interface';
import { MatCardModule } from '@angular/material/card';
import { RentedCarService } from 'src/app/Shared/Service/rented-car.service';
import { MatButtonModule } from '@angular/material/button';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
import { ToastService } from 'src/app/Shared/Service/toast.service';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule],
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent implements OnInit, OnDestroy {
  imageBaseUrl = 'http://localhost:5253/resources/';
  isLoggedIn: boolean = false;
  private subscription: Subscription = new Subscription();
  role$: Observable<string> = this.userStore.getRoleFormStore();

  constructor(
    private rentedCarService: RentedCarService,
    private loginService: LoginService,
    private userStore: UserStoreService,
    private toast: ToastService
  ) {}
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
  ngOnInit() {
    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.isLoggedIn = this.loginService.isLoggedIn();
      })
    );
  }
  orderList$: Observable<RentedCar[]> = this.rentedCarService.getRentedCars();
  return() {}
}
