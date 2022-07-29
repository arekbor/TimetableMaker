create procedure [dbo].[spLine_Delete]
	@lineId int
as
begin
	delete from [dbo].[Lines]
	where [id] = @lineId;
end