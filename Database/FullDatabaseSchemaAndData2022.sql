USE [MojaBiblioteka.Data]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstNameNameId] [int] NOT NULL,
	[SurnameLastNameId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstNameNameId] [int] NOT NULL,
	[SurnameLastNameId] [int] NOT NULL,
	[DateOfBirth] [datetime2](7) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Isbn] [nvarchar](17) NOT NULL,
	[ReleaseDate] [datetime2](7) NOT NULL,
	[PublisherId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Isbn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksAuthors](
	[BookIsbn] [nvarchar](17) NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_BooksAuthors] PRIMARY KEY CLUSTERED 
(
	[BookIsbn] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksCategories]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksCategories](
	[BookIsbn] [nvarchar](17) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_BooksCategories] PRIMARY KEY CLUSTERED 
(
	[BookIsbn] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastNames]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastNames](
	[LastNameId] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_LastNames] PRIMARY KEY CLUSTERED 
(
	[LastNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Names]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Names](
	[NameId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Names] PRIMARY KEY CLUSTERED 
(
	[NameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](55) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentalTransactionList]    Script Date: 17.01.2024 12:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalTransactionList](
	[BookIsbn] [nvarchar](17) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[RentalDate] [datetime2](7) NOT NULL,
	[ProlongTermCounter] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[RentalTransactionId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_RentalTransactionList] PRIMARY KEY CLUSTERED 
(
	[RentalTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'08813272-4753-4efc-aa25-674869551b87', N'Admin', N'ADMIN', N'cd333cfa-bea3-4bb3-b56a-46fd9471f17d')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'42153e90-3932-4629-9394-c150941f2854', N'Client', N'CLIENT', N'8a3c8c88-58cd-498a-9432-2bc3f7ce39d3')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'62a22bbd-aaf2-4ac2-99f6-3e60cb448c78', N'Employee', N'EMPLOYEE', N'fbb01a56-9780-4b06-89e9-36083bf89518')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4fc24388-086d-46b3-9702-845a342c6752', N'08813272-4753-4efc-aa25-674869551b87')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'53f99aca-9722-4401-a13d-7c8c64d5e057', N'42153e90-3932-4629-9394-c150941f2854')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5fb7271e-f2e6-446d-b5f9-01f00c82c23c', N'42153e90-3932-4629-9394-c150941f2854')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c984e9fb-7965-43c0-a0b8-efe2bb4635e7', N'62a22bbd-aaf2-4ac2-99f6-3e60cb448c78')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e530d838-067b-432c-accf-ff05c160b795', N'42153e90-3932-4629-9394-c150941f2854')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstNameNameId], [SurnameLastNameId]) VALUES (N'4fc24388-086d-46b3-9702-845a342c6752', N'administrator@test.com', N'ADMINISTRATOR@TEST.COM', N'administrator@test.com', N'ADMINISTRATOR@TEST.COM', 1, N'AQAAAAEAACcQAAAAELTpNsfQogZCkxgWf9gSaKUU8CdFG+ZSJYtDs5Sd7L7LpGJIVHkZ4TZGQs4JvUsq2g==', N'2I24QY2LD2AFMT6ICUPJEPMXTTOW4TCT', N'f3a14d51-d254-4187-abd0-5906d123819c', NULL, 0, 0, NULL, 1, 0, 4, 5)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstNameNameId], [SurnameLastNameId]) VALUES (N'53f99aca-9722-4401-a13d-7c8c64d5e057', N'klient3@test.com', N'KLIENT3@TEST.COM', N'klient3@test.com', N'KLIENT3@TEST.COM', 1, N'AQAAAAEAACcQAAAAEDKjYc6nbVbf54AdTrm7oyvykG56Lg33y3pV1ybiTaKRiYDrZ2uUSRsJHnk44motHA==', N'UJIPTQXXDM6XQS4C6N2HWUNJWTPHDTVQ', N'ed6348e7-54be-4b07-b09d-e10c3b0e2704', NULL, 0, 0, NULL, 1, 0, 8, 9)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstNameNameId], [SurnameLastNameId]) VALUES (N'5fb7271e-f2e6-446d-b5f9-01f00c82c23c', N'klient2@test.com', N'KLIENT2@TEST.COM', N'klient2@test.com', N'KLIENT2@TEST.COM', 1, N'AQAAAAEAACcQAAAAEMeUrhLcFG/aTbDz2HQeKkXOjlSr2u1ZlZoy5llfxIQlGu2TpUknDqx5sXG4jOa1iw==', N'PLWM7ZIUCKVZYU265XDV3IMA6U62J3IF', N'6c8aada2-6a16-4b3b-9c9e-738b50f5a3ab', NULL, 0, 0, NULL, 1, 0, 7, 8)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstNameNameId], [SurnameLastNameId]) VALUES (N'c984e9fb-7965-43c0-a0b8-efe2bb4635e7', N'pracownik@test.com', N'PRACOWNIK@TEST.COM', N'pracownik@test.com', N'PRACOWNIK@TEST.COM', 1, N'AQAAAAEAACcQAAAAEFbdpYZm0WrYBkpWTJxIPVhRjpRdqA6wTQUt0S7J1j/EJVUg5wmoPjjZDG63UtnnIg==', N'XIMVDFJAAYFJJ3VY7LVF4XLFEZ2NZ2F7', N'80b4e6cb-20f9-4313-9a5d-98c120545842', NULL, 0, 0, NULL, 1, 0, 5, 6)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstNameNameId], [SurnameLastNameId]) VALUES (N'e530d838-067b-432c-accf-ff05c160b795', N'klient@test.com', N'KLIENT@TEST.COM', N'klient@test.com', N'KLIENT@TEST.COM', 1, N'AQAAAAEAACcQAAAAEMjv5lmjH526/+GGPqA+48noftzEAhNnG4hzCsND47DGpNomrVTUgbiN9LUW2BvLKg==', N'DHR4W3OZA6QB5VU545ZOTPFGY642OPAH', N'2a67bee2-8472-4dbb-a0ab-25d879449389', NULL, 0, 0, NULL, 1, 0, 6, 7)
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [FirstNameNameId], [SurnameLastNameId], [DateOfBirth]) VALUES (1, 2, 2, CAST(N'1798-12-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([AuthorId], [FirstNameNameId], [SurnameLastNameId], [DateOfBirth]) VALUES (2, 1, 1, CAST(N'1846-05-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([AuthorId], [FirstNameNameId], [SurnameLastNameId], [DateOfBirth]) VALUES (3, 3, 3, CAST(N'1898-08-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([AuthorId], [FirstNameNameId], [SurnameLastNameId], [DateOfBirth]) VALUES (4, 3, 4, NULL)
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
INSERT [dbo].[Books] ([Isbn], [ReleaseDate], [PublisherId], [Amount], [Title]) VALUES (N'83759682765692392', CAST(N'2003-01-01T00:00:00.0000000' AS DateTime2), 3, 1, N'Pan Kleks')
INSERT [dbo].[Books] ([Isbn], [ReleaseDate], [PublisherId], [Amount], [Title]) VALUES (N'97883732718381234', CAST(N'2002-01-01T00:00:00.0000000' AS DateTime2), 2, 8, N'Dziady')
INSERT [dbo].[Books] ([Isbn], [ReleaseDate], [PublisherId], [Amount], [Title]) VALUES (N'97883926478501234', CAST(N'2006-01-01T00:00:00.0000000' AS DateTime2), 1, 3, N'Potop')
GO
INSERT [dbo].[BooksAuthors] ([BookIsbn], [AuthorId]) VALUES (N'83759682765692392', 3)
INSERT [dbo].[BooksAuthors] ([BookIsbn], [AuthorId]) VALUES (N'83759682765692392', 4)
INSERT [dbo].[BooksAuthors] ([BookIsbn], [AuthorId]) VALUES (N'97883732718381234', 1)
INSERT [dbo].[BooksAuthors] ([BookIsbn], [AuthorId]) VALUES (N'97883926478501234', 2)
GO
INSERT [dbo].[BooksCategories] ([BookIsbn], [CategoryId]) VALUES (N'97883732718381234', 1)
INSERT [dbo].[BooksCategories] ([BookIsbn], [CategoryId]) VALUES (N'97883732718381234', 3)
INSERT [dbo].[BooksCategories] ([BookIsbn], [CategoryId]) VALUES (N'97883926478501234', 1)
INSERT [dbo].[BooksCategories] ([BookIsbn], [CategoryId]) VALUES (N'97883926478501234', 2)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'historyczna')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'przygodowa')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (3, N'ludowa')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[LastNames] ON 

INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (1, N'sienkiewicz')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (2, N'mickiewicz')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (3, N'brzechwa')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (4, N'szancer')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (5, N'admin')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (6, N'pracownik')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (7, N'klient')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (8, N'klient2')
INSERT [dbo].[LastNames] ([LastNameId], [Surname]) VALUES (9, N'klient3')
SET IDENTITY_INSERT [dbo].[LastNames] OFF
GO
SET IDENTITY_INSERT [dbo].[Names] ON 

INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (1, N'henryk')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (2, N'adam')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (3, N'jan')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (4, N'admin')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (5, N'pracownik')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (6, N'klient')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (7, N'klient2')
INSERT [dbo].[Names] ([NameId], [FirstName]) VALUES (8, N'klient3')
SET IDENTITY_INSERT [dbo].[Names] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([PublisherId], [Name]) VALUES (1, N'Wyd. Artystyczne GCE 2017')
INSERT [dbo].[Publishers] ([PublisherId], [Name]) VALUES (2, N'GREG')
INSERT [dbo].[Publishers] ([PublisherId], [Name]) VALUES (3, N'"G&P" ; [Warszawa] : Porozumienie Wydawców, 2003')
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[RentalTransactionList] ON 

INSERT [dbo].[RentalTransactionList] ([BookIsbn], [UserId], [DueDate], [RentalDate], [ProlongTermCounter], [Status], [RentalTransactionId]) VALUES (N'97883732718381234', N'e530d838-067b-432c-accf-ff05c160b795', CAST(N'2024-04-17T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), 3, 0, 4)
INSERT [dbo].[RentalTransactionList] ([BookIsbn], [UserId], [DueDate], [RentalDate], [ProlongTermCounter], [Status], [RentalTransactionId]) VALUES (N'97883926478501234', N'5fb7271e-f2e6-446d-b5f9-01f00c82c23c', CAST(N'2024-04-17T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), 3, 0, 5)
INSERT [dbo].[RentalTransactionList] ([BookIsbn], [UserId], [DueDate], [RentalDate], [ProlongTermCounter], [Status], [RentalTransactionId]) VALUES (N'83759682765692392', N'53f99aca-9722-4401-a13d-7c8c64d5e057', CAST(N'2024-04-17T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), 3, 0, 6)
SET IDENTITY_INSERT [dbo].[RentalTransactionList] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [FirstNameNameId]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [SurnameLastNameId]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[RentalTransactionList] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DueDate]
GO
ALTER TABLE [dbo].[RentalTransactionList] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [RentalDate]
GO
ALTER TABLE [dbo].[RentalTransactionList] ADD  DEFAULT ((0)) FOR [ProlongTermCounter]
GO
ALTER TABLE [dbo].[RentalTransactionList] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_LastNames_SurnameLastNameId] FOREIGN KEY([SurnameLastNameId])
REFERENCES [dbo].[LastNames] ([LastNameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_LastNames_SurnameLastNameId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Names_FirstNameNameId] FOREIGN KEY([FirstNameNameId])
REFERENCES [dbo].[Names] ([NameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Names_FirstNameNameId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_Authors_LastNames_SurnameLastNameId] FOREIGN KEY([SurnameLastNameId])
REFERENCES [dbo].[LastNames] ([LastNameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_Authors_LastNames_SurnameLastNameId]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_Authors_Names_FirstNameNameId] FOREIGN KEY([FirstNameNameId])
REFERENCES [dbo].[Names] ([NameId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_Authors_Names_FirstNameNameId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers_PublisherId] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers_PublisherId]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Authors_AuthorId]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Books_BookIsbn] FOREIGN KEY([BookIsbn])
REFERENCES [dbo].[Books] ([Isbn])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Books_BookIsbn]
GO
ALTER TABLE [dbo].[BooksCategories]  WITH CHECK ADD  CONSTRAINT [FK_BooksCategories_Books_BookIsbn] FOREIGN KEY([BookIsbn])
REFERENCES [dbo].[Books] ([Isbn])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksCategories] CHECK CONSTRAINT [FK_BooksCategories_Books_BookIsbn]
GO
ALTER TABLE [dbo].[BooksCategories]  WITH CHECK ADD  CONSTRAINT [FK_BooksCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksCategories] CHECK CONSTRAINT [FK_BooksCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[RentalTransactionList]  WITH CHECK ADD  CONSTRAINT [FK_RentalTransactionList_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalTransactionList] CHECK CONSTRAINT [FK_RentalTransactionList_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[RentalTransactionList]  WITH CHECK ADD  CONSTRAINT [FK_RentalTransactionList_Books_BookIsbn] FOREIGN KEY([BookIsbn])
REFERENCES [dbo].[Books] ([Isbn])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RentalTransactionList] CHECK CONSTRAINT [FK_RentalTransactionList_Books_BookIsbn]
GO
