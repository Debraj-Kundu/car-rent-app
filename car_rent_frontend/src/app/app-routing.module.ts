import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Guard/auth.guard';

const routes: Routes = [
  {
    path: 'login',
    loadComponent: () =>
      import('./Core/login/login.component').then((c) => c.LoginComponent),
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full',
  },
  {
    path: 'home',
    loadComponent: () =>
      import('./Views/home/home.component').then((c) => c.HomeComponent),
  },
  {
    path: 'rented-car',
    loadComponent: () =>
      import('./Views/order/order.component').then((c) => c.OrderComponent),
    canActivate: [AuthGuard],
  },
  {
    path: 'book-car',
    loadComponent: () =>
      import('./Views/product/product.component').then(
        (c) => c.ProductComponent
      ),
  },
  {
    path: 'edit/:id',
    loadComponent: () =>
      import('./Views/edit-product/edit-product.component').then(
        (c) => c.EditProductComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'add',
    loadComponent: () =>
      import('./Views/add-product/add-product.component').then(
        (c) => c.AddProductComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'agreement',
    loadComponent: () =>
      import('./Views/rental-agreement/rental-agreement.component').then(
        (c) => c.RentalAgreementComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'edit-agreement',
    loadComponent: () =>
      import('./Views/edit-agremment/edit-agremment.component').then(
        (c) => c.EditAgremmentComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: 'all-agreements',
    loadComponent: () =>
      import('./Views/all-agreemments/all-agreemments.component').then(
        (c) => c.AllAgreemmentsComponent
      ),
    canActivate: [AuthGuard],
  },
  {
    path: '**',
    loadComponent: () =>
      import('./Core/error-page/error-page.component').then(
        (c) => c.ErrorPageComponent
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
