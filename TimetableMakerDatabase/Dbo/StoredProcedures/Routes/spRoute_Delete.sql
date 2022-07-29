create procedure [dbo].[spRoute_Delete]
	@routeId int
as
begin
	delete from [dbo].[Routes]
	where [id] = @routeId;
end
