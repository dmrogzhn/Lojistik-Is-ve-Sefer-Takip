/* diyelim ki seferden adam döndü*/
/* olmasý gereken olaylar þunlar:
	ilk etapta sýrada status durumu hepsinin waiting oldu
	sefer durumu: tamamlandý
	sefer dönüþ tarihi eklenecek
	seferden gelen adam sýranýn sonuna eklenecek ve status kýsmý waiting olacak

*/
/*kartý okuttuðumuzda þoför tablosundan 1 ýd si geldi var sayýyoruz*/

/* kartý dönünce okuttuðunda çalýþmasý gereken kod*/
update tbl_Sefer set sefer_Durumu = 'Tamamlandý', sefer_Donus_Tarihi = '2024-12-3' where sofor_ID = 1 /* sefer tablosundaki durum ve tarih kýsmýný hallettik*/
select * from tbl_Sefer

insert into tbl_Sira (sofor_ID,sira_No,sira_Statu)
values (1,(select MAX(sira_no)+1 from tbl_Sira),'Waiting')
select * from tbl_Sira

/*her þeyi elimizle yapýyoru*/

/*adam geldi adýný seçti iþi seçti ve kartý okuttu karttan gelen id deðeri 2 olsun*/
/* hala 1 numaralý iþimiz duruyor*/

insert into tbl_Sefer(ýs_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
values (1,2,'2024-12-02','Devam')
select * from tbl_Sefer
/*seferimiz oluþtu*/
/*artýk bu adamýn sýra tablosundaki status kýsmý waiting deðil onTrip yani yolda yapcaðýz*/
/*adamýn kartý okuttuðu anda aslýnda kendi ýd sindeki en son waiting olan sýra ýd sini bulup bunu on trip yaparsak tamamdýr bu iþ*/
select * from tbl_Sira where sofor_ID = 2 and sira_Statu ='Waiting' /* and yazdýðýmýz zaman iki koþulu da saðlamak zorunda ve eðer sistem doðru çalýþýyorsa geçerli ýd ye ait sadece bir adet waiting kaydý olmalý biz de onu onTrip yapacaðýz*/
update tbl_Sira set sira_Statu = 'onTrip' where sofor_ID = 2 and sira_Statu = 'Waiting'
select * from tbl_Sira
/*adam artýk yolda yaný sýra tablosunda yolda görünüyor ve biz de ona göre renkleri ayarlarýz adam gelince de completed yaparýz ve sýraya yeniden ekler waiting yaparýz*/
/* adam geldi ve kartýný okuttu karttan da 2 ýd si geldi*/
/*biz bu adamýn sefer tablosunda hiç sefer_durumu 'devam' olan seferi var mý ona bakacaðýz o seferin ýd sini alýp durum kýsmýný tamamlandý yapacaðýz*/
/*eðer sistem doðru çalýþýyorsa zaten o adamýn sefer tablosunda 1 tane devam durumunda seferi vardýr o yüzden and ile çözeriz ama kodda seferin olup olmama durumunu da kontrol et yani öyle bir sefer yoksa yani adam durduk yere kartý okuttuysa uyarý versin*/
update tbl_Sefer set sefer_Donus_Tarihi = '2024-12-03', sefer_Durumu = 'Tamamlandý' where sofor_ID = 2 and sefer_Durumu = 'Devam'
select * from tbl_Sefer
/* sýra tablosunda bu adamýn ýd sini ve onTrip olan satýrý alýp onu completed yapýp sonra bu adamý sýranýn en sonuna eklememiz lazým*/
update tbl_Sira set sira_Statu = 'Completed' where sofor_ID = 2  and sira_Statu ='onTrip'
select * from tbl_Sira
/*þimdi de sýranýn sonuna ekleyelim*/

insert into tbl_Sira (sofor_ID,sira_No,sira_Statu)
values(2,(select Max(sira_No)+1 from tbl_Sira),'Waiting')
select * from tbl_Sira

update tbl_Sira set sira_Statu = 'Completed' where sira_ID = 1

select * from tbl_Sira where sira_Statu = 'Waiting' or sira_Statu = 'onTrip'

/*aþaðýdaki kod iþ alýndý mý kýsmýnýn sefer tablosuna göre otomatik hareketini kontrol eder. yani oluþturulmuþ ama daha sefere çýkmamýþ iþ, sefere çýktýðý zaman iþ_alýndý mý kýsmýný evet olarak ayarlar. sonra iþ id sinin olduðu seferdeki sefer_durumu tamamlandý olduðunda iþ tablosunda iþ_alýndý mý kýsmý tamamlandý olur ve hali hazýrda listelenecek iþlerde görünmez*/

/*

-- Ýþ alýndý mý sütununu güncelleyen trigger
CREATE TRIGGER UpdateJobStatusOnInsert
ON Trips
AFTER INSERT
AS
BEGIN
    -- Ýþ eklendiðinde JobTaken 'Evet' olarak güncellenir
    UPDATE Jobs
    SET JobTaken = 'Yes'
    FROM Jobs j
    INNER JOIN Inserted i ON j.JobID = i.JobID;
END;

-- Sefer durumu tamamlandýðýnda JobTaken 'Tamamlandý' olarak güncelleyen trigger
CREATE TRIGGER UpdateJobStatusOnComplete
ON Trips
AFTER UPDATE
AS
BEGIN
    -- Eðer sefer durumu 'Tamamlandý' ise
    UPDATE Jobs
    SET JobTaken = 'Completed'
    FROM Jobs j
    INNER JOIN Inserted i ON j.JobID = i.JobID
    WHERE i.TripStatus = 'Completed';
END;

*/

/*
-- Sefer tablosu için trigger oluþtur
CREATE TRIGGER trg_SeferDurumGuncelle
ON tbl_Sefer
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Sefer tablosundaki güncellenen kayýtlarý al
    DECLARE @SeferDurum NVARCHAR(50), @IsID INT, @SoforID INT;

    SELECT @SeferDurum = tbl_Sefer.sefer_Durumu,
           @IsID = tbl_Sefer.ýs_ID,
           @SoforID = tbl_Sefer.sofor_ID
    FROM tbl_Sefer;

    -- Sefer_Durum 'yolda' olarak güncellendiðinde Ýþ tablosunda Is_Alindi_Mi sütununu güncelle
    IF @SeferDurum = 'Yolda'
    BEGIN
        UPDATE tbl_Is
        SET is_Alindi_Mi = 'Alýndý'
        WHERE is_ID = @IsID;

        UPDATE tbl_Sira
        SET sira_Statu = 'onTrip'
        WHERE sofor_ID = @SoforID and sira_Statu = 'Waiting';
    END

    -- Sefer_Durum 'tamamlandý' olarak güncellendiðinde Ýþ ve Sýra tablolarýný güncelle
    IF @SeferDurum = 'Tamamlandý'
    BEGIN
        UPDATE tbl_Is
        SET is_Alindi_Mi = 'Tamamlandý'
        WHERE is_ID = @IsID;

        UPDATE tbl_Sira
        SET sira_Statu = 'completed'
        WHERE sofor_ID = @SoforID and sira_Statu = 'onTrip';
    END
END;
GO
*/

/*yukarýdaki trigger çalýþýyor mu bunu kontrol etmek için yeni bir iþ oluþturuyorum*/
-- daha sonrasýnda iþ i sefere gönderip yola çýkarýð geri getireceðim ve ayný zamanda sýra iþini halletti mi kontrol edeceðim
-- iþ kýsmýný tablo üzerinden oluþturuyorum geri kalanýný buradan halledeceðim
-- iþ ýd miz iki

--DROP TRIGGER trg_SeferDurumGuncelle

-- SEFER BAÞLADIÐI AN GEÇERLÝ ÝÞÝN DURUM KISMINI ALINDI YAPTIK
/*CREATE TRIGGER is_Alindi_Mi_Guncelle
ON tbl_Sefer
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @SeferCikisTarihi date;

	select @SeferCikisTarihi = tbl_Sefer.sefer_Cikis_Tarihi from tbl_Sefer
    -- Ýþ eklendiðinde JobTaken 'Evet' olarak güncellenir
    UPDATE tbl_Is
    SET is_Alindi_Mi = 'Alýndý', is_Alinma_Tarihi = @SeferCikisTarihi
    where is_ID  IN (
        SELECT is_ID FROM INSERTED
    )
END;*/

--drop trigger is_Alindi_Mi_Guncelle

-- SEFERE ÇIKAN ÞOFÜRUN SIRA DURUMUNU ONTRIP YAPTIK
--CREATE TRIGGER sira_Guncelle
--on tbl_Sefer
--After INSERT
--as
--begin
--	SET NOCOUNT ON;
--	-- sefer tablosuna soforun id si gidince sira tablosunda onTrip yapacak
--	update tbl_Sira
--	set sira_Statu = 'onTrip'
--	where sofor_ID IN (
--		SELECT sofor_ID FROM INSERTED) and sira_Statu = 'Waiting'
--END;

--

-- SEFER TABLOSUNDA GÜNCELLEME OLDUÐU ZAMAN ÞOFÖRÜN SIRA DURUMUNU COMPLETED YAPACAÐIZ VE SONUNA EKLEYECEÐÝZ SONRASINDA DA GEÇERLÝ ÝÞ DURUMU TAMAMLANDI OLARAK DEÐÝÞECEK

--CREATE TRIGGER sira_Is_Durum_Guncelle
--on tbl_Sefer
--After Update
--As BEGIN
--		SET NOCOUNT ON;
--		-- Sefer tablosundaki güncellenen kayýtlarý al
--		DECLARE @SeferDurum NVARCHAR(50), @IsID INT, @SoforID INT, @SeferDonusTarihi date;

--		SELECT @SeferDurum = tbl_Sefer.sefer_Durumu,
--           @IsID = tbl_Sefer.ýs_ID,
--           @SoforID = tbl_Sefer.sofor_ID,
--		   @SeferDonusTarihi = tbl_Sefer.sefer_Donus_Tarihi
--		FROM tbl_Sefer;

--		IF @SeferDurum = 'Tamamlandý'
--		BEGIN
--			update tbl_Sira
--			set sira_Statu = 'Completed'
--			where sofor_ID = @SoforID and sira_Statu = 'onTrip'

--			insert into tbl_Sira (sofor_ID, sira_No,sira_Statu)
--			values (@SoforID,(select MAX(sira_no)+1 from tbl_Sira),'Waiting')

--			update tbl_Is
--			set is_Alindi_Mi = 'Tamamlandý', is_Tamamlanma_Tarihi = @SeferDonusTarihi
--			where is_ID = @IsID and is_Alindi_Mi = 'Alýndý'
--			END
--END;

--drop trigger sira_Is_Durum_Guncelle

select * from tbl_Is
select * from tbl_Sira

--insert into tbl_Sefer (ýs_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
--values (2,3,'2024-12-03','Yolda')

select * from tbl_Sefer

update tbl_Sefer
set sefer_Durumu = 'Tamamlandý', sefer_Donus_Tarihi = '2024-12-03'
where sofor_ID = 2 

/* triggerler doðru çalýþýyor mu kontrol çin baþtan iþ oluþturup durumu kontrol ediyorum. iþ kýsmýný tablodan elle dolduruyorum*/

-- SEFER OLUÞTURUYORUM SOFOR ID = 4 GELDÝ VAR SAYDIM

insert into tbl_Sefer (ýs_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
values (3,4,'2024-12-04','Yolda')

update tbl_Sefer
set sefer_Donus_Tarihi = '2024-12-05', sefer_Durumu = 'Tamamlandý'
where sofor_ID = 4 and sefer_Durumu = 'Yolda'

select sofor_ID from tbl_Sira where sofor_ID = 4 and sira_Statu = 'Waiting'

select sofor_Ad_Soyad as 'Þoförler' from gidecek_Sofor

select sofor_Ad_Soyad as 'þoförler', sofor_ID from gidecek_Sofor

SELECT name
FROM sys.triggers

insert into tbl_Sefer (ýs_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
values (2,6,'2024-12-06','Yolda')


select * from tbl_Sefer 

select * from tbl_Is
select * from tbl_Sira

CREATE TRIGGER is_Sirasýna_Ekleme
ON tbl_Is
AFTER INSERT
AS
BEGIN
    -- Yeni eklenen kaydýn ID'sini tbl_Is_Sirasi tablosuna ekle
    INSERT INTO tbl_Is_Sirasi (is_ID, sira_No, sira_Statu)
    SELECT 
        i.is_ID, -- tbl_Is tablosundaki yeni eklenen satýrýn ID'si
        ISNULL((SELECT MAX(sira_No) FROM tbl_Is_Sirasi), 0) + 1, -- Mevcut maksimum Sira_No deðerini al ve 1 artýr
        'Hayýr' -- Baþlangýç deðeri "Hayýr" olarak ayarla
    FROM 
        INSERTED i -- INSERTED sanal tablosu, yeni eklenen satýrlarý içerir
END;

select * from tbl_Is_Sirasi

insert into tbl_Is(is_Cikis_Birimi,is_Varis_Birimi,tasinacak_Yuk,is_Alindi_Mi)
values('konya','denizli','buðday','Hayýr')

-- iþ silinince çalýþacak trigger iþ silme triggeri yerine iki tane sorgu çalýþsýn önce iþin id sine ait olan sira satýrýný bulup silsin sonra da gitsin o iþi silsin güncelleme için trigger yazýlsýn
-- iþ güncellenince çalýþacak trigger yani iþ tamamlandýðýnda burada da tamamlandý olmalý ya da iþ alýndýysa gene burada alýndý olmalý ki alýnacaklar listesinde görünmesin

create trigger is_Sirasi_Statu_Guncelle
on tbl_Is
after update
as begin
	SET NOCOUNT ON;
	 DECLARE @isID INT, @isAlindiMi NVARCHAR(20);

    SELECT @isID = i.is_ID, 
           @isAlindiMi = i.is_Alindi_Mi 
    FROM INSERTED i;

    -- Eðer 'Is_Alindi_Mi' deðeri 'Alýndý' olarak güncellenmiþse
    IF @isAlindiMi = 'Alýndý'
    BEGIN
        UPDATE tbl_Is_Sirasi
        SET Sira_Statu = @isAlindiMi
        WHERE is_ID = @isID;
    END;

end;

--drop trigger is_Sirasi_Statu_Guncelle


select * from tbl_Is_Sirasi

update tbl_Is set is_Alindi_Mi = 'Alýndý' where is_ID = 4



-- iþ silme kýsmý için manuel yazacaðýz çünkü önce sýra tablosundan silinecek sonra iþ tablosundan silinecek

select * from Bekleyen_Isler

insert into tbl_Is(is_Cikis_Birimi,is_Varis_Birimi,tasinacak_Yuk,is_Olusturma_Tarihi,is_Alindi_Mi,is_Olusturan_Yetkili_ID)
values('istanbul','Konya','Balýk','2024-12-13','Hayýr',1)

select * from gidecek_Sofor 

select MIN(sira_No) from Bekleyen_Isler

CREATE TRIGGER sofor_Siraya_Ekle
ON tbl_Sofor
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- tbl_Sira tablosundaki mevcut en büyük sira_No'yu al
    DECLARE @maxSiraNo INT;
    SELECT @maxSiraNo = ISNULL(MAX(sira_No), 0) FROM tbl_Sira;

    -- Yeni eklenen sofor_ID'yi al
    DECLARE @soforID INT;
    SELECT @soforID = sofor_ID FROM inserted;

    -- tbl_Sira tablosuna yeni kayýt ekle
    INSERT INTO tbl_Sira (sofor_ID, sira_No, sira_Statu)
    VALUES (@soforID, @maxSiraNo + 1, 'Waiting');
END;

select * from tbl_Sira

CREATE TRIGGER sofor_Inaktif_Sira_Guncelle
ON tbl_Sofor
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Sadece AktifMi sütununda yapýlan deðiþikliklere tepki vermek için kontrol
    IF UPDATE(aktif_Mi)
    BEGIN
        -- Inaktif yapýlan þoförlerin ID'lerini al
        UPDATE tbl_Sira
        SET sira_Statu = 'Completed'
        WHERE sofor_ID IN (
            SELECT sofor_ID
            FROM inserted
            WHERE aktif_Mi = 0
        );
    END
END;

select * from tbl_Sira

update tbl_Sofor set aktif_Mi = 0 where sofor_ID = 7