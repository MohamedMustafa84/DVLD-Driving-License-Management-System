 
 
 
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