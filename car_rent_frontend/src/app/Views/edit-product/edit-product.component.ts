import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { Observable, Subscription, map, tap } from 'rxjs';
import { Car } from 'src/app/Shared/Interface/Car.interface';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';

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
  selector: 'app-edit-product',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule, ...matModules],
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css'],
})
export class EditProductComponent implements OnInit, OnDestroy {
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private toast: ToastService,
    private fb: FormBuilder,
  ) {
    this.productForm = this.fb.group({
      maker: new FormControl('', {
        validators: [
          Validators.required,
          Validators.maxLength(100),
          Validators.pattern('^[a-zA-Z0-9 ]+$'),
        ],
      }),
      model: new FormControl('', {
        validators: [
          Validators.required,
          Validators.maxLength(255),
          Validators.pattern('^[a-zA-Z0-9 ]+$'),
        ],
      }),
      rentalPrice: new FormControl('', { validators: [Validators.required] }),
      imageFile: new FormControl(''), //, { validators: [Validators.required] }
      carImage: new FormControl(''),
      id: new FormControl(this.id),
    });
  }

  id: string = '';
  product$!: Observable<Car>;
  productForm!: FormGroup;


  selected!: any;
  imageFile!: File;
  private subscription: Subscription = new Subscription();

  ngOnInit(): void {
    this.LoadFormData();
  }

  LoadFormData() {
    this.id = this.route.snapshot.paramMap.get('id') ?? '';
    this.product$ = this.productService.getProductById(this.id).pipe(
      tap((prod) => {
        this.productForm.patchValue(prod);
      })
    );
  }

  editProduct() {
    if (this.productForm.valid) {
      const formData: Car = Object.assign(this.productForm.value);
      if (this.imageFile != undefined) formData.imageFile = this.imageFile;
      this.subscription.add(
        this.productService.updateProduct(this.id, formData).subscribe({
          next: (res) => {
            this.toast.successToast('Product updated successfully!');
          },
          error: (err) => {
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
