using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandNameShort = "Brand name must be longer than 2 characters";
        public static string DailyPricePositive = "Daily price must be higher than 0";
        public static string CarNotAvailable = "Car is not available at the moment.";
        public static string RentalIsSucced = "Rental is created succesfully.";
        public static string RentalFinishedSuccesfully = "Rental is finished succesfully.";
        public static string CarsListed = "Cars listed succesfully.";
        public static string ImageAddedSuccesfully = "Image added successfully";
        public static string ImageUpdatedSuccessfully = "Image updated successfully";
        public static string FailAddedImageLimit= "A car can have maximum 5 photos.";
        public static string UserNotFound = "User has not been found";
        public static string PasswordError = "Password is wrong";
        public static string SuccessfulLogin = "Login is successfull.";
        public static string UserAlreadyExist = "User already exist.";
        public static string SuccessfullRegister = "User registered successfully.";
        public static string AccesTokenCreted = "Access token created successfully.";
    }
}
