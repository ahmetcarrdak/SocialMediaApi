# Social Media API

Bu proje, bir sosyal medya uygulaması için geliştirilen bir RESTful Web API'sidir. Bu API, kullanıcıların kaydolmasını, giriş yapmasını, gönderi paylaşmasını, beğeni ve yorum yapmasını sağlar.

## İçindekiler

1. [Kurulum](#kurulum)
2. [Kullanım](#kullanım)
3. [API Belgeleri](#api-belgeleri)
4. [Veritabanı Yapısı](#veritabanı-yapısı)
5. [Katkı](#katkı)
6. [Lisans](#lisans)

## Kurulum

### Gereksinimler

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)

### Adımlar

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/kullanici_adi/social-media-api.git
   cd social-media-api
   ```

2. Gerekli bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```

3. Veritabanı bağlantı ayarlarını yapın:
   - `appsettings.json` dosyasını açın ve `DefaultConnection` stringini veritabanınıza göre güncelleyin.

4. Veritabanı migrasyonlarını uygulayın:
   ```bash
   dotnet ef database update
   ```

5. Uygulamayı başlatın:
   ```bash
   dotnet run
   ```

## Kullanım

### API Endpoints

API'yi test etmek için Postman veya başka bir API istemcisi kullanabilirsiniz. Varsayılan olarak API, `https://localhost:5001` adresinde çalışır.

#### Kullanıcı Kayıt

- **Endpoint**: `/api/users/register`
- **Metod**: POST
- **Gönderilecek Veri**:
  ```json
  {
    "username": "kullaniciadi",
    "email": "email@example.com",
    "password": "Sifre123"
  }
  ```
- **Dönüş**: 201 Created

#### Kullanıcı Girişi

- **Endpoint**: `/api/users/login`
- **Metod**: POST
- **Gönderilecek Veri**:
  ```json
  {
    "email": "email@example.com",
    "password": "Sifre123"
  }
  ```
- **Dönüş**: 200 OK ve JWT Token

## Veritabanı Yapısı

Veritabanı şeması, aşağıdaki ana tabloları içerir:

- **Users**: Kullanıcı bilgilerini içerir.
- **Posts**: Kullanıcıların paylaştığı gönderiler.
- **Comments**: Gönderilere yapılan yorumlar.
- **Likes**: Gönderilere yapılan beğeniler.

## Katkı

Katkıda bulunmak istiyorsanız, lütfen bir konu açın veya bir çekme isteği gönderin. Herhangi bir katkı memnuniyetle karşılanır.
