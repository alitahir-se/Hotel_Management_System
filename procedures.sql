use hms55
go
create procedure Customer_Register
@Fname varchar(30)=NULL,@Lname varchar(30)=NULL,@Privelege int,@CNIC char(15)=NULL,@Address_c varchar(50),
@Phone varchar(11),@City varchar(30),@Email varchar(40)=NULL,@Password_c  varchar(20)=NULL,@flag int out

as
begin
 if(@Fname=NULL or @Lname=NULL or @CNIC=NULL or  @Email=NULL or @Password_c=NULL )
   begin
   print 'Enter all required Fields'
   set @flag=0
   end
   else
   begin
       
	   if(  exists (select * from Customer where Customer.CNIC=@CNIC) )
   begin
     set @flag=-2;
   end
   else if exists (select * from Customer where Customer.Email=@Email)
   begin 
   set @flag=-1;
   end
   
else
begin
  begin try
		insert into Customer values (@Fname,@Lname,@Privelege,@CNIC,@Address_c,@Phone,@City,@Email,@Password_c);
		set @flag=1;
  end try
   begin catch
       set @flag=0;
   end catch
end
end
end

go
create procedure show_rooms_available
as
begin
select Room_no,room.Category,Price-(Discount/100*Price) as Price_Room,Status_r Availability_of_room from room join room_category on room.Category=room_category.Category where Status_r='available'
end
create procedure show_rooms_occupied
as
begin
select Room_no,check_out available_at from Reservation_rooms
end

create procedure show_halls_available
as
begin
select Hall_no,Hall.Category,Price-(Discount/100*Price) as Price_Room,Status_h Availability_of_room from Hall join hall_category on Hall.Category=hall_category.Category where Status_h='available'
end
go
create procedure show_halls_occupied
as
begin
select Hall_no,check_out available_at from Reservation_Halls
end
create procedure add_room

@category varchar(10),
@status varchar(10),
@discount float
as 
begin
insert into room values(@category,@status,@discount)
end
create procedure add_hall

@category varchar(10),
@status varchar(10),
@discount float
as 
begin
insert into Hall values(@category,@status,@discount)
end
create procedure add_fb
@user varchar(40),
@fb varchar(140)
as
begin
declare @id int
select @id=cid from Customer where Email=@user
insert into Feedback values(@id,@fb)
end
create procedure add_dep
@name varchar(30)
as
begin
if (@name is not NULL)
begin
insert into Department values(@name)
end
end
create procedure add_item
@name varchar(50),
@price int
as
begin
if (@name is not NULL)
begin
insert into Menu values(@price,@name)
end
end

create procedure add_temp_login
@cnic varchar(15),
@password varchar(25)
as
begin
Insert into temp_login values(@cnic,@password)
end
go
create procedure give_password
@cnic varchar(15),
@password varchar(25) out,
@email varchar(50) out
as

begin
select @password=password_e from temp_login where Cnic=@cnic
select @email=Email from Applications where Cnic=@cnic 

end
create Procedure Admin_Login_Checking

@Username varchar(30)=NULL,  @Password varchar(30)=NULL,
@flag int out
as

begin
       if(@Username=NULL or @Password=NULL)
	   begin
	   print 'Enter Username and Password';
	   set @flag=0;
	   end

	   else 
	    begin 
		        if ( exists(select * from Administrator where Email=@Username  ))
		            begin
	                declare @check_password  varchar(30);
					select @check_password= password_a from Administrator where Email=@Username;
					            if(@check_password=@Password)
								begin
								 print 'Login Successful';set @flag=1;
								 end
								else
								begin
								 print 'Wrong Password';set @flag=0;
								 end

	                end
				else
				 begin
	                 print 'Incorrect Username';set @flag=0;
	                end
	    end

end
go
create procedure RemoveReservationForRoom_SP @CopyofReservation_id int,@success int out
as begin 
declare @CopyOfCheckIn datetime
declare @CopyOfDateTime datetime
select @CopyOfCheckIn=Reservation_rooms.check_in from Reservation_rooms where  Reservation_rooms.Reservation_id = @CopyofReservation_id
select @CopyOfDateTime = GETDATE()

if((DATEPART(DD,@CopyOfDateTime) >=  DATEPART(DD,@CopyOfCheckIn)) and (DATEPART(HH,@CopyOfDateTime) >= DATEPART(HH,@CopyOfCheckIn)+2))
begin
delete from Reservation_rooms where Reservation_rooms.Reservation_id = @CopyofReservation_id
set @success=1
end
else
print 'Cannot delete CheckIn Deadline Not Exceeded'
set @success=0
end
go

create procedure RoomCheckOut_SP @CopyofReservation_id int,@success int out, @Result int out
as begin
declare @CopyOfCheckIn date
declare @CopyofCheckOut datetime 
declare @DifferenceOfDate int
declare @IsPrivledge int
declare @CopyofCID int
declare @CopyofPrice int
declare @CopyofRoomNo int
declare @CopyofDiscount float
declare @Result int
declare @TotalDiscount int
select @CopyOfCheckIn= Record_Reservation_Rooms.check_in,@CopyofCheckOut=Record_Reservation_Rooms.check_out,@CopyofCID=Record_Reservation_Rooms.C_id,@CopyofRoomNo=Record_Reservation_Rooms.Room_no from Record_Reservation_Rooms where Record_Reservation_Rooms.Reservation_id=@CopyofReservation_id

SELECT @DifferenceOfDate=DATEDIFF(day,@CopyOfCheckIn,GETDATE()) 
select @IsPrivledge=Customer.Privelege from Customer where Customer.cid=@CopyofCID
select @CopyofPrice=room.Price,@CopyofDiscount=room.Discount from room where room.Room_no=@CopyofRoomNo


if(@IsPrivledge = 1)
begin 


select @Result=(@DifferenceOfDate*@CopyofPrice)-(@DifferenceOfDate*@CopyofPrice)*(0.2+@CopyofDiscount/100) 
end
else if(@CopyofDiscount != 0) 
begin
select @TotalDiscount = ((@DifferenceOfDate*@CopyofPrice)*(@CopyofDiscount/100)) 
select @Result=(@DifferenceOfDate*@CopyofPrice)- @TotalDiscount
end
else
begin
select @Result=@DifferenceOfDate*@CopyofPrice 
end

select @Result As Total

end
go

create procedure HallCheckOut_SP @CopyofReservation_id int,@success int out, @Result int out
as begin
declare @CopyOfCheckIn date
declare @CopyofCheckOut datetime 
declare @DifferenceOfDate int
declare @IsPrivledge int
declare @CopyofCID int
declare @CopyofPrice int
declare @CopyofHallNo int
declare @CopyofDiscount int
declare @Result int
select @CopyOfCheckIn= Record_Reservation_Halls.check_in,@CopyofCheckOut=Record_Reservation_Halls.check_out,@CopyofCID=Record_Reservation_Halls.C_id,@CopyofHallNo=Record_Reservation_Halls.Hall_no from Record_Reservation_Halls where Record_Reservation_Halls.Reservation_id=@CopyofReservation_id

SELECT @DifferenceOfDate=DATEDIFF(day,@CopyOfCheckIn,GETDATE()) 
select @IsPrivledge=Customer.Privelege from Customer where Customer.cid=@CopyofCID
select @CopyofPrice=Hall.Price,@CopyofDiscount=Hall.Discount from Hall where Hall.Hall_no=@CopyofHallNo

if(@IsPrivledge = 1)
begin 
select @Result=(@DifferenceOfDate*@CopyofPrice)-((@DifferenceOfDate*@CopyofPrice)*0.2 )
end
else if(@CopyofDiscount != 0) 
begin
select @Result  =(@DifferenceOfDate*@CopyofPrice)-(@DifferenceOfDate*@CopyofPrice)*(@CopyofDiscount/100) 
end
else
begin
select  @Result=@DifferenceOfDate*@CopyofPrice 
end

select @Result As Total

end
go

create procedure RemoveReservationForHall_SP @CopyofReservation_id int,@success int out
as begin 
declare @CopyOfCheckIn datetime
declare @CopyOfDateTime datetime
select @CopyOfCheckIn=Reservation_Halls.check_in from Reservation_Halls where  Reservation_Halls.Reservation_id = @CopyofReservation_id
select @CopyOfDateTime = GETDATE()

if((DATEPART(DD,@CopyOfDateTime) >=  DATEPART(DD,@CopyOfCheckIn)) and (DATEPART(HH,@CopyOfDateTime) >= DATEPART(HH,@CopyOfCheckIn)+2))
begin
delete from Reservation_Halls where Reservation_Halls.Reservation_id = @CopyofReservation_id
set @success=1
end
else
print 'Cannot delete CheckIn Deadline Not Exceeded'
set @success=1
end
go

create view show_reservationsHalls_view
as
select * from Reservation_Halls
go
create procedure show_reservationsHalls
as

begin 

select * from show_reservationsHalls_view

end
go
create view show_reservations_view
as
select * from Reservation_rooms
go
create procedure show_reservations
as

begin 

select * from show_reservations_view

end
go
create view show_reservationsRecord_view
as
select * from Record_Reservation_Rooms
go
create procedure show_reservationsRecord
as

begin 

select * from show_reservationsRecord_view

end
go
create view show_reservationsRecordHalls_view
as
select * from Record_Reservation_Halls
go
create procedure show_reservationsRecordHalls
as

begin 

select * from show_reservationsRecordHalls_view

end
go
create view show_application_view
as
select * from Applications

go
create procedure show_application
as
begin
select * from show_application_view
end

go
create view show_employee_view
as
select * from Employee
go

create procedure show_employee
as
begin
select * from show_employee_view
end

go

create view show_halls_available_view
as
select * from Hall where Status_h='available'
go

create procedure show_halls_available
as
begin
select * from show_halls_available_view
end

go

create view show_halls_occupied_view
as
select Hall_no,check_out as Available_at_time from Reservation_Halls 
go

create procedure show_halls_occupied
as
begin
select * from show_halls_occupied_view
end

go
create view show_rooms_available_view
as
select * from room where Status_r='available'
go

create procedure show_rooms_available
as
begin
select * from show_rooms_available_view
end

go

create view show_rooms_occupied_view
as
select Room_no,check_out as Available_at_time from Reservation_rooms
go

create procedure show_rooms_occupied
as
begin
select * from show_rooms_occupied_view
end

go

create view show_all_customer_info_view
as
select * from Customer
go

create procedure show_all_customer_info
as
begin
select * from show_all_customer_info_view
end

go

create view show_black_listed_view
as
select * from BlackList
go

create procedure show_black_listed
as
begin
select * from show_black_listed_view
end

go
create view show_Feedback_view
as
select * from Feedback
go

create procedure show_Feedback
as
begin
select * from show_Feedback_view
end

go

create view show_Menu_view
as
select * from Menu
go

create procedure show_Menu
as
begin
select * from show_Menu_view
end

go

create procedure CreateLogin
@emai varchar(50),
@password varchar(30)
as
begin
	Insert Employee_Login (Username,Password_u)
	values
	(@emai,@password)   
end
go

create Procedure InsertEmployee
@FName varchar(30),
@LName varchar(30),
@BD date,
@address varchar(30),
@sal int,
@DName varchar(30),
@DNoM varchar(20),
@gender varchar(8),
@CN varchar(15),
@email varchar(50)
as
begin
	declare @eid int = 1
	if exists (select E_id from Employee)
	begin
		select top(1) @eid =  E_id from Employee order by E_id desc
		set @eid = @eid + 1										
	end																	--Code to assign new Eid
	
	declare @DepNo int
	select @DepNo = Dno from Department where Name_d = @DName			--Code to determine dno using dname
	
	declare @sdate date
	set @sdate = GETDATE()

	Insert Employee (F_name,L_name,B_date,address_e,salary,Dno,DnoM,Sex,Cnic,Email,start_date_e)
	values
	(@eid, @FName, @LName, @BD, @address, @sal, @DepNo, @DNoM, @gender, @CN, @email, @sdate)
end
go

create procedure RejectApplication			
@CN_Ap varchar(15) = 'None',
@success int output
as
begin
	if(@CN_Ap != 'None')
	begin
		if exists (select * from Applications where Cnic = @CN_Ap)
		begin
			delete from Applications where Cnic = @CN_Ap
			set @success = 1
		end
		else
		begin
			set @success = 0
		end
	end
	else
	begin
		set @success = 0
	end
end
go


create procedure AcceptApplication			
@CN_Ap varchar(15) = 'None',
@sal_a int = 0
as
begin
	if(@CN_Ap != 'None')
	begin
		if exists (select * from Applications where Cnic = @CN_Ap)
		begin
			
		declare	@FNameAp varchar(30)
		select	@FNameAp = F_name from Applications where Cnic = @CN_Ap
		
		declare @LNameAp varchar(30)
		select	@LNameAp = L_name from Applications where Cnic = @CN_Ap

		declare	@BDAp date
		select	@BDAp = B_date from Applications where Cnic = @CN_Ap

		declare	@addressAp varchar(30)
		select	@addressAp = address_a from Applications where Cnic = @CN_Ap

		declare @DNameAp varchar(30)
		select	@DNameAp = dep_Name from Applications where Cnic = @CN_Ap

		declare	@genderAp varchar(8)
		select	@genderAp = sex from Applications where Cnic = @CN_Ap

		declare @emailAp varchar(50)
		select @emailAp = email from Applications where Cnic = @CN_Ap
		
		declare @Job_t2 varchar(20)
		select	@Job_t2 = job_type from Applications where Cnic = @CN_Ap



		execute InsertEmployee
		@FName = @FNameAp,
		@LName = @LNameAp,
		@BD = @BDAp,
		@address = @addressAp,
		@sal = @sal_a,
		@DName = @DNameAp,
		@DNoM =	@Job_t2,
		@gender = @genderAp,
		@CN = @CN_Ap,
		@email = @emailAp

		delete from Applications where Cnic = @CN_Ap
		end
		else
		begin
			Print 'No Application with given CNIC exists'
		end
	end
	else
	begin
		Print 'No CNIC is given'
	end
end
go

Create Procedure SendApplications
@FNameA varchar(30),
@LNameA varchar(30),
@BDA date,
@addressA varchar(30),
@DNameA varchar(30),
@DNoA varchar(20),				--Stores job type												
@genderA varchar(8),
@CNA varchar(15),
@emailA varchar(50)
as
begin

	Insert Applications(Cnic , F_name,L_name,B_date,job_type,address_a,Sex,Email,dep_Name)
	values
	(@CNA, @FNameA, @LNameA, @BDA, @DNoA, @addressA, @genderA, @emailA, @DNameA)
end
go

create procedure Reserve_room
@Rooms int,
@emai_res varchar(50),
@check_in datetime,
@check_out datetime,
@category varchar(10),
@success int output
as
begin
	declare @count_available int
	select @count_available = count(*) from room where Status_r = 'available' and Category=@category
	if(@count_available >= @Rooms)
	begin
		if exists(select * from Customer where Email = @emai_res)
		begin
			declare @cid_res int
			select @cid_res = cid from Customer where Email = @emai_res
			declare @Roomno int
			while(@Rooms != 0)
			begin
				select @Roomno = min(Room_no) from room where Status_r = 'available' and Category=@category
				
				insert into Reservation_rooms
				values
				(@cid_res, @check_in, @check_out, @Roomno)

				execute Update_Room
				@Room_no = @Roomno,
				@Status_r = 'occupied'

				set @Rooms = @Rooms - 1 
			end
			set @success = 1
		end
		else
		begin
			set @success = 0
		end	
	end
	else
	begin
		set @success = 0
	end

end
go
create procedure Reserve_hall
@Halls int,
@emai_res varchar(50),
@check_in datetime,
@check_out datetime,
@category varchar(10),
@success int output
as
begin
	declare @count_available int
	select @count_available = count(*) from Hall where Status_h = 'available' and Category=@category
	if(@count_available >= @Halls)
	begin
		if exists(select * from Customer where Email = @emai_res)
		begin
			declare @cid_res int
			select @cid_res = cid from Customer where Email = @emai_res
			declare @Hallno int
			while(@Halls != 0)
			begin
				select @Hallno = min(Hall_no) from Hall where Status_h = 'available' and Category=@category
				
				insert into Reservation_Halls
				values
				(@cid_res, @check_in, @check_out, @Hallno)

				execute Update_Hall
				@Hall_no = @Hallno,
				@Status_h = 'occupied'

				set @Halls = @Halls - 1 
			end
			set @success = 1
		end
		else
		begin
			set @success = 0
		end	
	end
	else
	begin
		set @success = 0
	end

end
go
create procedure Get_info
@email  varchar(40),
@Fname varchar(30) output ,
@Lname varchar(30) output,
@Privelege int output,
@CNIC char(15)  output,
@Address_c varchar(50) output,
@Phone varchar(11) output,
@City varchar(30) output

as
begin
select @Fname=Fname,@Lname=Lname,@Privelege=Privelege,@CNIC=CNIC,@Address_c=Address_c,@Phone=Phone,@City=City
 from customer where customer.Email=@email;

end

go

create Procedure Customer_Login_Checking

@Username varchar(30)=NULL,  @Password varchar(30)=NULL,
@flag int out
as

begin
       if(@Username=NULL or @Password=NULL)
	   begin
	   print 'Enter Username and Password';
	   set @flag=0;
	   end

	   else 
	    begin
		        if ( exists(select * from Customer where Email=@Username  ))
		            begin
	                declare @check_password  varchar(30);
					select @check_password= Password_c from Customer where Email=@Username;
					            if(@check_password=@Password)
								begin
								 print 'Login Successful';set @flag=1;
								 end
								else
								begin
								 print 'Wrong Password';set @flag=0;
								 end

	                end
				else
				 begin
	                 print 'Incorrect Username';set @flag=0;
	                end
	    end

end
go

create procedure blacklist_SP @CopyofCid int 
as begin
declare @CopyofFname varchar(30)
declare @CopyofLname varchar(30)
declare @CopyofCNIC varchar(15)
select @CopyofFname=Customer.Fname,@CopyofLname=Customer.Lname,@CopyofCNIC=Customer.CNIC from Customer where @CopyofCid=Customer.cid
INSERT BlackList ([Fname],[Lname],[Cnic]) values (@CopyofFname,@CopyofLname,@CopyofCNIC)

delete from Customer where cid = @CopyofCid
end
go

create Procedure Employee_Login_Checking

@Username varchar(30)=NULL,  @Password varchar(30)=NULL,@flag int out

as

begin
       if(@Username=NULL or @Password=NULL)
	   begin
	   print 'Enter Username and Password';
	   set @flag=0;
	   end

	   else 
	    begin
		        if ( exists(select * from Employee_Login where Employee_Login.Username=@Username  ))
		            begin
	                declare @check_password  varchar(30);
					select @check_password= Password_u from Employee_Login where Employee_Login.Username=@Username
					            if(@check_password=@Password)
								begin
								 print 'Login Successful';set @flag=1;
								 end
								else
								begin
								 print 'Wrong Password';set @flag=0;
								 end

	                end
				else
				 begin
	                 print 'Incorrect Username';set @flag=0;
	                end
	    end

end

go

create procedure manager_or_receptionist
@email varchar(50),
@job varchar(20) out
as
begin
select @job=DnoM from Employee where Email=@email
end
go





create procedure offers
as begin
select room.Category,room.Discount,room_category.Price  from room join room_category on room.Category=room_category.Category
end
go

create procedure change_the_discounts
@discount int,@category varchar(10)
as
begin
update room set Discount=@discount where Category=@category
update Hall set Discount=@discount where Category=@category
end
go