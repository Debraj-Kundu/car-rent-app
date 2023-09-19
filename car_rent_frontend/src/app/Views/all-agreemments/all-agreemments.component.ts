import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RentedCar } from 'src/app/Shared/Interface/RentedCar.interface';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { Car } from 'src/app/Shared/Interface/Car.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-all-agreemments',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule],
  templateUrl: './all-agreemments.component.html',
  styleUrls: ['./all-agreemments.component.css'],
})
export class AllAgreemmentsComponent implements OnInit {
  constructor(private router: Router) {}

  imageBaseUrl = 'http://localhost:5253/resources/';
  agreementList!: RentedCar[];

  ngOnInit(): void {
    this.agreementList = JSON.parse(localStorage.getItem('agremments') ?? '');
  }
  selectCar(car: RentedCar) {
    localStorage.setItem('booked-car', JSON.stringify(car));
    this.router.navigate(['/agreement']);
  }
}
