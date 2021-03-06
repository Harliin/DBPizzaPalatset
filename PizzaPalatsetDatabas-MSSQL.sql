USE [master]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [DB_A53DDD_Grupp1_admin]    Script Date: 2020-02-04 11:48:02 ******/
CREATE LOGIN [DB_A53DDD_Grupp1_admin] WITH PASSWORD=N'wHhRoA2I2Q8Fv0MkspvvWMgKvuQJh25kE53p/ltFp+k=', DEFAULT_DATABASE=[DB_A53DDD_Grupp1], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [DB_A53DDD_Grupp1_admin] DISABLE
GO
USE [DB_A53DDD_Grupp1]
GO
/****** Object:  Table [dbo].[Drink]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drink](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Drink] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Password] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EmployeeType] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extra]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extra](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Extra1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredient]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[EmployeeID] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDrink]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDrink](
	[OrderID] [int] NOT NULL,
	[DrinkID] [int] NOT NULL,
 CONSTRAINT [PK_OrderDrink] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[DrinkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderExtra]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderExtra](
	[OrderID] [int] NOT NULL,
	[ExtraID] [int] NOT NULL,
 CONSTRAINT [PK_OrderExtra] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderPasta]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPasta](
	[OrderID] [int] NOT NULL,
	[PastaID] [int] NOT NULL,
 CONSTRAINT [PK_OrderPasta] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[PastaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderPizza]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderPizza](
	[OrderID] [int] NOT NULL,
	[PizzaID] [int] NOT NULL,
 CONSTRAINT [PK_OrderPizza2] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[PizzaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderSallad]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderSallad](
	[OrderID] [int] NOT NULL,
	[SalladID] [int] NOT NULL,
 CONSTRAINT [PK_OrderSallad] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[SalladID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasta]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Pasta] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizza]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizza](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Pizza] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaIngredients]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaIngredients](
	[PizzaID] [int] NOT NULL,
	[IngredientsID] [int] NOT NULL,
 CONSTRAINT [PK_PizzaIngredients] PRIMARY KEY CLUSTERED 
(
	[PizzaID] ASC,
	[IngredientsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[OrderInfo] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
UPDATE STATISTICS [dbo].[Receipt] WITH ROWCOUNT = 0, PAGECOUNT = 0
GO
/****** Object:  Table [dbo].[Sallad]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sallad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Sallad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[OrderDrink]  WITH CHECK ADD  CONSTRAINT [FK_OrderDrink_Drink] FOREIGN KEY([DrinkID])
REFERENCES [dbo].[Drink] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderDrink] CHECK CONSTRAINT [FK_OrderDrink_Drink]
GO
ALTER TABLE [dbo].[OrderExtra]  WITH CHECK ADD  CONSTRAINT [FK_OrderExtra_Extra] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extra] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderExtra] CHECK CONSTRAINT [FK_OrderExtra_Extra]
GO
ALTER TABLE [dbo].[OrderExtra]  WITH CHECK ADD  CONSTRAINT [FK_OrderExtra_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderExtra] CHECK CONSTRAINT [FK_OrderExtra_Order]
GO
ALTER TABLE [dbo].[OrderPasta]  WITH CHECK ADD  CONSTRAINT [FK_OrderPasta_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderPasta] CHECK CONSTRAINT [FK_OrderPasta_Order]
GO
ALTER TABLE [dbo].[OrderPasta]  WITH CHECK ADD  CONSTRAINT [FK_OrderPasta_Pasta] FOREIGN KEY([PastaID])
REFERENCES [dbo].[Pasta] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderPasta] CHECK CONSTRAINT [FK_OrderPasta_Pasta]
GO
ALTER TABLE [dbo].[OrderPizza]  WITH CHECK ADD  CONSTRAINT [FK_OrderPizza2_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderPizza] CHECK CONSTRAINT [FK_OrderPizza2_Order]
GO
ALTER TABLE [dbo].[OrderPizza]  WITH CHECK ADD  CONSTRAINT [FK_OrderPizza2_Pizza] FOREIGN KEY([PizzaID])
REFERENCES [dbo].[Pizza] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderPizza] CHECK CONSTRAINT [FK_OrderPizza2_Pizza]
GO
ALTER TABLE [dbo].[OrderSallad]  WITH CHECK ADD  CONSTRAINT [FK_OrderSallad_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderSallad] CHECK CONSTRAINT [FK_OrderSallad_Order]
GO
ALTER TABLE [dbo].[OrderSallad]  WITH CHECK ADD  CONSTRAINT [FK_OrderSallad_Sallad] FOREIGN KEY([SalladID])
REFERENCES [dbo].[Sallad] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderSallad] CHECK CONSTRAINT [FK_OrderSallad_Sallad]
GO
ALTER TABLE [dbo].[PizzaIngredients]  WITH CHECK ADD  CONSTRAINT [FK_PizzaIngredients_Ingredient] FOREIGN KEY([IngredientsID])
REFERENCES [dbo].[Ingredient] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PizzaIngredients] CHECK CONSTRAINT [FK_PizzaIngredients_Ingredient]
GO
ALTER TABLE [dbo].[PizzaIngredients]  WITH CHECK ADD  CONSTRAINT [FK_PizzaIngredients_Pizza] FOREIGN KEY([PizzaID])
REFERENCES [dbo].[Pizza] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PizzaIngredients] CHECK CONSTRAINT [FK_PizzaIngredients_Pizza]
GO
/****** Object:  StoredProcedure [dbo].[AddDrink]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddDrink]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50), @Price int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Drink(Name, Price)
	VALUES (@Name,@Price)
END
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddEmployee] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(20),
	@Password nvarchar(20),
	@EmployeeType int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Employee(Name, Password, EmployeeType)
	VALUES(@Name, @Password, @EmployeeType)
END
GO
/****** Object:  StoredProcedure [dbo].[AddExtra]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddExtra]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50), @Price int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Extra([Name], Price)
	VALUES (@Name, @Price)
END
GO
/****** Object:  StoredProcedure [dbo].[AddIngredient]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddIngredient]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Ingredient(Name,Price)
	VALUES (@Name, 5)
END
GO
/****** Object:  StoredProcedure [dbo].[AddPasta]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPasta]
	-- Add the parameters for the stored procedure here
@Name nvarchar(50),
@Price int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Pasta(Name, Price)
	VALUES(@Name, @Price)
END
GO
/****** Object:  StoredProcedure [dbo].[AddPizza]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPizza] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Price int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Pizza(Name, Price) VALUES (@Name, @Price)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSallad]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSallad]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Price int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Sallad(Name, Price)
	VALUES (@Name,@Price)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateNewOrder]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateNewOrder] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [Order](Status) 
	VALUES (1);

	SELECT TOP 1 *
	FROM [Order]
	ORDER BY ID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDrink]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDrink]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Drink
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEmployee]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Employee
	WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteExtra]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteExtra]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Extra
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteIngredient]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteIngredient] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Ingredient
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrder]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteOrder] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Order]
	WHERE ID=@ID;

END
GO
/****** Object:  StoredProcedure [dbo].[DeletePasta]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePasta]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Pasta
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePizza]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePizza]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Pizza
	WHERE Pizza.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSallad]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSallad]
	-- Add the parameters for the stored procedure here
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Sallad
	WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DisplayCompleteOrder]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DisplayCompleteOrder]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM [Order] WHERE Status = 3
END
GO
/****** Object:  StoredProcedure [dbo].[DisplayOngoingOrder]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DisplayOngoingOrder]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM [Order] WHERE Status = 2
END
GO
/****** Object:  StoredProcedure [dbo].[GetAdmins]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAdmins] 
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20),
	@Password nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Employee
	WHERE EmployeeType = 1 and Name = @Username and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[GetChefs]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetChefs] 
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20),
	@Password nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Employee
	WHERE EmployeeType = 2 and Name = @Username and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDrinks]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderDrinks]
	-- Add the parameters for the stored procedure here
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Drink.*
	FROM Drink, OrderDrink
	WHERE OrderDrink.OrderID = @ID and OrderDrink.DrinkID= Drink.ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderExtras]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderExtras]
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Extra.*
	FROM Extra, OrderExtra
	WHERE OrderExtra.OrderID = @ID and OrderExtra.ExtraID= Extra.ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderPastas]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderPastas]
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Pasta.*
	FROM Pasta, OrderPasta
	WHERE OrderPasta.OrderID = @ID and OrderPasta.PastaID= Pasta.ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderPizzas]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderPizzas]
	-- Add the parameters for the stored procedure here
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Pizza.*
	FROM Pizza, OrderPizza
	WHERE OrderPizza.OrderID = @ID and OrderPizza.PizzaID= Pizza.ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderSallads]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderSallads]
	-- Add the parameters for the stored procedure here
@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Sallad.*
	FROM Sallad, OrderSallad
	WHERE OrderSallad.OrderID = @ID and OrderSallad.SalladID= Sallad.ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowDrinkByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowDrinkByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Drink.*
	FROM Drink
	WHERE Drink.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowDrinks]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowDrinks] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Drink
END
GO
/****** Object:  StoredProcedure [dbo].[ShowEmployees]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowEmployees]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Employee
END
GO
/****** Object:  StoredProcedure [dbo].[ShowExtraByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowExtraByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Extra.*
	FROM Extra
	WHERE Extra.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowExtras]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowExtras] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Extra
END
GO
/****** Object:  StoredProcedure [dbo].[ShowFinishedOrderID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowFinishedOrderID]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Order].ID
	From [Order]
	Where [Order].Status=3

END
GO
/****** Object:  StoredProcedure [dbo].[ShowIngredients]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowIngredients] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Ingredient
END
GO
/****** Object:  StoredProcedure [dbo].[ShowOngoingOrder]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowOngoingOrder]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ID FROM [Order] WHERE Status = 2
END
GO
/****** Object:  StoredProcedure [dbo].[ShowOrderByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowOrderByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [Order]
	WHERE [Order].ID = @ID

	--SELECT [Order].ID, Pizza.*
	--FROM [Order], Pizza, OrderPizza
	--WHERE [Order].ID = OrderPizza.OrderID AND Pizza.ID = OrderPizza.PizzaID AND [Order].ID = @ID;

	--SELECT [Order].*, Pasta.*
	--FROM [Order], Pasta, OrderPasta
	--WHERE [Order].ID = OrderPasta.OrderID AND Pasta.ID = OrderPasta.PastaID AND [Order].ID = @ID;

	--SELECT [Order].*, Sallad.*
	--FROM [Order], Sallad, OrderSallad
	--WHERE [Order].ID = OrderSallad.OrderID AND Sallad.ID = OrderSallad.SalladID AND [Order].ID = @ID;

	--SELECT [Order].*, Drink.*
	--FROM [Order], Drink, OrderDrink
	--WHERE [Order].ID = OrderDrink.OrderID AND Drink.ID = OrderDrink.DrinkID AND [Order].ID = @ID;

	--SELECT [Order].*, Extra.*
	--FROM [Order], Extra, OrderExtra
	--WHERE [Order].ID = OrderExtra.OrderID AND Extra.ID = OrderExtra.ExtraID AND [Order].ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[ShowOrderByStatus]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowOrderByStatus]
@STATUS int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM [Order]
	WHERE [Order].Status = @STATUS;

	--SELECT [Order].*, Pizza.*
	--FROM [Order], Pizza, OrderPizza
	--WHERE [Order].ID = OrderPizza.OrderID AND Pizza.ID = OrderPizza.PizzaID and [Order].Status = @STATUS;
	
	--SELECT [Order].*, Pasta.*
	--FROM [Order], Pasta, OrderPasta
	--WHERE [Order].ID = OrderPasta.OrderID AND Pasta.ID = OrderPasta.PastaID and [Order].Status = @STATUS;
	
	--SELECT [Order].*, Sallad.*
	--FROM [Order], Sallad, OrderSallad
	--WHERE [Order].ID = OrderSallad.OrderID AND Sallad.ID = OrderSallad.SalladID and [Order].Status = @STATUS;
	
	--SELECT [Order].*, Drink.*
	--FROM [Order], Drink, OrderDrink
	--WHERE [Order].ID = OrderDrink.OrderID AND Drink.ID = OrderDrink.DrinkID and [Order].Status = @STATUS;
	
	--SELECT [Order].*, Extra.*
	--FROM [Order], Extra, OrderExtra
	--WHERE [Order].ID = OrderExtra.OrderID AND Extra.ID = OrderExtra.ExtraID and [Order].Status = @STATUS;
END
GO
/****** Object:  StoredProcedure [dbo].[ShowOrders]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowOrders] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [Order]
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPastaByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowPastaByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Pasta.*
	FROM Pasta
	WHERE Pasta.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPastas]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowPastas]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Pasta
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPizzaByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowPizzaByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Pizza.*
	FROM Pizza
	WHERE Pizza.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPizzaIngredients]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowPizzaIngredients]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ingredient.*
	FROM Ingredient, PizzaIngredients
	WHERE Ingredient.ID = PizzaIngredients.IngredientsID and PizzaIngredients.PizzaID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPizzaIngredientsByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowPizzaIngredientsByID]
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Ingredient.*
	FROM Ingredient, PizzaIngredients
	WHERE Ingredient.ID = PizzaIngredients.IngredientsID and PizzaIngredients.PizzaID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowPizzas]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowPizzas] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Pizza
END
GO
/****** Object:  StoredProcedure [dbo].[ShowSalladByID]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowSalladByID] 
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Sallad.Name
	FROM Sallad
	WHERE Sallad.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[ShowSallads]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ShowSallads] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Sallad
END
GO
/****** Object:  StoredProcedure [dbo].[sp_OrderDrink]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderDrink]
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@DrinkID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO OrderDrink(OrderID, DrinkID)
	VALUES(@OrderID, @DrinkID)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_OrderExtra]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderExtra]
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@ExtraID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO OrderExtra(OrderID,ExtraID)
	VALUES(@OrderID, @ExtraID)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_OrderPasta]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderPasta] 
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@PastaID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO OrderPasta(OrderID, PastaID)
	VALUES(@OrderID, @PastaID)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_OrderPizza]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderPizza] 
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@PizzaID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO OrderPizza(OrderID, PizzaID)
	VALUES (@OrderID, @PizzaID)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_OrderSallad]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderSallad]
	-- Add the parameters for the stored procedure here
	@OrderID int,
	@SalladID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO OrderSallad(OrderID, SalladID)
	VALUES(@OrderID, @SalladID)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrderStatus]    Script Date: 2020-02-04 11:48:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateOrderStatus]

@ID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Order] 
	SET [Order].[Status] = [Status] + 1
	WHERE [Order].ID = @ID
END
GO
/****** Object:  Statistic [_WA_Sys_00000002_59063A47]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000002_59063A47] ON [dbo].[Drink]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000509E8F71000000002B02000000000000EB01000000000000E7030000E7000000280000000000000008D000340000000007000000F9C4FE0048AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000010000000000090410000803F0000000000009041000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000310000000000000077000000000000007F000000000000000800000000000000300010000000803F000000000000803F0400000100290043006F00630061002D0043006F006C006100FF01000000000000000100000001000000280000002800000000000000000000000900000043006F00630061002D0043006F006C0061000200000040000000000109000000000100000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_59063A47]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000003_59063A47] ON [dbo].[Drink]([Price]) WITH STATS_STREAM = 0x01000000010000000000000000000000EA1A5F5600000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000F8C4FE0048AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F1E0000000400000100000000000000
GO
/****** Object:  Statistic [PK_Drink]    Script Date: 2020-02-04 11:48:03 ******/
UPDATE STATISTICS [dbo].[Drink]([PK_Drink]) WITH STATS_STREAM = 0x01000000010000000000000000000000999C77610000000047020000000000000702000000000000380300003800000004000A0000000000000000000000000007000000DB0BE9004EAB0000060000000000000006000000000000000000803FABAA2A3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005000000050000000100000014000000000080400000C04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000009B00000000000000A30000000000000028000000000000003F0000000000000056000000000000006D000000000000008400000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F000000000000803F04000000040000100014000000803F000000000000803F06000000040000100014000000803F000000000000803F070000000400000600000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_5AB9788F]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000002_5AB9788F] ON [dbo].[Employee]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000317291EA0000000094020000000000005402000000000000E7030000E7000000280000000000000008D00034000000000700000087C4040151AB00000300000000000000030000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000010000000555555410000404000000000555555410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000008500000000000000E000000000000000E80000000000000018000000000000003F000000000000006600000000000000300010000000803F000000000000803F04000001002700470069006F00760061006E006E006100300010000000803F000000000000803F04000001002700470069006F00760061006E006E006900300010000000803F000000000000803F04000001001F0054006F006E007900FF01000000000000000300000003000000280000002800000000000000000000000C000000470069006F00760061006E006E00610054006F006E007900050000004000000000C007000000810107000001010100000104080000000300000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_5AB9788F]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000003_5AB9788F] ON [dbo].[Employee]([Password]) WITH STATS_STREAM = 0x0100000001000000000000000000000072BE3D1500000000A3020000000000006302000000000000E7030000E7000000280000000000000008D00034000000000700000088C4040151AB00000300000000000000030000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000010000000000060410000404000000000000060410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000008700000000000000EF00000000000000F70000000000000018000000000000003F000000000000006400000000000000300010000000803F000000000000803F04000001002700610064006D0069006E00310032003300300010000000803F000000000000803F040000010025006200610067006100720065003200300010000000803F000000000000803F040000010023006B0061007300730061003100FF010000000000000003000000030000002800000028000000000000000000000015000000610064006D0069006E0031003200330062006100670061007200650032006B00610073007300610031000400000040000000008108000000810708000001060F0000000300000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000004_5AB9788F]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000004_5AB9788F] ON [dbo].[Employee]([EmployeeType]) WITH STATS_STREAM = 0x01000000010000000000000000000000181B679E00000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000DE9FBF0051AB0000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000
GO
/****** Object:  Statistic [PK_Employee]    Script Date: 2020-02-04 11:48:03 ******/
UPDATE STATISTICS [dbo].[Employee]([PK_Employee]) WITH STATS_STREAM = 0x0100000001000000000000000000000014F67352000000000902000000000000C901000000000000380300003800000004000A0000000000000000000000000007000000FFF8FA0051AB00000300000000000000030000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F000000000000803F03000000040000100014000000803F000000000000803F040000000400000300000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_55F4C372]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000002_55F4C372] ON [dbo].[Extra]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000FDC69C2800000000D2020000000000009202000000000000E7030000E7000000640000000000000008D00034000000000700000042C74E0150AB00000300000000000000030000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000010000000ABAAAA410000404000000000ABAAAA410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000009D000000000000001E010000000000002601000000000000180000000000000049000000000000007000000000000000300010000000803F000000000000803F04000001003100440069007000700020002800560061006C006600720069002900300010000000803F000000000000803F040000010027004400720065007300730069006E006700300010000000803F000000000000803F04000001002D005600690074006C00F6006B00730062007200F6006400FF01000000000000000300000003000000280000002800000000000000000000001F000000440069007000700020002800560061006C006600720069002900720065007300730069006E0067005600690074006C00F6006B00730062007200F6006400050000004000000000C001000000810C01000001070D0000010B140000000300000000000000
GO
/****** Object:  Statistic [PK_Extra1]    Script Date: 2020-02-04 11:48:03 ******/
UPDATE STATISTICS [dbo].[Extra]([PK_Extra1]) WITH STATS_STREAM = 0x010000000100000000000000000000003D7F2B4C00000000EA01000000000000AA01000000000000380300003800000004000A000000000000000000000000000700000040C74E0150AB0000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000, ROWCOUNT = 3, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_6EF57B66]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000002_6EF57B66] ON [dbo].[Ingredient]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000B39DE5AD000000008B060000000000004B06000000000000E7030000E7000000640000000000000008D000349E01000007000000E4BE9A004BAB0000160000000000000016000000000000000000803F8C2E3A3D000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000015000000150000000100000010000000000070410000B0410000000000007041000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000CB03000000000000D704000000000000DF04000000000000A800000000000000CB00000000000000EC000000000000001301000000000000420100000000000071010000000000009801000000000000BD01000000000000DE01000000000000050200000000000036020000000000005D020000000000007A020000000000009F02000000000000C202000000000000E7020000000000000403000000000000270300000000000048030000000000006B03000000000000A003000000000000300010000000803F000000000000803F0400000100230041006E0061006E0061007300300010000000803F000000000000803F04000001002100420061006E0061006E00300010000000803F000000000000803F0400000100270042006100730069006C0069006B006100300010000000803F000000000000803F04000001002F0042006500610072006E0061006900730065007300E5007300300010000000803F000000000000803F04000001002F004300680061006D00700069006E006A006F006E0065007200300010000000803F000000000000803F04000001002700460065006600650072006F006E006900300010000000803F000000000000803F0400000100250046006500740061006F0073007400300010000000803F000000000000803F040000010021004B006500620061006200300010000000803F000000000000803F040000010027004B0065006200610062007300E5007300300010000000803F000000000000803F040000010031004B0072006F006E00E4007200740073006B006F0063006B006100300010000000803F000000000000803F040000010027004B00790063006B006C0069006E006700300010000000803F000000000000803F04000001001D004C00F6006B00300010000000803F000000000000803F040000010025004D007500730073006C006F007200300010000000803F000000000000803F040000010023004F006C006900760065007200300010000000803F000000000000803F040000010025004F0072006500670061006E006F00300010000000803F000000000000803F04000001001D004F0073007400300010000000803F000000000000803F040000010023004F007800660069006C00E900300010000000803F000000000000803F040000010021005200E4006B006F007200300010000000803F000000000000803F0400000100230053006B0069006E006B006100300010000000803F000000000000803F0400000100350053006F006C0074006F0072006B0061006400200074006F006D0061007400300010000000803F0000803F0000803F04000001002B005600690074006C00F6006B0073007300E5007300FF01000000000000000B0000000B000000280000002800000000000000000000004E00000041006E0061006E006100730042006100730069006C0069006B0061004300680061006D00700069006E006A006F006E006500720046006500740061006F00730074004B0065006200610062007300E5007300790063006B006C0069006E0067004D007500730073006C006F0072004F0072006500670061006E006F007800660069006C00E90053006B0069006E006B00610054006F006D00610074000E000000400000000081060000008108060000810C0E000081071A0000C001210000810722000001072900008107300000C001370000810638000001053E000081064300000105490000001600000000000000
GO
/****** Object:  Statistic [PK_Ingredient]    Script Date: 2020-02-04 11:48:03 ******/
UPDATE STATISTICS [dbo].[Ingredient]([PK_Ingredient]) WITH STATS_STREAM = 0x01000000010000000000000000000000C23D11A8000000002003000000000000E002000000000000380300003800000004000A0000000000000000000000000007000000619EAE0049AB0000160000000000000016000000000000000000803F8C2E3A3D00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C0000000C0000000100000014000000000080400000B041000000000000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001100000000000000000000000000000074010000000000007C01000000000000600000000000000077000000000000008E00000000000000A500000000000000BC00000000000000D300000000000000EA00000000000000010100000000000018010000000000002F0100000000000046010000000000005D01000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F05000000040000100014000000803F0000803F0000803F07000000040000100014000000803F0000803F0000803F09000000040000100014000000803F0000803F0000803F0B000000040000100014000000803F0000803F0000803F0D000000040000100014000000803F0000803F0000803F0F000000040000100014000000803F0000803F0000803F11000000040000100014000000803F0000803F0000803F13000000040000100014000000803F0000803F0000803F15000000040000100014000000803F000000000000803F160000000400001600000000000000, ROWCOUNT = 22, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_74AE54BC]    Script Date: 2020-02-04 11:48:03 ******/
CREATE STATISTICS [_WA_Sys_00000002_74AE54BC] ON [dbo].[Order]([Status]) WITH STATS_STREAM = 0x01000000010000000000000000000000CB64290E00000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000F271D80049AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F010000000400000100000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_74AE54BC]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000003_74AE54BC] ON [dbo].[Order]([EmployeeID]) WITH STATS_STREAM = 0x010000000100000000000000000000007480D6D400000000A4010000000000006401000000000000380200003800000004000A0000000000000000000000000007000000FFF8FA0051AB000012000000000000001200000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000140000000000000000009041000090410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000000000000000000000000000008000000000000001200000000000000
GO
/****** Object:  Statistic [PK_Order]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[Order]([PK_Order]) WITH STATS_STREAM = 0x01000000010000000000000000000000EF016C0E00000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000E4B2B8004AAB0000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000, ROWCOUNT = 24, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_70A8B9AE]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_70A8B9AE] ON [dbo].[OrderDrink]([DrinkID]) WITH STATS_STREAM = 0x01000000010000000000000000000000721ED60200000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000A7F69A0052AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F030000000400000100000000000000
GO
/****** Object:  Statistic [PK_OrderDrink]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[OrderDrink]([PK_OrderDrink]) WITH STATS_STREAM = 0x01000000020000000000000000000000AAACE62200000000E3010000000000008B01000000000000380300003800000004000A00000000000000000000000000380300003800000004000A0000000000000000000000000007000000A6F69A0052AB000001000000000000000100000000000000000000000000803F0000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000200000014000000000000410000803F00000000000080400000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F020000000400000100000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_7E02B4CC]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_7E02B4CC] ON [dbo].[OrderExtra]([ExtraID]) WITH STATS_STREAM = 0x01000000010000000000000000000000B91C4AF000000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000A9F69A0052AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F030000000400000100000000000000
GO
/****** Object:  Statistic [PK_OrderExtra]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[OrderExtra]([PK_OrderExtra]) WITH STATS_STREAM = 0x010000000200000000000000000000000D99FBA400000000E3010000000000008B01000000000000380300003800000004000A00000000000000000000000000380300003800000004000A0000000000000000000000000007000000A9F69A0052AB000001000000000000000100000000000000000000000000803F0000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000200000014000000000000410000803F00000000000080400000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F020000000400000100000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_0697FACD]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_0697FACD] ON [dbo].[OrderPasta]([PastaID]) WITH STATS_STREAM = 0x01000000010000000000000000000000C02F87C800000000CB010000000000008B01000000000000380300003800000004000A0000000000000000000000000007000000F477E50051AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F020000000400000100000000000000
GO
/****** Object:  Statistic [PK_OrderPasta]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[OrderPasta]([PK_OrderPasta]) WITH STATS_STREAM = 0x01000000020000000000000000000000D9F33BB100000000E3010000000000008B01000000000000380300003800000004000A00000000000000000000000000380300003800000004000A0000000000000000000000000007000000F377E50051AB000001000000000000000100000000000000000000000000803F0000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000200000014000000000000410000803F00000000000080400000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F020000000400000100000000000000, ROWCOUNT = 8, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_7A3223E8]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_7A3223E8] ON [dbo].[OrderPizza]([PizzaID]) WITH STATS_STREAM = 0x01000000010000000000000000000000FA969C6B00000000EA01000000000000AA01000000000000380300003800000004000A00000000000000000000000000070000009427E30051AB0000030000000000000003000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000404000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E00000000000000460000000000000010000000000000002700000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F030000000400000300000000000000
GO
/****** Object:  Statistic [PK_OrderPizza2]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[OrderPizza]([PK_OrderPizza2]) WITH STATS_STREAM = 0x01000000020000000000000000000000B30B23B300000000E3010000000000008B01000000000000380300003800000004000A00000000000000000000000000380300003800000004000A00000000000000000000000000070000008F27E30051AB000003000000000000000300000000000000000000000000803FABAAAA3E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000200000014000000000000410000404000000000000080400000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F00000000000000270000000000000008000000000000001000140000004040000000000000803F020000000400000300000000000000, ROWCOUNT = 15, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_5F7E2DAC]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_5F7E2DAC] ON [dbo].[OrderSallad]([SalladID]) WITH STATS_STREAM = 0x010000000100000000000000000000009CFC7BBE00000000CB010000000000008B01000000000000380300003800000004000A000000000000000000000000000700000024F6AB0051AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F010000000400000100000000000000
GO
/****** Object:  Statistic [PK_OrderSallad]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[OrderSallad]([PK_OrderSallad]) WITH STATS_STREAM = 0x01000000020000000000000000000000F265984E00000000E3010000000000008B01000000000000380300003800000004000A00000000000000000000000000380300003800000004000A0000000000000000000000000007000000F6A8AC0051AB000001000000000000000100000000000000000000000000803F0000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000200000014000000000000410000803F00000000000080400000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F020000000400000100000000000000, ROWCOUNT = 2, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000003_70DDC3D8]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000003_70DDC3D8] ON [dbo].[Pasta]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000026D709F0000000084030000000000004403000000000000E7030000E7000000640000000000000008D0003400000000070000006822F0004AAB00000500000000000000050000000000000000000000CDCC4C3E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000050000000500000001000000100000009A99C9410000A040000000009A99C9410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000001901000000000000D001000000000000D801000000000000280000000000000053000000000000007C00000000000000AF00000000000000E400000000000000300010000000803F000000000000803F04000001002B00410067006C0069006F0020004F006C0069006F00300010000000803F000000000000803F0400000100290043006100720062006F006E00610072006100300010000000803F000000000000803F0400000100330046007200750074007400690020006400690020004D00610072006500300010000000803F000000000000803F0400000100350050006100730074006100200063006F006E0020004300610072006E006500300010000000803F000000000000803F0400000100350050006100730074006100200063006F006E00200050006500730074006F00FF010000000000000005000000050000002800000028000000000000000000000035000000410067006C0069006F0020004F006C0069006F0043006100720062006F006E0061007200610046007200750074007400690020006400690020004D0061007200650050006100730074006100200063006F006E0020004300610072006E00650050006500730074006F00070000004000000000810A00000081090A0000810E130000400A21000081052B00000105300000000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000004_70DDC3D8]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000004_70DDC3D8] ON [dbo].[Pasta]([Price]) WITH STATS_STREAM = 0x0100000001000000000000000000000016AB0943000000002802000000000000E801000000000000380300003800000004000A0000000000000000000000000007000000DD0BE9004EAB0000050000000000000005000000000000000000803FCDCC4C3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000004000000040000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000007C000000000000008400000000000000200000000000000037000000000000004E000000000000006500000000000000100014000000803F000000000000803F4B000000040000100014000000803F0000803F0000803F5F000000040000100014000000803F000000000000803F69000000040000100014000000803F000000000000803F780000000400000500000000000000
GO
/****** Object:  Statistic [PK_Pasta]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[Pasta]([PK_Pasta]) WITH STATS_STREAM = 0x0100000001000000000000000000000019188355000000000902000000000000C901000000000000380300003800000004000A0000000000000000000000000007000000F129B80049AB0000050000000000000005000000000000000000803FCDCC4C3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F050000000400000500000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_10566F31]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_10566F31] ON [dbo].[Pizza]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000A5D4AB21000000003703000000000000F702000000000000E7030000E7000000640000000000000008D0003400000000070000006722F0004AAB00000500000000000000050000000000000000000000CDCC4C3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005000000050000000100000010000000000080410000A0400000000000008041000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000013000000000000000000000000000000EB0000000000000083010000000000008B0100000000000028000000000000004D0000000000000070000000000000009D00000000000000C600000000000000300010000000803F000000000000803F040000010025004200750073006F006C006C006100300010000000803F000000000000803F04000001002300480061007700610069006900300010000000803F000000000000803F04000001002D004B0065006200610062002000500069007A007A006100300010000000803F000000000000803F040000010029004D0061006E00680061007400740061006E00300010000000803F000000000000803F040000010025005600650073007500760069006F00FF0100000000000000050000000500000028000000280000000000000000000000280000004200750073006F006C006C0061004800610077006100690069004B0065006200610062002000500069007A007A0061004D0061006E00680061007400740061006E005600650073007500760069006F0006000000400000000081070000008106070000810B0D000081091800000107210000000500000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_10566F31]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000003_10566F31] ON [dbo].[Pizza]([Price]) WITH STATS_STREAM = 0x01000000010000000000000000000000C6B28DB000000000EA01000000000000AA01000000000000380300003800000004000A0000000000000000000000000007000000DD0BE9004EAB0000040000000000000004000000000000000000803FABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E000000000000004600000000000000100000000000000027000000000000001000140000000040000000000000803F50000000040000100014000000803F0000803F0000803F5A0000000400000400000000000000
GO
/****** Object:  Statistic [PK_Pizza]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[Pizza]([PK_Pizza]) WITH STATS_STREAM = 0x01000000010000000000000000000000856C2EF8000000000902000000000000C901000000000000380300003800000004000A000000000000000000000000000700000053D999004BAB0000050000000000000005000000000000000000803FCDCC4C3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000A04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F0000803F0000803F050000000400000500000000000000, ROWCOUNT = 5, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000001_22751F6C]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000001_22751F6C] ON [dbo].[PizzaIngredients]([PizzaID]) WITH STATS_STREAM = 0x01000000010000000000000000000000F7C7654F00000000EA01000000000000AA01000000000000380300003800000004000A00000000000000000000000000070000003E79A3004BAB000006000000000000000600000000000000000000000000003F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000020000000100000014000000000080400000C04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000003E000000000000004600000000000000100000000000000027000000000000001000140000004040000000000000803F020000000400001000140000004040000000000000803F030000000400000600000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000002_22751F6C]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_22751F6C] ON [dbo].[PizzaIngredients]([IngredientsID]) WITH STATS_STREAM = 0x01000000010000000000000000000000AA478215000000000902000000000000C901000000000000380300003800000004000A00000000000000000000000000070000003179A3004BAB00000600000000000000060000000000000000000000ABAAAA3E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000C04000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F0000000000000046000000000000001000140000000040000000000000803F100000000400001000140000004040000000000000803F11000000040000100014000000803F000000000000803F130000000400000600000000000000
GO
/****** Object:  Statistic [PK_PizzaIngredients]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[PizzaIngredients]([PK_PizzaIngredients]) WITH STATS_STREAM = 0x01000000020000000000000000000000E17F0958000000002102000000000000C901000000000000380300003800000004000A00000000000000000000000000380300003800000004000A0000000000000000000000000007000000E93EAB0051AB00000B000000000000000B00000000000000ABAAAA3E0000803E8C2EBA3D0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000200000014000000000000410000304100000000000080400000804000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F0000000000000046000000000000001000140000000040000000000000803F0100000004000010001400000040400000404000004040030000000400001000140000004040000000000000803F060000000400000B00000000000000, ROWCOUNT = 14, PAGECOUNT = 1
GO
/****** Object:  Statistic [_WA_Sys_00000002_571DF1D5]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000002_571DF1D5] ON [dbo].[Sallad]([Name]) WITH STATS_STREAM = 0x01000000010000000000000000000000AFBBAB47000000003F02000000000000FF01000000000000E7030000E7000000F00000000000000008D00034000000000700000094C2FC0048AB000001000000000000000100000000000000000000000000803F0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000100000001000000100000000000E0410000803F000000000000E0410000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000130000000000000000000000000000003B000000000000008B0000000000000093000000000000000800000000000000300010000000803F000000000000803F040000010033004F007300740020006F0063006800200073006B0069006E006B006100FF01000000000000000100000001000000280000002800000000000000000000000E0000004F007300740020006F0063006800200073006B0069006E006B006100020000004000000000010E000000000100000000000000
GO
/****** Object:  Statistic [_WA_Sys_00000003_571DF1D5]    Script Date: 2020-02-04 11:48:04 ******/
CREATE STATISTICS [_WA_Sys_00000003_571DF1D5] ON [dbo].[Sallad]([Price]) WITH STATS_STREAM = 0x01000000010000000000000000000000C852398700000000CB010000000000008B01000000000000380300003800000004000A000000000000000000000000000700000095C2FC0048AB000001000000000000000100000000000000000000000000803F000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001000000010000000100000014000000000080400000803F00000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000001F0000000000000027000000000000000800000000000000100014000000803F000000000000803F780000000400000100000000000000
GO
/****** Object:  Statistic [PK_Sallad]    Script Date: 2020-02-04 11:48:04 ******/
UPDATE STATISTICS [dbo].[Sallad]([PK_Sallad]) WITH STATS_STREAM = 0x01000000010000000000000000000000C964F62B000000000902000000000000C901000000000000380300003800000004000A0000000000000000000000000007000000DA0BE9004EAB0000040000000000000004000000000000000000803F0000803E000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000030000000100000014000000000080400000804000000000000080400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000110000000000000000000000000000005D00000000000000650000000000000018000000000000002F000000000000004600000000000000100014000000803F000000000000803F01000000040000100014000000803F0000803F0000803F03000000040000100014000000803F000000000000803F050000000400000400000000000000, ROWCOUNT = 4, PAGECOUNT = 1
GO
