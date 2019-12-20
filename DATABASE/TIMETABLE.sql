use STUDIFY2;

select * from LESSON;

----------------------------------------------------------------------------------------------
go
create procedure checkTimetableByIdGroup 
				@id int
as declare @count int
begin
	set @count = (select COUNT(*) from LESSON where GROUP_ID = @id);
	select @count;
end;

drop procedure checkTimetableByIdGroup;

----------------------------------------------------------------------------------------------

go 
create procedure insertTimetable
				@day int,
				@number int,
				@week varchar (10),
				@group_id int,
				@subgroup_id int
as begin
	insert into LESSON (LESSON_DAY, LESSON_NUMBER, LESSON_WEEK, GROUP_ID, SUBGROUP_ID) 
			values (@day, @number, @week, @group_id, @subgroup_id);
end;

drop procedure insertTimetable;

----------------------------------------------------------------------------------------------

go 
create procedure getTimetableByWeek
				@week varchar (10),
				@group_id int,
				@subroup_id int
as begin
	select * from LESSON where LESSON_WEEK = @week and GROUP_ID = @group_id and SUBGROUP_ID = @subroup_id;
end;

drop procedure getTimetableByWeek;

----------------------------------------------------------------------------------------------

go 
create procedure getTimetableByWeekAdmin
				@week varchar (10),
				@group int,
				@subgroup int, 
				@course int
as begin
	select * from LESSON where LESSON_WEEK = @week and GROUP_ID = (select top(1) ID from [dbo].[GROUP] where GROUP_NUMBER = @group 
					and COURSE = @course)
					and SUBGROUP_ID = (select top(1) ID from SUBGROUP where SUBGROUP_NUMBER = @subgroup);
end;

drop procedure getTimetableByWeekAdmin;

----------------------------------------------------------------------------------------------

go
create procedure getTimetable
as begin
	select * from LESSON;
end;

drop procedure getTimetable;

----------------------------------------------------------------------------------------------

go
create procedure updateTimetable
			@subject_name varchar(100),
			@timetable_id int
as begin
	update LESSON set SUBJECT_ID = (select ID from SUBJECT where SUBJECT_NAME = @subject_name) where ID = @timetable_id;
end;

drop procedure updateTimetable;
