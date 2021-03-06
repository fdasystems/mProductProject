/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.2000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2016
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [SiSistemasDEMO]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Precios]') AND type in (N'U'))
ALTER TABLE [dbo].[Precios] DROP CONSTRAINT IF EXISTS [FK_Precios_Productos_PreciosProductosId]
GO
/****** Object:  Index [NonClusteredIndex-Codigo]    Script Date: 24/03/2020 01:16:55 ******/
DROP INDEX IF EXISTS [NonClusteredIndex-Codigo] ON [dbo].[Productos]
GO
/****** Object:  Index [UQ__Producto__06370DAC9CE3E2E9]    Script Date: 24/03/2020 01:16:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
ALTER TABLE [dbo].[Productos] DROP CONSTRAINT IF EXISTS [UQ__Producto__06370DAC9CE3E2E9]
GO
/****** Object:  Index [NonClusteredIndex-dateAlta]    Script Date: 24/03/2020 01:16:55 ******/
DROP INDEX IF EXISTS [NonClusteredIndex-dateAlta] ON [dbo].[Precios]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 24/03/2020 01:16:55 ******/
DROP TABLE IF EXISTS [dbo].[Productos]
GO
/****** Object:  Table [dbo].[Precios]    Script Date: 24/03/2020 01:16:55 ******/
DROP TABLE IF EXISTS [dbo].[Precios]
GO
/****** Object:  Table [dbo].[Precios]    Script Date: 24/03/2020 01:16:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Precios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Precios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FAlta] [date] NOT NULL,
	[FBaja] [date] NULL,
	[ProductoId] [int] NOT NULL,
	[Utilidad] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NOT NULL,
	[Tarjeta] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 24/03/2020 01:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FAlta] [date] NOT NULL,
	[FBaja] [date] NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Codigo] [nvarchar](100) NOT NULL,
	[RutaImagen] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Precios] ON 

INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1, CAST(N'2020-02-18' AS Date), NULL, 10, CAST(500.20 AS Decimal(10, 2)), CAST(2991.03 AS Decimal(10, 2)), CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (2, CAST(N'2020-02-18' AS Date), NULL, 11, CAST(457.23 AS Decimal(10, 2)), CAST(2171.47 AS Decimal(10, 2)), CAST(2200.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (3, CAST(N'2020-02-18' AS Date), NULL, 12, CAST(110.00 AS Decimal(10, 2)), CAST(1078.17 AS Decimal(10, 2)), CAST(1245.18 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (4, CAST(N'2020-02-18' AS Date), NULL, 13, CAST(234.89 AS Decimal(10, 2)), CAST(852.50 AS Decimal(10, 2)), CAST(900.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (5, CAST(N'2020-02-18' AS Date), NULL, 14, CAST(123.57 AS Decimal(10, 2)), CAST(911.69 AS Decimal(10, 2)), CAST(1000.43 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (6, CAST(N'2020-02-18' AS Date), NULL, 15, CAST(567.00 AS Decimal(10, 2)), CAST(2890.00 AS Decimal(10, 2)), CAST(2900.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (7, CAST(N'2020-02-18' AS Date), NULL, 16, CAST(70.00 AS Decimal(10, 2)), CAST(190.00 AS Decimal(10, 2)), CAST(199.99 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (8, CAST(N'2020-02-18' AS Date), NULL, 17, CAST(90.00 AS Decimal(10, 2)), CAST(230.00 AS Decimal(10, 2)), CAST(254.68 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (9, CAST(N'2020-02-18' AS Date), NULL, 18, CAST(169.00 AS Decimal(10, 2)), CAST(330.00 AS Decimal(10, 2)), CAST(333.33 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (10, CAST(N'2020-03-13' AS Date), NULL, 19, CAST(18.80 AS Decimal(10, 2)), CAST(95.00 AS Decimal(10, 2)), CAST(98.80 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (11, CAST(N'2020-03-13' AS Date), NULL, 20, CAST(19.79 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), CAST(104.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (12, CAST(N'2020-03-13' AS Date), NULL, 21, CAST(20.78 AS Decimal(10, 2)), CAST(105.00 AS Decimal(10, 2)), CAST(109.20 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (13, CAST(N'2020-03-13' AS Date), NULL, 22, CAST(21.77 AS Decimal(10, 2)), CAST(110.00 AS Decimal(10, 2)), CAST(114.40 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (14, CAST(N'2020-03-13' AS Date), NULL, 23, CAST(22.76 AS Decimal(10, 2)), CAST(115.00 AS Decimal(10, 2)), CAST(119.60 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (15, CAST(N'2020-03-13' AS Date), NULL, 24, CAST(23.75 AS Decimal(10, 2)), CAST(120.00 AS Decimal(10, 2)), CAST(124.80 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (16, CAST(N'2020-03-13' AS Date), NULL, 25, CAST(24.74 AS Decimal(10, 2)), CAST(125.00 AS Decimal(10, 2)), CAST(130.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (17, CAST(N'2020-03-13' AS Date), NULL, 26, CAST(25.73 AS Decimal(10, 2)), CAST(130.00 AS Decimal(10, 2)), CAST(135.20 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (18, CAST(N'2020-03-13' AS Date), NULL, 27, CAST(26.72 AS Decimal(10, 2)), CAST(135.00 AS Decimal(10, 2)), CAST(140.40 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1013, CAST(N'2020-03-23' AS Date), NULL, 1020, CAST(520.00 AS Decimal(10, 2)), CAST(880.00 AS Decimal(10, 2)), CAST(900.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1014, CAST(N'2020-03-23' AS Date), NULL, 1021, CAST(521.00 AS Decimal(10, 2)), CAST(881.00 AS Decimal(10, 2)), CAST(901.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1015, CAST(N'2020-03-23' AS Date), NULL, 1022, CAST(522.00 AS Decimal(10, 2)), CAST(882.00 AS Decimal(10, 2)), CAST(902.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1016, CAST(N'2020-03-23' AS Date), NULL, 1023, CAST(523.00 AS Decimal(10, 2)), CAST(883.00 AS Decimal(10, 2)), CAST(903.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1017, CAST(N'2020-03-23' AS Date), NULL, 1024, CAST(524.00 AS Decimal(10, 2)), CAST(884.00 AS Decimal(10, 2)), CAST(904.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1018, CAST(N'2020-03-23' AS Date), NULL, 1025, CAST(525.00 AS Decimal(10, 2)), CAST(885.00 AS Decimal(10, 2)), CAST(905.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1019, CAST(N'2020-03-23' AS Date), NULL, 1026, CAST(526.00 AS Decimal(10, 2)), CAST(886.00 AS Decimal(10, 2)), CAST(906.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1020, CAST(N'2020-03-23' AS Date), NULL, 1027, CAST(527.00 AS Decimal(10, 2)), CAST(887.00 AS Decimal(10, 2)), CAST(907.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1021, CAST(N'2020-03-23' AS Date), NULL, 1028, CAST(528.00 AS Decimal(10, 2)), CAST(888.00 AS Decimal(10, 2)), CAST(908.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1022, CAST(N'2020-03-23' AS Date), NULL, 1029, CAST(529.00 AS Decimal(10, 2)), CAST(889.00 AS Decimal(10, 2)), CAST(909.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1023, CAST(N'2020-03-23' AS Date), NULL, 1030, CAST(530.00 AS Decimal(10, 2)), CAST(890.00 AS Decimal(10, 2)), CAST(910.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1024, CAST(N'2020-03-23' AS Date), NULL, 1031, CAST(531.00 AS Decimal(10, 2)), CAST(891.00 AS Decimal(10, 2)), CAST(911.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1025, CAST(N'2020-03-23' AS Date), NULL, 1032, CAST(532.00 AS Decimal(10, 2)), CAST(892.00 AS Decimal(10, 2)), CAST(912.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1026, CAST(N'2020-03-23' AS Date), NULL, 1033, CAST(533.00 AS Decimal(10, 2)), CAST(893.00 AS Decimal(10, 2)), CAST(913.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1027, CAST(N'2020-03-23' AS Date), NULL, 1034, CAST(534.00 AS Decimal(10, 2)), CAST(894.00 AS Decimal(10, 2)), CAST(914.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1028, CAST(N'2020-03-23' AS Date), NULL, 1035, CAST(535.00 AS Decimal(10, 2)), CAST(895.00 AS Decimal(10, 2)), CAST(915.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1029, CAST(N'2020-03-23' AS Date), NULL, 1036, CAST(536.00 AS Decimal(10, 2)), CAST(896.00 AS Decimal(10, 2)), CAST(916.00 AS Decimal(10, 2)))
INSERT [dbo].[Precios] ([Id], [FAlta], [FBaja], [ProductoId], [Utilidad], [PrecioVenta], [Tarjeta]) VALUES (1030, CAST(N'2020-03-23' AS Date), NULL, 1037, CAST(537.00 AS Decimal(10, 2)), CAST(897.00 AS Decimal(10, 2)), CAST(917.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Precios] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (10, CAST(N'2020-03-10' AS Date), NULL, N'CERRADURA', N'CERRADURA PUERTA PALIO/SIENA MANUAL TRASERA DER.', N'10150', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (11, CAST(N'2020-03-10' AS Date), NULL, N'CIERRE BAUL', N'CIERRE BAUL INTERIOR ESCORT 97 5 PUERTAS', N'12115', N'http://www.sisistemas.com.ar/web2/productos/01104038.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (12, CAST(N'2020-03-10' AS Date), NULL, N'CILINDROS DE BAUL', N'CIL.BAUL.VALEO PEUGEOT 405 (M.1993) CON LLAVE', N'10031', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (13, CAST(N'2020-03-10' AS Date), NULL, N'CILINDROS DE BAUL', N'ALOJAMIENTO CON CERR. BAUL FALCON 91 NEGRO', N'13458', N'http://www.sisistemas.com.ar/web2/productos/16137039.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (14, CAST(N'2020-03-10' AS Date), NULL, N'CILINDROS DE EMPAREJAMIENTO', N'EMPAREJAMIENTO PEUGEOT 206/207  IMPORTADO', N'42732', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (15, CAST(N'2020-03-10' AS Date), NULL, N'CILINDROS DE IGNICION', N'CIL.IGN.ORIGINAL FOCUS CON /CIL DE GUANTERA*******', N'14954', N'http://www.sisistemas.com.ar/web2/productos/93353848.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (16, CAST(N'2020-03-10' AS Date), NULL, N'CILINDROS DE IGNICION', N'CILINDRO DE IGNICION ASTRA 2001 EN ADELANTE', N'13632', N'http://www.sisistemas.com.ar/web2/productos/93363483.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (17, CAST(N'2020-03-10' AS Date), NULL, N'CILINDROS DE PUERTA', N'JUEGO CIL.PUERTA INDULOCK ESCORT 88', N'13418', N'http://www.sisistemas.com.ar/web2/productos/93368891.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (18, CAST(N'2020-03-10' AS Date), NULL, N'SOLENOIDES', N'SOLENOIDE PUERTA RENAULT MEGANE/CLIO/KANGOO YMOS', N'14204', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (19, CAST(N'2020-03-13' AS Date), NULL, N'CERRADURA', N'CERRADURA PUERTA PALIO/SIENA MANUAL TRASERA DER.', N'10160', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (20, CAST(N'2020-03-13' AS Date), NULL, N'CIERRE BAUL', N'CIERRE BAUL INTERIOR ESCORT 97 5 PUERTAS', N'12126', N'http://www.sisistemas.com.ar/web2/productos/01104038.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (21, CAST(N'2020-03-13' AS Date), NULL, N'CILINDROS DE BAUL', N'CIL.BAUL.VALEO PEUGEOT 405 (M.1993) CON LLAVE', N'10043', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (22, CAST(N'2020-03-13' AS Date), NULL, N'CILINDROS DE BAUL', N'ALOJAMIENTO CON CERR. BAUL FALCON 91 NEGRO', N'13471', N'http://www.sisistemas.com.ar/web2/productos/16137039.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (23, CAST(N'2020-03-13' AS Date), NULL, N'CILINDROS DE EMPAREJAMIENTO', N'EMPAREJAMIENTO PEUGEOT 206/207  IMPORTADO', N'42746', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (24, CAST(N'2020-03-13' AS Date), NULL, N'CILINDROS DE IGNICION', N'CIL.IGN.ORIGINAL FOCUS CON /CIL DE GUANTERA*******', N'14969', N'http://www.sisistemas.com.ar/web2/productos/93353848.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (25, CAST(N'2020-03-13' AS Date), NULL, N'CILINDROS DE IGNICION', N'CILINDRO DE IGNICION ASTRA 2001 EN ADELANTE', N'13648', N'http://www.sisistemas.com.ar/web2/productos/93363483.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (26, CAST(N'2020-03-13' AS Date), NULL, N'CILINDROS DE PUERTA', N'JUEGO CIL.PUERTA INDULOCK ESCORT 88', N'13435', N'http://www.sisistemas.com.ar/web2/productos/93368891.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (27, CAST(N'2020-03-13' AS Date), NULL, N'SOLENOIDES', N'SOLENOIDE PUERTA RENAULT MEGANE/CLIO/KANGOO YMOS', N'14222', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1020, CAST(N'2020-03-23' AS Date), NULL, N'CERRADURA', N'CERRADURA PUERTA PALIO/SIENA MANUAL TRASERA DER.', N'10140', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1021, CAST(N'2020-03-23' AS Date), NULL, N'CIERRE BAUL', N'CIERRE BAUL INTERIOR ESCORT 97 5 PUERTAS', N'12104', N'http://www.sisistemas.com.ar/web2/productos/01104038.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1022, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE BAUL', N'CIL.BAUL.VALEO PEUGEOT 405 (M.1993) CON LLAVE', N'10019', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1023, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE BAUL', N'ALOJAMIENTO CON CERR. BAUL FALCON 91 NEGRO', N'13445', N'http://www.sisistemas.com.ar/web2/productos/16137039.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1024, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE EMPAREJAMIENTO', N'EMPAREJAMIENTO PEUGEOT 206/207  IMPORTADO', N'42718', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1025, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE IGNICION', N'CIL.IGN.ORIGINAL FOCUS CON /CIL DE GUANTERA*******', N'14939', N'http://www.sisistemas.com.ar/web2/productos/93353848.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1026, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE IGNICION', N'CILINDRO DE IGNICION ASTRA 2001 EN ADELANTE', N'13616', N'http://www.sisistemas.com.ar/web2/productos/93363483.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1027, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE PUERTA', N'JUEGO CIL.PUERTA INDULOCK ESCORT 88', N'13401', N'http://www.sisistemas.com.ar/web2/productos/93368891.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1028, CAST(N'2020-03-23' AS Date), NULL, N'SOLENOIDES', N'SOLENOIDE PUERTA RENAULT MEGANE/CLIO/KANGOO YMOS', N'14186', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1029, CAST(N'2020-03-23' AS Date), NULL, N'CERRADURA', N'CERRADURA PUERTA PALIO/SIENA MANUAL TRASERA DER.', N'10141', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1030, CAST(N'2020-03-23' AS Date), NULL, N'CIERRE BAUL', N'CIERRE BAUL INTERIOR ESCORT 97 5 PUERTAS', N'12106', N'http://www.sisistemas.com.ar/web2/productos/01104038.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1031, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE BAUL', N'CIL.BAUL.VALEO PEUGEOT 405 (M.1993) CON LLAVE', N'10022', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1032, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE BAUL', N'ALOJAMIENTO CON CERR. BAUL FALCON 91 NEGRO', N'13449', N'http://www.sisistemas.com.ar/web2/productos/16137039.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1033, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE EMPAREJAMIENTO', N'EMPAREJAMIENTO PEUGEOT 206/207  IMPORTADO', N'42723', N'http://www.sisistemas.com.ar/web2/productos/01103905.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1034, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE IGNICION', N'CIL.IGN.ORIGINAL FOCUS CON /CIL DE GUANTERA*******', N'14945', N'http://www.sisistemas.com.ar/web2/productos/93353848.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1035, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE IGNICION', N'CILINDRO DE IGNICION ASTRA 2001 EN ADELANTE', N'13623', N'http://www.sisistemas.com.ar/web2/productos/93363483.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1036, CAST(N'2020-03-23' AS Date), NULL, N'CILINDROS DE PUERTA', N'JUEGO CIL.PUERTA INDULOCK ESCORT 88', N'13409', N'http://www.sisistemas.com.ar/web2/productos/93368891.png')
INSERT [dbo].[Productos] ([Id], [FAlta], [FBaja], [Nombre], [Descripcion], [Codigo], [RutaImagen]) VALUES (1037, CAST(N'2020-03-23' AS Date), NULL, N'SOLENOIDES', N'SOLENOIDE PUERTA RENAULT MEGANE/CLIO/KANGOO YMOS', N'14195', N'http://www.sisistemas.com.ar/web2/productos/90522729.png')
SET IDENTITY_INSERT [dbo].[Productos] OFF
/****** Object:  Index [NonClusteredIndex-dateAlta]    Script Date: 24/03/2020 01:16:56 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Precios]') AND name = N'NonClusteredIndex-dateAlta')
CREATE NONCLUSTERED INDEX [NonClusteredIndex-dateAlta] ON [dbo].[Precios]
(
	[FAlta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Producto__06370DAC9CE3E2E9]    Script Date: 24/03/2020 01:16:56 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND name = N'UQ__Producto__06370DAC9CE3E2E9')
ALTER TABLE [dbo].[Productos] ADD UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-Codigo]    Script Date: 24/03/2020 01:16:56 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND name = N'NonClusteredIndex-Codigo')
CREATE NONCLUSTERED INDEX [NonClusteredIndex-Codigo] ON [dbo].[Productos]
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Precios_Productos_PreciosProductosId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Precios]'))
ALTER TABLE [dbo].[Precios]  WITH CHECK ADD  CONSTRAINT [FK_Precios_Productos_PreciosProductosId] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Precios_Productos_PreciosProductosId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Precios]'))
ALTER TABLE [dbo].[Precios] CHECK CONSTRAINT [FK_Precios_Productos_PreciosProductosId]
GO
