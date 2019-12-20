use STUDIFY2;

select * from SUBJECT;

----------------------------------------------------------------------------------------------

go
create procedure insertSubject
		   @profession_id int,
		   @faculty_id int,
		   @subject_name varchar(100)
as begin
	if not exists (select SUBJECT_NAME from SUBJECT where SUBJECT_NAME = @subject_name)
		insert into SUBJECT (SUBJECT_NAME, FACULTY_ID, PROFESSION_ID) values (@subject_name, @faculty_id, @profession_id)
end;

drop procedure insertSubject;
----------------------------------------------------------------------------------------------
go
create procedure deleteSubject
		   @subject_id int
as begin
		delete from SUBJECT where ID = @subject_id;
end;

drop procedure deleteSubject;
----------------------------------------------------------------------------------------------
go
create procedure getSubjectByFacultyProfessionName
					@profession_name varchar(100)
as begin
	select * from SUBJECT where PROFESSION_ID = (select top(1) ID from PROFESSION where PROFESSION_NAME = @profession_name)
					order by SUBJECT_NAME asc;
end;

drop procedure getSubjectByFacultyProfessionName
----------------------------------------------------------------------------------------------
go
create procedure getSubjects
as begin
	select * from SUBJECT order by SUBJECT_NAME asc;
end;

drop procedure getSubjects