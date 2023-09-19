// import { Component, OnDestroy, OnInit } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import { ProductService } from 'src/app/Shared/Service/product.service';
// import { LoginService } from 'src/app/Shared/Service/login.service';
// import { ActivatedRoute, Router } from '@angular/router';
// import { Observable, Subscription, map } from 'rxjs';
// import { Car } from 'src/app/Shared/Interface/Car.interface';
// import { MatCardModule } from '@angular/material/card';
// import { CartService } from 'src/app/Shared/Service/cart.service';
// import { MatIconModule } from '@angular/material/icon';
// import { MatButtonModule } from '@angular/material/button';
// import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
// import { ToastService } from 'src/app/Shared/Service/toast.service';
// import {
//   FormBuilder,
//   FormControl,
//   FormGroup,
//   FormsModule,
//   ReactiveFormsModule,
// } from '@angular/forms';
// import { MatFormFieldModule } from '@angular/material/form-field';
// import { MatInputModule } from '@angular/material/input';

// const matModules = [
//   MatFormFieldModule,
//   MatInputModule,
//   MatCardModule,
//   MatIconModule,
//   MatButtonModule,
// ];

// @Component({
//   selector: 'app-product',
//   standalone: true,
//   imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
//   templateUrl: './product.component.html',
//   styleUrls: ['./product.component.css'],
// })
// export class ProductComponent implements OnInit, OnDestroy {
//   constructor(
//     private productService: ProductService,
//     private loginService: LoginService,
//     private route: ActivatedRoute,
//     private cartService: CartService,
//     private router: Router,
//     private userStore: UserStoreService,
//     private toast: ToastService,
//     private fb: FormBuilder
//   ) {}

//   id: string | null = '';
//   quantity: number = 1;
//   product$!: Observable<Car>;

//   reviewForm!: FormGroup;

//   imageBaseUrl = 'http://localhost:5253/resources/';
//   private subscription: Subscription = new Subscription();

//   isLoggedIn: boolean = false;

//   ngOnInit(): void {
//     this.id = this.route.snapshot.paramMap.get('id');

//     this.product$ = this.productService.getProductById(this.id);

//     this.subscription.add(
//       this.userStore.getfullnameFormStore().subscribe((val) => {
//         this.isLoggedIn = this.loginService.isLoggedIn();
//       })
//     );

//     this.reviewForm = this.fb.group({
//       comment: new FormControl(''),
//     });
//   }
//   increase() {
//     this.quantity += 1;
//   }
//   decrease() {
//     this.quantity = Math.max(0, this.quantity - 1);
//   }
//   addToCart() {
//     this.subscription.add(
//       this.product$.subscribe({
//         next: (res) => {
//           localStorage.setItem('selected-car', JSON.stringify(res));
//           this.router.navigate(['/agreement']);
//         },
//         error: (err) => {
//           this.toast.errorToast('Error occured');
//         },
//       })
//     );
//   }

//   ngOnDestroy(): void {
//     this.subscription.unsubscribe();
//   }
// }
import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Car } from 'src/app/Shared/Interface/Car.interface';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { BookCarService } from 'src/app/Shared/Service/book-car.service';
import { RentalAgreement } from 'src/app/Shared/Interface/RentalAgreement.interface';
import { RentedCar } from 'src/app/Shared/Interface/RentedCar.interface';

const matModules = [
  MatFormFieldModule,
  MatInputModule,
  MatCardModule,
  MatIconModule,
  MatButtonModule,
  MatDatepickerModule,
  MatNativeDateModule,
];

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit, OnDestroy {
  constructor(
    private loginService: LoginService,
    private route: ActivatedRoute,
    private router: Router,
    private userStore: UserStoreService,
    private toast: ToastService,
    private fb: FormBuilder,
    private bookCar: BookCarService
  ) {
    try {
      localStorage.getItem('selected-car');
    } catch (error) {
      console.log(error);
      localStorage.setItem('selected-car', '');
    }
  }
  imageBaseUrl = 'http://localhost:5253/resources/';

  car!: Car;
  isLoggedIn: boolean = false;
  private subscription: Subscription = new Subscription();
  rentForm!: FormGroup;
  dateRented!: Date;
  dateReturn!: Date;

  ngOnInit(): void {
    this.car = JSON.parse(localStorage.getItem('selected-car') ?? '');
    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.isLoggedIn = this.loginService.isLoggedIn();
      })
    );
    this.rentForm = this.fb.group({
      dateRented: new FormControl('', {
        validators: [Validators.required],
      }),
      dateReturn: new FormControl('', {
        validators: [Validators.required],
      }),
    });
  }
  book() {
    if (this.rentForm.valid) {
      this.dateRented = this.rentForm.value.dateRented;
      this.dateReturn = this.rentForm.value.dateReturn;
      const diffTime = Math.abs(
        this.dateReturn.getTime() - this.dateRented.getTime()
      );
      const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
      const agreement: RentedCar = {
        userId: 0,
        carId: this.car.id,
        carDto: this.car,
        dateRented: this.dateRented,
        dateReturn: this.dateReturn,
        totalCost: this.car.rentalPrice * diffDays,
        userDto: {
          id: 0,
          Name: '',
          Email: '',
          Password: '',
          Role: '',
        },
        id: 0,
        appliedForReturn: false,
      };
      localStorage.setItem('booked-car', JSON.stringify(agreement));
      this.router.navigate(['/agreement']);

      // this.bookCar.bookCar(agreement).subscribe({
      //   next: (res) => {
      //     this.toast.successToast('Booked successfully!');
      //     this.router.navigate(['/rented-car']);
      //   },
      //   error: (err) => {
      //     this.toast.errorToast('Car is booked try other date');
      //   },
      // });
    }
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
