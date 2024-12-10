create type Humansgender as enum('Male','Female');
create table schools
(
    id serial primary key ,
    schoolTitle varchar(50),
    levelCount int,
    isActive bool,
    createdAt date,
    updateAt date
);
create table students
(
    id serial primary key ,
    studentCode varchar(12),
    studentFullName varchar(50),
    gender Humansgender not null,
    dob date,
    email varchar(75),
    phone varchar(15),
    schoolId int references schools(id) on delete cascade,
    stage int,
    section varchar(2),
    isActive bool,
    joinDate date,
    createdAt date,
    updateAt date
);
create table subjects
(
    id serial primary key ,
    title varchar(100),
    schoolId int references schools(id) on delete cascade,
    stage int,
    team int,
    carryMark int,
    createdAt date,
    updateAt date
);
create table classrooms
(
    id serial primary key ,
    capacity int,
    roomType int,
    description varchar(50),
    createdAt date,
    updateAt date
);
create table teachers
(
    id serial primary key ,
    teacherCode varchar(12),
    teacherFullName varchar(50),
    gender Humansgender not null,
    dob date,
    email varchar(75),
    phone varchar(15),
    isActive bool,
    joinDate date,
    workingDays int,
    createdAt date,
    updateAt date
);
create table classes
(
    id serial primary key ,
    className varchar(50),
    subjectId int references subjects(id)on delete cascade,
    teacherId int references teachers(id)on delete cascade,
    classroomId int references classrooms(id)on delete cascade,
    section varchar(50),
    createdAt date,
    updateAt date
);
create table Parents
(
    id serial primary key ,
    parentCode varchar(12),
    parentFullName varchar(50),
    gender Humansgender not null,
    dob date,
    email varchar(75),
    phone varchar(15),
    createdAt date,
    updateAt date
);
create table StudentParents
(
    id serial primary key,
    studentId int unique references students(id) on delete cascade,
    parentId int references Parents(id),
    relationship int
);
create table classStudent
(
    id serial primary key ,
    studentId int references students(id) on delete cascade,
    classId int references classes(id) on delete cascade
);

insert into classrooms(capacity, roomType, description, createdAt, updateAt) values (@Capacity, @RoomType, @Description, @CreatedAt, @UpdateAt);
update classrooms capacity=@Capacity, roomType=@RoomType, description=@Description,createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;

insert into teachers(teacherCode, teacherFullName, gender, dob, email, phone, isActive, joinDate, workingDays, createdAt, updateAt) values (@TeacherCode, @TeacherFullName, @Gender, @Dob, @Email, @Phone, @IsActive, @JoinDate, @WorkingDays, @CreatedAt, @UpdateAt);
update teachers set teacherCode=@TeacherCode, teacherFullName=@TeacherFullName, gender=@Gender, dob=@Dob, email=@Email, phone=@Phone, isActive=@IsActive, joinDate=@JoinDate, workingDays=@WorkingDays, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;




insert into classes (className, subjectId, teacherId, classroomId, section, createdAt, updateAt) values (@ClassName, @SubjectId, @TeacherId, @ClassroomId, @Section, @CreatedAt, @UpdateAt);
update classes set className=@ClassName, subjectId=@SubjectId, teacherId=@TeacherId, classroomId=@ClassroomId, section=@Section, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;

insert into classStudent(studentId, classId) values (@StudentId, @ClassId);
update classStudent set studentId=@StudentId, classId=@ClassId where id=@Id;


insert into Parents( parentCode, parentFullName, gender, dob, email, phone, createdAt, updateAt) values ( @ParentCode, @ParentFullName, @Gender, @Dob, @Email, @Phone, @CreatedAt, @UpdateAt);

update Parents set parentCode=@ParentCode, parentFullName=@ParentFullName, gender=@Gender, dob=@Dob, email=@Email, phone=@Phone, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;

insert into subjects( title, schoolId, stage, team, carryMark, createdAt, updateAt) values ( @Title, @SchoolId, @Stage, @Team, @CarryMark, @CreatedAt, @UpdateAt);

update subjects set title=@Title, schoolId=@SchoolId, stage=@Stage, team=@Team, carryMark=@CarryMark, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;


insert into students(studentCode, studentFullName, gender, dob, email, phone, schoolId, stage, section, isActive, joinDate, createdAt, updateAt) values (@StudentCode, @StudentFullName, @Gender, @Dob, @Email, @Phone, @SchoolId, @Stage, @Section, @IsActive, @JoinDate, @CreatedAt, @UpdateAt);

update students set studentCode=@StudentCode, studentFullName=@StudentFullName, gender=@Gender, dob=@Dob, email=@Email, phone=@Phone, schoolId=@SchoolId, stage@Stage, section=@Section, isActive=@IsActive, joinDate@JoinDate, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;

insert into StudentParents( studentId, parentId, relationship) values ( @StudentId, @ParentId, @Relationship);

update StudentParents set studentId=@StudentId, parentId=@ParentId, relationship=@Relationship where id=@Id;


insert into schools( schoolTitle, levelCount, isActive, createdAt, updateAt) values ( @SchoolTitle, @LevelCount, @IsActive, @CreatedAt, @UpdateAt);

update schools set schoolTitle=@SchoolTitle, levelCount=@LevelCount, isActive=@IsActive, createdAt=@CreatedAt, updateAt=@UpdateAt where id=@Id;

