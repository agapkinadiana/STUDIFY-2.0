create database STUDIFY2;

use STUDIFY2;

create table ROLE (
	ID int primary key identity(1,1),
    TYPE varchar(20) not null
);
drop table ROLE;

create table FACULTY (
	ID int primary key identity(1,1),
    FACULTY_NAME varchar(100) not null
);
drop table FACULTY;

create table PROFESSION (
	ID int primary key identity(1,1),
    PROFESSION_NAME varchar(100) not null,
    FACULTY_ID int not null references FACULTY(ID)
);
drop table PROFESSION;

create table [dbo].[GROUP] (
	ID int primary key identity(1,1),
    COURSE int not null check (COURSE >=1 and COURSE <= 6),
    GROUP_NUMBER int not null check (GROUP_NUMBER >=1 and GROUP_NUMBER <=15),
    FACULTY_ID int not null references FACULTY(ID),
    PROFESSION_ID int not null references PROFESSION(ID)
);
drop table [dbo].[GROUP];

create table SUBGROUP (
	ID int primary key identity(1,1),
    SUBGROUP_NUMBER int not null check (SUBGROUP_NUMBER = 1 or SUBGROUP_NUMBER = 2)
);
drop table SUBGROUP;

create table STUDENT (
	ID int primary key,
    STUDENT_NAME varchar(100),
    PHOTO varbinary(MAX),
    LOGIN varchar(50) not null,
    PASSWORD varbinary(256) not null,
    ROLE_ID int not null references ROLE(ID),
    GROUP_ID int references [dbo].[GROUP](ID),
    SUBGROUP_ID int references SUBGROUP(ID)
);
drop table STUDENT;

create table SUBJECT (
	ID int primary key identity(1,1),
    SUBJECT_NAME varchar(100) not null,
	FACULTY_ID int not null references FACULTY(ID),
    PROFESSION_ID int not null references PROFESSION(ID)
);
drop table SUBJECT;

create table LESSON (
	ID int primary key identity(1,1),
    LESSON_DAY int,
	LESSON_NUMBER int,
    LESSON_TIME varchar (30),
    LESSON_TYPE varchar (30),
    LESSON_WEEK varchar (10),
	AUDITORIUM varchar (10),
    SUBJECT_ID int references SUBJECT(ID),
    GROUP_ID int not null references [dbo].[GROUP](ID),
    SUBGROUP_ID int not null references SUBGROUP(ID)
);
drop table LESSON;

create table ADS (
	ID int primary key identity(1,1),
    CONTENT varchar(500) not null,
    DATE_OF_CREATE datetime not null,
    STUDENT_ID int not null references STUDENT(ID)
);
drop table ADS;

create table TASK (
	ID int primary key identity(1,1),
    CONTENT varchar(500) not null,
    DUEDATE date not null,
    IS_COMPLITE bit not null,
    SUBJECT_ID int not null references SUBJECT(ID),
    STUDENT_ID int not null references STUDENT(ID)
);
drop table TASK;

create table PROGRESS (
	ID int primary key identity(1,1),
    NEEDED_TASKS int not null,
    COMPLITED_TASKS int not null,
    PROGRESS_COUNT as (COMPLITED_TASKS * 100 / NEEDED_TASKS),
	SUBJECT_ID int not null references SUBJECT(ID),
    STUDENT_ID int not null references STUDENT(ID)
);
drop table PROGRESS;

use master;
drop database STUDIFY;
 