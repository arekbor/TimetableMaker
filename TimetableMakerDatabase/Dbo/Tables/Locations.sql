create table [dbo].[Locations] (
	-- identificator of location
	[id] int not null identity(1,1) primary key,
	-- name of stop 
	[name] nvarchar(50) not null unique,
	-- name of city or commune
	[zone] nvarchar(50) not null
);