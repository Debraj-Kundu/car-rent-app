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
  selector: 'app-rental-agreement',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
  templateUrl: './rental-agreement.component.html',
  styleUrls: ['./rental-agreement.component.css'],
})
export class RentalAgreementComponent implements OnInit, OnDestroy {
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
      localStorage.getItem('booked-car');
    } catch (error) {
      console.log(error);
      localStorage.setItem('booked-car', '');
    }
  }
  imageBaseUrl = 'http://localhost:5253/resources/';

  car!: RentedCar;
  isLoggedIn: boolean = false;
  private subscription: Subscription = new Subscription();
  rentForm!: FormGroup;
  dateRented!: Date;
  dateReturn!: Date;
  totalCost!: number;
  user: User = {
    id: 0,
    Name: '',
    Email: '',
    Password: '',
    Role: '',
  };

  ngOnInit(): void {
    this.car = JSON.parse(localStorage.getItem('booked-car') ?? '');
    this.totalCost = this.car.totalCost;
    this.dateRented = this.car.dateRented;
    this.dateReturn = this.car.dateReturn;
    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.isLoggedIn = this.loginService.isLoggedIn();
        this.user.Name = val || this.loginService.getFullNameFromToken();
      })
    );
    this.subscription.add(
      this.userStore.getIdFormStore().subscribe((val) => {
        this.user.id = +val || this.loginService.getIdFromToken();
      })
    );

    this.rentForm = this.fb.group({
      dateRented: new FormControl(this.car.dateRented, {
        validators: [Validators.required],
      }),
      dateReturn: new FormControl(this.car.dateReturn, {
        validators: [Validators.required],
      }),
    });
  }
  private calTotal() {
    this.dateRented = this.rentForm.value.dateRented ?? this.dateRented;
    this.dateReturn = this.rentForm.value.dateReturn ?? this.dateReturn;
    const diffTime = Math.abs(
      new Date(this.dateReturn).getTime() - new Date(this.dateRented).getTime()
    );
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
    return this.car.carDto.rentalPrice * diffDays;
  }
  dateChange() {
    this.totalCost = this.calTotal();
  }
  book() {
    this.dateRented = this.rentForm.value.dateRented;
    this.dateReturn = this.rentForm.value.dateReturn;
    if (this.rentForm.valid) {
      const agreement: RentalAgreement = {
        userId: 0,
        carId: this.car.carDto.id,
        dateRented: this.dateRented,
        dateReturn: this.dateReturn,
        totalCost: this.calTotal(),
      };
      this.bookCar.bookCar(agreement).subscribe({
        next: (res) => {
          this.toast.successToast('Rented successfully!');
          try {
            let agreements: any[] = JSON.parse(
              localStorage.getItem('agremments') ?? ''
            );
            agreements = agreements.filter(
              (rc) => rc.carDto.id !== agreement.carId
            );
            localStorage.setItem('agremments', JSON.stringify(agreements));
            localStorage.removeItem('booked-car');
          } catch (err) {}
          this.router.navigate(['/rented-car']);
        },
        error: (err) => {
          this.toast.errorToast('Car is rented try other date');
        },
      });
    }
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
