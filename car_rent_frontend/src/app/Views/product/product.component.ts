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
import { User } from 'src/app/Shared/Interface/User.interface';
import CustomValidators from 'src/app/Shared/CustomValidator';

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
  minDate: Date = new Date(Date.now());
  user: User = {
    id: 0,
    Name: '',
    Email: '',
    Password: '',
    Role: '',
  };
  ngOnInit(): void {
    this.car = JSON.parse(localStorage.getItem('selected-car') ?? '');
    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.isLoggedIn = this.loginService.isLoggedIn();
        this.user.Name = val;
      })
    );
    this.subscription.add(
      this.userStore.getIdFormStore().subscribe((val) => {
        this.user.id = +val;
        console.log(val);
      })
    );
    this.rentForm = this.fb.group(
      {
        dateRented: new FormControl('', {
          validators: [Validators.required],
        }),
        dateReturn: new FormControl('', {
          validators: [Validators.required],
        }),
      },
      {
        validators: [CustomValidators.match('dateRented', 'dateReturn')],
      }
    );
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
        userId: this.user.id,
        carId: this.car.id,
        carDto: this.car,
        dateRented: this.dateRented,
        dateReturn: this.dateReturn,
        totalCost: this.car.rentalPrice * diffDays,
        userDto: this.user,
        id: 0,
        appliedForReturn: false,
      };
      localStorage.setItem('booked-car', JSON.stringify(agreement));
      try {
        const agreemments: any[] = JSON.parse(
          localStorage.getItem('agremments') ?? ''
        );
        if (agreemments.length > 0)
          localStorage.setItem(
            'agremments',
            JSON.stringify([...agreemments, agreement])
          );
      } catch (err) {
        localStorage.setItem('agremments', JSON.stringify([agreement]));
      }
      this.router.navigate(['/agreement']);
    }
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
