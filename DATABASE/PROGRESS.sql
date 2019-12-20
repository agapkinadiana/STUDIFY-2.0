use STUDIFY2;

select * from PROGRESS;

----------------------------------------------------------------------------------------------

go
create procedure addProgress
			@student_id int,
			@subject_name varchar(100)
as begin
	if not exists (select * from PROGRESS 
							where SUBJECT_ID = (select ID from SUBJECT where SUBJECT_NAME = @subject_name))
		insert into PROGRESS (NEEDED_TASKS, COMPLITED_TASKS, SUBJECT_ID, STUDENT_ID)
			values (1, 0, (select ID from SUBJECT where SUBJECT_NAME = @subject_name), @student_id);
	else print 'Such progress exists!'
end;

drop procedure addProgress;

----------------------------------------------------------------------------------------------

go
create procedure getProgress
			@student_id int
as begin
	select * from PROGRESS where STUDENT_ID = @student_id;
end;

drop procedure getProgress;

----------------------------------------------------------------------------------------------

go
create procedure updateProgress
			@complited int,
			@needed int,
			@progress_id int
as begin 
	begin tran
		update PROGRESS set COMPLITED_TASKS = @complited where ID = @progress_id;
		update PROGRESS set NEEDED_TASKS = @needed where ID = @progress_id;
	if @@ERROR <> 0
		rollback
	commit
end;

drop procedure updateProgress;

----------------------------------------------------------------------------------------------

go 
create procedure deleteProgress
			@progress_id int
as begin
	delete from PROGRESS where ID = @progress_id;
end;

drop procedure deleteProgress;