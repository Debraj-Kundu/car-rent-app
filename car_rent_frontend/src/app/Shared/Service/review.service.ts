import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cart } from '../Interface/RentalAgreement.interface';
import { LoginService } from './login.service';
import { UserStoreService } from './user-store.service';
import { Review } from '../Interface/Review.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ReviewService {
    constructor(private http:HttpClient){}

    apiurl = `${environment.baseurl}/review`;

    postReview(review:Review){
        return this.http.post(this.apiurl, review);
    }
}
