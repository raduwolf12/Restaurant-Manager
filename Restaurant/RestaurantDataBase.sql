USE [master]
GO
/****** Object:  Database [databaseWPF]    Script Date: 5/31/2020 6:08:43 PM ******/
CREATE DATABASE [databaseWPF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'databaseWPF', FILENAME = N'E:\Programe\New folder\MSSQL14.SQLEXPRESS\MSSQL\DATA\databaseWPF.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'databaseWPF_log', FILENAME = N'E:\Programe\New folder\MSSQL14.SQLEXPRESS\MSSQL\DATA\databaseWPF_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [databaseWPF] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [databaseWPF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [databaseWPF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [databaseWPF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [databaseWPF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [databaseWPF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [databaseWPF] SET ARITHABORT OFF 
GO
ALTER DATABASE [databaseWPF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [databaseWPF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [databaseWPF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [databaseWPF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [databaseWPF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [databaseWPF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [databaseWPF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [databaseWPF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [databaseWPF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [databaseWPF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [databaseWPF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [databaseWPF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [databaseWPF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [databaseWPF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [databaseWPF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [databaseWPF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [databaseWPF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [databaseWPF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [databaseWPF] SET  MULTI_USER 
GO
ALTER DATABASE [databaseWPF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [databaseWPF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [databaseWPF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [databaseWPF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [databaseWPF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [databaseWPF] SET QUERY_STORE = OFF
GO
USE [databaseWPF]
GO
/****** Object:  Table [dbo].[Alergeni]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alergeni](
	[id_alergeni] [int] IDENTITY(1,1) NOT NULL,
	[denumire] [nchar](50) NULL,
 CONSTRAINT [PK_Alergeni] PRIMARY KEY CLUSTERED 
(
	[id_alergeni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorii]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorii](
	[id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[denumire] [nchar](50) NULL,
 CONSTRAINT [PK_Categorii] PRIMARY KEY CLUSTERED 
(
	[id_categorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda_Meniu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Meniu](
	[id_comanda] [int] NOT NULL,
	[id_meniu] [int] NOT NULL,
	[cantitate] [int] NULL,
	[pret_CM] [float] NULL,
 CONSTRAINT [PK_Comanda_Meniu] PRIMARY KEY CLUSTERED 
(
	[id_comanda] ASC,
	[id_meniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda_Preparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Preparat](
	[id_comanda] [int] NOT NULL,
	[id_preparat] [int] NOT NULL,
	[cantitate] [int] NULL,
	[pret_CP] [float] NULL,
 CONSTRAINT [PK_Comanda_Preparat] PRIMARY KEY CLUSTERED 
(
	[id_comanda] ASC,
	[id_preparat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comenzi]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comenzi](
	[id_comanda] [int] IDENTITY(1,1) NOT NULL,
	[id_user] [int] NULL,
	[id_status] [int] NULL,
	[data_coamnda] [timestamp] NULL,
 CONSTRAINT [PK_Comenzi] PRIMARY KEY CLUSTERED 
(
	[id_comanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu](
	[id_meniu] [int] IDENTITY(1,1) NOT NULL,
	[denumire] [nchar](30) NULL,
	[id_categorie] [int] NULL,
 CONSTRAINT [PK_Meniu] PRIMARY KEY CLUSTERED 
(
	[id_meniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu_Preparate]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu_Preparate](
	[id_meniu] [int] NULL,
	[id_preparat] [int] NULL,
	[cantitate] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poze]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poze](
	[id_poza] [int] IDENTITY(1,1) NOT NULL,
	[link] [nchar](100) NULL,
 CONSTRAINT [PK_Poze] PRIMARY KEY CLUSTERED 
(
	[id_poza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparat_Alergeni]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparat_Alergeni](
	[id_preparat] [int] NOT NULL,
	[id_alergeni] [int] NOT NULL,
 CONSTRAINT [PK_Preparat_Alergeni] PRIMARY KEY CLUSTERED 
(
	[id_preparat] ASC,
	[id_alergeni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparat_Poza]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparat_Poza](
	[id_poza] [int] NOT NULL,
	[id_preparat] [int] NOT NULL,
 CONSTRAINT [PK_Preparat_Poza] PRIMARY KEY CLUSTERED 
(
	[id_poza] ASC,
	[id_preparat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparate]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparate](
	[id_preparat] [int] IDENTITY(1,1) NOT NULL,
	[denumire] [nchar](50) NULL,
	[pret] [float] NULL,
	[cantintate_portie] [int] NULL,
	[cantitate_restaurant] [int] NULL,
	[id_categorie] [int] NULL,
 CONSTRAINT [PK_Preparate] PRIMARY KEY CLUSTERED 
(
	[id_preparat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pret_Comenzi]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pret_Comenzi](
	[id_pretComanda] [int] IDENTITY(1,1) NOT NULL,
	[id_comanda] [int] NULL,
	[pret] [float] NULL,
 CONSTRAINT [PK_Pret_Comenzi] PRIMARY KEY CLUSTERED 
(
	[id_pretComanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roluri]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roluri](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[denumire] [nchar](100) NULL,
 CONSTRAINT [PK_Roluri] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id_status] [int] IDENTITY(1,1) NOT NULL,
	[nume] [nchar](100) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[id_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Rol]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Rol](
	[id_user] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_User_Rol] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NULL,
	[Surname] [nchar](100) NULL,
	[Email] [nchar](100) NULL,
	[Adress] [nchar](100) NULL,
	[Phone] [nchar](100) NULL,
	[Password] [nchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alergeni] ON 

INSERT [dbo].[Alergeni] ([id_alergeni], [denumire]) VALUES (1, N'gluten                                            ')
INSERT [dbo].[Alergeni] ([id_alergeni], [denumire]) VALUES (2, N'oua                                               ')
INSERT [dbo].[Alergeni] ([id_alergeni], [denumire]) VALUES (3, N'telina                                            ')
INSERT [dbo].[Alergeni] ([id_alergeni], [denumire]) VALUES (4, N'lactoza                                           ')
INSERT [dbo].[Alergeni] ([id_alergeni], [denumire]) VALUES (5, N'arahide                                           ')
INSERT [dbo].[Alergeni] ([id_alergeni], [denumire]) VALUES (6, N'ciocolata                                         ')
SET IDENTITY_INSERT [dbo].[Alergeni] OFF
SET IDENTITY_INSERT [dbo].[Categorii] ON 

INSERT [dbo].[Categorii] ([id_categorie], [denumire]) VALUES (1, N'bauturi                                           ')
INSERT [dbo].[Categorii] ([id_categorie], [denumire]) VALUES (2, N'deserturi                                         ')
INSERT [dbo].[Categorii] ([id_categorie], [denumire]) VALUES (3, N'supe/ciorbe                                       ')
INSERT [dbo].[Categorii] ([id_categorie], [denumire]) VALUES (4, N'aperitive                                         ')
INSERT [dbo].[Categorii] ([id_categorie], [denumire]) VALUES (5, N'mic dejun                                         ')
INSERT [dbo].[Categorii] ([id_categorie], [denumire]) VALUES (6, N'Preparate calde                                   ')
SET IDENTITY_INSERT [dbo].[Categorii] OFF
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (3, 1, 1, 52.2)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (6, 1, 1, 52.2)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (7, 1, 2, 104.4)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (7, 2, 1, 38.7)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (7, 3, 1, 23.4)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (9, 1, 1, 52.2)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (9, 3, 1, 30.6)
INSERT [dbo].[Comanda_Meniu] ([id_comanda], [id_meniu], [cantitate], [pret_CM]) VALUES (10, 1, 0, 0)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (3, 1, 1, 8)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (3, 10, 2, 24)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (6, 1, 1, 8)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (6, 2, 1, 8)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (6, 4, 1, 15)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (7, 1, 1, 8)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (7, 2, 1, 8)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (7, 4, 1, 15)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (8, 5, 1, 35)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (8, 6, 1, 15)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (9, 4, 2, 30)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (11, 2, 1, 8)
INSERT [dbo].[Comanda_Preparat] ([id_comanda], [id_preparat], [cantitate], [pret_CP]) VALUES (11, 5, 1, 35)
SET IDENTITY_INSERT [dbo].[Comenzi] ON 

INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (1, 6, 6)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (2, 6, 6)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (3, 12, 4)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (4, 12, 2)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (5, 12, 2)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (6, 12, 1)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (7, 12, 9)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (8, 12, 9)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (9, 1008, 3)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (10, 12, 8)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (11, 12, 1)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (12, 12, 6)
INSERT [dbo].[Comenzi] ([id_comanda], [id_user], [id_status]) VALUES (13, 12, 6)
SET IDENTITY_INSERT [dbo].[Comenzi] OFF
SET IDENTITY_INSERT [dbo].[Meniu] ON 

INSERT [dbo].[Meniu] ([id_meniu], [denumire], [id_categorie]) VALUES (1, N'Platou de peste               ', 6)
INSERT [dbo].[Meniu] ([id_meniu], [denumire], [id_categorie]) VALUES (2, N'Fish&Chips                    ', 6)
INSERT [dbo].[Meniu] ([id_meniu], [denumire], [id_categorie]) VALUES (3, N'Meniul Zilei                  ', 6)
SET IDENTITY_INSERT [dbo].[Meniu] OFF
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (1, 5, 250)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (1, 6, 200)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (1, 7, 200)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (2, 5, 250)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (2, 7, 150)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (3, 3, 200)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (3, 7, 150)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (3, 9, 56)
INSERT [dbo].[Meniu_Preparate] ([id_meniu], [id_preparat], [cantitate]) VALUES (3, 1, 500)
SET IDENTITY_INSERT [dbo].[Poze] ON 

INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (1, N'https://i.pinimg.com/736x/2a/07/bc/2a07bce5ec93d3b37fcc7e5645d241ec.jpg                             ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (2, N'https://coralia-online.ro/wp-content/uploads/fanta-15228.jpg                                        ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (6, N'https://www.cora.ro/images/products/2502816/gallery/2502816_hd_1.jpg                                ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (7, N'https://luckycake.ro/wp-content/uploads/2016/01/tort-ciocolata-si-branza-3.jpg                      ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (8, N'https://i.ytimg.com/vi/ExFqvzXjqZM/maxresdefault.jpg                                                ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (9, N'https://savoriurbane.com/wp-content/uploads/2014/08/12.06.2015-Cascaval-pane-Valentina-Pielaru.jpg  ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (10, N'https://restaurantulbotosani.ro/wp-content/uploads/2019/08/cascaval-pane-botosani.jpg               ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (11, N'https://www.e-retete.ro/files/recipes/salata-de-varza-simpla.jpg                                    ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (12, N'https://planeturbanfood.ro/wp-content/uploads/2019/03/CARTOFI-min.jpg                               ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (13, N'https://jamilacuisine.ro/wp-content/uploads/2013/04/ciorba-de-burta.jpg                             ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (14, N'https://www.lalena.ro/images/uploaded/1920x_Pastrav-la-Gratar-643.jpg                               ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (15, N'https://media.kaufland.com/images/PPIM/AP_Content_1010/std.lang.all/07/50/Asset_1020750.jpg         ')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (16, N'data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMTEhUSEhIWFhUWFRUXFRUXGBcWGBcXFRUWFxUVF')
INSERT [dbo].[Poze] ([id_poza], [link]) VALUES (17, N'https://www.petitchef.ro/imgupl/recipe/supa-crema-de-ciuperci--356468p576026.jpg                    ')
SET IDENTITY_INSERT [dbo].[Poze] OFF
INSERT [dbo].[Preparat_Alergeni] ([id_preparat], [id_alergeni]) VALUES (4, 2)
INSERT [dbo].[Preparat_Alergeni] ([id_preparat], [id_alergeni]) VALUES (4, 6)
INSERT [dbo].[Preparat_Alergeni] ([id_preparat], [id_alergeni]) VALUES (10, 2)
INSERT [dbo].[Preparat_Alergeni] ([id_preparat], [id_alergeni]) VALUES (10, 3)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (1, 4)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (2, 1)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (6, 2)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (7, 4)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (8, 10)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (9, 10)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (10, 10)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (11, 9)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (12, 7)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (13, 3)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (14, 5)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (15, 6)
INSERT [dbo].[Preparat_Poza] ([id_poza], [id_preparat]) VALUES (17, 8)
SET IDENTITY_INSERT [dbo].[Preparate] ON 

INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (1, N'Fanta                                             ', 8, 500, 10, 1)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (2, N'Sprite                                            ', 8, 500, 10, 1)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (3, N'Ciorba de burta                                   ', 14, 300, 1000, 3)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (4, N'Tort de ciocolata                                 ', 15, 50, 1000, 2)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (5, N'pastrav la gratar                                 ', 35, 330, 5000, 6)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (6, N'mix fructe de mare pane                           ', 15, 250, 1500, 6)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (7, N'cartofi prajiti                                   ', 8, 250, 4000, 4)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (8, N'supa crema de ciuperci                            ', 12, 150, 3000, 3)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (9, N'salata de varza                                   ', 4, 50, 1000, 4)
INSERT [dbo].[Preparate] ([id_preparat], [denumire], [pret], [cantintate_portie], [cantitate_restaurant], [id_categorie]) VALUES (10, N'Cascaval Pane                                     ', 12, 120, 2000, 5)
SET IDENTITY_INSERT [dbo].[Preparate] OFF
SET IDENTITY_INSERT [dbo].[Pret_Comenzi] ON 

INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (1, NULL, 120)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (2, 6, 120)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (3, 6, 52.2)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (4, 7, 23.4)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (5, 9, 30.6)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (6, 8, 15)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (7, 10, 0)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (8, 10, 0)
INSERT [dbo].[Pret_Comenzi] ([id_pretComanda], [id_comanda], [pret]) VALUES (9, 11, 35)
SET IDENTITY_INSERT [dbo].[Pret_Comenzi] OFF
SET IDENTITY_INSERT [dbo].[Roluri] ON 

INSERT [dbo].[Roluri] ([id_rol], [denumire]) VALUES (1, N'Utilizator                                                                                          ')
INSERT [dbo].[Roluri] ([id_rol], [denumire]) VALUES (2, N'Lucrator                                                                                            ')
SET IDENTITY_INSERT [dbo].[Roluri] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([id_status], [nume]) VALUES (1, N'Asteptare                                                                                           ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (2, N'Preluat                                                                                             ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (3, N'Preparare                                                                                           ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (4, N'Preparata                                                                                           ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (5, N'Livrata                                                                                             ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (6, N'inregistrata                                                                                        ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (7, N'se pregateste                                                                                       ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (8, N'a plecat la client                                                                                  ')
INSERT [dbo].[Status] ([id_status], [nume]) VALUES (9, N'anulata                                                                                             ')
SET IDENTITY_INSERT [dbo].[Status] OFF
INSERT [dbo].[User_Rol] ([id_user], [id_rol]) VALUES (6, 1)
INSERT [dbo].[User_Rol] ([id_user], [id_rol]) VALUES (8, 1)
INSERT [dbo].[User_Rol] ([id_user], [id_rol]) VALUES (9, 1)
INSERT [dbo].[User_Rol] ([id_user], [id_rol]) VALUES (12, 2)
INSERT [dbo].[User_Rol] ([id_user], [id_rol]) VALUES (1007, 1)
INSERT [dbo].[User_Rol] ([id_user], [id_rol]) VALUES (1008, 1)
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Email], [Adress], [Phone], [Password]) VALUES (6, N'nume                                                                                                ', N'prenume                                                                                             ', N'e@yahoo.com                                                                                         ', N'adrs                                                                                                ', N'0730405060                                                                                          ', N'pass                                                                                                ')
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Email], [Adress], [Phone], [Password]) VALUES (8, N'app                                                                                                 ', N'app                                                                                                 ', N'app@yahoo.com                                                                                       ', N'Adresss                                                                                             ', N'0000123                                                                                             ', N'passApp                                                                                             ')
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Email], [Adress], [Phone], [Password]) VALUES (9, N'Taraburca                                                                                           ', N'Radu                                                                                                ', N'rtaraburca@yahoo.com                                                                                ', N'adresa                                                                                              ', N'21436554745                                                                                         ', N'Admin                                                                                               ')
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Email], [Adress], [Phone], [Password]) VALUES (12, N'numet                                                                                               ', N'prenumeT                                                                                            ', N't@t.com                                                                                             ', N'sdasa                                                                                               ', N'09876432                                                                                            ', N'passt                                                                                               ')
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Email], [Adress], [Phone], [Password]) VALUES (1007, N'Adi                                                                                                 ', N'Costache                                                                                            ', N'a.costea@gmail.com                                                                                  ', N'str mare                                                                                            ', N'092312435                                                                                           ', N'parola                                                                                              ')
INSERT [dbo].[Users] ([UserId], [Name], [Surname], [Email], [Adress], [Phone], [Password]) VALUES (1008, N'Andrei                                                                                              ', N'Dan                                                                                                 ', N'andrei@gmail.com                                                                                    ', N'str                                                                                                 ', N'024354435                                                                                           ', N'parola                                                                                              ')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Comanda_Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Meniu_Comenzi] FOREIGN KEY([id_comanda])
REFERENCES [dbo].[Comenzi] ([id_comanda])
GO
ALTER TABLE [dbo].[Comanda_Meniu] CHECK CONSTRAINT [FK_Comanda_Meniu_Comenzi]
GO
ALTER TABLE [dbo].[Comanda_Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Meniu_Meniu] FOREIGN KEY([id_meniu])
REFERENCES [dbo].[Meniu] ([id_meniu])
GO
ALTER TABLE [dbo].[Comanda_Meniu] CHECK CONSTRAINT [FK_Comanda_Meniu_Meniu]
GO
ALTER TABLE [dbo].[Comanda_Preparat]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Preparat_Comenzi] FOREIGN KEY([id_comanda])
REFERENCES [dbo].[Comenzi] ([id_comanda])
GO
ALTER TABLE [dbo].[Comanda_Preparat] CHECK CONSTRAINT [FK_Comanda_Preparat_Comenzi]
GO
ALTER TABLE [dbo].[Comanda_Preparat]  WITH CHECK ADD  CONSTRAINT [FK_Comanda_Preparat_Preparate] FOREIGN KEY([id_preparat])
REFERENCES [dbo].[Preparate] ([id_preparat])
GO
ALTER TABLE [dbo].[Comanda_Preparat] CHECK CONSTRAINT [FK_Comanda_Preparat_Preparate]
GO
ALTER TABLE [dbo].[Comenzi]  WITH CHECK ADD  CONSTRAINT [FK_Comenzi_Status] FOREIGN KEY([id_status])
REFERENCES [dbo].[Status] ([id_status])
GO
ALTER TABLE [dbo].[Comenzi] CHECK CONSTRAINT [FK_Comenzi_Status]
GO
ALTER TABLE [dbo].[Comenzi]  WITH CHECK ADD  CONSTRAINT [FK_Comenzi_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Comenzi] CHECK CONSTRAINT [FK_Comenzi_Users]
GO
ALTER TABLE [dbo].[Meniu]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Categorii] FOREIGN KEY([id_categorie])
REFERENCES [dbo].[Categorii] ([id_categorie])
GO
ALTER TABLE [dbo].[Meniu] CHECK CONSTRAINT [FK_Meniu_Categorii]
GO
ALTER TABLE [dbo].[Meniu_Preparate]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Preparate_Meniu] FOREIGN KEY([id_meniu])
REFERENCES [dbo].[Meniu] ([id_meniu])
GO
ALTER TABLE [dbo].[Meniu_Preparate] CHECK CONSTRAINT [FK_Meniu_Preparate_Meniu]
GO
ALTER TABLE [dbo].[Meniu_Preparate]  WITH CHECK ADD  CONSTRAINT [FK_Meniu_Preparate_Preparate] FOREIGN KEY([id_preparat])
REFERENCES [dbo].[Preparate] ([id_preparat])
GO
ALTER TABLE [dbo].[Meniu_Preparate] CHECK CONSTRAINT [FK_Meniu_Preparate_Preparate]
GO
ALTER TABLE [dbo].[Preparat_Alergeni]  WITH CHECK ADD  CONSTRAINT [FK_Preparat_Alergeni_Alergeni] FOREIGN KEY([id_alergeni])
REFERENCES [dbo].[Alergeni] ([id_alergeni])
GO
ALTER TABLE [dbo].[Preparat_Alergeni] CHECK CONSTRAINT [FK_Preparat_Alergeni_Alergeni]
GO
ALTER TABLE [dbo].[Preparat_Alergeni]  WITH CHECK ADD  CONSTRAINT [FK_Preparat_Alergeni_Preparate] FOREIGN KEY([id_preparat])
REFERENCES [dbo].[Preparate] ([id_preparat])
GO
ALTER TABLE [dbo].[Preparat_Alergeni] CHECK CONSTRAINT [FK_Preparat_Alergeni_Preparate]
GO
ALTER TABLE [dbo].[Preparat_Poza]  WITH CHECK ADD  CONSTRAINT [FK_Preparat_Poza_Poze] FOREIGN KEY([id_poza])
REFERENCES [dbo].[Poze] ([id_poza])
GO
ALTER TABLE [dbo].[Preparat_Poza] CHECK CONSTRAINT [FK_Preparat_Poza_Poze]
GO
ALTER TABLE [dbo].[Preparat_Poza]  WITH CHECK ADD  CONSTRAINT [FK_Preparat_Poza_Preparate] FOREIGN KEY([id_preparat])
REFERENCES [dbo].[Preparate] ([id_preparat])
GO
ALTER TABLE [dbo].[Preparat_Poza] CHECK CONSTRAINT [FK_Preparat_Poza_Preparate]
GO
ALTER TABLE [dbo].[Preparate]  WITH CHECK ADD  CONSTRAINT [FK_Preparate_Categorii] FOREIGN KEY([id_categorie])
REFERENCES [dbo].[Categorii] ([id_categorie])
GO
ALTER TABLE [dbo].[Preparate] CHECK CONSTRAINT [FK_Preparate_Categorii]
GO
ALTER TABLE [dbo].[Pret_Comenzi]  WITH CHECK ADD  CONSTRAINT [FK_Pret_Comenzi_Comenzi] FOREIGN KEY([id_comanda])
REFERENCES [dbo].[Comenzi] ([id_comanda])
GO
ALTER TABLE [dbo].[Pret_Comenzi] CHECK CONSTRAINT [FK_Pret_Comenzi_Comenzi]
GO
ALTER TABLE [dbo].[User_Rol]  WITH CHECK ADD  CONSTRAINT [FK_User_Rol_Roluri] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roluri] ([id_rol])
GO
ALTER TABLE [dbo].[User_Rol] CHECK CONSTRAINT [FK_User_Rol_Roluri]
GO
ALTER TABLE [dbo].[User_Rol]  WITH CHECK ADD  CONSTRAINT [FK_User_Rol_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[User_Rol] CHECK CONSTRAINT [FK_User_Rol_Users]
GO
/****** Object:  StoredProcedure [dbo].[CreateAlergeniPreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateAlergeniPreparat]
@DenumirePrep  nvarchar(100),
@DenumireAlerg  nvarchar(100)
as
INSERT INTO [dbo].[Preparat_Alergeni]
           ([id_preparat]
           ,[id_alergeni])
     VALUES
           ((select Preparate.id_preparat from Preparate where Preparate.denumire=@DenumirePrep)
           ,(select Alergeni.id_alergeni from Alergeni where Alergeni.denumire=@DenumireAlerg))
GO
/****** Object:  StoredProcedure [dbo].[CreateMenu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateMenu]
@Denumire  nvarchar(100),
@Categorie nvarchar(100)
as
INSERT INTO [dbo].[Meniu]
           ([denumire]
           ,[id_categorie])
     VALUES
           (@Denumire
           ,(select Categorii.id_categorie from Categorii where Categorii.denumire=@Categorie))
GO
/****** Object:  StoredProcedure [dbo].[CreateMenuPreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateMenuPreparat]
@Meniu  nvarchar(100),
@Preparat nvarchar(100),
@Cantitate int
as
INSERT INTO [dbo].[Meniu_Preparate]
           ([id_meniu]
           ,[id_preparat]
           ,[cantitate])
     VALUES
           ((select Meniu.id_meniu from Meniu where Meniu.denumire=@Meniu)
           ,(select Preparate.id_preparat from Preparate where Preparate.denumire=@Preparat)
           ,@Cantitate)
GO
/****** Object:  StoredProcedure [dbo].[CreatePoza]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreatePoza]
@Link  nvarchar(100)
as
INSERT INTO [dbo].[Poze]
           ([link])
     VALUES
           (@Link)
GO
/****** Object:  StoredProcedure [dbo].[CreatePozePreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreatePozePreparat]
@DenumirePrep  nvarchar(100),
@Link  nvarchar(100)
as
INSERT INTO [dbo].[Preparat_Poza]
           ([id_poza]
           ,[id_preparat])
     VALUES
           ((select Poze.id_poza from Poze where Poze.link=@Link)
           ,(select Preparate.id_preparat from Preparate where Preparate.denumire=@DenumirePrep))
GO
/****** Object:  StoredProcedure [dbo].[CreatePreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreatePreparat]
@Denumire  nvarchar(100),
@Pret float,
@CantitatePortie int,
@CantitateRestaurant int,
@Categorie nvarchar(100)
as
INSERT INTO [dbo].[Preparate]
           ([denumire]
           ,[pret]
           ,[cantintate_portie]
           ,[cantitate_restaurant]
           ,[id_categorie])
     VALUES
           (@Denumire 
           ,@Pret
           ,@CantitatePortie
           ,@CantitateRestaurant
           ,(select Categorii.id_categorie from Categorii where Categorii.denumire=@Categorie))
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser] 
@Name nvarchar(100),
@Surname nvarchar(100),
@Email nvarchar(100),
@Adress nvarchar(100),
@Phone nvarchar(100),
@Password nvarchar(100)   
AS   

     
	INSERT INTO Users VALUES (@Name,@Surname,@Email,@Adress,@Phone,@Password)
GO
/****** Object:  StoredProcedure [dbo].[CreateUser2]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateUser2]
@Name  nvarchar(100)
,@Surname nvarchar(100)
,@Email nvarchar(100)
,@Adress nvarchar(100)
,@Phone nvarchar(100)
,@Password nvarchar(100)
as
INSERT INTO [dbo].[Users]
           ([Name]
           ,[Surname]
           ,[Email]
           ,[Adress]
           ,[Phone]
           ,[Password])
     VALUES
           (@Name
           ,@Surname
           ,@Email
           ,@Adress
           ,@Phone
           ,@Password);
		

INSERT INTO [dbo].[User_Rol]
           ([id_user]
           ,[id_rol])
     VALUES
           ((select Users.UserId from Users where Users.Email=@Email)
           ,1)
GO
/****** Object:  StoredProcedure [dbo].[DeleteAlergeniPreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteAlergeniPreparat]
@Denumire  nvarchar(100)
as
DELETE Preparat_Alergeni from Preparat_Alergeni join Preparate on Preparate.id_preparat=Preparat_Alergeni.id_preparat where Preparate.denumire=@Denumire
GO
/****** Object:  StoredProcedure [dbo].[DeleteMeniu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteMeniu]
@Denumire  nvarchar(100)
as
DELETE FROM [dbo].[Meniu]
      WHERE Meniu.denumire=@Denumire
GO
/****** Object:  StoredProcedure [dbo].[DeleteMeniuPreparate]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteMeniuPreparate]
@Denumire  nvarchar(100)
as
DELETE Meniu_Preparate FROM Meniu_Preparate join Meniu on Meniu.id_meniu=Meniu_Preparate.id_meniu where Meniu.denumire=@Denumire
GO
/****** Object:  StoredProcedure [dbo].[DeletePozePreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeletePozePreparat]
@Denumire  nvarchar(100)
as
DELETE Preparat_Poza from Preparat_Poza join Preparate on Preparate.id_preparat=Preparat_Poza.id_preparat where Preparate.denumire=@Denumire
GO
/****** Object:  StoredProcedure [dbo].[DeletePreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeletePreparat]
@DenumirePrep  nvarchar(100)
as
DELETE FROM [dbo].[Preparate]
      WHERE Preparate.denumire=@DenumirePrep
GO
/****** Object:  StoredProcedure [dbo].[GetAllAlergeni]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllAlergeni]
as
select * from Alergeni
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategorii]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllCategorii]
as
select * from Categorii
GO
/****** Object:  StoredProcedure [dbo].[GetAllStatus]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllStatus]
as
select * from Status
GO
/****** Object:  StoredProcedure [dbo].[GetComandaInregistrataId]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetComandaInregistrataId]
@userId int
as
select Comenzi.id_comanda from Comenzi join Users on Comenzi.id_user=Users.UserId  join Status on Comenzi.id_status=Status.id_status  where Users.UserId=@userId and Status.nume='inregistrata' 
GO
/****** Object:  StoredProcedure [dbo].[GetComenziByEmail]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetComenziByEmail]
@Email nvarchar(100)
as
select Comenzi.id_user,Comenzi.id_comanda,Comenzi.data_coamnda,Users.Name,Users.Surname,Users.Adress,Status.nume,Pret_Comenzi.pret from Comenzi join Users on Comenzi.id_user=Users.UserId join Pret_Comenzi on Comenzi.id_comanda=Pret_Comenzi.id_comanda join Status on Status.id_status=Comenzi.id_status where Users.Email=@Email
GO
/****** Object:  StoredProcedure [dbo].[GetComenziFull]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetComenziFull]
as
select Comenzi.id_user,Comenzi.id_comanda,Comenzi.data_coamnda,Users.Name,Users.Surname,Users.Adress,Status.nume,Pret_Comenzi.pret from Comenzi join Users on Comenzi.id_user=Users.UserId join Pret_Comenzi on Comenzi.id_comanda=Pret_Comenzi.id_comanda join Status on Status.id_status=Comenzi.id_status
GO
/****** Object:  StoredProcedure [dbo].[InregistrareComanda]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InregistrareComanda]
@userId int
as
INSERT INTO [dbo].[Comenzi]([id_user],[id_status])
     VALUES
           (@userId,6)
GO
/****** Object:  StoredProcedure [dbo].[LoginCheck]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginCheck]   
    @Email nvarchar(50),   
    @Password nvarchar(50)   
AS   
 
    SELECT COUNT(*)
    FROM Users  
    WHERE Email = @Email AND Password = @Password  
GO
/****** Object:  StoredProcedure [dbo].[LoginCheck1]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginCheck1]   
    @Email nvarchar(50),   
    @Password nvarchar(50)   
AS   

    SET NOCOUNT ON;  
    SELECT Name,Surname,Email,Adress,Phone 
    FROM Users  
    WHERE Email = @Email AND Password = @Password  
GO
/****** Object:  StoredProcedure [dbo].[LoginCheckTest]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginCheckTest]   
    @Email nvarchar(50),   
    @Password nvarchar(50)   
AS   
 
    SELECT COUNT(*)
    FROM Users  
    WHERE Email = @Email AND Password = @Password  
GO
/****** Object:  StoredProcedure [dbo].[PretComanda]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PretComanda]
@userId int,
@Pret float
as
INSERT INTO [dbo].[Pret_Comenzi]
           ([id_comanda]
           ,[pret])
     VALUES
           ((select Top(1)Comenzi.id_comanda from Comenzi join Users on Comenzi.id_user=Users.UserId 
		   join Status on Comenzi.id_status=Status.id_status  where Users.UserId=@userId and Status.nume='inregistrata')
           ,@Pret)
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllergeniForPreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPGetAllergeniForPreparat]
@Denumire nvarchar(100)
AS
	 SELECT Alergeni.denumire FROM Preparat_Alergeni Join Preparate
	 On Preparat_Alergeni.id_preparat=Preparate.id_preparat  
	 Join Alergeni on Alergeni.id_alergeni=Preparat_Alergeni.id_alergeni 
	 where Preparate.denumire=@Denumire

GO
/****** Object:  StoredProcedure [dbo].[SPGetAllMenues]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPGetAllMenues]
 as
 select Meniu.* from Meniu join Categorii on Meniu.id_categorie=Categorii.id_categorie
GO
/****** Object:  StoredProcedure [dbo].[SPGetAllPhotosForPreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPGetAllPhotosForPreparat]
 @Denumire nvarchar(100)
 as
 select Poze.* from Preparate join Preparat_Poza on Preparate.id_preparat=Preparat_Poza.id_preparat join Poze on Preparat_Poza.id_poza=Poze.id_poza where Preparate.denumire = @Denumire 
GO
/****** Object:  StoredProcedure [dbo].[SPGetMeniuriByCategorie]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPGetMeniuriByCategorie]
 @Categorie nvarchar(100)
 as
  select Meniu.* from Meniu join Categorii on Meniu.id_categorie=Categorii.id_categorie where Categorii.denumire=@Categorie
GO
/****** Object:  StoredProcedure [dbo].[SPGetMenuIdByDenumire]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPGetMenuIdByDenumire]
@Name  nvarchar(100)
as
select Meniu.id_meniu from Meniu where Meniu.denumire=@Name
GO
/****** Object:  StoredProcedure [dbo].[SPGetPreparate]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPGetPreparate]
AS   
	SELECT * FROM Preparate
GO
/****** Object:  StoredProcedure [dbo].[SPGetPreparateByCategorie]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPGetPreparateByCategorie]
 @Categorie nvarchar(100)
 as
  select Preparate.id_preparat,Preparate.denumire,Preparate.pret,Preparate.cantintate_portie,Preparate.cantitate_restaurant,Preparate.id_categorie
 from Preparate join Categorii on Preparate.id_categorie=Categorii.id_categorie
 where Categorii.denumire=@Categorie
GO
/****** Object:  StoredProcedure [dbo].[SPGetPreparateByMenu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPGetPreparateByMenu]
 @Denumire nvarchar(100)
 as
   SELECT Preparate.denumire,Preparate.pret,Meniu_Preparate.cantitate,Preparate.cantitate_restaurant FROM Meniu Join Meniu_Preparate
 On Meniu.id_meniu=Meniu_Preparate.id_meniu  
 Join Preparate on Preparate.id_preparat=Meniu_Preparate.id_preparat 
 where Meniu.denumire=@Denumire
GO
/****** Object:  StoredProcedure [dbo].[SPGetPreparatePriceSumByMenu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPGetPreparatePriceSumByMenu]
 @Denumire nvarchar(100)
 as
 SELECT SUM(Preparate.pret) FROM Meniu Join Meniu_Preparate
 On Meniu.id_meniu=Meniu_Preparate.id_meniu  
 Join Preparate on Preparate.id_preparat=Meniu_Preparate.id_preparat 
 where Meniu.denumire=@Denumire
GO
/****** Object:  StoredProcedure [dbo].[SPGetPreparatIdByDenumire]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPGetPreparatIdByDenumire]
@Name  nvarchar(100)
as
select Preparate.id_preparat from Preparate where Preparate.denumire=@Name
GO
/****** Object:  StoredProcedure [dbo].[SPInsertMenuInComanda]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPInsertMenuInComanda]
@id_comanda int,
@id_meniu int,
@cantitate int,
@pret_CM float
as
INSERT INTO [dbo].[Comanda_Meniu]
           ([id_comanda]
           ,[id_meniu]
           ,[cantitate]
           ,[pret_CM])
     VALUES
           (@id_comanda
           ,@id_meniu
           ,@cantitate
           ,@pret_CM)
GO
/****** Object:  StoredProcedure [dbo].[SPInsertMenuInComanda2]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPInsertMenuInComanda2]
@userId int,
@Name  nvarchar(100),
@cantitate int,
@pret_CM float
as
INSERT INTO [dbo].[Comanda_Meniu]
           ([id_comanda]
           ,[id_meniu]
           ,[cantitate]
           ,[pret_CM])
     VALUES
           ((select top(1)Comenzi.id_comanda from Comenzi join Users on Comenzi.id_user=Users.UserId 
		   join Status on Comenzi.id_status=Status.id_status  where Users.UserId=@userId and Status.nume='inregistrata') 
           ,(select Meniu.id_meniu from Meniu where Meniu.denumire=@Name)
           ,@cantitate
           ,@pret_CM)
GO
/****** Object:  StoredProcedure [dbo].[SPInsertPreparatInComanda]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPInsertPreparatInComanda]
@id_comanda int,
@id_meniu int,
@cantitate int,
@pret_CP float
as
INSERT INTO [dbo].[Comanda_Preparat]
           ([id_comanda]
           ,[id_preparat]
           ,[cantitate]
           ,[pret_CP])
     VALUES
           (@id_comanda
           ,@id_meniu
           ,@cantitate
           ,@pret_CP)
GO
/****** Object:  StoredProcedure [dbo].[SPInsertPreparatInComanda2]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SPInsertPreparatInComanda2]
@userId int,
@Name  nvarchar(100),
@cantitate int,
@pret_CP float
as
INSERT INTO [dbo].[Comanda_Preparat]
           ([id_comanda]
           ,[id_preparat]
           ,[cantitate]
           ,[pret_CP])
     VALUES
           ((select top(1)Comenzi.id_comanda from Comenzi join Users on Comenzi.id_user=Users.UserId 
		   join Status on Comenzi.id_status=Status.id_status  where Users.UserId=@userId and Status.nume='inregistrata') 
           ,(select Preparate.id_preparat from Preparate where Preparate.denumire=@Name)
           ,@cantitate
           ,@pret_CP)
GO
/****** Object:  StoredProcedure [dbo].[SPLoginAndReturnUser]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPLoginAndReturnUser]
@Email nvarchar(100),
@Password nvarchar(100)
AS
	select Users.UserId,Users.Name,Users.Surname,Users.Adress,Users.Email,Users.Phone,Roluri.denumire from User_Rol 
	join Users on Users.UserId=User_Rol.id_user 
	join Roluri on Roluri.id_rol=User_Rol.id_rol 
	where Users.Email=@Email and Users.Password=@Password

GO
/****** Object:  StoredProcedure [dbo].[spLoginCheck]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spLoginCheck]
    @Email Varchar(100),
    @Password Varchar(100) ,
    @LoginStatus char(1) = null output,
    @Error Varchar(1000) output 
AS
BEGIN

    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN

            SET @Error = 'None'
            SET @LoginStatus = ''

            IF EXISTS(SELECT TOP 1 *  from Users WHERE Email = @Email AND Password = @Password )
            BEGIN
                SET @LoginStatus='Y'
            END

            ELSE
            BEGIN
                SET @LoginStatus='N'
            END

        END
    END TRY

    BEGIN CATCH
        BEGIN           
            SET @Error = ERROR_MESSAGE()
        END
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SPSearchMenuAll]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPSearchMenuAll]
 @Denumire nvarchar(100)
 as
 select * from Meniu where Meniu.denumire like '%'+@Denumire+'%'
GO
/****** Object:  StoredProcedure [dbo].[SPSearchMenuByCategorie]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPSearchMenuByCategorie]
 @Denumire nvarchar(100),
 @Categorie nvarchar(100)
 as
   select * from Meniu join Categorii on Categorii.id_categorie=Meniu.id_categorie  where Meniu.denumire like '%'+@Denumire+'%' and  Categorii.denumire =@Categorie
GO
/****** Object:  StoredProcedure [dbo].[SPSearchMenuByCategorie2]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPSearchMenuByCategorie2]
 @Denumire nvarchar(100),
 @Categorie nvarchar(100)
 as
   select Meniu.* from Meniu join Categorii on Categorii.id_categorie=Meniu.id_categorie  where Meniu.denumire like '%'+@Denumire+'%' and  Categorii.denumire =@Categorie
GO
/****** Object:  StoredProcedure [dbo].[SPSearchPreparatAll]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPSearchPreparatAll]
 @Denumire nvarchar(100)
 as
 select * from Preparate where Preparate.denumire like '%'+@Denumire+'%'
GO
/****** Object:  StoredProcedure [dbo].[SPSearchPreparatByCategorie]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[SPSearchPreparatByCategorie]
 @Denumire nvarchar(100),
 @Categorie nvarchar(100)
 as
 select Preparate.* from Preparate join Categorii on Categorii.id_categorie=Preparate.id_categorie where Preparate.denumire like '%'+@Denumire+'%' and  Categorii.denumire =@Categorie
GO
/****** Object:  StoredProcedure [dbo].[SPSelectProductByCategorie]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPSelectProductByCategorie] 
@Product nvarchar(100)
AS   
	SELECT * FROM Preparate JOIN Categorii ON Preparate.id_categorie = Categorii.id_categorie WHERE Categorii.denumire=@Product
GO
/****** Object:  StoredProcedure [dbo].[UpdateComandaStatus]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateComandaStatus]
@UserId int,
@DenumireStatus nvarchar(100),
@IDComanda int
as
UPDATE [dbo].[Comenzi]
   SET [id_user] = @UserId
      ,[id_status] = (select Status.id_status from Status where Status.nume=@DenumireStatus)
 WHERE  Comenzi.id_comanda=@IDComanda
GO
/****** Object:  StoredProcedure [dbo].[UpdateMeniu]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateMeniu]
@Denumire  nvarchar(100),
@Categorie nvarchar(100),
@Id int
as
UPDATE [dbo].[Meniu]
   SET [denumire] = @Denumire
      ,[id_categorie] = (select Categorii.id_categorie from Categorii where Categorii.denumire=@Categorie)
 WHERE Meniu.id_meniu=@Id
GO
/****** Object:  StoredProcedure [dbo].[UpdatePreparat]    Script Date: 5/31/2020 6:08:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdatePreparat]
@Denumire  nvarchar(100),
@Pret float,
@CantitatePortie int,
@CantitateRestaurant int,
@Categorie nvarchar(100),
@ID int
as
UPDATE [dbo].[Preparate]
   SET [denumire] = @Denumire 
      ,[pret] = @Pret
      ,[cantintate_portie] = @CantitatePortie
      ,[cantitate_restaurant] = @CantitateRestaurant
      ,[id_categorie] = (select Categorii.id_categorie from Categorii where Categorii.denumire=@Categorie)
 WHERE Preparate.id_preparat=@ID
GO
USE [master]
GO
ALTER DATABASE [databaseWPF] SET  READ_WRITE 
GO
