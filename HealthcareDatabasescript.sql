USE [master]
GO
/****** Object:  Database [Healthcare ]    Script Date: 14-04-2023 05:11:20 PM ******/
CREATE DATABASE [Healthcare ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Healthcare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Healthcare .mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Healthcare _log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Healthcare _log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Healthcare ] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Healthcare ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Healthcare ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Healthcare ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Healthcare ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Healthcare ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Healthcare ] SET ARITHABORT OFF 
GO
ALTER DATABASE [Healthcare ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Healthcare ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Healthcare ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Healthcare ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Healthcare ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Healthcare ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Healthcare ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Healthcare ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Healthcare ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Healthcare ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Healthcare ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Healthcare ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Healthcare ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Healthcare ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Healthcare ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Healthcare ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Healthcare ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Healthcare ] SET RECOVERY FULL 
GO
ALTER DATABASE [Healthcare ] SET  MULTI_USER 
GO
ALTER DATABASE [Healthcare ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Healthcare ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Healthcare ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Healthcare ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Healthcare ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Healthcare ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Healthcare ', N'ON'
GO
ALTER DATABASE [Healthcare ] SET QUERY_STORE = OFF
GO
USE [Healthcare ]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[DeviceID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [nvarchar](50) NOT NULL,
	[DeviceBrand] [nvarchar](50) NOT NULL,
	[PhotoPath] [nvarchar](500) NOT NULL,
	[Price] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[DeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disease]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disease](
	[diseaseID] [int] IDENTITY(1,1) NOT NULL,
	[diseaseName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Disease] PRIMARY KEY CLUSTERED 
(
	[diseaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_Assigndevice]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_Assigndevice](
	[AssignID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
 CONSTRAINT [PK_map_Assigndevice] PRIMARY KEY CLUSTERED 
(
	[AssignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_AssignDisease ]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_AssignDisease ](
	[AssignID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DiseaseID] [int] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[AssignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_AssignMedicine]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_AssignMedicine](
	[AssignID] [int] IDENTITY(1,1) NOT NULL,
	[MedicineID] [int] NOT NULL,
	[PatientID] [int] NOT NULL,
 CONSTRAINT [PK_map_AssignMedicine] PRIMARY KEY CLUSTERED 
(
	[AssignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_Disease_Device]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_Disease_Device](
	[AssignID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceID] [int] NOT NULL,
	[DiseaseID] [int] NOT NULL,
 CONSTRAINT [PK_map_Disease_Device] PRIMARY KEY CLUSTERED 
(
	[AssignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_Disease_Doctor_User]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_Disease_Doctor_User](
	[AssignID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[DiseaseID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Disease_Doctor_User] PRIMARY KEY CLUSTERED 
(
	[AssignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_SelectDisease]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_SelectDisease](
	[SelectID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NOT NULL,
	[DiseaseID] [int] NOT NULL,
 CONSTRAINT [PK_map_SelectDisease] PRIMARY KEY CLUSTERED 
(
	[SelectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[map_Selectdoctor]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[map_Selectdoctor](
	[SelectID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[DoctorID] [int] NOT NULL,
 CONSTRAINT [PK_map_Selectdoctor] PRIMARY KEY CLUSTERED 
(
	[SelectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[MedicineID] [int] IDENTITY(1,1) NOT NULL,
	[Medicinename] [nvarchar](50) NOT NULL,
	[UsageInstructions] [nvarchar](50) NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
	[ActiveIngredient] [nvarchar](50) NOT NULL,
	[SideEffects] [nvarchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Medicine] PRIMARY KEY CLUSTERED 
(
	[MedicineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MLT_User]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MLT_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_MLT_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Readings]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Readings](
	[ReadingID] [int] IDENTITY(1,1) NOT NULL,
	[AssignID] [int] NOT NULL,
	[ReadingValue] [float] NOT NULL,
	[ReadingDate] [date] NOT NULL,
 CONSTRAINT [PK_Readings] PRIMARY KEY CLUSTERED 
(
	[ReadingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recommendation]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recommendation](
	[RecoID] [int] NOT NULL,
	[PatientID] [int] NOT NULL,
	[DoctorID] [int] NOT NULL,
	[Recommend] [nvarchar](500) NOT NULL,
	[Create] [datetime] NOT NULL,
	[Update] [datetime] NOT NULL,
 CONSTRAINT [PK_Recommendation] PRIMARY KEY CLUSTERED 
(
	[RecoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [int] NOT NULL,
	[PatientID] [int] NOT NULL,
	[ReportDate] [date] NOT NULL,
	[FilePath] [nvarchar](500) NOT NULL,
	[ReportResults] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[US_Doctor]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[US_Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[OfficeAddress] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_US_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[US_Patient]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[US_Patient](
	[Patient_ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[address] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_dbo.US_Patient] PRIMARY KEY CLUSTERED 
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[US_Patient] ADD  CONSTRAINT [DF_US_Patient_BirthDate]  DEFAULT (getdate()) FOR [BirthDate]
GO
ALTER TABLE [dbo].[map_Assigndevice]  WITH CHECK ADD  CONSTRAINT [FK_map_Assigndevice_Devices] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Devices] ([DeviceID])
GO
ALTER TABLE [dbo].[map_Assigndevice] CHECK CONSTRAINT [FK_map_Assigndevice_Devices]
GO
ALTER TABLE [dbo].[map_Assigndevice]  WITH CHECK ADD  CONSTRAINT [FK_map_Assigndevice_US_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[MLT_User] ([UserID])
GO
ALTER TABLE [dbo].[map_Assigndevice] CHECK CONSTRAINT [FK_map_Assigndevice_US_Patient]
GO
ALTER TABLE [dbo].[map_AssignDisease ]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Disease] FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[Disease] ([diseaseID])
GO
ALTER TABLE [dbo].[map_AssignDisease ] CHECK CONSTRAINT [FK_Table_1_Disease]
GO
ALTER TABLE [dbo].[map_AssignDisease ]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_US_Patient] FOREIGN KEY([UserID])
REFERENCES [dbo].[MLT_User] ([UserID])
GO
ALTER TABLE [dbo].[map_AssignDisease ] CHECK CONSTRAINT [FK_Table_1_US_Patient]
GO
ALTER TABLE [dbo].[map_AssignMedicine]  WITH CHECK ADD  CONSTRAINT [FK_map_AssignMedicine_map_AssignMedicine] FOREIGN KEY([MedicineID])
REFERENCES [dbo].[Medicine] ([MedicineID])
GO
ALTER TABLE [dbo].[map_AssignMedicine] CHECK CONSTRAINT [FK_map_AssignMedicine_map_AssignMedicine]
GO
ALTER TABLE [dbo].[map_AssignMedicine]  WITH CHECK ADD  CONSTRAINT [FK_map_AssignMedicine_US_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[US_Patient] ([Patient_ID])
GO
ALTER TABLE [dbo].[map_AssignMedicine] CHECK CONSTRAINT [FK_map_AssignMedicine_US_Patient]
GO
ALTER TABLE [dbo].[map_Disease_Device]  WITH CHECK ADD  CONSTRAINT [FK_map_Disease_Device_Devices] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Devices] ([DeviceID])
GO
ALTER TABLE [dbo].[map_Disease_Device] CHECK CONSTRAINT [FK_map_Disease_Device_Devices]
GO
ALTER TABLE [dbo].[map_Disease_Device]  WITH CHECK ADD  CONSTRAINT [FK_map_Disease_Device_Disease] FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[Disease] ([diseaseID])
GO
ALTER TABLE [dbo].[map_Disease_Device] CHECK CONSTRAINT [FK_map_Disease_Device_Disease]
GO
ALTER TABLE [dbo].[map_Disease_Doctor_User]  WITH CHECK ADD  CONSTRAINT [FK_Disease_Doctor_User_Disease] FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[Disease] ([diseaseID])
GO
ALTER TABLE [dbo].[map_Disease_Doctor_User] CHECK CONSTRAINT [FK_Disease_Doctor_User_Disease]
GO
ALTER TABLE [dbo].[map_Disease_Doctor_User]  WITH CHECK ADD  CONSTRAINT [FK_Disease_Doctor_User_MLT_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[MLT_User] ([UserID])
GO
ALTER TABLE [dbo].[map_Disease_Doctor_User] CHECK CONSTRAINT [FK_Disease_Doctor_User_MLT_User]
GO
ALTER TABLE [dbo].[map_Disease_Doctor_User]  WITH CHECK ADD  CONSTRAINT [FK_Disease_Doctor_User_US_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[US_Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[map_Disease_Doctor_User] CHECK CONSTRAINT [FK_Disease_Doctor_User_US_Doctor]
GO
ALTER TABLE [dbo].[map_SelectDisease]  WITH CHECK ADD  CONSTRAINT [FK_map_SelectDisease_Disease] FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[Disease] ([diseaseID])
GO
ALTER TABLE [dbo].[map_SelectDisease] CHECK CONSTRAINT [FK_map_SelectDisease_Disease]
GO
ALTER TABLE [dbo].[map_SelectDisease]  WITH CHECK ADD  CONSTRAINT [FK_map_SelectDisease_US_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[US_Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[map_SelectDisease] CHECK CONSTRAINT [FK_map_SelectDisease_US_Doctor]
GO
ALTER TABLE [dbo].[map_Selectdoctor]  WITH CHECK ADD  CONSTRAINT [FK_map_Selectdoctor_US_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[US_Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[map_Selectdoctor] CHECK CONSTRAINT [FK_map_Selectdoctor_US_Doctor]
GO
ALTER TABLE [dbo].[map_Selectdoctor]  WITH CHECK ADD  CONSTRAINT [FK_map_Selectdoctor_US_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[MLT_User] ([UserID])
GO
ALTER TABLE [dbo].[map_Selectdoctor] CHECK CONSTRAINT [FK_map_Selectdoctor_US_Patient]
GO
ALTER TABLE [dbo].[Readings]  WITH CHECK ADD  CONSTRAINT [FK_Readings_map_Assigndevice] FOREIGN KEY([ReadingID])
REFERENCES [dbo].[map_Assigndevice] ([AssignID])
GO
ALTER TABLE [dbo].[Readings] CHECK CONSTRAINT [FK_Readings_map_Assigndevice]
GO
ALTER TABLE [dbo].[Recommendation]  WITH CHECK ADD  CONSTRAINT [FK_Recommendation_US_Doctor] FOREIGN KEY([DoctorID])
REFERENCES [dbo].[US_Doctor] ([DoctorID])
GO
ALTER TABLE [dbo].[Recommendation] CHECK CONSTRAINT [FK_Recommendation_US_Doctor]
GO
ALTER TABLE [dbo].[Recommendation]  WITH CHECK ADD  CONSTRAINT [FK_Recommendation_US_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[US_Patient] ([Patient_ID])
GO
ALTER TABLE [dbo].[Recommendation] CHECK CONSTRAINT [FK_Recommendation_US_Patient]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_US_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[US_Patient] ([Patient_ID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_US_Patient]
GO
/****** Object:  StoredProcedure [dbo].[PR_assignDisease_Delete]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       procedure [dbo].[PR_assignDisease_Delete]
		@assignID	int

AS

DELETE 

FROM [dbo].[map_Disease_Doctor_User]

WHERE [dbo].[map_Disease_Doctor_User].[AssignID] = @assignID
GO
/****** Object:  StoredProcedure [dbo].[PR_assignDisease_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE         PROCEDURE [dbo].[PR_assignDisease_Insert]
	@userID  int,
    @DiseaseID  int
		
AS

INSERT INTO [dbo].[map_AssignDisease ]

(
	       [dbo].[map_AssignDisease ].[UserID],
		   [dbo].[map_AssignDisease ].[DiseaseID]
		   
		  
)

VALUES
(
	@userID,
	@DiseaseID
)
GO
/****** Object:  StoredProcedure [dbo].[PR_AssignDisease_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE           procedure [dbo].[PR_AssignDisease_SelectAll]

AS

SELECT
           [dbo].[map_AssignDisease ].[AssignID],
		   [dbo].[MLT_User].[UserName],
		   [dbo].[Disease].[diseaseName]
FROM	   [dbo].[map_AssignDisease]

INNER JOIN  [dbo].[MLT_User]
ON			[dbo].[MLT_User].[UserID] = [dbo].[map_AssignDisease ].[UserID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_AssignDisease ].[DiseaseID]

ORDER BY	[dbo].[map_AssignDisease ].[AssignID]
			
GO
/****** Object:  StoredProcedure [dbo].[PR_assignDisease_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     procedure [dbo].[PR_assignDisease_SelectByPK] 
	@assignID	int
		
AS

SELECT 
		 [dbo].[map_AssignDisease ].[AssignID],
		 [dbo].[map_AssignDisease ].[DiseaseID],
		 [dbo].[map_AssignDisease ].[UserID]		 
FROM     [dbo].[map_AssignDisease ]

INNER JOIN  [dbo].[MLT_User]
ON			[dbo].[MLT_User].[UserID] = [dbo].[map_AssignDisease ].[UserID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_AssignDisease ].[DiseaseID]


WHERE  [dbo].[map_AssignDisease ].[AssignID]=@assignID;

GO
/****** Object:  StoredProcedure [dbo].[PR_assignDisease_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    Procedure [dbo].[PR_assignDisease_UpdateByPK]
	@assignID int,
	@DiseaseID int,
	@userID int
   
AS

Update [dbo].[map_AssignDisease ]

Set    
	  [dbo].[map_AssignDisease ].[DiseaseID]= @DiseaseID,
	  [dbo].[map_AssignDisease ].[UserID]= @userID   
Where [dbo].[map_AssignDisease ].[AssignID]  = @assignID
GO
/****** Object:  StoredProcedure [dbo].[PR_Device_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[PR_Device_Insert]
	@DeviceName  nvarchar(100),
    @DeviceBarnd  nvarchar(100),
	@DevicePhotoPath nvarchar(500),
	@Price nvarchar(50),
	@des nvarchar(1000)
AS

INSERT INTO [dbo].[Devices]
(
	  [dbo].[Devices].[DeviceName] ,
	   [dbo].[Devices].[DeviceBrand],
	   [dbo].[Devices].[PhotoPath] ,
	   [dbo].[Devices].[Price],
	   [dbo].[Devices].[Description]
)

VALUES
(
	@DeviceName,
	@DeviceBarnd,
	@DevicePhotoPath,
	 @Price,
	 @des
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Device_SelectComboBox]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create    PROCEDURE [dbo].[PR_Device_SelectComboBox] 
	
AS
SELECT 
			[dbo].[Devices].[DeviceID],
			[dbo].[Devices].[DeviceName]			
FROM [dbo].[Devices]

GO
/****** Object:  StoredProcedure [dbo].[PR_Devices_DeleteByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   Procedure [dbo].[PR_Devices_DeleteByPK]
	
	@DeviceID int

AS

Delete from [dbo].[map_Assigndevice]
Where [dbo].[map_Assigndevice].[DeviceID] = @DeviceID

Delete from [dbo].[Devices]
Where [dbo].[Devices].[DeviceID] = @DeviceID
GO
/****** Object:  StoredProcedure [dbo].[PR_Devices_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     procedure [dbo].[PR_Devices_SelectAll]

AS

SELECT
           [dbo].[Devices].[DeviceID],
		   [dbo].[Devices].[DeviceName],
		   [dbo].[Devices].[DeviceBrand],
		   [dbo].[Devices].[PhotoPath],
		   [dbo].[Devices].[Price],
		   [dbo].[Devices].[Description]
FROM	   [dbo].[Devices]

GO
/****** Object:  StoredProcedure [dbo].[PR_Devices_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[PR_Devices_SelectByPK]

	@deviceID int

AS

SELECT [dbo].[Devices].[DeviceID],
	   [dbo].[Devices].[DeviceName],
	   [dbo].[Devices].[DeviceBrand],
	   [dbo].[Devices].[PhotoPath],
	  [dbo].[Devices].[Price],
	   [dbo].[Devices].[Description]
FROM [dbo].[Devices]

WHERE [dbo].[Devices].[DeviceID] = @deviceID 
GO
/****** Object:  StoredProcedure [dbo].[PR_Devices_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   Procedure [dbo].[PR_Devices_UpdateByPK]
	
	@DeviceID int,
	@DeviceName  nvarchar(100),
    @DeviceBrand  nvarchar(100),
	@DevicePhotoPath nvarchar(500),
	@Price nvarchar(50),
	@des nvarchar(1000)


AS

Update [dbo].[Devices]

Set    
	   [dbo].[Devices].[DeviceName] = @DeviceName,
	   [dbo].[Devices].[DeviceBrand] = @DeviceBrand,
	   [dbo].[Devices].[PhotoPath] = @DevicePhotoPath,
	   [dbo].[Devices].[Price] = @Price,
	   [dbo].[Devices].[Description] = @des
Where [dbo].[Devices].[DeviceID]  = @DeviceID
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_DeleteByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       Procedure [dbo].[PR_Disease_DeleteByPK]
	
	@diseaseID int

AS

Delete from [dbo].[map_Selectdisease]
Where [dbo].[map_Selectdisease].[DiseaseID] = @diseaseID

Delete from [dbo].[map_AssignDisease ]
Where [dbo].[map_AssignDisease ].[DiseaseID] = @diseaseID

Delete from [dbo].[Disease]
Where [dbo].[Disease].[DiseaseID] = @diseaseID
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Device_Delete]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       procedure [dbo].[PR_Disease_Device_Delete]
		@assignID	int

AS

DELETE 

FROM [dbo].[map_Disease_Device]

WHERE [dbo].[map_Disease_Device].[AssignID] = @assignID
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Device_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create           PROCEDURE [dbo].[PR_Disease_Device_Insert]
	@deviceID  int,
    @diseaseID  int
		
AS

INSERT INTO [dbo].[map_Disease_Device]

(
	       [dbo].[map_Disease_Device].[DeviceID],
		   [dbo].[map_Disease_Device].[DiseaseID]
		   
		  
)

VALUES
(
	@deviceID,
	@diseaseID
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Device_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE             procedure [dbo].[PR_Disease_Device_SelectAll]

AS

SELECT
           [dbo].[map_Disease_Device].[AssignID],
		   [dbo].[Devices].[DeviceName],		   
		   [dbo].[Disease].[diseaseName]
FROM	   [dbo].[map_Disease_Device]

INNER JOIN  [dbo].[Devices]
ON			[dbo].[Devices].[DeviceID] = [dbo].[map_Disease_Device].[DeviceID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_Disease_Device].[DiseaseID]

ORDER BY	[dbo].[map_Disease_Device].[AssignID]
			
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Device_SelectByDiseaseID]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     procedure [dbo].[PR_Disease_Device_SelectByDiseaseID] 
@DiseaseID int
AS

SELECT
           [dbo].[map_Disease_Device].[AssignID],
		   [dbo].[Devices].[DeviceID],
		   [dbo].[Devices].[DeviceName],
		   [dbo].[Devices].[DeviceBrand],
		   [dbo].[Devices].[PhotoPath],
		   [dbo].[Devices].[Price],
		   [dbo].[Devices].[Description],
		   [dbo].[Disease].[diseaseName]
FROM	   [dbo].[map_Disease_Device]

INNER JOIN  [dbo].[Devices]
ON			[dbo].[Devices].[DeviceID] = [dbo].[map_Disease_Device].[DeviceID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_Disease_Device].[DiseaseID]
 
 Where [dbo].[map_Disease_Device].[DiseaseID]=@DiseaseID
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Device_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       procedure [dbo].[PR_Disease_Device_SelectByPK] 
	@assignID	int
		
AS

SELECT 
		 [dbo].[map_Disease_Device].[AssignID],
		 [dbo].[map_Disease_Device].[DiseaseID],
		 [dbo].[map_Disease_Device].[DeviceID]		 
FROM     [dbo].[map_Disease_Device]

INNER JOIN  [dbo].[Devices]
ON			[dbo].[Devices].[DeviceID] = [dbo].[map_Disease_Device].[DeviceID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_Disease_Device].[DiseaseID]


WHERE  [dbo].[map_Disease_Device].[AssignID]=@assignID;

GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Device_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create      Procedure [dbo].[PR_Disease_Device_UpdateByPK]
	@assignID int,
	@DiseaseID int,
	@deviceID int
   
AS

Update [dbo].[map_Disease_Device]

Set    
	  [dbo].[map_Disease_Device].[DiseaseID]= @DiseaseID,
	  [dbo].[map_Disease_Device].[DeviceID]= @deviceID   
Where [dbo].[map_Disease_Device].[AssignID]  = @assignID
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Docror_User_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE           PROCEDURE [dbo].[PR_Disease_Docror_User_Insert]
	@userID  int,
    @DiseaseID  int,
	@DoctorID   int
		
AS

INSERT INTO [dbo].[map_Disease_Doctor_User]

(
	       [dbo].[Disease_Doctor_User].[UserID],
		   [dbo].[Disease_Doctor_User].[DiseaseID],
		   [dbo].[Disease_Doctor_User].[DoctorID]
		  
)

VALUES
(
	@userID,
	@DiseaseID,
	@DoctorID 
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Doctor_user_Delete]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       procedure [dbo].[PR_Disease_Doctor_user_Delete]
		@assignID	int

AS

DELETE 

FROM [dbo].[map_Disease_Doctor_User]

WHERE [dbo].[map_Disease_Doctor_User].[AssignID] = @assignID
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Doctor_User_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     procedure [dbo].[PR_Disease_Doctor_User_SelectAll]

AS

SELECT
            [dbo].[map_Disease_Doctor_User].[AssignID],
		    [dbo].[map_Disease_Doctor_User].[DiseaseID],
			[dbo].[map_Disease_Doctor_User].[DoctorID],
			[dbo].[map_Disease_Doctor_User].[UserID],
		   [dbo].[MLT_User].[UserName],
		   [dbo].[Disease].[diseaseName],
		   [dbo].[US_Doctor].[DoctorName]
FROM	   [dbo].[map_Disease_Doctor_User]

INNER JOIN  [dbo].[MLT_User]
ON			[dbo].[MLT_User].[UserID] = [dbo].[map_Disease_Doctor_User].[UserID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_Disease_Doctor_User].[DiseaseID]

INNER JOIN  [dbo].[US_Doctor]
ON			[dbo].[US_Doctor].[DoctorID] = [dbo].[map_Disease_Doctor_User].[DoctorID]

	
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Doctor_User_SelectAllBYuser_doctor_disease_id]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       procedure [dbo].[PR_Disease_Doctor_User_SelectAllBYuser_doctor_disease_id]
@userID int,
@doctorID int,
@diseaseID int
AS

SELECT
            [dbo].[map_Disease_Doctor_User].[AssignID],
		    [dbo].[map_Disease_Doctor_User].[DiseaseID],
			[dbo].[map_Disease_Doctor_User].[DoctorID],
			[dbo].[map_Disease_Doctor_User].[UserID],
		   [dbo].[MLT_User].[UserName],
		   [dbo].[Disease].[diseaseName],
		   [dbo].[US_Doctor].[DoctorName]
FROM	   [dbo].[map_Disease_Doctor_User]

INNER JOIN  [dbo].[MLT_User]
ON			[dbo].[MLT_User].[UserID] = [dbo].[map_Disease_Doctor_User].[UserID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_Disease_Doctor_User].[DiseaseID]

INNER JOIN  [dbo].[US_Doctor]
ON			[dbo].[US_Doctor].[DoctorID] = [dbo].[map_Disease_Doctor_User].[DoctorID]

where  
[dbo].[map_Disease_Doctor_User].[UserID]=@userID
AND
[dbo].[map_Disease_Doctor_User].[DoctorID]=@doctorID
AND
[dbo].[map_Disease_Doctor_User].[DiseaseID]=@diseaseID

		
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Doctor_User_SelectAllBYuserid]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     procedure [dbo].[PR_Disease_Doctor_User_SelectAllBYuserid]
@userID int
AS

SELECT
            [dbo].[map_Disease_Doctor_User].[AssignID],
		    [dbo].[map_Disease_Doctor_User].[DiseaseID],
			[dbo].[map_Disease_Doctor_User].[DoctorID],
			[dbo].[map_Disease_Doctor_User].[UserID],
		   [dbo].[MLT_User].[UserName],
		   [dbo].[Disease].[diseaseName],
		   [dbo].[US_Doctor].[DoctorName]
FROM	   [dbo].[map_Disease_Doctor_User]

INNER JOIN  [dbo].[MLT_User]
ON			[dbo].[MLT_User].[UserID] = [dbo].[map_Disease_Doctor_User].[UserID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_Disease_Doctor_User].[DiseaseID]

INNER JOIN  [dbo].[US_Doctor]
ON			[dbo].[US_Doctor].[DoctorID] = [dbo].[map_Disease_Doctor_User].[DoctorID]

where  [dbo].[map_Disease_Doctor_User].[UserID]=@userID

		
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[PR_Disease_Insert]
	@DiseaseName  nvarchar(100)
AS

INSERT INTO [dbo].[Disease]

(
	       [dbo].[Disease].[diseaseName]
)

VALUES
(
	@DiseaseName
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       procedure [dbo].[PR_Disease_SelectAll]

AS

SELECT
           [dbo].[Disease].[diseaseID],
		   [dbo].[Disease].[diseaseName]
FROM	   [dbo].[Disease]
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[PR_Disease_SelectByPK]

	@diseaseID int

AS

SELECT [dbo].[Disease].[diseaseID],
	   [dbo].[Disease].[diseaseName]
FROM  [dbo].[Disease]

WHERE  [dbo].[Disease].[diseaseID] = @diseaseID 
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_SelectComboBox]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create    PROCEDURE [dbo].[PR_Disease_SelectComboBox] 
	
AS
SELECT 
			[dbo].[Disease].[diseaseID],
			[dbo].[Disease].[diseaseName]			
FROM [dbo].[Disease]


		
GO
/****** Object:  StoredProcedure [dbo].[PR_Disease_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     Procedure [dbo].[PR_Disease_UpdateByPK]
	
	@DiseaseID int,
	@DiseaseName  nvarchar(100)
   
AS

Update [dbo].[Disease]

Set    
	   [dbo].[Disease].[diseaseName] = @DiseaseName   
Where [dbo].[Disease].[diseaseID]  = @DiseaseID
GO
/****** Object:  StoredProcedure [dbo].[PR_Doctor_DeleteByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     Procedure [dbo].[PR_Doctor_DeleteByPK]
	
	@doctorID int

AS

Delete from [dbo].[map_Selectdisease]
Where [dbo].[map_Selectdisease].[DoctorID] = @doctorID

Delete from [dbo].[map_Selectdoctor]
Where [dbo].[map_Selectdoctor].[DoctorID] = @doctorID

Delete from [dbo].[US_Doctor]
Where [dbo].[US_Doctor].[DoctorID] = @doctorID
GO
/****** Object:  StoredProcedure [dbo].[PR_Doctor_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[PR_Doctor_Insert]
	@doctorName  nvarchar(100),
    @des  nvarchar(100),
	@email nvarchar(500),
	@phone nvarchar(100),
	@officeAdd nvarchar(1000)
AS

INSERT INTO [dbo].[US_Doctor]
(
	 [dbo].[US_Doctor].[DoctorName] ,
	   [dbo].[US_Doctor].[Description],
	    [dbo].[US_Doctor].[Email] ,
	   [dbo].[US_Doctor].[PhoneNumber] ,
	   [dbo].[US_Doctor].[OfficeAddress]
)

VALUES
(
	@doctorName,
	@des,
	@email,
	@phone,
	 @officeAdd
)
GO
/****** Object:  StoredProcedure [dbo].[PR_Doctor_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       procedure [dbo].[PR_Doctor_SelectAll]

AS

SELECT
           [dbo].[US_Doctor].[DoctorID],
		   [dbo].[US_Doctor].[DoctorName],
		   [dbo].[US_Doctor].[Description],
		   [dbo].[US_Doctor].[Email],
		   [dbo].[US_Doctor].[PhoneNumber],
		   [dbo].[US_Doctor].[OfficeAddress]
FROM	   [dbo].[US_Doctor]
GO
/****** Object:  StoredProcedure [dbo].[PR_Doctor_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[PR_Doctor_SelectByPK]

	@doctorID int

AS

SELECT [dbo].[US_Doctor].[DoctorID],
	   [dbo].[US_Doctor].[DoctorName],
	   [dbo].[US_Doctor].[Description],
	   [dbo].[US_Doctor].[Email],
	   [dbo].[US_Doctor].[PhoneNumber],
	   [dbo].[US_Doctor].[OfficeAddress]
FROM   [dbo].[US_Doctor]

WHERE [dbo].[US_Doctor].[DoctorID] = @doctorID
GO
/****** Object:  StoredProcedure [dbo].[PR_Doctor_SelectComboBox]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create    PROCEDURE [dbo].[PR_Doctor_SelectComboBox] 
	
AS
SELECT 
			[dbo].[US_Doctor].[DoctorID],
			[dbo].[US_Doctor].[DoctorName]
			
FROM [dbo].[US_Doctor]
GO
/****** Object:  StoredProcedure [dbo].[PR_Doctor_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     Procedure [dbo].[PR_Doctor_UpdateByPK]
	
	@doctorID int,
	@doctorName  nvarchar(100),
    @des  nvarchar(100),
	@email nvarchar(500),
	@phone nvarchar(100),
	@officeAdd nvarchar(1000)

AS

Update [dbo].[US_Doctor] 

Set    
	  [dbo].[US_Doctor].[DoctorName]= @doctorName,
	   [dbo].[US_Doctor].[Description]= @des,
	    [dbo].[US_Doctor].[Email] = @email,
	   [dbo].[US_Doctor].[PhoneNumber] = @phone,
	   [dbo].[US_Doctor].[OfficeAddress]=@officeAdd
Where [dbo].[US_Doctor].[DoctorID] = @doctorID
GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_Delete]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   PROCEDURE [dbo].[PR_MLT_User_Delete] 

@UserID	int

AS

DELETE

FROM

[dbo].[MLT_User]

WHERE [dbo].[MLT_User].[UserID] =	@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

create   PROCEDURE [dbo].[PR_MLT_User_Insert]		

@UserName	nchar(50),
@Password	nchar(50),
@CreationDate	datetime,
@ModificationDate	datetime

AS

INSERT INTO [dbo].[MLT_User] 	
(
	UserName,
	Password,
	CreationDate,
	ModificationDate
	
)

VALUES
(
	@UserName,
	@Password,
	ISNULL(@CreationDate,GETDATE()),
	ISNULL(@ModificationDate,GETDATE())

)
GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   PROCEDURE[dbo].[PR_MLT_User_SelectAll] 


AS

SELECT

		 [dbo].[MLT_User].[UserID],
		 [dbo].[MLT_User].[UserName],
		 [dbo].[MLT_User].[Password],
		 [dbo].[MLT_User].[CreationDate],
		[dbo].[MLT_User].[ModificationDate]

		

				

FROM	[dbo].[MLT_User]
GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   PROCEDURE[dbo].[PR_MLT_User_SelectByPK]

@UserID	int


AS

SELECT

		 [dbo].[MLT_User].[UserID],
		 [dbo].[MLT_User].[UserName],
		 [dbo].[MLT_User].[Password],
		 [dbo].[MLT_User].[CreationDate],
		 [dbo].[MLT_User].[ModificationDate]	

FROM	[dbo].[MLT_User]

WHERE [dbo].[MLT_User].[UserID] = @UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_SelectByUserNamePassword]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create     PROCEDURE [dbo].[PR_MLT_User_SelectByUserNamePassword] 

@UserName nvarchar(50),
@Password nvarchar(50)

AS

SELECT 
			[dbo].[MLT_User].[UserID],
			[dbo].[MLT_User].[UserName],
			[dbo].[MLT_User].[Password],
			[dbo].[MLT_User].[CreationDate],
			[dbo].[MLT_User].[ModificationDate]
FROM
			[dbo].[MLT_User]
WHERE
			[dbo].[MLT_User].[UserName] = @UserName AND
			[dbo].[MLT_User].[Password] = @Password
GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_SelectComboBox]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create     PROCEDURE [dbo].[PR_MLT_User_SelectComboBox] 
@UserID int

AS

SELECT 
			[dbo].[MLT_User].[UserID],
			[dbo].[MLT_User].[UserName]

FROM [dbo].[MLT_User]

where [dbo].[MLT_User].[UserID] = @UserID

GO
/****** Object:  StoredProcedure [dbo].[PR_MLT_User_Update]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create     PROCEDURE [dbo].[PR_MLT_User_Update]

@UserID				int,
@UserName			nvarchar(50),
@Password			nvarchar(50),
@ModificationDate	datetime

AS

UPDATE		[dbo].[MLT_User]

SET
			[dbo].[MLT_User].UserName = @UserName,
			[dbo].[MLT_User].[Password] = @Password,
			[dbo].[MLT_User].[ModificationDate] = ISNULL(@ModificationDate,GETDATE())
WHERE
			[dbo].[MLT_User].[UserID] = @UserID;
GO
/****** Object:  StoredProcedure [dbo].[PR_Patient_DeleteByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     Procedure [dbo].[PR_Patient_DeleteByPK]
	
	@patientID int

AS

Delete from [dbo].[map_AssignDisease ]
Where [dbo].[map_AssignDisease ].[PatientID] = @patientID

Delete from [dbo].[map_AssignMedicine]
Where [dbo].[map_AssignMedicine].[PatientID] = @patientID


Delete from [dbo].[US_Patient]
Where [dbo].[US_Patient].[Patient_ID] = @patientID
GO
/****** Object:  StoredProcedure [dbo].[PR_Patient_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[PR_Patient_Insert]
	@patientName  nvarchar(100),
    @birthDate  datetime,
	@gender nvarchar(50),
	@email nvarchar(100),
	@phone nvarchar(50),
	@add nvarchar(1000)
	
AS

INSERT INTO [dbo].[US_Patient]

(
	       [dbo].[US_Patient].[PatientName],
		   [dbo].[US_Patient].[BirthDate],
		   [dbo].[US_Patient].[Gender],
		   [dbo].[US_Patient].[Email],
		   [dbo].[US_Patient].[PhoneNumber],
		   [dbo].[US_Patient].[address]
		  
)

VALUES
(
	@patientName,
   ISNULL(@birthDate,getdate()),
	@gender,
	@email,
	@phone,
	@add

)
GO
/****** Object:  StoredProcedure [dbo].[PR_Patient_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       procedure [dbo].[PR_Patient_SelectAll]

AS

SELECT
           [dbo].[US_Patient].[Patient_ID],
		   [dbo].[US_Patient].[PatientName],
		   [dbo].[US_Patient].[BirthDate],
		   [dbo].[US_Patient].[Gender],
		   [dbo].[US_Patient].[Email],
		   [dbo].[US_Patient].[PhoneNumber],
		   [dbo].[US_Patient].[address]
		    
FROM	   [dbo].[US_Patient]

GO
/****** Object:  StoredProcedure [dbo].[PR_Patient_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[PR_Patient_SelectByPK] 

	@patientID int

AS

SELECT     [dbo].[US_Patient].[Patient_ID],
	       [dbo].[US_Patient].[PatientName],
		   [dbo].[US_Patient].[BirthDate],
		   [dbo].[US_Patient].[Gender],
		   [dbo].[US_Patient].[Email],
		   [dbo].[US_Patient].[PhoneNumber],
		   [dbo].[US_Patient].[address]
FROM [dbo].[US_Patient]

WHERE [dbo].[US_Patient].[Patient_ID] = @patientID 
GO
/****** Object:  StoredProcedure [dbo].[PR_Patient_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE       Procedure [dbo].[PR_Patient_UpdateByPK]
	
	@patientID int,
	@patientName  nvarchar(100),
    @birthDate  datetime,
	@gender nvarchar(50),
	@email nvarchar(100),
	@phone nvarchar(50),
	@add nvarchar(1000)
	

AS

Update [dbo].[US_Patient] 

Set    
	  [dbo].[US_Patient].[PatientName]= @patientName,
	   [dbo].[US_Patient].[BirthDate]= ISNULL(@birthDate,getdate()),
	    [dbo].[US_Patient].[Gender] = @gender,
	   [dbo].[US_Patient].[Email]=@email,
	   [dbo].[US_Patient].[PhoneNumber] = @phone
	   
	   
Where [dbo].[US_Patient].[Patient_ID] = @patientID
GO
/****** Object:  StoredProcedure [dbo].[PR_SelectDisease_ByDiseasePK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    procedure [dbo].[PR_SelectDisease_ByDiseasePK]
 @DiseaseID  int	
AS

SELECT
           [dbo].[map_SelectDisease].[SelectID],
		   [dbo].[map_SelectDisease].[DoctorID],
		   [dbo].[map_SelectDisease].[DiseaseID],
		   [dbo].[US_Doctor].[DoctorName],
		    [dbo].[US_Doctor].[Description],
			 [dbo].[US_Doctor].[Email],
			  [dbo].[US_Doctor].[PhoneNumber],
			  [dbo].[US_Doctor].[OfficeAddress],
		   [dbo].[Disease].[diseaseName]
		   
FROM	   [dbo].[map_SelectDisease]

INNER JOIN  [dbo].[US_Doctor]
ON			[dbo].[US_Doctor].[DoctorID] = [dbo].[map_SelectDisease].[DoctorID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_SelectDisease].[DiseaseID]

WHERE  [dbo].[map_SelectDisease].[DiseaseID]=@DiseaseID;
	
GO
/****** Object:  StoredProcedure [dbo].[PR_selectDisease_Delete]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[PR_selectDisease_Delete]
		@SelectID	int

AS

DELETE 

FROM [dbo].[map_SelectDisease]

WHERE [dbo].[map_SelectDisease].[SelectID] = @SelectID
GO
/****** Object:  StoredProcedure [dbo].[PR_SelectDisease_Insert]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       PROCEDURE [dbo].[PR_SelectDisease_Insert]
	@DoctorID  int,
    @DiseaseID  int
		
AS

INSERT INTO [dbo].[map_SelectDisease]

(
	       [dbo].[map_SelectDisease].[DoctorID],
		   [dbo].[map_SelectDisease].[DiseaseID]
		   
		  
)

VALUES
(
	@DoctorID,
	@DiseaseID
)
GO
/****** Object:  StoredProcedure [dbo].[PR_SelectDisease_SelectAll]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE         procedure [dbo].[PR_SelectDisease_SelectAll]

AS

SELECT
           [dbo].[map_SelectDisease].[SelectID],
		   [dbo].[US_Doctor].[DoctorName],
		   [dbo].[US_Doctor].[description],
		   [dbo].[US_Doctor].[Email],
		   [dbo].[US_Doctor].[PhoneNumber],
	       [dbo].[US_Doctor].[OfficeAddress],
		   [dbo].[Disease].[diseaseName]
FROM	   [dbo].[map_SelectDisease]

INNER JOIN  [dbo].[US_Doctor]
ON			[dbo].[US_Doctor].[DoctorID] = [dbo].[map_SelectDisease].[DoctorID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_SelectDisease].[DiseaseID]

ORDER BY	[dbo].[map_SelectDisease].[SelectID]
	
GO
/****** Object:  StoredProcedure [dbo].[PR_SelectDisease_SelectByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   procedure [dbo].[PR_SelectDisease_SelectByPK] 
	@SelectID	int
		
AS

SELECT 
		 [dbo].[map_SelectDisease].[SelectID],
		 [dbo].[map_SelectDisease].[DoctorID],
		 [dbo].[map_SelectDisease].[DiseaseID]		 
FROM     [dbo].[map_SelectDisease]

INNER JOIN  [dbo].[US_Doctor]
ON			[dbo].[US_Doctor].[DoctorID] = [dbo].[map_SelectDisease].[DoctorID]

INNER JOIN  [dbo].[Disease]
ON			[dbo].[Disease].[diseaseID] = [dbo].[map_SelectDisease].[DiseaseID]


WHERE  [dbo].[map_SelectDisease].[SelectID]=@SelectID;

GO
/****** Object:  StoredProcedure [dbo].[PR_SelectDisease_UpdateByPK]    Script Date: 14-04-2023 05:11:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create       Procedure [dbo].[PR_SelectDisease_UpdateByPK]
	@selectID int,
	@DiseaseID int,
	@DoctorID int
   
AS

Update [dbo].[map_SelectDisease]

Set    
	  [dbo].[map_SelectDisease].[DiseaseID]= @DiseaseID,
	  [dbo].[map_SelectDisease].[DoctorID]= @DoctorID   
Where [dbo].[map_SelectDisease].[SelectID]  = @selectID
GO
USE [master]
GO
ALTER DATABASE [Healthcare ] SET  READ_WRITE 
GO
