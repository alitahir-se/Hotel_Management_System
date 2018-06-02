create database hms55
go

use hms55
go
create table Customer(
cid int not null identity(1,1),
Fname varchar(30) not null,
Lname varchar(30) not null,
Privelege int,
CNIC char(15) not null unique,
Address_c varchar(50),
Phone varchar(11),
City varchar(30),
Email varchar(40) not null,
Password_c varchar(20) not null,
primary key(cid),
unique(Email)

)
create table room_category(
Category varchar(10) primary key, --category determines price 
Price int,

)

create table room(
Room_no int not null identity(1,1),
Category varchar(10) foreign key references room_category (Category) on update cascade on delete cascade ,
Status_r varchar(10) not null,
Discount float,
primary key(Room_no)
)
create table hall_category(
Category varchar(10) primary key, --category determines price 
Price int,

)

create table Hall(
Hall_no int not null identity(1,1),
Category varchar(10) foreign key references hall_category (Category) on update cascade on delete cascade ,
Status_h varchar(10) not null,
Discount int,
primary key(Hall_no)
)

create table Menu(
item_id int not null identity(1,1),
Price int,
Name_i varchar(50),
primary key(item_id)
)
create table orders(
order_id int not null,
item_id int not null default -1, --does order_id determines item_id? 
cid int,
quantity int,
price int,
total_p int,
Order_date date,
constraint fk_or_i Foreign key(item_id) references Menu(item_id) on update cascade on delete set default,
constraint fk_or_c Foreign key(cid) references Customer(cid) on update cascade on delete set null ,
primary key(order_id,item_id)
)
create table Feedback(
Feedback_id int identity(1,1),
c_id int,
Feedback_given varchar(140),
primary key(Feedback_id),
constraint fk_fb_c Foreign key (c_id) references Customer(cid) on delete set null on update cascade
)


create table Department(
Dno int not null identity(1,1), --dname determines dno ?
Name_d varchar(30) not null unique,
primary key(Dno)
)

create table Employee(
E_id int not null identity(1,1),
F_name varchar(30),
L_name varchar(30),
B_date date,
address_e varchar(30),
salary int,
Dname varchar(30),
DnoM varchar(20),
Sex varchar(8),
Cnic varchar(15),
Email varchar(50) not null unique,
start_date_e date,
primary key (E_id),
constraint fk_emp_dno foreign key(Dname) references Department(Name_d) on delete set null on update cascade,
)

Create table BlackList(
Fname varchar(30),
Lname varchar(30),
Cnic varchar(15) primary key
)
Create table Employee_Login(
Username varchar(50) primary key, 
Password_u varchar (30),
constraint fk_emplogin_email Foreign key(Username) references Employee(Email) on delete cascade on update cascade
)
create table Applications(
Cnic varchar(15) primary key,
Dep_name varchar(30),
F_name varchar(30),
L_name varchar(30),
B_date date,
job_type varchar(20),
address_a varchar(30),
Sex varchar(8),
Email varchar(50) unique,
constraint fk_app_dep_name  foreign key(Dep_name) references Department(Name_d) on delete cascade on update cascade
)
create table Reservation_rooms(
Reservation_id int not null primary key identity(1,1),
C_id int ,
check_in datetime,
check_out datetime,
Room_no int,
constraint fk_res_r_c  foreign key(C_id) references Customer(cid) on delete cascade on update cascade,
constraint fk_res_r_rno  foreign key(Room_no) references room(Room_no) on delete cascade on update cascade
)
create table Reservation_Halls(
Reservation_id int not null primary key identity(1,1),
C_id int,
check_in datetime,
check_out datetime,
Hall_no int,
constraint fk_res_h_c  foreign key(C_id) references Customer(cid) on delete cascade on update cascade,
constraint fk_res_h_rno   foreign key(Hall_no) references Hall(Hall_no) on delete cascade on update cascade
)
create table Record_Reservation_Halls(
Reservation_id int not null primary key ,
C_id int,
check_in datetime,
check_out datetime,
Hall_no int,
constraint fk_rres_h_c  foreign key(C_id) references Customer(cid) on delete set null on update cascade,
constraint fk_rres_h_h  foreign key(Hall_no) references Hall(Hall_no) on delete set null  on update cascade
)
create table Record_Reservation_Rooms(
Reservation_id int not null primary key,
C_id int,
check_in datetime,
check_out datetime,
Room_no int,
constraint fk_rres_r_c  foreign key(C_id) references Customer(cid) on delete set null on update cascade,
constraint fk_rres_r_r  foreign key(Room_no) references room(Room_no) on delete set null  on update cascade
)
create table Administrator(
Email varchar(40),
password_a varchar(20)
)
create table temp_login(
cnic varchar(15) primary key,
password_e varchar(25),
foreign key(cnic) references Applications(Cnic) on delete cascade on update cascade
)