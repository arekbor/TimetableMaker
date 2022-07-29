create procedure [dbo].[spLocation_Get]
	@locationId int
as
begin
	select [id], [name], [zone]
	from [dbo].[Locations]
	where [id] = @locationId;
end