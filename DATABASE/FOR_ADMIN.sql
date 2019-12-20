use STUDIFY2;

select * from ROLE;
select * from STUDENT;

update student set role_id = 1 where ID = 0;
---------------------------------------------------------------------------------------------
go
create procedure checkAdminData
		   @login varchar(50),
           @password varchar(20),
		   @result nvarchar(256) output
as declare @key_value nvarchar(128) = 'sunshine'
begin try
    if exists (select * from STUDENT where @login = LOGIN and @password = convert(varchar(20), decryptbypassphrase(@key_value, PASSWORD)))
     set @result = 'true'
	else print 'error'
end try
begin catch
	print 'Error ' + convert(varchar, error_number()) + ':' + error_message()
end catch;

drop procedure checkAdminData;
----------------------------------------------------------------------------------------------

go
create procedure setHeadman
		   @student_id int
as begin
	if exists (select * from STUDENT where ID = @student_id and ROLE_ID = 3)
		update STUDENT set ROLE_ID = 2 where ID = @student_id
	else if exists (select * from STUDENT where ID = @student_id and ROLE_ID = 2)
		update STUDENT set ROLE_ID = 3 where ID = @student_id
end;

drop procedure setHeadman;

----------------------------------------------------------------------------------------------
go 
create procedure getStudentsForAdmin
as begin
	select * from STUDENT where ROLE_ID != (select ID from ROLE where TYPE = 'Admin');
end;

exec getStudentsForAdmin;

drop procedure getStudentsForAdmin;

----------------------------------------------------------------------------------------------

go
create procedure getUserByLogin
			@login varchar(50)
as begin
	select * from STUDENT where LOGIN = @login;
end;

drop procedure getUserByLogin;

----------------------------------------------------------------------------------------------

go
create procedure deleteStudent
		   @student_id int
as begin
	begin tran
		delete from PROGRESS where STUDENT_ID = @student_id;
		delete from ADS where STUDENT_ID = @student_id;
		delete from TASK where STUDENT_ID = @student_id;
		delete from STUDENT where ID = @student_id;
	if @@ERROR <> 0
		rollback
	commit
end;

drop procedure deleteStudent;
----------------------------------------------------------------------------------------------