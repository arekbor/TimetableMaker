create procedure [dbo].[spMode_Delete]
	@modeId int
as
begin
	delete from [dbo].[Modes]
	where [id] = @modeId;
end