CREATE TABLE [dbo].[Personendaten]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Vorname] NVARCHAR(50) NOT NULL, 
    [Nachname] NVARCHAR(50) NOT NULL, 
    [Geburtsdatum] DATE NOT NULL, 
    [Adresse] NVARCHAR(50) NOT NULL, 
    [PLZ] INT NOT NULL, 
    [Ort] NVARCHAR(50) NOT NULL, 
    [Tel.:] NVARCHAR(50) NOT NULL, 
    [E-Mail] NVARCHAR(50) NOT NULL, 
    [Beitrittsdatum] DATE NOT NULL, 
    [Mitgliedsschaftskategorie] NVARCHAR(50) NOT NULL, 
    [Bezahlmethode] NVARCHAR(50) NOT NULL, 
    [Notiz] TEXT NULL, 

    
)
