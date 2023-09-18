import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { RentedCar } from 'src/app/Shared/Interface/RentedCar.interface';
import { MatCardModule } from '@angular/material/card';
import { RentedCarService } from 'src/app/Shared/Service/rented-car.service';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent {
  imageBaseUrl = 'http://localhost:5253/resources/';
  constructor(private rentedCarService: RentedCarService) {}
  orderList$: Observable<RentedCar[]> = this.rentedCarService.getRentedCars();
}
