using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid= "Araç ismi geçersiz";
        public static string CarsListed="Araçlar listelendi";
        public static string CarDeleted="Araç silindi";
        public static string CarUpdated="Araç bilgileri güncellendi";

        // Brand Messages 
        public static string BrandAdded = "Marka eklendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka bilgisi güncellendi";


        // Color Messages

        public static string ColordAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk bilgisi güncellendi";

        // Customer Messages

        public static string CustomerdAdded = "Müşteri eklendi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri bilgisi güncellendi";
        public static string NotRegistered="Müşteri kullanıcı olarak sisteme kayıtlı değilzz";

        // User Messages

        public static string UserdAdded = "Kullanıcı eklendi";
        public static string UserListed = "Kullanıcı listelendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı bilgisi güncellendi";


        // Rental Messages

        public static string RentaldAdded = "Kiralama bilgisi eklendi";
        public static string RentalListed = "Kiralama bilgisi listelendi";
        public static string RentalDeleted = "Kiralama bilgisi silindi";
        public static string RentalUpdated = "Kiralama bilgisi güncellendi";
        public static string NotAvaliable="Araç kiralamak için uygun değil";

        // Ortak Mesaj

        public static string NotListed = "Listelenecek ürün bulunamadı";
        
    }
}
