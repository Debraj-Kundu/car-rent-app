import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import { Car } from 'src/app/Shared/Interface/Car.interface';
import { MatSelectModule } from '@angular/material/select';
import { Subscription } from 'rxjs';

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatSelectModule,
];
@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit, OnDestroy {
  constructor(
    private productService: ProductService,
    private router: Router,
    private toast: ToastService,
    private fb: FormBuilder,
  ) {}

  id: string | null = '';
  product: Car = {
    maker: '',
    model: '',
    rentalPrice: 0,
    availabilityStatus: true,
    carImage: '',
    imageFile: new File([], ''),
    id: 0,
  };

  imageFile!: File;
  productForm!: FormGroup;

  private subscription: Subscription = new Subscription();

  selected!: any;

  ngOnInit(): void {
    this.productForm = this.fb.group({
      name: new FormControl('', {
        validators: [
          Validators.required,
          Validators.maxLength(100),
          Validators.pattern('^[a-zA-Z0-9 ]+$'),
        ],
      }),
      description: new FormControl('', {
        validators: [
          Validators.required,
          Validators.maxLength(255),
          Validators.pattern('^[a-zA-Z0-9 ]+$'),
        ],
      }),
      price: new FormControl('', { validators: [Validators.required] }),
      discount: new FormControl(''),
      availableQuantity: new FormControl('', {
        validators: [Validators.required],
      }),
      image: new FormControl('', { validators: [Validators.required] }),
      specification: new FormControl(''),
      id: new FormControl(this.id),
    });
  }

  addProduct() {
    if (this.productForm.valid) {
      const formData: Car = Object.assign(this.productForm.value);
      formData.imageFile = this.imageFile;
      this.subscription.add(
        this.productService.postProduct(formData).subscribe({
          next: (res) => {
            this.toast.successToast('Product added successfully!');
            this.router.navigate(['/home']);
          },
          error: (res) => {
            this.toast.errorToast('Error occured retry!');
          },
        })
      );
    }
  }

  onChange(event: any) {
    this.imageFile = event.target.files[0];
  }

  clearForm() {
    this.productForm.reset();
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
