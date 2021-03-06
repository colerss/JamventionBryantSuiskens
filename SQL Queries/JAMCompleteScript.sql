USE [PR_r0739290]
GO
/****** Object:  Schema [JAM]    Script Date: 5/01/2021 16:29:36 ******/
CREATE SCHEMA [JAM]
GO
/****** Object:  Table [JAM].[AdminKeys]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[AdminKeys](
	[KeyID] [int] IDENTITY(1,1) NOT NULL,
	[HashedPassword] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JAM.AdminKeys] PRIMARY KEY CLUSTERED 
(
	[KeyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[GuestRoles]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[GuestRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JAM.GuestRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Guests]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Guests](
	[GuestID] [int] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[ResidenceID] [int] NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[TelephoneNr] [nvarchar](15) NULL,
	[IsVegetarian] [bit] NOT NULL,
	[RoleID] [int] NOT NULL,
	[InvoiceID] [int] NULL,
	[RoomID] [int] NULL,
 CONSTRAINT [PK_JAM.Guests] PRIMARY KEY CLUSTERED 
(
	[GuestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Invoices]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Invoices](
	[InvoiceID] [int] NOT NULL,
	[DebitorNr] [int] NOT NULL,
	[TicketTypeID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[LocalRooms]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[LocalRooms](
	[RoomID] [int] NOT NULL,
	[RoomTypeID] [int] NOT NULL,
	[RoomCode] [nvarchar](5) NOT NULL,
	[RoomColor] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_JAM.LocalRooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Locations]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Locations](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_JAM.Locations] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Nationalities]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Nationalities](
	[NationalityID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JAM.Nationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[OtherRooms]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[OtherRooms](
	[RoomID] [int] NOT NULL,
	[RoomDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JAM.OtherRooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Payments]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[Amount] [money] NOT NULL,
	[InvoiceID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Residences]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Residences](
	[ResidenceID] [int] NOT NULL,
	[PostalCode] [nvarchar](10) NULL,
	[City] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[NationalityID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.Residences] PRIMARY KEY CLUSTERED 
(
	[ResidenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Rooms]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[Beds] [int] NOT NULL,
 CONSTRAINT [PK_JAM.Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[RoomTypes]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[RoomTypes](
	[RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_JAM.RoomTypes] PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[TicketTypes]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[TicketTypes](
	[TicketTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TicketName] [nvarchar](max) NOT NULL,
	[TicketPrice] [money] NOT NULL,
	[OnFriday] [bit] NOT NULL,
	[OnSaturday] [bit] NOT NULL,
	[OnSunday] [bit] NOT NULL,
 CONSTRAINT [PK_JAM.TicketTypes] PRIMARY KEY CLUSTERED 
(
	[TicketTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[TimeSlots]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[TimeSlots](
	[TimeSlotID] [int] IDENTITY(1,1) NOT NULL,
	[Day] [datetime] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
 CONSTRAINT [PK_JAM.TimeSlots] PRIMARY KEY CLUSTERED 
(
	[TimeSlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[WorkshopModels]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[WorkshopModels](
	[WorkshopModelID] [int] IDENTITY(1,1) NOT NULL,
	[ModelID] [int] NOT NULL,
	[WorkshopID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.WorkshopModels] PRIMARY KEY CLUSTERED 
(
	[WorkshopModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[WorkshopParticipants]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[WorkshopParticipants](
	[WorkshopParticipantID] [int] IDENTITY(1,1) NOT NULL,
	[GuestID] [int] NOT NULL,
	[WorkshopID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.WorkshopParticipants] PRIMARY KEY CLUSTERED 
(
	[WorkshopParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [JAM].[Workshops]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[Workshops](
	[WorkshopID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TimeslotID] [int] NOT NULL,
	[Slots] [int] NOT NULL,
	[LocationID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.Workshops] PRIMARY KEY CLUSTERED 
(
	[WorkshopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [JAM].[WorkshopTeacher]    Script Date: 5/01/2021 16:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [JAM].[WorkshopTeacher](
	[WorkshopParticipantID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[WorkshopID] [int] NOT NULL,
 CONSTRAINT [PK_JAM.WorkshopTeacher] PRIMARY KEY CLUSTERED 
(
	[WorkshopParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [JAM].[AdminKeys] ON 

INSERT [JAM].[AdminKeys] ([KeyID], [HashedPassword]) VALUES (1, N'-204084189')
INSERT [JAM].[AdminKeys] ([KeyID], [HashedPassword]) VALUES (2, N'-38967440')
SET IDENTITY_INSERT [JAM].[AdminKeys] OFF
GO
SET IDENTITY_INSERT [JAM].[GuestRoles] ON 

INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (1, N'Participant')
INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (2, N'Model')
INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (3, N'Teacher')
INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (4, N'Catering')
INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (5, N'Staff')
INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (6, N'Special')
INSERT [JAM].[GuestRoles] ([RoleID], [RoleName]) VALUES (7, N'Organizer')
SET IDENTITY_INSERT [JAM].[GuestRoles] OFF
GO
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (1, N'Bryant', N'Suiskens', 1, N'bryantsuiskensmast@gmail.com', N'032957841', 0, 6, NULL, 28)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (2, N'azer', N'azer', 2, N'azer', N'azer', 0, 1, 0, 1)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (3, N'azer', N'azer', 3, N'azer', N'azer', 0, 2, NULL, NULL)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (4, N'aezr', N'eaze', 5, N'razdd', N'195789', 0, 1, 1, 1)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (5, N'zaer', N'arzaerd', 7, N'azer', N'azer', 0, 1, 3, 1)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (6, N'azer', N'azer', 8, N'vdsaze', N'azer', 0, 1, 4, 1)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (7, N'Raphaela', N'Fieldhouse', 9, N'zertzertzfgzert', N'15789456789', 0, 3, NULL, NULL)
INSERT [JAM].[Guests] ([GuestID], [FirstName], [LastName], [ResidenceID], [EmailAddress], [TelephoneNr], [IsVegetarian], [RoleID], [InvoiceID], [RoomID]) VALUES (8, N'Paula', N'Southern', 10, N'fazeraezr', N'98798498', 0, 3, NULL, NULL)
GO
INSERT [JAM].[Invoices] ([InvoiceID], [DebitorNr], [TicketTypeID]) VALUES (0, 2020478, 1)
INSERT [JAM].[Invoices] ([InvoiceID], [DebitorNr], [TicketTypeID]) VALUES (1, 20203489, 1)
INSERT [JAM].[Invoices] ([InvoiceID], [DebitorNr], [TicketTypeID]) VALUES (2, 2019879, 1)
INSERT [JAM].[Invoices] ([InvoiceID], [DebitorNr], [TicketTypeID]) VALUES (3, 0, 1)
INSERT [JAM].[Invoices] ([InvoiceID], [DebitorNr], [TicketTypeID]) VALUES (4, 2020145, 1)
GO
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (1, 1, N'1-1', N'Pink')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (2, 1, N'1-2', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (3, 1, N'1-3', N'Purple')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (4, 1, N'1-4', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (5, 2, N'2-1', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (6, 2, N'2-2', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (7, 2, N'2-3', N'Pink')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (8, 2, N'2-4', N'Purple')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (9, 3, N'3-1', N'Purple')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (10, 3, N'3-2', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (11, 3, N'3-3', N'Pink')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (12, 3, N'3-4', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (13, 4, N'4-1', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (14, 4, N'4-2', N'Purple')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (15, 4, N'4-3', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (16, 4, N'4-4', N'Pink')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (17, 5, N'5-1', N'Pink')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (18, 5, N'5-2', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (19, 5, N'5-3', N'Purple')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (20, 5, N'5-4', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (21, 6, N'0', N'Purple')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (22, 6, N'1', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (23, 6, N'1', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (24, 6, N'2', N'Blue')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (25, 6, N'2', N'Yellow')
INSERT [JAM].[LocalRooms] ([RoomID], [RoomTypeID], [RoomCode], [RoomColor]) VALUES (26, 7, N'', N'')
GO
SET IDENTITY_INSERT [JAM].[Locations] ON 

INSERT [JAM].[Locations] ([LocationID], [LocationName]) VALUES (1, N'Hen House')
INSERT [JAM].[Locations] ([LocationID], [LocationName]) VALUES (2, N'Cows Shed')
INSERT [JAM].[Locations] ([LocationID], [LocationName]) VALUES (3, N'Swallows Nest')
INSERT [JAM].[Locations] ([LocationID], [LocationName]) VALUES (4, N'Piggery')
INSERT [JAM].[Locations] ([LocationID], [LocationName]) VALUES (5, N'The Stable')
SET IDENTITY_INSERT [JAM].[Locations] OFF
GO
SET IDENTITY_INSERT [JAM].[Nationalities] ON 

INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (1, N'Afghanistan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (2, N'Albania')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (3, N'Algeria')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (4, N'Andorra')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (5, N'Angola')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (6, N'Antigua and Barbuda')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (7, N'Argentina')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (8, N'Armenia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (9, N'Australia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (10, N'Austria')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (11, N'Azerbaijan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (12, N'Bahamas')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (13, N'Bahrain')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (14, N'Bangladesh')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (15, N'Barbados')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (16, N'Belarus')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (17, N'Belgium')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (18, N'Belize')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (19, N'Benin')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (20, N'Bhutan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (21, N'Bolivia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (22, N'Bosnia and Herzegovina')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (23, N'Botswana')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (24, N'Brazil')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (25, N'Brunei')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (26, N'Bulgaria')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (27, N'Burkina Faso')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (28, N'Burma')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (29, N'Burundi')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (30, N'Cambodia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (31, N'Cameroon')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (32, N'Canada')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (33, N'Cape Verde')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (34, N'Central Africa')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (35, N'Chad')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (36, N'Chile')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (37, N'China')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (38, N'Colombia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (39, N'Comoros')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (40, N'Congo')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (41, N'Costa Rica')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (42, N'Cote dIvoire')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (43, N'Crete')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (44, N'Croatia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (45, N'Cuba')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (46, N'Cyprus')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (47, N'Czech Republic')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (48, N'Denmark')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (49, N'Djibouti')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (50, N'Dominican Republic')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (51, N'East Timor')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (52, N'Ecuador')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (53, N'Egypt')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (54, N'El Salvador')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (55, N'Equatorial Guinea')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (56, N'Eritrea')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (57, N'Estonia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (58, N'Ethiopia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (59, N'Fiji')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (60, N'Finland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (61, N'France')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (62, N'Gabon')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (63, N'Gambia, The')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (64, N'Georgia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (65, N'Germany')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (66, N'Ghana')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (67, N'Greece')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (68, N'Grenada')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (69, N'Guadeloupe')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (70, N'Guatemala')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (71, N'Guinea')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (72, N'Guinea-Bissau')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (73, N'Guyana')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (74, N'Haiti')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (75, N'Holy See')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (76, N'Honduras')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (77, N'Hong Kong')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (78, N'Hungary')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (79, N'Iceland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (80, N'India')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (81, N'Indonesia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (82, N'Iran')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (83, N'Iraq')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (84, N'Ireland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (85, N'Israel')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (86, N'Italy')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (87, N'Ivory Coast')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (88, N'Jamaica')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (89, N'Japan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (90, N'Jordan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (91, N'Kazakhstan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (92, N'Kenya')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (93, N'Kiribati')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (94, N'Korea, North')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (95, N'Korea, South')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (96, N'Kosovo')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (97, N'Kuwait')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (98, N'Kyrgyzstan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (99, N'Laos')
GO
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (100, N'Latvia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (101, N'Lebanon')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (102, N'Lesotho')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (103, N'Liberia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (104, N'Libya')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (105, N'Liechtenstein')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (106, N'Lithuania')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (107, N'Macau')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (108, N'Macedonia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (109, N'Madagascar')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (110, N'Malawi')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (111, N'Malaysia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (112, N'Maldives')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (113, N'Mali')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (114, N'Malta')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (115, N'Marshall Islands')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (116, N'Mauritania')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (117, N'Mauritius')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (118, N'Mexico')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (119, N'Micronesia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (120, N'Moldova')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (121, N'Monaco')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (122, N'Mongolia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (123, N'Montenegro')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (124, N'Morocco')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (125, N'Mozambique')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (126, N'Namibia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (127, N'Nauru')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (128, N'Nepal')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (129, N'Netherlands')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (130, N'New Zealand')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (131, N'Nicaragua')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (132, N'Niger')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (133, N'Nigeria')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (134, N'North Korea')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (135, N'Norway')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (136, N'Oman')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (137, N'Pakistan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (138, N'Palau')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (139, N'Panama')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (140, N'Papua New Guinea')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (141, N'Paraguay')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (142, N'Peru')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (143, N'Philippines')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (144, N'Poland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (145, N'Portugal')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (146, N'Qatar')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (147, N'Romania')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (148, N'Russia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (149, N'Rwanda')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (150, N'Saint Lucia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (151, N'Saint Vincent and the Grenadines')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (152, N'Samoa')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (153, N'San Marino')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (154, N'Sao Tome and Principe')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (155, N'Saudi Arabia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (156, N'Scotland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (157, N'Senegal')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (158, N'Serbia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (159, N'Seychelles')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (160, N'Sierra Leone')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (161, N'Singapore')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (162, N'Slovakia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (163, N'Slovenia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (164, N'Solomon Islands')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (165, N'Somalia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (166, N'South Africa')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (167, N'South Korea')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (168, N'Spain')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (169, N'Sri Lanka')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (170, N'Sudan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (171, N'Suriname')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (172, N'Swaziland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (173, N'Sweden')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (174, N'Switzerland')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (175, N'Syria')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (176, N'Taiwan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (177, N'Tajikistan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (178, N'Tanzania')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (179, N'Thailand')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (180, N'Tibet')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (181, N'Timor-Leste')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (182, N'Togo')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (183, N'Tonga')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (184, N'Trinidad and Tobago')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (185, N'Tunisia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (186, N'Turkey')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (187, N'Turkmenistan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (188, N'Tuvalu')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (189, N'Uganda')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (190, N'Ukraine')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (191, N'United Arab Emirates')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (192, N'United Kingdom')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (193, N'United States')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (194, N'Uruguay')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (195, N'Uzbekistan')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (196, N'Vanuatu')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (197, N'Venezuela')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (198, N'Vietnam')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (199, N'Yemen')
GO
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (200, N'Zambia')
INSERT [JAM].[Nationalities] ([NationalityID], [CountryName]) VALUES (201, N'Zimbabwe')
SET IDENTITY_INSERT [JAM].[Nationalities] OFF
GO
INSERT [JAM].[OtherRooms] ([RoomID], [RoomDescription]) VALUES (27, N'Suiskens; Kamer Ouders')
INSERT [JAM].[OtherRooms] ([RoomID], [RoomDescription]) VALUES (28, N'Suiskens; Studio')
INSERT [JAM].[OtherRooms] ([RoomID], [RoomDescription]) VALUES (29, N'Suiskens; Kantoor Willy')
INSERT [JAM].[OtherRooms] ([RoomID], [RoomDescription]) VALUES (30, N'Suiskens; Kamer Bryant')
INSERT [JAM].[OtherRooms] ([RoomID], [RoomDescription]) VALUES (31, N'Bed and Breakfast Wortel')
INSERT [JAM].[OtherRooms] ([RoomID], [RoomDescription]) VALUES (32, N'Testkamer')
GO
SET IDENTITY_INSERT [JAM].[Payments] ON 

INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (1, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 140.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (2, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 140.0000, 1)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (3, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 140.0000, 1)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (4, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 20.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (5, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 20.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (6, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 40.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (7, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 20.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (8, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 15.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (9, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 25.0000, 0)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (10, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 20.0000, 2)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (11, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 25.0000, 2)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (12, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 120.0000, 2)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (13, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 180.0000, 2)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (14, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 10.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (15, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 10.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (16, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 10.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (17, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 10.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (18, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 10.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (19, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 15.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (20, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 25.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (21, CAST(N'2020-11-27T00:00:00.000' AS DateTime), 10.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (22, CAST(N'2020-12-03T00:00:00.000' AS DateTime), 40.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (23, CAST(N'2020-12-03T00:00:00.000' AS DateTime), 15.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (24, CAST(N'2020-12-03T00:00:00.000' AS DateTime), 15.0000, 3)
INSERT [JAM].[Payments] ([PaymentID], [PaymentDate], [Amount], [InvoiceID]) VALUES (25, CAST(N'2020-12-03T00:00:00.000' AS DateTime), 20.0000, 3)
SET IDENTITY_INSERT [JAM].[Payments] OFF
GO
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (1, N'2323', N'Wortel', N'Sintjanstraat 16E', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (2, N'azer', N'azer', N'aazer', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (3, N'azer', N'az', N'azer', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (4, N'azer', N'azer', N'azer', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (5, N'16789', N'azersdv', N'azefsdv', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (6, N'26789', N'afeazr', N'azerazersd', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (7, N'azer', N'azer', N'qsdfazer', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (8, N'azerazer', N'qsdfazer', N'sqdazer', 17)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (9, N'19875', N'Enfield', N'azaergzetezrt', 192)
INSERT [JAM].[Residences] ([ResidenceID], [PostalCode], [City], [Address], [NationalityID]) VALUES (10, N'2897897', N'Enfield', N'azerasddvazer', 192)
GO
SET IDENTITY_INSERT [JAM].[Rooms] ON 

INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (1, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (2, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (3, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (4, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (5, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (6, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (7, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (8, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (9, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (10, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (11, 6)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (12, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (13, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (14, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (15, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (16, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (17, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (18, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (19, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (20, 5)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (21, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (22, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (23, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (24, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (25, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (26, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (27, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (28, 4)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (29, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (30, 3)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (31, 2)
INSERT [JAM].[Rooms] ([RoomID], [Beds]) VALUES (32, 5)
SET IDENTITY_INSERT [JAM].[Rooms] OFF
GO
SET IDENTITY_INSERT [JAM].[RoomTypes] ON 

INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (1, N'Rabbit')
INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (2, N'Sheep')
INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (3, N'Duck')
INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (4, N'Piglet')
INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (5, N'Pig')
INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (6, N'Rooster')
INSERT [JAM].[RoomTypes] ([RoomTypeID], [TypeName]) VALUES (7, N'At Piggery')
SET IDENTITY_INSERT [JAM].[RoomTypes] OFF
GO
SET IDENTITY_INSERT [JAM].[TicketTypes] ON 

INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (1, N'JAM Ticket', 280.0000, 1, 1, 1)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (2, N'JAM 4-Beds Ticket', 265.0000, 1, 1, 1)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (3, N'Early Bird JAM Ticket', 255.0000, 1, 1, 1)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (4, N'Gift Jam Ticket', 0.0000, 1, 1, 1)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (5, N'8-Hour Ticket', 165.0000, 0, 1, 0)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (6, N'8-Hour Gift Ticket', 0.0000, 0, 1, 0)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (7, N'6-Hour Ticket', 125.0000, 0, 0, 1)
INSERT [JAM].[TicketTypes] ([TicketTypeID], [TicketName], [TicketPrice], [OnFriday], [OnSaturday], [OnSunday]) VALUES (8, N'6-Hour Gift Ticket', 0.0000, 0, 0, 1)
SET IDENTITY_INSERT [JAM].[TicketTypes] OFF
GO
SET IDENTITY_INSERT [JAM].[TimeSlots] ON 

INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (17, CAST(N'2020-10-16T00:00:00.000' AS DateTime), CAST(N'00:18:30' AS Time), CAST(N'00:22:30' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (18, CAST(N'2020-10-16T00:00:00.000' AS DateTime), CAST(N'00:15:30' AS Time), CAST(N'00:18:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (19, CAST(N'2020-10-16T00:00:00.000' AS DateTime), CAST(N'00:08:30' AS Time), CAST(N'00:12:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (20, CAST(N'2020-10-17T00:00:00.000' AS DateTime), CAST(N'00:09:00' AS Time), CAST(N'00:12:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (21, CAST(N'2020-10-17T00:00:00.000' AS DateTime), CAST(N'00:08:30' AS Time), CAST(N'00:12:30' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (22, CAST(N'2020-10-17T00:00:00.000' AS DateTime), CAST(N'00:13:30' AS Time), CAST(N'00:17:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (23, CAST(N'2020-10-17T00:00:00.000' AS DateTime), CAST(N'00:13:30' AS Time), CAST(N'00:17:30' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (24, CAST(N'2020-10-17T00:00:00.000' AS DateTime), CAST(N'00:18:30' AS Time), CAST(N'00:22:30' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (25, CAST(N'2020-10-18T00:00:00.000' AS DateTime), CAST(N'00:08:30' AS Time), CAST(N'00:12:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (26, CAST(N'2020-10-18T00:00:00.000' AS DateTime), CAST(N'00:09:00' AS Time), CAST(N'00:12:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (27, CAST(N'2020-10-18T00:00:00.000' AS DateTime), CAST(N'00:08:30' AS Time), CAST(N'00:12:30' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (28, CAST(N'2020-10-18T00:00:00.000' AS DateTime), CAST(N'00:13:30' AS Time), CAST(N'00:17:00' AS Time))
INSERT [JAM].[TimeSlots] ([TimeSlotID], [Day], [StartTime], [EndTime]) VALUES (29, CAST(N'2020-10-18T00:00:00.000' AS DateTime), CAST(N'00:13:30' AS Time), CAST(N'00:17:30' AS Time))
SET IDENTITY_INSERT [JAM].[TimeSlots] OFF
GO
SET IDENTITY_INSERT [JAM].[WorkshopModels] ON 

INSERT [JAM].[WorkshopModels] ([WorkshopModelID], [ModelID], [WorkshopID]) VALUES (1, 3, 3)
SET IDENTITY_INSERT [JAM].[WorkshopModels] OFF
GO
SET IDENTITY_INSERT [JAM].[WorkshopParticipants] ON 

INSERT [JAM].[WorkshopParticipants] ([WorkshopParticipantID], [GuestID], [WorkshopID]) VALUES (31, 2, 3)
INSERT [JAM].[WorkshopParticipants] ([WorkshopParticipantID], [GuestID], [WorkshopID]) VALUES (32, 4, 3)
INSERT [JAM].[WorkshopParticipants] ([WorkshopParticipantID], [GuestID], [WorkshopID]) VALUES (33, 5, 3)
SET IDENTITY_INSERT [JAM].[WorkshopParticipants] OFF
GO
SET IDENTITY_INSERT [JAM].[Workshops] ON 

INSERT [JAM].[Workshops] ([WorkshopID], [Name], [TimeslotID], [Slots], [LocationID]) VALUES (3, N'Avondactiviteiten', 17, 150, 4)
SET IDENTITY_INSERT [JAM].[Workshops] OFF
GO
SET IDENTITY_INSERT [JAM].[WorkshopTeacher] ON 

INSERT [JAM].[WorkshopTeacher] ([WorkshopParticipantID], [TeacherID], [WorkshopID]) VALUES (8, 7, 3)
SET IDENTITY_INSERT [JAM].[WorkshopTeacher] OFF
GO
ALTER TABLE [JAM].[Guests]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Guests_JAM.GuestRoles_RoleID] FOREIGN KEY([RoleID])
REFERENCES [JAM].[GuestRoles] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Guests] CHECK CONSTRAINT [FK_JAM.Guests_JAM.GuestRoles_RoleID]
GO
ALTER TABLE [JAM].[Guests]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Guests_JAM.Invoices_InvoiceID] FOREIGN KEY([InvoiceID])
REFERENCES [JAM].[Invoices] ([InvoiceID])
GO
ALTER TABLE [JAM].[Guests] CHECK CONSTRAINT [FK_JAM.Guests_JAM.Invoices_InvoiceID]
GO
ALTER TABLE [JAM].[Guests]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Guests_JAM.Residences_ResidenceID] FOREIGN KEY([ResidenceID])
REFERENCES [JAM].[Residences] ([ResidenceID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Guests] CHECK CONSTRAINT [FK_JAM.Guests_JAM.Residences_ResidenceID]
GO
ALTER TABLE [JAM].[Guests]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Guests_JAM.Rooms_RoomID] FOREIGN KEY([RoomID])
REFERENCES [JAM].[Rooms] ([RoomID])
GO
ALTER TABLE [JAM].[Guests] CHECK CONSTRAINT [FK_JAM.Guests_JAM.Rooms_RoomID]
GO
ALTER TABLE [JAM].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Invoices_JAM.TicketTypes_TicketTypeID] FOREIGN KEY([TicketTypeID])
REFERENCES [JAM].[TicketTypes] ([TicketTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Invoices] CHECK CONSTRAINT [FK_JAM.Invoices_JAM.TicketTypes_TicketTypeID]
GO
ALTER TABLE [JAM].[LocalRooms]  WITH CHECK ADD  CONSTRAINT [FK_JAM.LocalRooms_JAM.Rooms_RoomID] FOREIGN KEY([RoomID])
REFERENCES [JAM].[Rooms] ([RoomID])
GO
ALTER TABLE [JAM].[LocalRooms] CHECK CONSTRAINT [FK_JAM.LocalRooms_JAM.Rooms_RoomID]
GO
ALTER TABLE [JAM].[LocalRooms]  WITH CHECK ADD  CONSTRAINT [FK_JAM.LocalRooms_JAM.RoomTypes_RoomTypeID] FOREIGN KEY([RoomTypeID])
REFERENCES [JAM].[RoomTypes] ([RoomTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[LocalRooms] CHECK CONSTRAINT [FK_JAM.LocalRooms_JAM.RoomTypes_RoomTypeID]
GO
ALTER TABLE [JAM].[OtherRooms]  WITH CHECK ADD  CONSTRAINT [FK_JAM.OtherRooms_JAM.Rooms_RoomID] FOREIGN KEY([RoomID])
REFERENCES [JAM].[Rooms] ([RoomID])
GO
ALTER TABLE [JAM].[OtherRooms] CHECK CONSTRAINT [FK_JAM.OtherRooms_JAM.Rooms_RoomID]
GO
ALTER TABLE [JAM].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Payments_JAM.Invoices_InvoiceID] FOREIGN KEY([InvoiceID])
REFERENCES [JAM].[Invoices] ([InvoiceID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Payments] CHECK CONSTRAINT [FK_JAM.Payments_JAM.Invoices_InvoiceID]
GO
ALTER TABLE [JAM].[Residences]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Residences_JAM.Nationalities_NationalityID] FOREIGN KEY([NationalityID])
REFERENCES [JAM].[Nationalities] ([NationalityID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Residences] CHECK CONSTRAINT [FK_JAM.Residences_JAM.Nationalities_NationalityID]
GO
ALTER TABLE [JAM].[WorkshopModels]  WITH CHECK ADD  CONSTRAINT [FK_JAM.WorkshopModels_JAM.Guests_ModelID] FOREIGN KEY([ModelID])
REFERENCES [JAM].[Guests] ([GuestID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[WorkshopModels] CHECK CONSTRAINT [FK_JAM.WorkshopModels_JAM.Guests_ModelID]
GO
ALTER TABLE [JAM].[WorkshopModels]  WITH CHECK ADD  CONSTRAINT [FK_JAM.WorkshopModels_JAM.Workshops_WorkshopID] FOREIGN KEY([WorkshopID])
REFERENCES [JAM].[Workshops] ([WorkshopID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[WorkshopModels] CHECK CONSTRAINT [FK_JAM.WorkshopModels_JAM.Workshops_WorkshopID]
GO
ALTER TABLE [JAM].[WorkshopParticipants]  WITH CHECK ADD  CONSTRAINT [FK_JAM.WorkshopParticipants_JAM.Guests_GuestID] FOREIGN KEY([GuestID])
REFERENCES [JAM].[Guests] ([GuestID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[WorkshopParticipants] CHECK CONSTRAINT [FK_JAM.WorkshopParticipants_JAM.Guests_GuestID]
GO
ALTER TABLE [JAM].[WorkshopParticipants]  WITH CHECK ADD  CONSTRAINT [FK_JAM.WorkshopParticipants_JAM.Workshops_WorkshopID] FOREIGN KEY([WorkshopID])
REFERENCES [JAM].[Workshops] ([WorkshopID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[WorkshopParticipants] CHECK CONSTRAINT [FK_JAM.WorkshopParticipants_JAM.Workshops_WorkshopID]
GO
ALTER TABLE [JAM].[Workshops]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Workshops_JAM.Locations_LocationID] FOREIGN KEY([LocationID])
REFERENCES [JAM].[Locations] ([LocationID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Workshops] CHECK CONSTRAINT [FK_JAM.Workshops_JAM.Locations_LocationID]
GO
ALTER TABLE [JAM].[Workshops]  WITH CHECK ADD  CONSTRAINT [FK_JAM.Workshops_JAM.TimeSlots_TimeslotID] FOREIGN KEY([TimeslotID])
REFERENCES [JAM].[TimeSlots] ([TimeSlotID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[Workshops] CHECK CONSTRAINT [FK_JAM.Workshops_JAM.TimeSlots_TimeslotID]
GO
ALTER TABLE [JAM].[WorkshopTeacher]  WITH CHECK ADD  CONSTRAINT [FK_JAM.WorkshopTeacher_JAM.Guests_TeacherID] FOREIGN KEY([TeacherID])
REFERENCES [JAM].[Guests] ([GuestID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[WorkshopTeacher] CHECK CONSTRAINT [FK_JAM.WorkshopTeacher_JAM.Guests_TeacherID]
GO
ALTER TABLE [JAM].[WorkshopTeacher]  WITH CHECK ADD  CONSTRAINT [FK_JAM.WorkshopTeacher_JAM.Workshops_WorkshopID] FOREIGN KEY([WorkshopID])
REFERENCES [JAM].[Workshops] ([WorkshopID])
ON DELETE CASCADE
GO
ALTER TABLE [JAM].[WorkshopTeacher] CHECK CONSTRAINT [FK_JAM.WorkshopTeacher_JAM.Workshops_WorkshopID]
GO
