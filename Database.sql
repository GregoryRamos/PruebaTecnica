USE [Student]
GO
/****** Object:  Table [dbo].[Attendaces]    Script Date: 1/3/2024 1:03:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendaces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Date] [datetimeoffset](7) NOT NULL,
	[Status] [int] NOT NULL,
	[comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Attendaces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 1/3/2024 1:03:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/3/2024 1:03:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Gender] [int] NOT NULL,
	[Birthday] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1/3/2024 1:03:22 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Attendaces] ON 

INSERT [dbo].[Attendaces] ([Id], [StudentId], [SubjectId], [Date], [Status], [comment]) VALUES (1, 1, 1, CAST(N'2024-03-01T00:00:00.0000000-04:00' AS DateTimeOffset), 1, N'')
SET IDENTITY_INSERT [dbo].[Attendaces] OFF
GO
SET IDENTITY_INSERT [dbo].[Grades] ON 

INSERT [dbo].[Grades] ([Id], [StudentId], [SubjectId], [Score]) VALUES (1, 1, 1, 80)
INSERT [dbo].[Grades] ([Id], [StudentId], [SubjectId], [Score]) VALUES (2, 8, 1, 100)
INSERT [dbo].[Grades] ([Id], [StudentId], [SubjectId], [Score]) VALUES (3, 1, 2, 10)
INSERT [dbo].[Grades] ([Id], [StudentId], [SubjectId], [Score]) VALUES (4, 8, 2, 30)
INSERT [dbo].[Grades] ([Id], [StudentId], [SubjectId], [Score]) VALUES (5, 1, 2, 10)
INSERT [dbo].[Grades] ([Id], [StudentId], [SubjectId], [Score]) VALUES (6, 8, 2, 20)
SET IDENTITY_INSERT [dbo].[Grades] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [Name], [Gender], [Birthday]) VALUES (1, N'lisse Yens', 1, CAST(N'2000-06-13T04:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Students] ([Id], [Name], [Gender], [Birthday]) VALUES (8, N'marko', 0, CAST(N'2023-12-14T04:00:00.0000000+00:00' AS DateTimeOffset))
INSERT [dbo].[Students] ([Id], [Name], [Gender], [Birthday]) VALUES (9, N'ale', 1, CAST(N'2024-03-21T04:00:00.0000000+00:00' AS DateTimeOffset))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([Id], [Name], [Description]) VALUES (1, N'Lengua Española', N'n/a')
INSERT [dbo].[Subjects] ([Id], [Name], [Description]) VALUES (2, N'Matemáticas', N'n/a')
INSERT [dbo].[Subjects] ([Id], [Name], [Description]) VALUES (3, N'Ciencias Sociales', N'n/a')
INSERT [dbo].[Subjects] ([Id], [Name], [Description]) VALUES (4, N'Ciencias Naturales', N'n/a')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
GO
ALTER TABLE [dbo].[Attendaces]  WITH CHECK ADD  CONSTRAINT [FK_Attendaces_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendaces] CHECK CONSTRAINT [FK_Attendaces_Students_StudentId]
GO
ALTER TABLE [dbo].[Attendaces]  WITH CHECK ADD  CONSTRAINT [FK_Attendaces_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendaces] CHECK CONSTRAINT [FK_Attendaces_Subjects_SubjectId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Students_StudentId]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Subjects_SubjectId]
GO
