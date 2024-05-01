USE AutoManagerDB;

-- Crear tabla Persona
CREATE TABLE Persona (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    CONSTRAINT UC_Persona UNIQUE (Nombre, Apellido)
);

-- Crear tabla Coche
CREATE TABLE Coche (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Marca NVARCHAR(100) NOT NULL,
    Modelo NVARCHAR(100) NOT NULL,
    VIN NVARCHAR(17) NOT NULL,
    CONSTRAINT UC_Coche UNIQUE (VIN)
);

-- Crear tabla PropietarioCoche
CREATE TABLE PropietarioCoche (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PersonaId INT,
    CocheId INT UNIQUE,
    CONSTRAINT FK_PropietarioCoche_Persona FOREIGN KEY (PersonaId) REFERENCES Persona(Id) ON DELETE CASCADE,
    CONSTRAINT FK_PropietarioCoche_Coche FOREIGN KEY (CocheId) REFERENCES Coche(Id) ON DELETE CASCADE,
    CONSTRAINT UC_PropietarioCoche UNIQUE (PersonaId, CocheId) 
);
