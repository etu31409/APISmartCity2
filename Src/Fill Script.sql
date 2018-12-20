INSERT INTO Users (UserName, Email, [Password]) VALUES ('janedoe', 'janedoe@mail.com','123'); 
INSERT INTO Users (UserName, Email, [Password]) VALUES ('johndoe', 'johndoe@mail.com','456');

INSERT INTO Categorie (Libelle) VALUES ('Restaurant');
INSERT INTO Categorie (Libelle) VALUES ('Commerce');
INSERT INTO Categorie (Libelle) VALUES ('Bar');

INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('Burger King', 'Rue du Burger King', 26, 'Restauration rapide', 'Whooper', 'info@Burger-King.com',1,1);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('Quick', 'Rue du Quick', 123, 'Restauration rapide', 'Giant', 'info@Quick.com',2,1);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('KFC', 'Rue du KFC', 17, 'Restauration rapide', 'Saut de poulet','info@KFC.com',2,1);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('MacDo', 'Rue du MacDo', 63, 'Restauration rapide', 'Big Mac', 'info@MacDo.com',1,1);

INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], AdresseMail, IdUser, IdCategorie) VALUES ('Foot Locker', 'Rue du Foot Locker', 1, 'Magasin de chaussures', 'info@Foot-Locker.com',1,2);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('Zara', 'Rue du Zara', 74, 'Magasin de vétements', 'Echarpe Hiver', 'info@Zara.com',1,2);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], AdresseMail, IdUser, IdCategorie) VALUES ('Zeeman', 'Rue du Zeeman', 416, 'Plus grande chaine de magasin en belgique', 'info@Zeeman.com',2,2);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('Sixt', 'Rue du Sixt', 50, 'Location de voitures', 'Mercedes AMG', 'info@Sixt.com',2,2);

INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], AdresseMail, IdUser, IdCategorie) VALUES ('Barnabeer', 'Rue du Barnabeer', 1, 'Plus grand bar de namur', 'info@Barnabeer.com',1,3);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('Green Fairy', 'Rue du green', 74, 'Bar qui rend hommage a green lantern', 'Pinte de 50 à moitié prix', 'info@green-fairy.com',1,3);
INSERT INTO Commerce (NomCommerce, Rue, Numero, [Description], AdresseMail, IdUser, IdCategorie) VALUES ('Au nom de la rose', 'Rue du bar', 416, 'Bar / kot a projet', 'info@ANDLR.com',2,3);
INSERT INTO Commerce (NomCommerce, Rue, Numero, Description, ProduitPhare, AdresseMail, IdUser, IdCategorie) VALUES ('Etoile', 'Rue magique', 50, 'Petit bar rustique qui propose des parties de billard', 'Chimay bleu', 'info@etoiles.com',2,3);
