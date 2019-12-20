create login STUDIFY_ADMIN   
    with password = 'STUDIFY_ADMIN';  
go  

create user STUDIFY_ADMIN for login STUDIFY_ADMIN;  
go

create role ADMIN authorization STUDIFY_ADMIN;

grant execute on checkAdminData to ADMIN;
grant execute on setHeadman to ADMIN;
grant execute on getStudentsForAdmin to ADMIN;
grant execute on insertFaculty to ADMIN;
grant execute on deleteFaculty to ADMIN;
grant execute on getFaculties to ADMIN;
grant execute on getFacultyIdByName to ADMIN;
grant execute on insertProfession to ADMIN;
grant execute on getProfessionIdByName to ADMIN;
grant execute on deleteProfession to ADMIN;
grant execute on getProfessions to ADMIN;
grant execute on insertGroup to ADMIN;
grant execute on getGroup to ADMIN;
grant execute on getGroupByProfessionName to ADMIN;
grant execute on getCourse to ADMIN;
grant execute on getSubgroup to ADMIN;
grant execute on deleteGroup to ADMIN;
grant execute on insertSubject to ADMIN;
grant execute on deleteSubject to ADMIN;
grant execute on getSubjectByFacultyProfessionName to ADMIN;
grant execute on getSubjects to ADMIN;
grant execute on getTimetableByWeekAdmin to ADMIN;
grant execute on getTimetable to ADMIN;
grant execute on updateTimetable to ADMIN;
grant execute on insertSubject to ADMIN;
grant execute on getUserByLogin to ADMIN;
grant execute on getProfessionByFacultyName to ADMIN;
grant execute on deleteStudent to ADMIN;
grant execute on exportToXML to ADMIN;
grant execute on importToXML to ADMIN;
use master
go
grant administer bulk operations TO STUDIFY_ADMIN;

--------------------------------------------------------------------------
create login STUDIFY_STUDENT  
    with password = 'STUDIFY_STUDENT';  
go  

create user STUDIFY_STUDENT for login STUDIFY_STUDENT;  
go

create role STUDENT authorization STUDIFY_STUDENT;

grant execute on getStudentByCard to STUDENT;
grant execute on registerStudent to STUDENT;
grant execute on getUserByLogin to STUDENT;
grant execute on checkStudentData to STUDENT;
grant execute on checkRole to STUDENT;
grant execute on getStudentsForHeadman to STUDENT;
grant execute on setPhoto to STUDENT;
grant execute on getFaculties to STUDENT;
grant execute on getProfessions to STUDENT;
grant execute on getGroupId to STUDENT;
grant execute on getSubgroupId to STUDENT;
grant execute on getSubgroup to STUDENT;
grant execute on getCourse to STUDENT;
grant execute on getSubjects to STUDENT;
grant execute on getSubjectByFacultyProfessionName to STUDENT;
grant execute on checkTimetableByIdGroup to STUDENT;
grant execute on getTimetableByWeekAdmin to STUDENT;
grant execute on getTimetableByWeek to STUDENT;
grant execute on insertTimetable to STUDENT;
grant execute on updateTimetable to STUDENT;
grant execute on sendMessage to STUDENT;
grant execute on deleteMessage to STUDENT;
grant execute on getMessage to STUDENT;
grant execute on countMessage to STUDENT;
grant execute on addProgress to STUDENT;
grant execute on getProgress to STUDENT;
grant execute on updateProgress to STUDENT;
grant execute on deleteProgress to STUDENT;
grant execute on addTask to STUDENT;
grant execute on getTasksForStudent to STUDENT;
grant execute on getTasksBySubject to STUDENT;
grant execute on deleteTask to STUDENT;
grant execute on changeCompliteTrue to STUDENT;
grant execute on changeCompliteFalse to STUDENT;
grant execute on getUnsatisfiedTasks to STUDENT;
grant execute on getSatisfiedTasks to STUDENT;
grant execute on getFacultyIdByName to STUDENT;
grant execute on getProfessionIdByName to STUDENT;
