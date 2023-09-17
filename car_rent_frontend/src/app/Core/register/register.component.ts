import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { User } from 'src/app/Shared/Interface/User.interface';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { RegisterService } from 'src/app/Shared/Service/register.service';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import CustomValidators from 'src/app/Shared/CustomValidator';
import { Subscription } from 'rxjs';

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
];

@Component({
  selector: 'app-register',
  standalone: true,
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
})
export class RegisterComponent implements OnInit, OnDestroy {
  registerForm!: FormGroup;
  userInfo: User = {
    id: 0,
    Name: '',
    Email: '',
    Password: '',
    Role: '',
  };
  private subscription: Subscription = new Subscription();

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private toast: ToastService,
    private registerService: RegisterService
  ) {
    this.registerForm = this.fb.group(
      {
        Name: new FormControl('', {
          validators: [
            Validators.required,
            Validators.maxLength(50),
            Validators.pattern('^[a-zA-Z]+$'),
          ],
        }),
        Email: new FormControl('', {
          validators: [
            Validators.required,
            Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$'),
          ],
        }),
        PhoneNumber: new FormControl('', {
          validators: [Validators.required, Validators.pattern('[0-9]{10}')],
        }),
        Password: new FormControl('', {
          validators: [
            Validators.required,
            Validators.pattern(
              '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&]).{8,}'
            ),
          ],
        }),
        ConfirmPassword: new FormControl('', {
          validators: [
            Validators.required,
            Validators.pattern(
              '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&]).{8,}'
            ),
          ],
        }),
      },
      {
        validators: [CustomValidators.match('Password', 'ConfirmPassword')],
      }
    );
  }

  ngOnInit(): void {}

  register() {
    if (this.registerForm.valid) {
      this.userInfo.Name = this.registerForm.value.Name;
      this.userInfo.Email = this.registerForm.value.Email;
      this.userInfo.Password = this.registerForm.value.Password;

      this.subscription.add(
        this.registerService.postUser(this.userInfo).subscribe({
          next: (res) => {
            console.log(res);
            this.registerForm.reset();
            this.toast.successToast('SignUp Successful!');
            this.router.navigate(['login']);
          },
          error: (err) => {
            console.log(err);
            this.toast.errorToast('SignUp Failed! Email already exist');
          },
        })
      );
    }
  }

  ClearForm() {
    this.registerForm.reset();
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
