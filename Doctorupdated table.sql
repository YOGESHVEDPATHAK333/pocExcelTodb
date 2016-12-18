USE [DoctorsManagementSystem]
GO

/****** Object:  Table [dbo].[Doctor]    Script Date: 18/12/2016 1.43.50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Doctor](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[FormNumber] [int] NULL,
	[Date] [date] NULL,
	[Title] [varchar](50) NULL,
	[FullName] [varchar](100) NULL,
	[Gender] [bit] NULL,
	[DateOfBirth] [date] NULL,
	[MobileNumber] [varchar](15) NULL,
	[LandLineNumber] [varchar](15) NULL,
	[Qualifications] [varchar](50) NULL,
	[Speciality] [varchar](50) NULL,
	[Expertise] [varchar](50) NULL,
	[RegistrationNumber] [varchar](50) NULL,
	[YearsOfExperience] [varchar](10) NULL,
	[ShortProfile] [varchar](100) NULL,
	[Email] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[Latitude] [decimal](18, 0) NULL,
	[Longitude] [decimal](18, 0) NULL,
	[Subscription] [bit] NULL,
	[SmartPhone] [bit] NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

