USE [GiustiRestaurante]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/01/2016 03:03:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categoria]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 29/01/2016 03:03:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mesa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Mesa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Situacao] [int] NOT NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 29/01/2016 03:03:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pedido](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MesaId] [int] NOT NULL,
	[Situacao] [int] NOT NULL,
	[ValorTotal] [float] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PedidoPrato]    Script Date: 29/01/2016 03:03:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidoPrato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PedidoPrato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[PratoId] [int] NOT NULL,
	[Opcoes] [varchar](50) NULL,
	[Situacao] [int] NOT NULL,
 CONSTRAINT [PK_PedidoPrato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prato]    Script Date: 29/01/2016 03:03:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Prato]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Prato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Descricao] [varchar](300) NOT NULL,
	[Preco] [float] NOT NULL,
	[Opcoes] [varchar](10) NULL,
 CONSTRAINT [PK_Prato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

GO
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (1, N'Entradas')
GO
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (2, N'Pratos Principais')
GO
INSERT [dbo].[Categoria] ([Id], [Nome]) VALUES (3, N'Sobremeas')
GO
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Mesa] ON 

GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (1, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (2, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (3, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (4, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (5, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (6, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (7, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (8, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (9, 0)
GO
INSERT [dbo].[Mesa] ([Id], [Situacao]) VALUES (10, 0)
GO
SET IDENTITY_INSERT [dbo].[Mesa] OFF
GO
SET IDENTITY_INSERT [dbo].[Prato] ON 

GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (1, 1, N'Bolinhos de Queijo', N'Salgados', 15, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (3, 1, N'Coxinhas', N'Salgados', 14.5, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (5, 2, N'Filé Parmegiana', N'Carne Vermelha', 35, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (6, 2, N'Macarronada', N'Massa', 45, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (7, 2, N'Peixe no molho de abóbora', N'Peixes', 40, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (8, 3, N'Sorvete', N'Doces', 10, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (9, 3, N'Doce de Leite', N'Doces', 7.5, NULL)
GO
INSERT [dbo].[Prato] ([Id], [CategoriaId], [Nome], [Descricao], [Preco], [Opcoes]) VALUES (10, 3, N'Petit Gateau', N'Doces', 12.5, NULL)
GO
SET IDENTITY_INSERT [dbo].[Prato] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pedido_Mesa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pedido]'))
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Mesa] FOREIGN KEY([MesaId])
REFERENCES [dbo].[Mesa] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Pedido_Mesa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Pedido]'))
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Mesa]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidoPrato_Pedido]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidoPrato]'))
ALTER TABLE [dbo].[PedidoPrato]  WITH CHECK ADD  CONSTRAINT [FK_PedidoPrato_Pedido] FOREIGN KEY([PedidoId])
REFERENCES [dbo].[Pedido] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidoPrato_Pedido]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidoPrato]'))
ALTER TABLE [dbo].[PedidoPrato] CHECK CONSTRAINT [FK_PedidoPrato_Pedido]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidoPrato_Prato]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidoPrato]'))
ALTER TABLE [dbo].[PedidoPrato]  WITH CHECK ADD  CONSTRAINT [FK_PedidoPrato_Prato] FOREIGN KEY([PratoId])
REFERENCES [dbo].[Prato] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PedidoPrato_Prato]') AND parent_object_id = OBJECT_ID(N'[dbo].[PedidoPrato]'))
ALTER TABLE [dbo].[PedidoPrato] CHECK CONSTRAINT [FK_PedidoPrato_Prato]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Prato_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Prato]'))
ALTER TABLE [dbo].[Prato]  WITH CHECK ADD  CONSTRAINT [FK_Prato_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Prato_Categoria]') AND parent_object_id = OBJECT_ID(N'[dbo].[Prato]'))
ALTER TABLE [dbo].[Prato] CHECK CONSTRAINT [FK_Prato_Categoria]
GO