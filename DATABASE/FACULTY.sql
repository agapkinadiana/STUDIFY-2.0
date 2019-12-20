use STUDIFY2;

select * from FACULTY;

---------------------------------------------------------------------------------------------

go
create procedure insertFaculty
		   @faculty_name varchar(100)
as begin
	if not exists (select FACULTY_NAME from FACULTY where FACULTY_NAME = @faculty_name)
		insert into FACULTY (FACULTY_NAME) values (@faculty_name)
end;

drop procedure insertFaculty;

----------------------------------------------------------------------------------------------
go
create procedure deleteFaculty
		   @faculty_id int
as begin
	begin tran
		delete from PROGRESS where STUDENT_ID = (select ID from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where FACULTY_ID = @faculty_id));
		delete from ADS where  STUDENT_ID = (select ID from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where FACULTY_ID = @faculty_id));
		delete from TASK where  STUDENT_ID = (select ID from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where FACULTY_ID = @faculty_id));
		delete from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where FACULTY_ID = @faculty_id);
		delete from LESSON where GROUP_ID = (select ID from [dbo].[GROUP] where FACULTY_ID = @faculty_id);
		delete from [dbo].[GROUP] where FACULTY_ID = @faculty_id;
		delete from PROFESSION where FACULTY_ID = @faculty_id;
		delete from FACULTY where ID = @faculty_id;
	if @@ERROR <> 0
		rollback
	commit
end;

drop procedure deleteFaculty;

----------------------------------------------------------------------------------------------

go
create procedure getFaculties
as begin
	select * from FACULTY;
end;

drop procedure getFaculties;

----------------------------------------------------------------------------------------------

go
create procedure getFacultyIdByName
			@faculty_name varchar(100)
as declare @id int
begin
	set @id = (select top(1) ID from FACULTY where FACULTY_NAME = @faculty_name);
	select @id;
end;

drop procedure getFacultyIdByName;