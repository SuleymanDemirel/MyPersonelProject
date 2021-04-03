using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductListed = "Ürün listelendi.";
        public static string ProductDetailsListed = "Ürün detayları listelendi.";
        public static string ProductImageAdded = "Ürün Fotoğrafı Eklendi.";
        public static string ProductsImagesListed = "Ürünlerin Fotoğrafları Listelendi.";
        public static string ProductImageDeleted = "Ürün Fotoğrafı Silindi.";
        public static string ProductImageLimitExceded = "Limit aşıldı.";
        public static string ProductImageUpdated = "Ürün fotoğrafı güncellendi .";
       
        
        
        public static string UserRegistered = "Kayıt yapıldı.";

        public static string AccessTokenCreated = "Giriş Başarılı/Token oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
         public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Giriş Başarılı.";
        public static string UserAlreadyExists = "UserAlreadyExists";

        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}

