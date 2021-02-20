﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {  // static yaparsan class ın new lenmesine gerek kalmaz. Kodun okunurluğunu arttırır.
        public static string CarAdded = "Araba Eklendi.";
        public static string CarNameInValid = "Araba ismi geçersiz.";
        public static string CarMaintenenceTime = "Sistem bakımda olduğundan işleminize devam edilemiyor.";
        public static string CarListed = "Arabalar Listelendi. ";
        public static string CarUpdated = "Araba güncellendi. ";
        public static string CarDeleted = "Araba silindi. ";
        //////////
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandNameInValid = "Marka ismi geçersiz.";
        public static string BrandMaintenenceTime = "Sistem bakımda olduğundan işleminize devam edilemiyor.";
        public static string BrandListed = "Markalar Listelendi. ";
        public static string BrandUpdated = " Marka güncellendi. ";
        public static string BrandDeleted = " Marka silindi. ";
        ///////////
        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorNameInValid = "Renk ismi geçersiz.";
        public static string ColorMaintenenceTime = "Sistem bakımda olduğundan işleminize devam edilemiyor.";
        public static string ColorListed = "Renkler Listelendi. ";
        public static string ColorUpdated = "Renk güncellendi. ";
        public static string ColorDeleted = "Renk silindi. ";
        /////////
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserNameInValid = "Kullanıcı ismi geçersiz.";
        public static string UserMaintenenceTime = "Sistem bakımda olduğundan işleminize devam edilemiyor.";
        public static string UserListed = "Kullanıcılar Listelendi. ";
        public static string UserUpdated = "Kullanıcı bilgileri veritabanında güncellendi. ";
        public static string UserDeleted = "Kullanıcı bilgileri veritabanından silindi. ";
        ////////
        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerInValid = "Müşteri ismi geçersiz.";
        public static string CustomerMaintenenceTime = "Sistem bakımda olduğundan işleminize devam edilemiyor.";
        public static string CustomerListed = "Müşteriler Listelendi. ";
        public static string CustomerUpdated = "Müşteri bilgileri veritabanında güncellendi. ";
        public static string CustomerDeleted = "Müşteri veritabanından silindi. ";
        ///////
        public static string RentalAdded = "Kiralama işlemi başladı.";
        public static string RentalNameInValid = "Kiralama ismi geçersiz.";
        public static string RentalMaintenenceTime = "Sistem bakımda olduğundan işleminize devam edilemiyor.";
        public static string RentalListed = "Kiralamalar Listelendi. ";
        public static string RentalUpdated = "Kiralama işlemi güncellendi. ";
        public static string RentalDeleted = "Kiralama işlemi veritabanından silindi. ";
        public static string RentalNotAvailable = "Bu araba için kiralama işlemi yapılamaz.";
        public static string RentalCompleted = "Kiralama işlemi tamamlandı.";
    }
}


