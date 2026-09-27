 
 insert into ApplicationsTypes values
	('NewLocalDrivingLicense',15.000),
	('NewDrivingLicenseRenewal',5.000),
	('ReplacementForLoastLicense',10.000),
	('ReplacementForDamagedLicense',5.000),
	('ReleaseDetainedDrivingLicense',15.000),
	('NewInternationalLicese',30.000);


	-- add discription to application status to be as documentation for it 

	EXEC sp_addextendedProperty 
	@name=N'MS-Discription',
	@value=N'1-New ,2-Cancle ,3-Completed ',
	@level0type=N'SCHEMA',@level0name='dbo',
	@level1type=N'TABLE',@level1name='Applications',
	@level2type=N'COLUMN',@level2name='ApplicationStatus';



	-- add license classes references data

	insert into LicenseClasses (ClassName,ClassDescription,DefaultValidityLength,MinimumAllowedAge,ClassFees) values
		('Small Motorcycle','Small Motorcycle License',5,18,15),
		('Heavy Motorcycle License','Heavy Motocycle License',5,18,30),
		('Ordinary Driving License','Ordinary Driving License',10,18,20),
		('Commercial Driving License','Commercial Driving License',5,21,200),
		('Agricultural Driving License','Agricultural Driving License',5,21,50),
		('Small And Medium Bus','Small And Medium Bus',5,21,250),
		('Truck And Heavy Vehicle','Truck And Heavy Vehicle',5,21,3000);