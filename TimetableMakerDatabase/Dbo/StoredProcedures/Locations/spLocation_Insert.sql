create procedure [dbo].[spLocation_Insert]
	@locationName nvarchar(50),
	@locationZone nvarchar(50)
as
begin
	insert into [dbo].[Locations] ([name] , [zone])
	values (@locationName, @locationZone);
end