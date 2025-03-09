
# Lojistik Şoför - İş Yönetim Sistemi

## Açıklama
Bu proje, bir firmadaki sefere çıkması gereken işlerin ve bu işleri lojistiğini gerçekleştirecek olan şoförlerin sefer sıralarına uygun hareket etmeleri için geliştirilmiş bir sistemdir. Hem sefer takibinin kolaylaşması hem de elde edilen verilerin işlenmesi açısından oldukça etkili bir çözümdür. Henüz dijitalleşmemiş bu süreçlerin içerisindeki oluşabilecek karışıklık ve haksızlık gibi sorunlar doğrultusunda oluşmuş bir ihtiyaçtır. İşlerin ve şoförlerin yolculuk sırasını sistem FIFO (First In, First Out) prensibine göre belirler ve hem iş hem de şoförün sefer sırası oluşabilecek aksiliklere karşı güncellenebilir olarak ayarlanmıştır.

## Teknolojiler ve Kullanılan Araçlar
- **.NET Framework**: 4.6.1
- **MetroSetModernUI**: 1.4.0.0
- **MetroSetUI**: 2.0.0

## Kurulum Talimatları

### Gereksinimler:
- **.NET Framework 4.6.1** veya daha üstü
- **SQL Server**: Uygulamanın veritabanı bağlantısı için
- **RFID Kart Okuyucu**: Kart okuma işlemleri için

### Kurulum Adımları:
1. Uygulamayı indirin ve açın.
2. İlk açılışta, sol üst köşedeki **Ayarlar** butonundan SQL bağlantısı ve kart okuyucu bağlantı ayarlarını yapılandırın. İlk kurulumda, SQL bağlantı için bir **txt dosyası**, RFID okuyucu için ise **json dosyası** otomatik olarak oluşturulacaktır.
3. Kurulumdan sonra, yetkili girişini yapmak için gerekli bağlantı bilgilerini sağlayın.
4. Uygulama açıldığında, iki ana buton olan **Sıra Listesi** ve **Sefer İşlemleri** karşınıza çıkacaktır.

## Kullanım Talimatları

### 1. **Sıra Listesi**:
Bu bölümde, şoförlerin sefere çıkış sıralarını ve seferdeki şoförleri görebileceksiniz.  
- **Yeşil Satırlar**: Seferdeki şoförleri gösterir.  
- **Mavi Satırlar**: Bekleyen şoförleri gösterir.

### 2. **Sefer İşlemleri**:
- Şoför kendini seçtikten sonra, sağ tarafta sefer için uygun işler sırasıyla listelenir.
- Şoför sıradaki işi seçmekten başka bir seçenek kullanamaz. 
- İş seçimi yapıldıktan sonra, RFID okuyucu aktif olur ve şoförün kartını okuması istenir.
- Kart doğruysa, sefer işlemi başlar. Sefer tamamlandığında, şoför kartını okuyucuya okutmalı ve sırası kuyruğun sonuna eklenir.

### 3. **Ayarlar Butonu**:
Bu ekranda iş ve şoför sırasını değiştirme, güncelleme, silme ve ekleme gibi işlemleri gerçekleştirebilirsiniz. 
- Sürükle-bırak yöntemi ile sıralamaları değiştirebilir, belirli iş veya şoförleri değiştirebilirsiniz.

### 4. **Veritabanı Bağlantısı**:
Uygulama, doğrudan SQL veritabanına bağlanarak her işlem anında veritabanına yansımasını sağlar. Anlık verileri görme ve güncelleme imkanı sunar.

**Not**: Kart okuma işlemi için kullanılacak RFID okuyucunun SDK dokümanına uygun olarak geliştirilmelidir.

## Veritabanı Yapısı

- **tbl_Is**: İş bilgilerinin tutulduğu tablo (Çıkış birimi, varış birimi, iş durumu, taşınacak yük, vb.)
- **tbl_Is_Sirasi**: İş sırasının tutulduğu tablo (İş ID, sıra no, sıra durumu)
- **tbl_Sefer**: Şoförlerin hangi işi ne zaman aldığını ve tamamladığını belirten tablo (İş ID, Şoför ID, Sefer çıkış ve dönüş tarihi, Sefer durumu)
- **tbl_Sofor**: Şoför ve araçlarının tutulduğu tablo
- **tbl_Sira**: Şoför sırasının tutulduğu tablo (Şoför ID, sıra no, sıra durumu)
- **tbl_Yetkili**: Şoför dışındaki kullanıcı bilgilerini ve yetki derecelerini tutan tablo

## Özellikler
- **FIFO (First In, First Out) Kuyruk Yönetimi**: Şoförlerin sıradaki iş sırasına göre düzenlenmesi.
- **Sürücü Kart Okuma ile Sıra Güncelleme**: RFID kart okuyucu ile şoför sırasının güncellenmesi.
- **Dinamik Metro Tile UI**: Kullanıcı dostu ekran tasarımı ile dinamik arayüz.
- **Veritabanı Takibi**: İşlerin ve şoförlerin durumu veritabanı üzerinden takip edilir.
- **Sıra Güncelleme**: Ani gelişen durumlara göre sıralama güncellenebilir.
- **Yetkilendirme**: Sınırlı kullanım ve güvenlik için yetkilendirme sistemi.

## Gelecekteki Planlar
- Gelişmiş raporlama özellikleri
- ERP sistemleri ile entegrasyon

## İletişim
- **Proje Geliştiricisi**: [Oğuzhan Demir]
- **E-posta**: [dmrogz_26@hotmail.com]
