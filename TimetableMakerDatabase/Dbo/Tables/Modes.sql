create table [dbo].[Modes] (
	-- identificator of transport mode
	[id] int not null identity(1,1) primary key,
	-- type of transport mode (tram, bus, train etc.)
	[type] nvarchar(50) not null,
	-- model of transport mode (Pafawag 5B/6B, Solaris Urbino 12, Konstal 105Na etc.)
	[model] nvarchar(50) not null,
	-- max allow seats in vehicle
	[seats] int not null
);