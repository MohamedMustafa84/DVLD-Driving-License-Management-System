
 create table Countries(
	CountryID int  Primary key IDENTITY(1,1) ,
	CountryName nvarchar(50)
 );



create Table People (
	PersonID int primary key IDENTITY(1,1),
	FirstName nvarchar(20) not null,
	SecondName nvarchar(20) not null,
	ThirdName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	NationalNo nvarchar(20) not null unique,
	DateOFBirth datetime not null,
	phone nvarchar(10) not null,
	NationaltyID int references Countries(CountryID),
	Email nvarchar(20) not null,
	PersonAddress nvarchar(500) not null,
	Gender tinyInt not null,
	ImagePath nvarchar(250) 
);


 
 create table Users(
	 UserID int  primary key IDENTITY(1,1),
	 PersonID int references People(PersonID),
	 UserName nvarchar(20) not null,
	 UserPassword nvarchar(20) not null,
	 IsActive bit not null
 );


 create table ApplicationsTypes(
	 ApplicationTypeID int primary key IDENTITY(1,1),
	 ApplicationTitle nvarchar(40) not null,
	 ApplicationFees smallmoney not null

 );

  create table Applications(
		ApplicationID int  primary key IDENTITY(1,1),
		ApplicationTypeID int not null references ApplicationsTypes(ApplicationTypeID),
		ApplicationDate DateTime not null ,
		ApplicationStatus nvarchar(20) null,
		LastStatusDate DateTime not null,
		PaidFees smallmoney not null,
		CreatedByUserID int references Users(UserID)not null
	);





	create Table LicenseClasses (
		LicenseClassID int  Primary Key IDENTITY(1,1),
		ClassName nvarchar(50) not null,
		ClassDescription nvarchar(500) not null,
		DefaultValityLength tinyint not null,
		MinimumAllowedAge tinyint  not null,
		ClassFees smallmoney not null
	);
 

 create Table LocalDrivingLicenseApplications (
	 LocalDrivingLicenseApplicationID int Primary Key IDENTITY(1,1) ,
	 ApplicationID int  not null references Applications(ApplicationID),
	 LicenseClassID int not null references LicenseClasses(LicenseClassID)
 );


 Create Table TestTypes ( 
	 TestTypeID int  Primary key IDENTITY(1,1),
	 TestTypeTitle nvarchar(100) not null,
	 TestTypeDescription nvarchar(500) not null,
	 TestPaidFees smallmoney not null 
 );



 
 create table TestAppointments (
	 TestAppointmentID int  Primary Key IDENTITY(1,1),
	 TestTypeID int not null references TestTypes(TestTypeID),
	 CreatedByUserID int not null references Users(UserID),
	 AppointmentDate datetime not null ,
	 LocallDrivingLicenseApplicatioID int not null references LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID),
	 PaidFees smallmoney  not null ,
	 AppilicationID int references Applications(ApplicationID) not null,
	 ISlocked bit  not null ,
	 RetakeTestApplicationID int references Applications(ApplicationID)
 );


 Create Table Tests(
	TestID int primary key IDENTITY(1,1) ,
	TestAppointmentID int references TestAppointments(TestAppointmentID) not null,
	TestResult bit ,
	Notes nvarchar(500) ,
	CreatedByUserID int references Users(UserID) not null 

);



  create Table Drivers (
	DriverID int Primary key IDENTITY(1,1) ,
	PersonID int references People(PersonID)  not null ,
	CreatedByUserID  int references Users(UserID) not null ,
	CreatDate datetime not null
);

  create table Licenses (
	 LicenseID int  Primary key IDENTITY(1,1),
	 LicenseClassID int references LicenseClasses(LicenseClassID) not null ,
	 DriverID int references Drivers(DriverID ) not null ,
	 IssueDate datetime not null,
	 ExperationDate datetime not null ,
	 Notes nvarchar(500) ,
	 PaidFees smallmoney not null,
	 IsActive bit not null,
	 IssueReason tinyint not null ,
	 CreatedByUserID  int references Users(UserID ) not null
	);


	create table DetainedLicenses (
		 DetainedID int primary key IDENTITY(1,1) ,
		 LicenseID int references Licenses(LicenseID ) not null ,
		 DetainedDate datetime not null ,
		 FineFees smallmoney  not null ,
		 CreatedByUserID int references Users(UserID) not null ,
		 IsReleased bit not null ,
		 ReleasedDate datetime ,
		 ReleasedByUserID  int references Users(UserID ),
		 ReleasedApplicationID int references Applications(ApplicationID)
	);


