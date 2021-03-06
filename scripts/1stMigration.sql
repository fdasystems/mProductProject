/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [SiSistemasDEMO]
GO
/****** Object:  User [FdaSystems]    Script Date: 09/03/2020 21:36:37 
CREATE USER [FdaSystems] FOR LOGIN [FdaSystems] WITH DEFAULT_SCHEMA=[FdaSystems]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [FdaSystems]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [FdaSystems]
GO
ALTER ROLE [db_datareader] ADD MEMBER [FdaSystems]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [FdaSystems]
GO
 Object:  Table [dbo].[Categorias]    Script Date: 09/03/2020 21:36:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
CREATE TABLE [dbo].[Categorias](
	[Id] [int] identity(1,1),
	[FAlta] [date] NULL,
	[FBaja] [date] NULL,
	[IDNegocio] [int] NULL,
	[Categoria] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

*/

CREATE  TABLE [dbo].[Productos](
	[Id] [int] identity(1,1),
	[FAlta] [date] NOT NULL,
	[FBaja] [date] NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Codigo] [nvarchar](100) UNIQUE NOT NULL,
	[RutaImagen] [nvarchar](max) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--alter table [dbo].[Productos] ADD [Codigo] [nvarchar](max) NULL


/****** Object:  Table [dbo].[Precios]    Script Date: 09/03/2020 21:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precios](
	[Id] [int] identity(1,1),
	[FAlta] [date] NOT NULL,
	[FBaja] [date] NULL,
--	[IDNegocio] [int] NULL,
--	[IDLista] [int] NULL,
	[ProductoId] [int] NOT NULL,
	[Utilidad] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NOT NULL,
	[Tarjeta] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Precios] WITH CHECK ADD  CONSTRAINT [FK_Precios_Productos_PreciosProductosId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO


/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/03/2020 21:36:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  TABLE [dbo].[Usuarios](
	[Id] [int] identity(1,1) NOT NULL,
	[FAlta] [date] NULL,
	[FBaja] [date] NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Pass] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--INSERT [dbo].[Categorias] ([IDCategoria], [FAlta], [FBaja], [IDNegocio], [Categoria]) VALUES (1, CAST(N'2020-01-23' AS Date), NULL, 2, N'Clientes')
--INSERT [dbo].[Categorias] ([IDCategoria], [FAlta], [FBaja], [IDNegocio], [Categoria]) VALUES (2, CAST(N'2020-01-23' AS Date), NULL, 2, N'Proveedores')
	
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CERRADURA', 'CERRADURA PUERTA PALIO/SIENA MANUAL TRASERA DER.', '10150', 'http://www.sisistemas.com.ar/web2/productos/01103905.png') 
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CIERRE BAUL', 'CIERRE BAUL INTERIOR ESCORT 97 5 PUERTAS', '12115', 'http://www.sisistemas.com.ar/web2/productos/01104038.png') 
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CILINDROS DE BAUL', 'CIL.BAUL.VALEO PEUGEOT 405 (M.1993) CON LLAVE', '10031', 'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CILINDROS DE BAUL', 'ALOJAMIENTO CON CERR. BAUL FALCON 91 NEGRO', '13458', 'http://www.sisistemas.com.ar/web2/productos/16137039.png') 
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CILINDROS DE EMPAREJAMIENTO', 'EMPAREJAMIENTO PEUGEOT 206/207  IMPORTADO', '42732', 'http://www.sisistemas.com.ar/web2/productos/36606166.png') 
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CILINDROS DE IGNICION', 'CIL.IGN.ORIGINAL FOCUS CON /CIL DE GUANTERA*******', '14954', 'http://www.sisistemas.com.ar/web2/productos/93353848.png') 
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CILINDROS DE IGNICION', 'CILINDRO DE IGNICION ASTRA 2001 EN ADELANTE', '13632', 'http://www.sisistemas.com.ar/web2/productos/93363483.png')
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'CILINDROS DE PUERTA', 'JUEGO CIL.PUERTA INDULOCK ESCORT 88', '13418', 'http://www.sisistemas.com.ar/web2/productos/93368891.png') 
INSERT [dbo].[Productos] ([FAlta],[FBaja],[Nombre],[Descripcion], [Codigo], [RutaImagen]) VALUES (GETDATE(), NULL, 'SOLENOIDES', 'SOLENOIDE PUERTA RENAULT MEGANE/CLIO/KANGOO YMOS', '14204', 'http://www.sisistemas.com.ar/web2/productos/93385843.png')










INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL,  10, CAST(500.20 AS Decimal(10, 2)), CAST(2991.03 AS Decimal(10, 2)), CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 11, CAST(457.23 AS Decimal(10, 2)), CAST(2171.47 AS Decimal(10, 2)), CAST(2200.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 12, CAST(110.00 AS Decimal(10, 2)), CAST(1078.17 AS Decimal(10, 2)), CAST(1245.18 AS Decimal(10, 2)))

INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 13, CAST(234.89 AS Decimal(10, 2)), CAST(852.50 AS Decimal(10, 2)), CAST(900.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 14, CAST(123.57 AS Decimal(10, 2)), CAST(911.69 AS Decimal(10, 2)), CAST(1000.43 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 15, CAST(567.00 AS Decimal(10, 2)), CAST(2890.00 AS Decimal(10, 2)), CAST(2900.00 AS Decimal(10, 2)))

INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 16, CAST(70.00 AS Decimal(10, 2)), CAST(190.00 AS Decimal(10, 2)), CAST(199.99 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 17, CAST(90.00 AS Decimal(10, 2)), CAST(230.00 AS Decimal(10, 2)), CAST(254.68 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ( [FAlta], [FBaja], /*[IDNegocio], [IDLista],*/ [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES ( CAST(N'2020-02-18' AS Date), NULL, 18, CAST(169.00 AS Decimal(10, 2)), CAST(330.00 AS Decimal(10, 2)), CAST(333.33 AS Decimal(10, 2)))









INSERT [dbo].[Usuarios] ( [FAlta], [FBaja], [Usuario], [Pass]) VALUES ( CAST(N'2019-06-12' AS Date), NULL, N'SiSistemas', N'85E48799CAFF66274003AF222B3AB1CC')
INSERT [dbo].[Usuarios] ( [FAlta], [FBaja], [Usuario], [Pass]) VALUES ( CAST(N'2020-01-23' AS Date), NULL, N'Demo', N'086D2A6C0E184AE017F7895DA2FE6C4F')

--UPDATE [dbo].[Productos] SET [Codigo]='123-339'
