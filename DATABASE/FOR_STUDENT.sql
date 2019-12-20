use STUDIFY2;

select * from STUDENT;

----------------------------------------------------------------------------------------------

go
create procedure registerStudent
		@num_card int,
		@name varchar(100),
		@login varchar(50),
		@password varchar(20),
		@group_id int,
		@subgroup_id int
as declare @key_value nvarchar(128) = 'sunshine'
begin
	begin tran
	if not exists (select * from STUDENT where ID = @num_card and LOGIN = @login)
		insert into STUDENT (ID, STUDENT_NAME, LOGIN, PASSWORD, ROLE_ID, GROUP_ID, SUBGROUP_ID) 
					values (@num_card, @name, @login, encryptbypassphrase(@key_value, @password), 3, @group_id, @subgroup_id)
	if @@ERROR <> 0
		rollback
	commit
end;

drop procedure registerStudent;

----------------------------------------------------------------------------------------------

go
create procedure getStudentByCard
			@card_number int
as begin
	select * from STUDENT where ID = @card_number;
end;

drop procedure getStudentByCard;

----------------------------------------------------------------------------------------------

go
create procedure checkStudentData
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

drop procedure checkStudentData;

----------------------------------------------------------------------------------------------

go 
create procedure checkRole
				@id int,
				@role nvarchar(256) output
as begin
	set @role = (select (select top(1) TYPE from ROLE where ROLE.ID = STUDENT.ROLE_ID) as ROLE from STUDENT where ID = @id);
end;

drop procedure checkRole;

----------------------------------------------------------------------------------------------
go
create procedure getStudentsForHeadman
			@course int,
			@group int,
			@faculty_id int,
			@profession_id int
as begin
	select * from STUDENT where GROUP_ID = (select top(1) ID from [dbo].[GROUP] where COURSE = @course 
			and GROUP_NUMBER = @group
			and FACULTY_ID = @faculty_id 
			and PROFESSION_ID = @profession_id)
end;

drop procedure getStudentsForHeadman;

----------------------------------------------------------------------------------------------
go
create procedure setPhoto
		   @student_id int,
		   @photo varbinary(max)
as begin
	update STUDENT set PHOTO = @photo where ID = @student_id;
end;

drop procedure setPhoto;
