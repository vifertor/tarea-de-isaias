CREATE DATABASE Tarea;

-- Usar la base de datos
USE Tarea

-- Crear la tabla de vacunas
CREATE TABLE vacunas (
    Id_vacuna INT PRIMARY KEY IDENTITY(1,1),
    Nombre_vacuna NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NOT NULL,
    Estado BIT NOT NULL,
    Fecha_aplicacion DATETIME NOT NULL,
    Id_animal INT NOT NULL
);


 INSERT INTO Vacunas (Nombre_vacuna, Descripcion, Estado, Fecha_aplicacion, Id_animal)
VALUES 
    ('Vacuna A', 'Descripción de la Vacuna A', 1, '2024-10-09', 1),
    ('Vacuna B', 'Descripción de la Vacuna B', 1, '2024-09-30', 2),
    ('Vacuna C', 'Descripción de la Vacuna C', 0, '2024-09-15', 3),
    ('Vacuna D', 'Descripción de la Vacuna D', 1, '2024-10-01', 4),
    ('Vacuna E', 'Descripción de la Vacuna E', 1, '2024-10-05', 5);

------------procedimiento para incertar
CREATE PROCEDURE insertar_vacuna
    @NombreVacuna NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Estado BIT,
    @FechaAplicacion DATETIME,
    @IdAnimal INT
AS
BEGIN
    INSERT INTO vacunas (Nombre_vacuna, Descripcion, Estado, Fecha_aplicacion, Id_animal)
    VALUES (@NombreVacuna, @Descripcion, @Estado, @FechaAplicacion, @IdAnimal);
END;

-----------------------------Procedimiento almacenado para modificar una vacuna
CREATE PROCEDURE modificar_vacuna
    @IdVacuna INT,
    @NombreVacuna NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @Estado BIT,
    @FechaAplicacion DATETIME,
    @IdAnimal INT
AS
BEGIN
    UPDATE vacunas
    SET Nombre_vacuna = @NombreVacuna,
        Descripcion = @Descripcion,
        Estado = @Estado,
        Fecha_aplicacion = @FechaAplicacion,
        Id_animal = @IdAnimal
    WHERE Id_vacuna = @IdVacuna;
END;

------------Procedimiento almacenado para buscar una vacuna por ID
CREATE PROCEDURE buscar_vacuna_id
    @IdVacuna INT
AS
BEGIN
    SELECT * FROM vacunas WHERE Id_vacuna = @IdVacuna;
END;

----------- Procedimiento almacenado para listar todas las vacunas----------------
CREATE PROCEDURE listar_vacunas
AS
BEGIN
    SELECT * FROM vacunas;
END;

------------------ Procedimiento almacenado para eliminar una vacu--na
CREATE PROCEDURE eliminar_vacuna
    @IdVacuna INT
AS
BEGIN
    DELETE FROM vacunas WHERE Id_vacuna = @IdVacuna;
END;







