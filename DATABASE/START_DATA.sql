use STUDIFY2;

select * from ROLE;
select * from STUDENT;
select * from SUBGROUP;

go
create procedure startData
as declare @key_value nvarchar(128) = 'sunshine',
		   @in_type varchar(20) = 'Admin'
begin
    insert into ROLE(TYPE) values ('Admin'), ('Headman'), ('Student');
	insert into SUBGROUP(SUBGROUP_NUMBER) values (1), (2);
    insert into STUDENT(ID, LOGIN, PASSWORD, ROLE_ID) values (0, 'admin', encryptbypassphrase(@key_value, 'admin'), 1);
end; 
drop procedure startData;
----------------------------------------------------------------------------------------------
go
exec startData;