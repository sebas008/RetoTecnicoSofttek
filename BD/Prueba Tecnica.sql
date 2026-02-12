USE master;
GO

/* CREACIÓN DE LA BASE DE DATOS */
IF DB_ID('PruebaTecnica') IS NULL
    CREATE DATABASE PruebaTecnica;
GO

USE PruebaTecnica;
GO

/* CREACIÓN DE LAS TABLAS */

--VALIDACION DE LAS TABLAS
IF OBJECT_ID('dbo.Libro', 'U') IS NOT NULL DROP TABLE dbo.Libro;
IF OBJECT_ID('dbo.Autor', 'U') IS NOT NULL DROP TABLE dbo.Autor;
GO

--CREACION DE LAS TABLAS (EN ESE ORDEN POR EL CONFLICTO DE LA LLAVE FORANEA)

--AUTOR
CREATE TABLE dbo.Autor
(
    AutorId           INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NombreCompleto    NVARCHAR(150) NOT NULL,
    FechaNacimiento   DATE NOT NULL,
    CiudadProcedencia NVARCHAR(120) NULL,
    CorreoElectronico NVARCHAR(150) NOT NULL UNIQUE
);
GO

--LIBRO
CREATE TABLE dbo.Libro
(
    LibroId       INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Titulo        NVARCHAR(200) NOT NULL,
    Anio          INT NOT NULL,
    Genero        NVARCHAR(80) NULL,
    NumeroPaginas INT NULL,
    AutorId       INT NOT NULL REFERENCES dbo.Autor(AutorId),
    FechaRegistro DATETIME NOT NULL DEFAULT(GETDATE()),
    CHECK (Anio BETWEEN 1400 AND 2100),
    CHECK (NumeroPaginas IS NULL OR NumeroPaginas > 0)
);
GO

/* CREACIÓN DE STORES */

-- INSERTAR AUTORES
IF OBJECT_ID('dbo.usp_Autor_Insertar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Autor_Insertar;
GO

CREATE PROCEDURE dbo.usp_Autor_Insertar
    @NombreCompleto     NVARCHAR(150),
    @FechaNacimiento    DATE,
    @CiudadProcedencia  NVARCHAR(120) = NULL,
    @CorreoElectronico  NVARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Autor (NombreCompleto, FechaNacimiento, CiudadProcedencia, CorreoElectronico)
    VALUES (@NombreCompleto, @FechaNacimiento, @CiudadProcedencia, @CorreoElectronico);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS AutorId;
END
GO

-- INSERTAR LIBROS
IF OBJECT_ID('dbo.usp_Libro_Insertar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Libro_Insertar;
GO

CREATE PROCEDURE dbo.usp_Libro_Insertar
    @Titulo         NVARCHAR(200),
    @Anio           INT,
    @Genero         NVARCHAR(80) = NULL,
    @NumeroPaginas  INT = NULL,
    @AutorId        INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Libro (Titulo, Anio, Genero, NumeroPaginas, AutorId)
    VALUES (@Titulo, @Anio, @Genero, @NumeroPaginas, @AutorId);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS LibroId;
END
GO


--LISTAR AUTORES
IF OBJECT_ID('dbo.usp_Autor_Listar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Autor_Listar;
GO

CREATE PROCEDURE dbo.usp_Autor_Listar
AS
BEGIN
     
     SELECT NombreCompleto, FechaNacimiento, CiudadProcedencia, CorreoElectronico
     
     FROM dbo.Autor
END
GO


--LISTAR LIBROS
IF OBJECT_ID('dbo.usp_Libro_Listar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.usp_Libro_Listar;
GO

CREATE PROCEDURE dbo.usp_Libro_Listar
AS
BEGIN
     
     SELECT Titulo, Anio, Genero, NumeroPaginas
     
     FROM dbo.Libro
END
GO


