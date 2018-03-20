
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/06/2018 18:17:28
-- Generated from EDMX file: C:\Users\FDA\source\repos\ServicioMecanico\ServicioMecanico\Models\ModelCarService.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarService];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CarBrand_IdCarBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_CarBrand_IdCarBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_ServicesCar_IdCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServicesCars] DROP CONSTRAINT [FK_ServicesCar_IdCar];
GO
IF OBJECT_ID(N'[dbo].[FK_ServicesCar_IdService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServicesCars] DROP CONSTRAINT [FK_ServicesCar_IdService];
GO
IF OBJECT_ID(N'[dbo].[FK_CarOwner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_CarOwner];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[CarBrands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarBrands];
GO
IF OBJECT_ID(N'[dbo].[Owners]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Owners];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[ServicesCars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicesCars];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [IdCar] int IDENTITY(1,1) NOT NULL,
    [IdCarBrand] int  NOT NULL,
    [YearCar] nchar(4)  NOT NULL,
    [LicensePlate] nchar(10)  NOT NULL,
    [Observations] nchar(50)  NULL,
    [IdOwner] int  NOT NULL
);
GO

-- Creating table 'CarBrands'
CREATE TABLE [dbo].[CarBrands] (
    [IdCarBrand] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Owners'
CREATE TABLE [dbo].[Owners] (
    [IdOwner] int IDENTITY(1,1) NOT NULL,
    [CardId] int  NOT NULL,
    [LastName] nchar(10)  NOT NULL,
    [Name] nchar(10)  NOT NULL,
    [Observations] nchar(50)  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [IdService] int IDENTITY(1,1) NOT NULL,
    [Description] nchar(50)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Observations] nchar(50)  NULL
);
GO

-- Creating table 'ServicesCars'
CREATE TABLE [dbo].[ServicesCars] (
    [IdServicesCar] int IDENTITY(1,1) NOT NULL,
    [IdCar] int  NOT NULL,
    [IdService] int  NOT NULL,
    [ServiceDate] datetime  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Observations] nchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCar] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([IdCar] ASC);
GO

-- Creating primary key on [IdCarBrand] in table 'CarBrands'
ALTER TABLE [dbo].[CarBrands]
ADD CONSTRAINT [PK_CarBrands]
    PRIMARY KEY CLUSTERED ([IdCarBrand] ASC);
GO

-- Creating primary key on [IdOwner] in table 'Owners'
ALTER TABLE [dbo].[Owners]
ADD CONSTRAINT [PK_Owners]
    PRIMARY KEY CLUSTERED ([IdOwner] ASC);
GO

-- Creating primary key on [IdService] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([IdService] ASC);
GO

-- Creating primary key on [IdServicesCar] in table 'ServicesCars'
ALTER TABLE [dbo].[ServicesCars]
ADD CONSTRAINT [PK_ServicesCars]
    PRIMARY KEY CLUSTERED ([IdServicesCar] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCarBrand] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_CarBrand_IdCarBrand]
    FOREIGN KEY ([IdCarBrand])
    REFERENCES [dbo].[CarBrands]
        ([IdCarBrand])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarBrand_IdCarBrand'
CREATE INDEX [IX_FK_CarBrand_IdCarBrand]
ON [dbo].[Cars]
    ([IdCarBrand]);
GO

-- Creating foreign key on [IdCar] in table 'ServicesCars'
ALTER TABLE [dbo].[ServicesCars]
ADD CONSTRAINT [FK_ServicesCar_IdCar]
    FOREIGN KEY ([IdCar])
    REFERENCES [dbo].[Cars]
        ([IdCar])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServicesCar_IdCar'
CREATE INDEX [IX_FK_ServicesCar_IdCar]
ON [dbo].[ServicesCars]
    ([IdCar]);
GO

-- Creating foreign key on [IdService] in table 'ServicesCars'
ALTER TABLE [dbo].[ServicesCars]
ADD CONSTRAINT [FK_ServicesCar_IdService]
    FOREIGN KEY ([IdService])
    REFERENCES [dbo].[Services]
        ([IdService])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServicesCar_IdService'
CREATE INDEX [IX_FK_ServicesCar_IdService]
ON [dbo].[ServicesCars]
    ([IdService]);
GO

-- Creating foreign key on [IdOwner] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_CarOwner]
    FOREIGN KEY ([IdOwner])
    REFERENCES [dbo].[Owners]
        ([IdOwner])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarOwner'
CREATE INDEX [IX_FK_CarOwner]
ON [dbo].[Cars]
    ([IdOwner]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------