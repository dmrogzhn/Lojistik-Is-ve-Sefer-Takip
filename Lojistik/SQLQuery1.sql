/* diyelim ki seferden adam d�nd�*/
/* olmas� gereken olaylar �unlar:
	ilk etapta s�rada status durumu hepsinin waiting oldu
	sefer durumu: tamamland�
	sefer d�n�� tarihi eklenecek
	seferden gelen adam s�ran�n sonuna eklenecek ve status k�sm� waiting olacak

*/
/*kart� okuttu�umuzda �of�r tablosundan 1 �d si geldi var say�yoruz*/

/* kart� d�n�nce okuttu�unda �al��mas� gereken kod*/
update tbl_Sefer set sefer_Durumu = 'Tamamland�', sefer_Donus_Tarihi = '2024-12-3' where sofor_ID = 1 /* sefer tablosundaki durum ve tarih k�sm�n� hallettik*/
select * from tbl_Sefer

insert into tbl_Sira (sofor_ID,sira_No,sira_Statu)
values (1,(select MAX(sira_no)+1 from tbl_Sira),'Waiting')
select * from tbl_Sira

/*her �eyi elimizle yap�yoru*/

/*adam geldi ad�n� se�ti i�i se�ti ve kart� okuttu karttan gelen id de�eri 2 olsun*/
/* hala 1 numaral� i�imiz duruyor*/

insert into tbl_Sefer(�s_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
values (1,2,'2024-12-02','Devam')
select * from tbl_Sefer
/*seferimiz olu�tu*/
/*art�k bu adam�n s�ra tablosundaki status k�sm� waiting de�il onTrip yani yolda yapca��z*/
/*adam�n kart� okuttu�u anda asl�nda kendi �d sindeki en son waiting olan s�ra �d sini bulup bunu on trip yaparsak tamamd�r bu i�*/
select * from tbl_Sira where sofor_ID = 2 and sira_Statu ='Waiting' /* and yazd���m�z zaman iki ko�ulu da sa�lamak zorunda ve e�er sistem do�ru �al���yorsa ge�erli �d ye ait sadece bir adet waiting kayd� olmal� biz de onu onTrip yapaca��z*/
update tbl_Sira set sira_Statu = 'onTrip' where sofor_ID = 2 and sira_Statu = 'Waiting'
select * from tbl_Sira
/*adam art�k yolda yan� s�ra tablosunda yolda g�r�n�yor ve biz de ona g�re renkleri ayarlar�z adam gelince de completed yapar�z ve s�raya yeniden ekler waiting yapar�z*/
/* adam geldi ve kart�n� okuttu karttan da 2 �d si geldi*/
/*biz bu adam�n sefer tablosunda hi� sefer_durumu 'devam' olan seferi var m� ona bakaca��z o seferin �d sini al�p durum k�sm�n� tamamland� yapaca��z*/
/*e�er sistem do�ru �al���yorsa zaten o adam�n sefer tablosunda 1 tane devam durumunda seferi vard�r o y�zden and ile ��zeriz ama kodda seferin olup olmama durumunu da kontrol et yani �yle bir sefer yoksa yani adam durduk yere kart� okuttuysa uyar� versin*/
update tbl_Sefer set sefer_Donus_Tarihi = '2024-12-03', sefer_Durumu = 'Tamamland�' where sofor_ID = 2 and sefer_Durumu = 'Devam'
select * from tbl_Sefer
/* s�ra tablosunda bu adam�n �d sini ve onTrip olan sat�r� al�p onu completed yap�p sonra bu adam� s�ran�n en sonuna eklememiz laz�m*/
update tbl_Sira set sira_Statu = 'Completed' where sofor_ID = 2  and sira_Statu ='onTrip'
select * from tbl_Sira
/*�imdi de s�ran�n sonuna ekleyelim*/

insert into tbl_Sira (sofor_ID,sira_No,sira_Statu)
values(2,(select Max(sira_No)+1 from tbl_Sira),'Waiting')
select * from tbl_Sira

update tbl_Sira set sira_Statu = 'Completed' where sira_ID = 1

select * from tbl_Sira where sira_Statu = 'Waiting' or sira_Statu = 'onTrip'

/*a�a��daki kod i� al�nd� m� k�sm�n�n sefer tablosuna g�re otomatik hareketini kontrol eder. yani olu�turulmu� ama daha sefere ��kmam�� i�, sefere ��kt��� zaman i�_al�nd� m� k�sm�n� evet olarak ayarlar. sonra i� id sinin oldu�u seferdeki sefer_durumu tamamland� oldu�unda i� tablosunda i�_al�nd� m� k�sm� tamamland� olur ve hali haz�rda listelenecek i�lerde g�r�nmez*/

/*

-- �� al�nd� m� s�tununu g�ncelleyen trigger
CREATE TRIGGER UpdateJobStatusOnInsert
ON Trips
AFTER INSERT
AS
BEGIN
    -- �� eklendi�inde JobTaken 'Evet' olarak g�ncellenir
    UPDATE Jobs
    SET JobTaken = 'Yes'
    FROM Jobs j
    INNER JOIN Inserted i ON j.JobID = i.JobID;
END;

-- Sefer durumu tamamland���nda JobTaken 'Tamamland�' olarak g�ncelleyen trigger
CREATE TRIGGER UpdateJobStatusOnComplete
ON Trips
AFTER UPDATE
AS
BEGIN
    -- E�er sefer durumu 'Tamamland�' ise
    UPDATE Jobs
    SET JobTaken = 'Completed'
    FROM Jobs j
    INNER JOIN Inserted i ON j.JobID = i.JobID
    WHERE i.TripStatus = 'Completed';
END;

*/

/*
-- Sefer tablosu i�in trigger olu�tur
CREATE TRIGGER trg_SeferDurumGuncelle
ON tbl_Sefer
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Sefer tablosundaki g�ncellenen kay�tlar� al
    DECLARE @SeferDurum NVARCHAR(50), @IsID INT, @SoforID INT;

    SELECT @SeferDurum = tbl_Sefer.sefer_Durumu,
           @IsID = tbl_Sefer.�s_ID,
           @SoforID = tbl_Sefer.sofor_ID
    FROM tbl_Sefer;

    -- Sefer_Durum 'yolda' olarak g�ncellendi�inde �� tablosunda Is_Alindi_Mi s�tununu g�ncelle
    IF @SeferDurum = 'Yolda'
    BEGIN
        UPDATE tbl_Is
        SET is_Alindi_Mi = 'Al�nd�'
        WHERE is_ID = @IsID;

        UPDATE tbl_Sira
        SET sira_Statu = 'onTrip'
        WHERE sofor_ID = @SoforID and sira_Statu = 'Waiting';
    END

    -- Sefer_Durum 'tamamland�' olarak g�ncellendi�inde �� ve S�ra tablolar�n� g�ncelle
    IF @SeferDurum = 'Tamamland�'
    BEGIN
        UPDATE tbl_Is
        SET is_Alindi_Mi = 'Tamamland�'
        WHERE is_ID = @IsID;

        UPDATE tbl_Sira
        SET sira_Statu = 'completed'
        WHERE sofor_ID = @SoforID and sira_Statu = 'onTrip';
    END
END;
GO
*/

/*yukar�daki trigger �al���yor mu bunu kontrol etmek i�in yeni bir i� olu�turuyorum*/
-- daha sonras�nda i� i sefere g�nderip yola ��kar�� geri getirece�im ve ayn� zamanda s�ra i�ini halletti mi kontrol edece�im
-- i� k�sm�n� tablo �zerinden olu�turuyorum geri kalan�n� buradan halledece�im
-- i� �d miz iki

--DROP TRIGGER trg_SeferDurumGuncelle

-- SEFER BA�LADI�I AN GE�ERL� ���N DURUM KISMINI ALINDI YAPTIK
/*CREATE TRIGGER is_Alindi_Mi_Guncelle
ON tbl_Sefer
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @SeferCikisTarihi date;

	select @SeferCikisTarihi = tbl_Sefer.sefer_Cikis_Tarihi from tbl_Sefer
    -- �� eklendi�inde JobTaken 'Evet' olarak g�ncellenir
    UPDATE tbl_Is
    SET is_Alindi_Mi = 'Al�nd�', is_Alinma_Tarihi = @SeferCikisTarihi
    where is_ID  IN (
        SELECT is_ID FROM INSERTED
    )
END;*/

--drop trigger is_Alindi_Mi_Guncelle

-- SEFERE �IKAN �OF�RUN SIRA DURUMUNU ONTRIP YAPTIK
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

-- SEFER TABLOSUNDA G�NCELLEME OLDU�U ZAMAN �OF�R�N SIRA DURUMUNU COMPLETED YAPACA�IZ VE SONUNA EKLEYECE��Z SONRASINDA DA GE�ERL� �� DURUMU TAMAMLANDI OLARAK DE���ECEK

--CREATE TRIGGER sira_Is_Durum_Guncelle
--on tbl_Sefer
--After Update
--As BEGIN
--		SET NOCOUNT ON;
--		-- Sefer tablosundaki g�ncellenen kay�tlar� al
--		DECLARE @SeferDurum NVARCHAR(50), @IsID INT, @SoforID INT, @SeferDonusTarihi date;

--		SELECT @SeferDurum = tbl_Sefer.sefer_Durumu,
--           @IsID = tbl_Sefer.�s_ID,
--           @SoforID = tbl_Sefer.sofor_ID,
--		   @SeferDonusTarihi = tbl_Sefer.sefer_Donus_Tarihi
--		FROM tbl_Sefer;

--		IF @SeferDurum = 'Tamamland�'
--		BEGIN
--			update tbl_Sira
--			set sira_Statu = 'Completed'
--			where sofor_ID = @SoforID and sira_Statu = 'onTrip'

--			insert into tbl_Sira (sofor_ID, sira_No,sira_Statu)
--			values (@SoforID,(select MAX(sira_no)+1 from tbl_Sira),'Waiting')

--			update tbl_Is
--			set is_Alindi_Mi = 'Tamamland�', is_Tamamlanma_Tarihi = @SeferDonusTarihi
--			where is_ID = @IsID and is_Alindi_Mi = 'Al�nd�'
--			END
--END;

--drop trigger sira_Is_Durum_Guncelle

select * from tbl_Is
select * from tbl_Sira

--insert into tbl_Sefer (�s_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
--values (2,3,'2024-12-03','Yolda')

select * from tbl_Sefer

update tbl_Sefer
set sefer_Durumu = 'Tamamland�', sefer_Donus_Tarihi = '2024-12-03'
where sofor_ID = 2 

/* triggerler do�ru �al���yor mu kontrol �in ba�tan i� olu�turup durumu kontrol ediyorum. i� k�sm�n� tablodan elle dolduruyorum*/

-- SEFER OLU�TURUYORUM SOFOR ID = 4 GELD� VAR SAYDIM

insert into tbl_Sefer (�s_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
values (3,4,'2024-12-04','Yolda')

update tbl_Sefer
set sefer_Donus_Tarihi = '2024-12-05', sefer_Durumu = 'Tamamland�'
where sofor_ID = 4 and sefer_Durumu = 'Yolda'

select sofor_ID from tbl_Sira where sofor_ID = 4 and sira_Statu = 'Waiting'

select sofor_Ad_Soyad as '�of�rler' from gidecek_Sofor

select sofor_Ad_Soyad as '�of�rler', sofor_ID from gidecek_Sofor

SELECT name
FROM sys.triggers

insert into tbl_Sefer (�s_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu)
values (2,6,'2024-12-06','Yolda')


select * from tbl_Sefer 

select * from tbl_Is
select * from tbl_Sira

CREATE TRIGGER is_Siras�na_Ekleme
ON tbl_Is
AFTER INSERT
AS
BEGIN
    -- Yeni eklenen kayd�n ID'sini tbl_Is_Sirasi tablosuna ekle
    INSERT INTO tbl_Is_Sirasi (is_ID, sira_No, sira_Statu)
    SELECT 
        i.is_ID, -- tbl_Is tablosundaki yeni eklenen sat�r�n ID'si
        ISNULL((SELECT MAX(sira_No) FROM tbl_Is_Sirasi), 0) + 1, -- Mevcut maksimum Sira_No de�erini al ve 1 art�r
        'Hay�r' -- Ba�lang�� de�eri "Hay�r" olarak ayarla
    FROM 
        INSERTED i -- INSERTED sanal tablosu, yeni eklenen sat�rlar� i�erir
END;

select * from tbl_Is_Sirasi

insert into tbl_Is(is_Cikis_Birimi,is_Varis_Birimi,tasinacak_Yuk,is_Alindi_Mi)
values('konya','denizli','bu�day','Hay�r')

-- i� silinince �al��acak trigger i� silme triggeri yerine iki tane sorgu �al��s�n �nce i�in id sine ait olan sira sat�r�n� bulup silsin sonra da gitsin o i�i silsin g�ncelleme i�in trigger yaz�ls�n
-- i� g�ncellenince �al��acak trigger yani i� tamamland���nda burada da tamamland� olmal� ya da i� al�nd�ysa gene burada al�nd� olmal� ki al�nacaklar listesinde g�r�nmesin

create trigger is_Sirasi_Statu_Guncelle
on tbl_Is
after update
as begin
	SET NOCOUNT ON;
	 DECLARE @isID INT, @isAlindiMi NVARCHAR(20);

    SELECT @isID = i.is_ID, 
           @isAlindiMi = i.is_Alindi_Mi 
    FROM INSERTED i;

    -- E�er 'Is_Alindi_Mi' de�eri 'Al�nd�' olarak g�ncellenmi�se
    IF @isAlindiMi = 'Al�nd�'
    BEGIN
        UPDATE tbl_Is_Sirasi
        SET Sira_Statu = @isAlindiMi
        WHERE is_ID = @isID;
    END;

end;

--drop trigger is_Sirasi_Statu_Guncelle


select * from tbl_Is_Sirasi

update tbl_Is set is_Alindi_Mi = 'Al�nd�' where is_ID = 4



-- i� silme k�sm� i�in manuel yazaca��z ��nk� �nce s�ra tablosundan silinecek sonra i� tablosundan silinecek

select * from Bekleyen_Isler

insert into tbl_Is(is_Cikis_Birimi,is_Varis_Birimi,tasinacak_Yuk,is_Olusturma_Tarihi,is_Alindi_Mi,is_Olusturan_Yetkili_ID)
values('istanbul','Konya','Bal�k','2024-12-13','Hay�r',1)

select * from gidecek_Sofor 

select MIN(sira_No) from Bekleyen_Isler

CREATE TRIGGER sofor_Siraya_Ekle
ON tbl_Sofor
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- tbl_Sira tablosundaki mevcut en b�y�k sira_No'yu al
    DECLARE @maxSiraNo INT;
    SELECT @maxSiraNo = ISNULL(MAX(sira_No), 0) FROM tbl_Sira;

    -- Yeni eklenen sofor_ID'yi al
    DECLARE @soforID INT;
    SELECT @soforID = sofor_ID FROM inserted;

    -- tbl_Sira tablosuna yeni kay�t ekle
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

    -- Sadece AktifMi s�tununda yap�lan de�i�ikliklere tepki vermek i�in kontrol
    IF UPDATE(aktif_Mi)
    BEGIN
        -- Inaktif yap�lan �of�rlerin ID'lerini al
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