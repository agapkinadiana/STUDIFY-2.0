use STUDIFY2;

select * from PROFESSION;

---------------------------------------------------------------------------------------------

go
create procedure insertProfession
		   @profession_name varchar(100),
		   @faculty_id int
as begin
	if not exists (select PROFESSION_NAME from PROFESSION where PROFESSION_NAME = @profession_name)
		insert into PROFESSION (PROFESSION_NAME, FACULTY_ID) values (@profession_name, @faculty_id)
end;

drop procedure insertProfession;

----------------------------------------------------------------------------------------------

go
create procedure getProfessionIdByName
			@profession_name varchar(100)
as declare @id int
begin
	set @id = (select top(1) ID from PROFESSION where PROFESSION_NAME = @profession_name);
	select @id;
end;

drop procedure getProfessionIdByName;

----------------------------------------------------------------------------------------------
go
create procedure deleteProfession
		   @profession_id int
as begin
	begin tran
		delete from PROGRESS where STUDENT_ID = (select ID from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where PROFESSION_ID = @profession_id));
		delete from ADS where  STUDENT_ID = (select ID from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where PROFESSION_ID = @profession_id));
		delete from TASK where  STUDENT_ID = (select ID from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where PROFESSION_ID = @profession_id));
		delete from STUDENT where GROUP_ID = (select ID from [dbo].[GROUP] where PROFESSION_ID = @profession_id);
		delete from LESSON where GROUP_ID = (select ID from [dbo].[GROUP] where PROFESSION_ID = @profession_id);
		delete from [dbo].[GROUP] where PROFESSION_ID = @profession_id;
		delete from PROFESSION where ID = @profession_id
	if @@ERROR <> 0
		rollback
	commit
end;

drop procedure deleteProfession;

----------------------------------------------------------------------------------------------

go
create procedure getProfessions
as begin
	select * from PROFESSION;
end;

drop procedure getProfessions;

----------------------------------------------------------------------------------------------

go
create procedure getProfessionByFacultyName
					@faculty_name varchar(100)
as begin
	select * from PROFESSION where FACULTY_ID = (select top(1) ID from FACULTY where FACULTY_NAME = @faculty_name);
end;

drop procedure getProfessionByFacultyName