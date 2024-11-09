# JsonDataDictionary

Bu proje, belirli bir dizin altında bulunan TypeScript (.ts) dosyalarını okuyarak JSON içeriklerini işlemek ve konsola belirli bir formatta yazdırmak amacıyla geliştirilmiştir.

## Proje Özellikleri

- **Dosya Filtreleme:** `index.ts` dosyaları işlenmez.
- **JSON İçerik İşleme:** TypeScript dosyalarındaki `export default` ifadelerini kaldırarak JSON verisi çıkarılır.
- **Konsol Çıktısı:** JSON verileri belirli bir formatta konsola yazdırılır.

### Örnek Çıktı:

  Dosya: shippingFile.ts 
  shippingFile.title => Sevkiyat 
  shippingFile.key => Sevkiyat Kodu 
  shippingFile.columns.category => Kategori 
  shippingFile.columns.isActive => Durum
  
  Dosya: supplier.ts 
  supplier.title => Tedarikçi 
  supplier.columns.name => Adı 
  supplier.columns.isActive => Durum 
  supplier.columns.createdDate => Kayıt Tarihi


## Kullanım

1. Projeyi klonlayın veya indirin.
2. `Program.cs` içinde `basePath` değişkenini TypeScript dosyalarının bulunduğu dizine göre güncelleyin.
3. Projeyi çalıştırın. Konsolda her dosya için yukarıdaki gibi bir çıktı alacaksınız.

## Geliştirme Notları

- `resources` dizini altındaki tüm `.ts` dosyaları okunur.
- `index.ts` dosyaları işlenmez.
- JSON içeriği düzgün çıkarılamazsa hata mesajı konsola yazdırılır.

## Gereksinimler

- .NET 6 veya üzeri
- Newtonsoft.Json kütüphanesi

## Kurulum

1. Projeyi klonlayın:
git clone https://github.com/kullaniciadi/JsonDataDictionary.git


2. Gerekli bağımlılıkları yükleyin:
- `Newtonsoft.Json` NuGet paketini yüklemek için:
  ```
  dotnet add package Newtonsoft.Json
  ```

3. Projeyi çalıştırın:
dotnet run


## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır.
