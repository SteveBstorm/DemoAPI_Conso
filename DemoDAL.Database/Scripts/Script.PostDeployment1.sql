/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE DemoDal
GO

INSERT INTO Brand (Name) 
VALUES ('Marque A'), ('Marque B')

INSERT INTO Product (Name, BrandId, EAN13, Price) 
VALUES ('Test', 1, '978020137962', 3.14),
       ('Hello', 2, '978020146562', 9.99),
       ('World', 2, '978020351262', 100)

