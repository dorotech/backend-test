SET IDENTITY_INSERT [Books] ON
GO

INSERT INTO [Books]([Id],[Title],[Author],[Language],[Edition],[Pages],[Publishing],
[ISBN10],[ISBN13],[DimensionLength],[DimensionHeight],[DimensionWidth])
VALUES
(1,
'O verdadeiro criador de tudo: Como o c�rebro humano esculpiu o universo como n�s o conhecemos',
'Miguel Nicolelis', 'Portugu�s', 1, 400, 'Editora Cr�tica', '6555350288', '978-6555350289', 22.8, 15.2, 1.8)
,
(2,
'Made In Maca�ba',
'Miguel Nicolelis', 'Portugu�s', 1, 312, 'Editora Cr�tica', '8542206894', '978-8542206890', 22.6, 15.8, 2)
,
(3,
'Prazer Em Conhecer. A Aventura Da Ci�ncia E Da Educa��o',
'Gilberto Nicolelis; Miguel Dimenstein', 
'Portugu�s', 1, 112, 'Editora Papirus', '8561773030', '978-8561773038', 20.83, 13.72, 1.02)
GO

SET IDENTITY_INSERT [Books] OFF
GO