create procedure [dbo].[spLine_Insert]
	@lineName varchar(10),
	@modeId int
as
begin
	insert into [dbo].[Lines] ([lineName], [modeId])
	values
	(@lineName, @modeId)
end