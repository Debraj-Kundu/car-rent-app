import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderService } from 'src/app/Shared/Service/order.service';
import { Observable } from 'rxjs';
import { RentedCar } from 'src/app/Shared/Interface/RentedCar.interface';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, MatCardModule],
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent {
  imageBaseUrl = 'https://localhost:5253/resources/';
  constructor(private orderService: OrderService) {}
  orderList$: Observable<RentedCar[]> = this.orderService.getOrder();
}
