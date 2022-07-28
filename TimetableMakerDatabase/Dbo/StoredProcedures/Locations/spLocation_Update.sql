create procedure [dbo].[spLocation_Update]
	@locationName nvarchar(50),
	@locationZone nvarchar(50),
	@locationId int
as
begin
	update [dbo].[Locations] 
	set 
	[name] = IsNull(@locationName, [name]),
	[zone] = IsNull(@locationZone, [zone])
	where [id] = @locationId;
end