import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductService } from 'src/app/Shared/Service/product.service';
import { Car } from 'src/app/Shared/Interface/Car.interface';
import { Observable, Subscription, map } from 'rxjs';

import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSort, MatSortModule } from '@angular/material/sort';

import { LoginService } from 'src/app/Shared/Service/login.service';
import { UserStoreService } from 'src/app/Shared/Service/user-store.service';
import { Router, RouterModule } from '@angular/router';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ToastService } from 'src/app/Shared/Service/toast.service';
import { MatInputModule } from '@angular/material/input';

const matModules = [
  MatButtonModule,
  MatTableModule,
  MatPaginatorModule,
  MatIconModule,
  MatDialogModule,
  MatSelectModule,
  MatFormFieldModule,
  MatSortModule,
  MatInputModule,
  MatFormFieldModule,
];

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    ...matModules,
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(
    private productService: ProductService,
    private loginService: LoginService,
    private userStore: UserStoreService,
    private toast: ToastService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  imageBaseUrl = 'http://localhost:5253/resources/';

  productsList$: Observable<Car[]> = this.productService.getAllProducts();

  selected!: any;
  modelSearchBox!: FormGroup;
  makerSearchBox!: FormGroup;
  priceSearchBox!: FormGroup;
  searchText = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  displayColumns: string[] = ['name', 'description', 'price', 'image'];
  private dataSource = new MatTableDataSource<Car>();

  tableData$: Observable<any> = this.productsList$.pipe(
    map((item) => {
      const dataSource = this.dataSource;
      dataSource.data = item;
      dataSource.paginator = this.paginator;
      dataSource.sort = this.sort;
      return dataSource;
    })
  );

  userRole: string = '';
  private subscription: Subscription = new Subscription();

  ngOnInit(): void {
    this.modelSearchBox = this.fb.group({
      search: new FormControl(''),
    });
    this.makerSearchBox = this.fb.group({
      search: new FormControl(''),
    });
    this.priceSearchBox = this.fb.group({
      search: new FormControl(''),
    });
    const roleFormToken = this.loginService.getRoleFromToken();
    this.userStore.getRoleFormStore().subscribe((val) => {
      this.userRole = val || roleFormToken;
    });
    if (this.userRole === 'Admin') this.displayColumns.push('actions');
  }

  valueChange(value: any) {
    if (value == null) {
      this.tableData$ = this.productService.getAllProducts().pipe(
        map((item) => {
          const dataSource = this.dataSource;
          dataSource.data = item;
          dataSource.paginator = this.paginator;
          dataSource.sort = this.sort;
          return dataSource;
        })
      );
      return;
    }
    this.toast.successToast(value.name);
    this.tableData$ = this.productsList$.pipe(
      map((item) => {
        const dataSource = this.dataSource;

        dataSource.paginator = this.paginator;
        dataSource.sort = this.sort;
        return dataSource;
      })
    );
  }
  filterByMaker() {
    this.tableData$ = this.productsList$.pipe(
      map((item) => {
        const dataSource = this.dataSource;
        dataSource.data = item.filter((prod) =>
          prod.maker
            .toLocaleLowerCase()
            .includes(this.makerSearchBox.value.search.toLocaleLowerCase())
        );
        dataSource.paginator = this.paginator;
        dataSource.sort = this.sort;
        return dataSource;
      })
    );
  }
  filterByModel() {
    this.tableData$ = this.productsList$.pipe(
      map((item) => {
        const dataSource = this.dataSource;
        dataSource.data = item.filter((prod) =>
          prod.model
            .toLocaleLowerCase()
            .includes(this.modelSearchBox.value.search.toLocaleLowerCase())
        );
        dataSource.paginator = this.paginator;
        dataSource.sort = this.sort;
        return dataSource;
      })
    );
  }
  filterByPrice() {
    this.tableData$ = this.productsList$.pipe(
      map((item) => {
        const dataSource = this.dataSource;
        dataSource.data = item.filter((prod) =>
          prod.rentalPrice
            .toString()
            .includes(this.priceSearchBox.value.search.toLocaleLowerCase())
        );
        dataSource.paginator = this.paginator;
        dataSource.sort = this.sort;
        return dataSource;
      })
    );
  }
  deleteProduct(id: string) {
    if (confirm('You are about to delete the product')) {
      this.subscription.add(
        this.productService.deleteProduct(id).subscribe({
          next: (res) => {
            this.tableData$ = this.productsList$.pipe(
              map((item) => {
                const dataSource = this.dataSource;
                dataSource.data = item;
                dataSource.paginator = this.paginator;
                dataSource.sort = this.sort;
                return dataSource;
              })
            );
            this.toast.successToast('Product deleted successfully');
          },
          error: (err) => {
            this.toast.successToast('Something went wrong');
          },
        })
      );
    }
  }

  selectedCar(car: any) {
    localStorage.setItem('selected-car', JSON.stringify(car));
    this.router.navigate(['/book-car']);
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
