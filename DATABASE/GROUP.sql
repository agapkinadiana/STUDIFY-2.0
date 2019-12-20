use STUDIFY2;

select * from [dbo].[GROUP];

----------------------------------------------------------------------------------------------
go
create procedure insertGroup
		   @profession_id int,
		   @faculty_id int,
		   @course int,
		   @group int
as begin
	if not exists (select * from [dbo].[GROUP] where PROFESSION_ID = @profession_id and FACULTY_ID = @faculty_id and COURSE = @course and GROUP_NUMBER = @group)
		insert into [dbo].[GROUP](COURSE, GROUP_NUMBER, FACULTY_ID, PROFESSION_ID) values (@course, @group, @faculty_id, @profession_id)
end;

drop procedure insertGroup;

----------------------------------------------------------------------------------------------
go 
create procedure getGroupId
				@course int,
				@group_number int,
				@faculty_id int,
				@profession_id int
as declare @id int
begin
	set @id = (select top(1) ID from  [dbo].[GROUP] where COURSE = @course and GROUP_NUMBER = @group_number and FACULTY_ID = @faculty_id and PROFESSION_ID = @profession_id)
	select @id;
end;

drop procedure getGroupId;

----------------------------------------------------------------------------------------------

go 
create procedure getSubgroupId
				@subgroup int
as declare @id int
begin
	set @id = (select top(1) ID from SUBGROUP where SUBGROUP_NUMBER = @subgroup)
	select @id;
end;

drop procedure getSubgroupId;


----------------------------------------------------------------------------------------------
go
create procedure getGroup
as begin
	select distinct GROUP_NUMBER from [dbo].[GROUP] order by GROUP_NUMBER asc;
end;

drop procedure getGroup;

----------------------------------------------------------------------------------------------
go
create procedure getGroupByProfessionName
					@profession_name varchar(100)
as begin
	select * from [dbo].[GROUP] where PROFESSION_ID = (select top(1) ID from PROFESSION where PROFESSION_NAME = @profession_name);
end;

drop procedure getGroupByProfessionName
----------------------------------------------------------------------------------------------

go
create procedure getCourse
as begin
	select distinct COURSE from [dbo].[GROUP] order by COURSE asc;
end;

drop procedure getCourse;

----------------------------------------------------------------------------------------------

go
create procedure getSubgroup
as begin
	select distinct SUBGROUP_NUMBER from [dbo].[SUBGROUP] order by SUBGROUP_NUMBER asc;
end;

drop procedure getSubgroup;

----------------------------------------------------------------------------------------------
go
create procedure deleteGroup
		   @group_id int
as begin
	begin tran
		delete from PROGRESS where STUDENT_ID = (select ID from STUDENT where GROUP_ID = @group_id);
		delete from ADS where STUDENT_ID = (select ID from STUDENT where GROUP_ID = @group_id);
		delete from TASK where STUDENT_ID = (select ID from STUDENT where GROUP_ID = @group_id);
		delete from STUDENT where GROUP_ID = @group_id;
		delete from LESSON where GROUP_ID = @group_id;
		delete from [dbo].[GROUP] where ID = @group_id;
	if @@ERROR <> 0
		rollback
	commit
end;

drop procedure deleteGroup;
----------------------------------------------------------------------------------------------