USE [DoctorsManagementSystem]
GO

/****** Object:  Table [dbo].[Doctor]    Script Date: 16/12/2016 10.56.34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Doctor](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[FormNumber] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Title] [varchar](50) NULL,
	[FullName] [varchar](100) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
	[LandLineNumber] [varchar](15) NULL,
	[Qualifications] [varchar](50) NOT NULL,
	[Speciality] [varchar](50) NOT NULL,
	[Expertise] [varchar](50) NOT NULL,
	[RegistrationNumber] [varchar](50) NOT NULL,
	[YearsOfExperience] [varchar](10) NULL,
	[ShortProfile] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Website] [varchar](50) NULL,
	[Subscription] [bit] NOT NULL,
	[SmartPhone] [bit] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

