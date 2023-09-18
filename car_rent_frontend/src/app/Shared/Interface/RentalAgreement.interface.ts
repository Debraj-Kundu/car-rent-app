import { Car } from "./Car.interface";
import { User } from "./User.interface";

export interface RentalAgreement{
    userId: number,
    // userDto: User,
    carId: number,
    // carDto: Car,
    // id: number,
    dateRented: Date,
    dateReturn: Date,
    totalCost: number
};