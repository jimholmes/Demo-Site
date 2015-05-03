USE [demos]
GO

DELETE FROM [dbo].[Contacts]
GO

INSERT INTO [dbo].[Contacts]
           ([FName]
           ,[LName]
           ,[Company]
           ,[Region])
     VALUES
('Isaac', 'Asimov','Seldon Foundation','Earth'),
('Ludwig','Beethoven','Top Notch Music Academy','Europe'),
('Jayne','Cobb','Blue Sun','New Earth'),
('Albert','Einstein','Relativity, Inc.','Eastern'),
('Jim','Holmes','Pillar','Midwest'),
('Robin','Knight','Bravely Bravely, LLC','Scotland'),
('Guinevere','Leodegrance','Round Table Hotels','Scotland'),
('Katy','McGillicuddy','Tip Top Software','Midwest'),
('Sarah','Merwin','Merwin Consulting Ltd','West'),
('Reynolds','Malcom','Serenity, Inc.','New Earth'),
('River','Tam','Serenity, Inc.','New Earth')

GO


