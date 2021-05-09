SET IDENTITY_INSERT [dbo].[Bus] ON

INSERT INTO  [dbo].[Bus](Id,SeatCapacity, LastUpdateDate, RecordStatus)
VALUES (1,20,GETDATE(),'A'),(2,20,GETDATE(),'A'),(3,20,GETDATE(),'A')

SET IDENTITY_INSERT [dbo].[Bus] OFF



SET IDENTITY_INSERT [dbo].[Location] ON

INSERT INTO [dbo].[Location] (Id,LocationName, LastUpdateDate, RecordStatus)
VALUES (1,'Ýstanbul',GETDATE(),'A'),(2,'Ankara',GETDATE(),'A'),(3,'Ýzmir',GETDATE(),'A'),(4,'Antalya',GETDATE(),'A')

SET IDENTITY_INSERT [dbo].[Location] OFF

INSERT INTO [dbo].[Route] (BusId, StartLocationId, EndLocationId, FilledSeatCount, DepartureTime, RoutPrice, LastUpdateDate, RecordStatus)
VALUES (1,1,1,0,'2021-05-09', 100, GETDATE(),'A'),(2,2,2,0,'2021-05-15',80, GETDATE(),'A'),(3,3,3,0,'2021-06-19', 50, GETDATE(),'A')

INSERT INTO [dbo].[User] (UserName, UserSurname, Email, Password, CreateDate, IsAdmin, LastUpdateDate, RecordStatus)
VALUES('Yusuf','Aydýn','yusuf@gmail.com','123456',GETDATE(),1,GETDATE(),'A')

