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
    private fb: FormBuilder
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
  Login() {
    if (this.rentForm.valid) {
      this.dateRented = this.rentForm.value.dateRented;
      this.dateReturn = this.rentForm.value.dateReturn;
      this.router.navigate(['/rented-cars']);
    }
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
