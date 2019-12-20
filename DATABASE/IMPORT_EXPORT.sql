

go
create procedure exportToXML
as begin
	select * from FACULTY
	for xml path('Faculty'), root('Faculty')
end

drop procedure exportToXML

----------------------------------------------------------------------------------------------

go
create procedure importToXML
as begin
	insert into FACULTY(FACULTY_NAME)
	select
		MY_XML.FACULTY.query('FACULTY_NAME').value('.', 'varchar(100)')
   
from (select cast (MY_XML AS xml)
      from openrowset(bulk 'C:\DATABASE\FACULTY.xml', single_blob) as T(MY_XML)) as T(MY_XML)
      cross apply MY_XML.nodes('Faculty/Faculty') AS MY_XML (FACULTY);
end

drop procedure importToXML;

--------------------------------------------------------------------------------------------------------------
declare @count int
set @count = 0 
while @count < 100000 begin
	insert into STUDENT(ID, LOGIN, PASSWORD, ROLE_ID) values (@count, 'lala', 2, 1);
	set @count = @count + 1 
if @count % 100 = 0 and @@trancount > 0 
commit 
end 
if @@trancount > 0 
commit 

select count(*) from STUDENT;

select * from student where login = '1';
select * from student where password = 3;

create nonclustered index LOGIN_INDX
on STUDENT(LOGIN)
go
drop index LOGIN_INDX on STUDENT

create nonclustered index PASSWORD_INDX
on STUDENT(PASSWORD)
go
drop index PASSWORD_INDX on STUDENT
