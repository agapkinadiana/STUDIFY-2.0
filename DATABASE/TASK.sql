use STUDIFY2;

select * from TASK;

----------------------------------------------------------------------------------------------
go
create procedure addTask
			@student_id int,
			@deadline datetime,
			@subject varchar(100), 
			@content varchar(500)
as begin
	insert into TASK (CONTENT, DUEDATE, IS_COMPLITE, SUBJECT_ID, STUDENT_ID) 
			values (@content, @deadline, 0, (select ID from SUBJECT where SUBJECT_NAME = @subject), @student_id);
end;

drop procedure addTask;

----------------------------------------------------------------------------------------------

go
create procedure getTasksForStudent
			@student_id int
as begin
	select * from TASK where STUDENT_ID = @student_id;
end;

drop procedure getTasksForStudent;

----------------------------------------------------------------------------------------------

go
create procedure getTasksBySubject
			@student_id int,
			@subject varchar(100)
as begin
	select * from TASK where STUDENT_ID = @student_id and SUBJECT_ID = (select ID from SUBJECT where SUBJECT_NAME = @subject);
end;

drop procedure getTasksBySubject;

----------------------------------------------------------------------------------------------

go
create procedure deleteTask
			@task_id int
as begin
	delete from TASK where ID = @task_id;
end;

drop procedure deleteTask;

----------------------------------------------------------------------------------------------

go
create procedure changeCompliteTrue
			@task_id int
as begin
	update TASK set IS_COMPLITE = 1 where ID = @task_id
end;

drop procedure changeCompliteTrue;

----------------------------------------------------------------------------------------------

go
create procedure changeCompliteFalse
			@task_id int
as begin
	update TASK set IS_COMPLITE = 0 where ID = @task_id
end;

drop procedure changeCompliteFalse;

----------------------------------------------------------------------------------------------

go
create procedure getUnsatisfiedTasks
			@student_id int
as begin
	select * from TASK where IS_COMPLITE = 0 and STUDENT_ID = @student_id;
end;

drop procedure getUnsatisfiedTasks

----------------------------------------------------------------------------------------------
go
create procedure getSatisfiedTasks
			@student_id int
as begin
	select * from TASK where IS_COMPLITE = 1 and STUDENT_ID = @student_id;
end;

drop procedure getSatisfiedTasks

----------------------------------------------------------------------------------------------