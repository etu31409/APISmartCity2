DROP TABLE Actualite;
DROP TABLE ImageCommerce;
DROP TABLE Commerce;
DROP TABLE Personne;
DROP TABLE Categorie;
DROP TABLE Horaire;

CREATE TABLE Personne(
	IdPersonne int IDENTITY(1,1) PRIMARY KEY,
	Nom varchar(30) NOT NULL,
	Prenom varchar(30) NOT NULL,
	Mail varchar(30) NOT NULL,
	EstCommercant tinyint,
	NumeroTelephone int,
	MotDePasse varchar(60) NOT NULL,
);

INSERT INTO Personne (Nom, Prenom, Mail, MotDePasse) VALUES ('doe', 'jane', 'janedoe@mail.com','123'); 
INSERT INTO Personne (Nom, Prenom, Mail, MotDePasse) VALUES ('doe', 'john', 'johndoe@mail.com','456'); 

CREATE TABLE Categorie(
	IdCategorie int IDENTITY(1,1) PRIMARY KEY,
	Libelle varchar(30) NOT NULL
);

INSERT INTO Categorie (Libelle) VALUES ('Restaurant');
INSERT INTO Categorie (Libelle) VALUES ('Commerce');
INSERT INTO Categorie (Libelle) VALUES ('Bar');

CREATE TABLE Commerce(
	IdCommerce int IDENTITY(1,1) PRIMARY KEY,
	NomCommerce varchar(30) NOT NULL,
	Rue varchar(30) NOT NULL,
	Numero int NOT NULL,
	Description varchar(255),
	ProduitPhare varchar(50),
	ParcoursProduitPhare varchar(30),
	NumeroGsm int,
	NumeroFixe int,
	AdresseMail varchar(50) NOT NULL,
	UrlPageFacebook varchar(30),
	Longitude int,
	Latitude int,
	IdCategorie int,
	IdPersonne int,
	RowVersion timestamp,
	FOREIGN KEY (IdPersonne) REFERENCES Personne(IdPersonne),
	FOREIGN KEY (IdCategorie) REFERENCES Categorie(IdCategorie)
);
/*Il faut d'abord insérer les catégories pour que ca marche !!!*/

INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('Burger King', 'Rue du Burger King', 26, 'Restauration rapide', 'Whooper', 'info@Burger-King.com',1,1);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('Quick', 'Rue du Quick', 123, 'Restauration rapide', 'Giant', 'info@Quick.com',2,1);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('KFC', 'Rue du KFC', 17, 'Restauration rapide', 'Saut de poulet','info@KFC.com',2,1);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('MacDo', 'Rue du MacDo', 63, 'Restauration rapide', 'Big Mac', 'info@MacDo.com',1,1);

INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, AdresseMail, IdPersonne, IdCategorie) VALUES ('Foot Locker', 'Rue du Foot Locker', 1, 'Magasin de chaussures', 'info@Foot-Locker.com',1,2);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('Zara', 'Rue du Zara', 74, 'Magasin de vétements', 'Echarpe Hiver', 'info@Zara.com',1,2);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, AdresseMail, IdPersonne, IdCategorie) VALUES ('Zeeman', 'Rue du Zeeman', 416, 'Plus grande chaine de magasin en belgique', 'info@Zeeman.com',2,2);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('Sixt', 'Rue du Sixt', 50, 'Location de voitures', 'Mercedes AMG', 'info@Sixt.com',2,2);

INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, AdresseMail, IdPersonne, IdCategorie) VALUES ('Barnabeer', 'Rue du Barnabeer', 1, 'Plus grand bar de namur', 'info@Barnabeer.com',1,3);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('Green Fairy', 'Rue du green', 74, 'Bar qui rend hommage a green lantern', 'Pinte de 50 à moitié prix', 'info@green-fairy.com',1,3);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, AdresseMail, IdPersonne, IdCategorie) VALUES ('Au nom de la rose', 'Rue du bar', 416, 'Bar / kot a projet', 'info@ANDLR.com',2,3);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdPersonne, IdCategorie) VALUES ('Etoile', 'Rue magique', 50, 'Petit bar rustique qui propose des parties de billard', 'Chimay bleu', 'info@etoiles.com',2,3);

CREATE TABLE ImageCommerce(
	idImageCommerce int IDENTITY(1,1) PRIMARY KEY,
	Url varchar(255),
	IdCommerce int,
	FOREIGN KEY (IdCommerce) REFERENCES Commerce(IdCommerce)
);

CREATE TABLE Horaire(
	IdHoraire int IDENTITY(1,1) PRIMARY KEY,
	Libelle varchar(30) NOT NULL,
	HoraireDebut dateTime NOT NULL,
	HoraireFin dateTime NOT NULL,
	RowVersion timestamp,
);

CREATE TABLE Actualite(
	IdActualite int IDENTITY(1,1) PRIMARY KEY,
	Libelle varchar(30) NOT NULL,
	Texte varchar(30),
	Date date,
	IdCommerce int,
	IdSiteTouristique int,
	FOREIGN KEY (IdCommerce) REFERENCES Commerce(IdCommerce)
);