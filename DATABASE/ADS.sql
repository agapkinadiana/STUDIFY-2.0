use STUDIFY2;

select * from ADS;

----------------------------------------------------------------------------------------------
go 
create procedure sendMessage
		@content varchar(500),
		@date datetime,
		@id int
as begin
	if ((select (select TYPE from ROLE where ROLE.ID = STUDENT.ROLE_ID) as ROLE from STUDENT where ID = @id) = 'Headman')
		insert into ADS(CONTENT, DATE_OF_CREATE, STUDENT_ID) values (@content, GETDATE ( ), @id)
	else print 'function not available'
end;

drop procedure sendMessage;

----------------------------------------------------------------------------------------------

go
create procedure deleteMessage
		@message_id int
as begin
	if exists (select * from ADS where ID = @message_id)
		delete from ADS where ID = @message_id
end;

drop procedure deleteMessage;

----------------------------------------------------------------------------------------------

go
create procedure getMessage
as begin
	select * from ADS order by DATE_OF_CREATE desc;
end;

drop procedure getMessage;

----------------------------------------------------------------------------------------------

go
create procedure countMessage
as begin
	select count(*) from ADS;
end;

drop procedure countMessage;

----------------------------------------------------------------------------------------------