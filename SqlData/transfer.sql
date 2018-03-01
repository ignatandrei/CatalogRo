-- Script Date: 3/1/2018 11:52 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Format] (
  [IDFormat] INTEGER  NOT NULL
, [Nume] nvarchar(150)  NOT NULL
, [EnglishName] nvarchar(150)  NULL
, CONSTRAINT [PK_Format] PRIMARY KEY ([IDFormat])
);
CREATE TABLE [Categorie] (
  [IDCategorie] INTEGER  NOT NULL
, [Nume] nvarchar(150)  NOT NULL
, [Parent] int  NULL
, [EnglishName] nvarchar(150)  NULL
, CONSTRAINT [PK_Categorie] PRIMARY KEY ([IDCategorie])
, FOREIGN KEY ([Parent]) REFERENCES [Categorie] ([IDCategorie]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO [Format] ([IDFormat],[Nume],[EnglishName]) VALUES (
1,'PDF',NULL);
INSERT INTO [Format] ([IDFormat],[Nume],[EnglishName]) VALUES (
2,'JPG',NULL);
INSERT INTO [Format] ([IDFormat],[Nume],[EnglishName]) VALUES (
3,'TXT',NULL);
INSERT INTO [Categorie] ([IDCategorie],[Nume],[Parent],[EnglishName]) VALUES (
1,'Beletristica',NULL,NULL);
INSERT INTO [Categorie] ([IDCategorie],[Nume],[Parent],[EnglishName]) VALUES (
2,'Poezie',1,NULL);
INSERT INTO [Categorie] ([IDCategorie],[Nume],[Parent],[EnglishName]) VALUES (
3,'Drama',2,NULL);
INSERT INTO [Categorie] ([IDCategorie],[Nume],[Parent],[EnglishName]) VALUES (
4,'Altele',NULL,NULL);
INSERT INTO [Categorie] ([IDCategorie],[Nume],[Parent],[EnglishName]) VALUES (
5,'Eseu',4,NULL);
INSERT INTO [Categorie] ([IDCategorie],[Nume],[Parent],[EnglishName]) VALUES (
6,'Cronica',4,NULL);
COMMIT;

