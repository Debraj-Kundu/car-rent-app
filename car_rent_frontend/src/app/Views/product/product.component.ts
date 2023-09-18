import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { LoginService } from 'src/app/Shared/Service/login.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, map } from 'rxjs';
import { Car } from 'src/app/Shared/Interface/Car.interface';
import { MatCardModule } from '@angular/material/card';
import { CartService } from 'src/app/Shared/Service/cart.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

const matModules = [
  MatFormFieldModule,
  MatInputModule,
  MatCardModule,
  MatIconModule,
  MatButtonModule,
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
    private productService: ProductService,
    private loginService: LoginService,
    private route: ActivatedRoute,
    private cartService: CartService,
    private router: Router,
    private userStore: UserStoreService,
    private toast: ToastService,
    private fb: FormBuilder
  ) {}

  id: string | null = '';
  quantity: number = 1;
  product$!: Observable<Car>;

  reviewForm!: FormGroup;

  imageBaseUrl = 'http://localhost:5253/resources/';
  private subscription: Subscription = new Subscription();

  isLoggedIn: boolean = false;

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    this.product$ = this.productService.getProductById(this.id);

    this.subscription.add(
      this.userStore.getfullnameFormStore().subscribe((val) => {
        this.isLoggedIn = this.loginService.isLoggedIn();
      })
    );

    this.reviewForm = this.fb.group({
      comment: new FormControl(''),
    });
  }
  increase() {
    this.quantity += 1;
  }
  decrease() {
    this.quantity = Math.max(0, this.quantity - 1);
  }
  addToCart() {
    this.subscription.add(
      this.product$.subscribe({
        next: (res) => {
          // productId = res;
          localStorage.setItem('selected-car', JSON.stringify(res));
          this.router.navigate(['/agreement']);
          this.toast.successToast('Added to cart');
          // this.cartService
          //   .postCart({ productId, quantity: this.quantity })
          //   .subscribe({
          //     next: (res) => {
          //     },
          //     error: (err) => {
          //       this.toast.errorToast('Error occured');
          //     },
          //   });
        },
        error: (err) => {
          this.toast.errorToast('Error occured');
        },
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
