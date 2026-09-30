 
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
		('Class 1 - Small Motorcycle','It allows the driver to drive small motorcycles, It is suitable for motorcycles with small capacity and limited power.',5,18,15.0000),
		('Class 2 - Heavy Motorcycle License','Heavy Motorcycle License (Large Motorcycle License)',5,21,30.0000),
		('Class 3 - Ordinary driving license','Ordinary driving license (car licence)',10,18,20.0000),
		('Class 4 - Commercial','Commercial driving license (taxi/limousine)',10,21,200.0000),
		('Class 5 - Agricultural','Agricultural and work vehicles used in farming or construction, (tractors / tillage machinery)',10,21,50.000),
		('Class 6 - Small and medium bus','Small and medium bus license',10,21,250.0000),
		('Class 7 - Truck and heavy vehicle','Truck And Heavy Vehicle',5,21,3000);


	-- add tests types and its deatails 

		insert into TestTypes (TestTypeTitle,TestTypeDescription,TestPaidFees) values
			('Vision Test','This assesses the applicants visual acuity to ensure they have sufficient vision to drive safely',10.0000),
			('Written Test','This test assesses the applicants knowledge of traffic rules, road signs, and driving regulations. It typically consists of multiple-choice questions, and the applicant must select the correct answer(s). The written test aims to ensure that the applicant understands the rules of the road and can apply them in various driving scenarios',20.0000),
			('Street Test' , 'This test evaluates the applicants driving skills and ability to operate a motor vehicle safely on public roads. A licensed examiner accompanies the applicant in the vehicle and observes their driving performance.',35.0000);



			

	-- add discription to license issue resson  column to be as documentation for it 

	EXEC sp_addextendedProperty 
	@name=N'MS-Discription',
	@value=N'1-First Time,2-Renew,3-Replacement For Loast,4-Replacement For Damaged',
	@level0type=N'SCHEMA',@level0name='dbo',
	@level1type=N'TABLE',@level1name='Licenses',
	@level2type=N'COLUMN',@level2name='IssueReason';
