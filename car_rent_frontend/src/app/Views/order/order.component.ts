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
import { Router } from '@angular/router';

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
  role!: string;

  constructor(
    private rentedCarService: RentedCarService,
    private loginService: LoginService,
    private userStore: UserStoreService,
    private toast: ToastService,
    private router:Router,
  ) {}

  ngOnInit() {
    const roleFormToken = this.loginService.getRoleFromToken();
    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.isLoggedIn = this.loginService.isLoggedIn();
        this.userStore.getRoleFormStore().subscribe((val) => {
          this.role = val || roleFormToken;
        });
      })
    );
  }
  orderList$: Observable<RentedCar[]> = this.rentedCarService.getRentedCars();
  applyReturn(id: number) {
    let item: RentedCar;
    this.subscription.add(
      this.orderList$.subscribe((list: RentedCar[]) => {
        item = list.filter((car) => car.id === id)[0];
        item.appliedForReturn = true;
        console.log(item);
        
        this.rentedCarService.updateCar(item).subscribe({
          next: (res) => {
            this.orderList$ = this.rentedCarService.getRentedCars();
            this.toast.successToast('Applied for return!');
          },
          error: (err) => {
            this.toast.errorToast('Error occured retry!');
          },
        });
      })
    );
  }
  acceptReturn(id: number) {
    this.subscription.add(
      this.rentedCarService.deleteCartItem(id).subscribe({
        next: (res) => {
          this.orderList$ = this.rentedCarService.getRentedCars();
          this.toast.successToast('Successfully returned!');
        },
        error: (err) => {
          this.toast.errorToast('Error occured retry!');
        },
      })
    );
  }
  editReturn(car: any) {
    localStorage.setItem('rented-car', JSON.stringify(car));
    this.router.navigate(['edit-agreement']);
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
