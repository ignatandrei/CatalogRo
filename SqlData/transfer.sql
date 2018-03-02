-- Script Date: 3/2/2018 11:40 AM  - ErikEJ.SqlCeScripting version 3.5.2.75
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [ResursaDict] (
  [ID] bigint  NOT NULL
, [Nume] nvarchar(50)  NOT NULL
, [Valoare] nvarchar(50)  NOT NULL
, [TableValue] nvarchar(50)  NULL
, CONSTRAINT [PK_ResursaDict] PRIMARY KEY ([ID])
);
CREATE TABLE [ResursaAlternativa] (
  [Id] uniqueidentifier NOT NULL
, [IdResursa] uniqueidentifier NOT NULL
, [Titlu] nvarchar(500)  NULL
, [Autor] nvarchar(500)  NULL
, [Descriere] ntext NULL
, [Subiect] nvarchar(2000)  NULL
, [Format] int  NULL
, [UrlResursa] nvarchar(500)  NULL
, [Url2Resursa] nvarchar(500)  NULL
, [Contributor] nvarchar(500)  NULL
, [IDEntuziast] int  NOT NULL
, [DataIntroducere] datetime current_timestamp NOT NULL
);
CREATE TABLE [Format] (
  [IDFormat] INTEGER  NOT NULL
, [Nume] nvarchar(150)  NOT NULL
, [EnglishName] nvarchar(150)  NULL
, CONSTRAINT [PK_Format] PRIMARY KEY ([IDFormat])
);
CREATE TABLE [Entuziast] (
  [Id] bigint  NOT NULL
, [Nume] nvarchar(500)  NULL
, [Prenume] nvarchar(500)  NULL
, [Email] nvarchar(500)  NULL
, [Telefon] nvarchar(500)  NULL
, [Note] nvarchar(500)  NULL
, [Validat] bit NOT NULL
, [Parola] ntext NOT NULL
, CONSTRAINT [PK_Entuziast] PRIMARY KEY ([Id])
);
CREATE TABLE [ResursaInregistrare] (
  [IDEntuziast] bigint  NOT NULL
, [UniqueID] uniqueidentifier NOT NULL
, [DataIntroducere] datetime current_timestamp NOT NULL
, CONSTRAINT [PK_ResursaInregistrare] PRIMARY KEY ([UniqueID])
, FOREIGN KEY ([IDEntuziast]) REFERENCES [Entuziast] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [ResursaValoare] (
  [Valoare] nchar(10)  NULL
, [IDResursaDict] bigint  NOT NULL
, [UniqueID] uniqueidentifier NOT NULL
, CONSTRAINT [PK_ResursaValoare] PRIMARY KEY ([IDResursaDict],[UniqueID])
, FOREIGN KEY ([IDResursaDict]) REFERENCES [ResursaDict] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([UniqueID]) REFERENCES [ResursaInregistrare] ([UniqueID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Categorie] (
  [IDCategorie] INTEGER  NOT NULL
, [Nume] nvarchar(150)  NOT NULL
, [Parent] int  NULL
, [EnglishName] nvarchar(150)  NULL
, CONSTRAINT [PK_Categorie] PRIMARY KEY ([IDCategorie])
, FOREIGN KEY ([Parent]) REFERENCES [Categorie] ([IDCategorie]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Resursa] (
  [ID] uniqueidentifier NOT NULL
, [Titlu] nvarchar(500)  NOT NULL
, [Autor] nvarchar(500)  NOT NULL
, [Categorie] int  NOT NULL
, [Descriere] ntext NOT NULL
, [Subiect] nvarchar(2000)  NOT NULL
, [Format] int  NOT NULL
, [UrlResursa] nvarchar(500)  NULL
, [Url2Resursa] nvarchar(500)  NULL
, [Note] ntext NULL
, CONSTRAINT [PK_Resursa] PRIMARY KEY ([ID])
, FOREIGN KEY ([Categorie]) REFERENCES [Categorie] ([IDCategorie]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([Format]) REFERENCES [Format] ([IDFormat]) ON DELETE NO ACTION ON UPDATE NO ACTION
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

INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(1,'Resursa','Titlu',NULL);
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(2,'Resursa','Autor',NULL);
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(3,'Resursa','Categorie','Categorie');
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(4,'Resursa','Descriere',NULL);
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(5,'Resursa','Subiect',NULL);
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(6,'Resursa','Format','Format');
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(7,'Resursa','UrlResursa',NULL);
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(8,'Resursa','Url2Resursa',NULL);
INSERT INTO [ResursaDict]([ID],[Nume],[Valoare],[TableValue])VALUES(9,'Resursa','Note',NULL);

COMMIT;

