USE [PrivacyDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2021/12/27 22:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainee]    Script Date: 2021/12/27 22:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainee](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](200) NOT NULL,
	[Location] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[Interesting] [nvarchar](500) NOT NULL,
	[EmailCode] [nvarchar](50) NULL,
	[SetCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Trainee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 2021/12/27 22:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[KindOfTrainer] [nvarchar](500) NOT NULL,
	[Certificate] [nvarchar](50) NULL,
	[DescribeYourself] [nvarchar](max) NULL,
	[Location] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[EmailCode] [nvarchar](50) NULL,
	[SetCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Trainer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (1, N'admin', N'admin')
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (2, N'111', N'1111')
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (3, N'111', N'1111')
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (6, N'1111', N'11111')
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (7, N'1111', N'11111')
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (8, N'1111', N'123232')
GO
INSERT [dbo].[Admin] ([Id], [Username], [Password]) VALUES (9, N'2323', N'32323')
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainee] ON 
GO
INSERT [dbo].[Trainee] ([Id], [Username], [Password], [Gender], [Phone], [Location], [Email], [CreateDateTime], [Interesting], [EmailCode], [SetCode]) VALUES (1, N'1', N'1', N'Male', N'+4115838232222', N'3', N'4@qq.com', CAST(N'2021-12-25T00:50:25.610' AS DateTime), N'Health', NULL, NULL)
GO
INSERT [dbo].[Trainee] ([Id], [Username], [Password], [Gender], [Phone], [Location], [Email], [CreateDateTime], [Interesting], [EmailCode], [SetCode]) VALUES (2, N'11', N'111', N'Male', N'+6115838232222', N'1111', N'4@qq.com', CAST(N'2021-12-27T20:36:25.617' AS DateTime), N'Health,Education', NULL, NULL)
GO
INSERT [dbo].[Trainee] ([Id], [Username], [Password], [Gender], [Phone], [Location], [Email], [CreateDateTime], [Interesting], [EmailCode], [SetCode]) VALUES (3, N'13213', N'13213', N'Femail', N'+6115838232222', N'1321321', N'2834400100@qq.com', CAST(N'2021-12-27T21:04:55.827' AS DateTime), N'Health', NULL, NULL)
GO
INSERT [dbo].[Trainee] ([Id], [Username], [Password], [Gender], [Phone], [Location], [Email], [CreateDateTime], [Interesting], [EmailCode], [SetCode]) VALUES (4, N'666', N'666', N'Male', N'+6115838232222', N'666', N'2834400100@qq.com', CAST(N'2021-12-27T22:06:32.277' AS DateTime), N'Health,Education', N'2125', N'2125')
GO
SET IDENTITY_INSERT [dbo].[Trainee] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainer] ON 
GO
INSERT [dbo].[Trainer] ([Id], [Username], [Password], [Gender], [Phone], [KindOfTrainer], [Certificate], [DescribeYourself], [Location], [Email], [CreateDateTime], [EmailCode], [SetCode]) VALUES (1, N'555', N'555', N'Femail', N'+6115838232222', N'Health,Education', N'555', N'555', N'555', N'2834400100@qq.com', CAST(N'2021-12-27T22:01:56.350' AS DateTime), N'6746', N'6746')
GO
INSERT [dbo].[Trainer] ([Id], [Username], [Password], [Gender], [Phone], [KindOfTrainer], [Certificate], [DescribeYourself], [Location], [Email], [CreateDateTime], [EmailCode], [SetCode]) VALUES (2, N'555', N'555', N'Femail', N'+6115838232222', N'Health,Education', N'555', N'555', N'555', N'2834400100@qq.com', CAST(N'2021-12-27T22:03:28.680' AS DateTime), N'6862', N'6862')
GO
INSERT [dbo].[Trainer] ([Id], [Username], [Password], [Gender], [Phone], [KindOfTrainer], [Certificate], [DescribeYourself], [Location], [Email], [CreateDateTime], [EmailCode], [SetCode]) VALUES (3, N'555', N'555', N'Femail', N'+6115838232222', N'Health,Education', N'555', N'555', N'555', N'2834400100@qq.com', CAST(N'2021-12-27T22:04:55.210' AS DateTime), N'7388', N'7388')
GO
SET IDENTITY_INSERT [dbo].[Trainer] OFF
GO
