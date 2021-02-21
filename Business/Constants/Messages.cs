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

        // Ortak Mesaj

        public static string NotListed = "Listelenecek ürün bulunamadı";
    }
}
