DROP TABLE Personne;
DROP TABLE Actualite;
DROP TABLE ImageCommerce;
DROP TABLE Commerce;
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

CREATE TABLE Categorie(
	IdCategorie int IDENTITY(1,1) PRIMARY KEY,
	Libelle varchar(30) NOT NULL
);

INSERT INTO Categorie (Libelle) VALUES ('Restaurant');
INSERT INTO Categorie (Libelle) VALUES ('Commerce');

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
	FOREIGN KEY (IdPersonne) REFERENCES Personne(IdPersonne),
	FOREIGN KEY (IdCategorie) REFERENCES Categorie(IdCategorie)
);
/*Il faut d'abord insérer les catégories pour que ca marche !!!*/

INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail) VALUES ('Burger King', 'Rue du Burger King', 26, 'Restauration rapide', 'Whooper', 'info@Burger-King.com');
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail) VALUES ('Quick', 'Rue du Quick', 123, 'Restauration rapide', 'Giant', 'info@Quick.com');
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail) VALUES ('KFC', 'Rue du KFC', 17, 'Restauration rapide', 'Saut de poulet','info@KFC.com');
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail) VALUES ('MacDo', 'Rue du MacDo', 63, 'Restauration rapide', 'Big Mac', 'info@MacDo.com');

INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, AdresseMail) VALUES ('Foot Locker', 'Rue du Foot Locker', 1, 'Magasin de chaussures', 'info@Foot-Locker.com');
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail) VALUES ('Zara', 'Rue du Zara', 74, 'Magasin de vétements', 'Echarpe Hiver', 'info@Zara.com');
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, AdresseMail) VALUES ('Zeeman', 'Rue du Zeeman', 416, 'Plus grande chaine de magasin en belgique', 'info@Zeeman.com');
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail) VALUES ('Sixt', 'Rue du Sixt', 50, 'Location de voitures', 'Mercedes AMG', 'info@Sixt.com');

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
	HoraireFin dateTime NOT NULL
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