create procedure [dbo].[spLocation_Delete]
	@locationId int
as
begin
	delete from [dbo].[Locations]
	where [id] = @locationId;
end