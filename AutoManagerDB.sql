USE AutoManagerDB;

-- Crear la taula Persona per emmagatzemar informació sobre les persones
CREATE TABLE Persona (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    CONSTRAINT UC_Persona UNIQUE (Nombre, Apellido) -- Restricció que garanteix noms únics (no es permeten duplicats)
);

-- Crear la taula Coche per emmagatzemar informació sobre els cotxes
CREATE TABLE Coche (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Marca NVARCHAR(100) NOT NULL,
    Modelo NVARCHAR(100) NOT NULL,
    VIN NVARCHAR(17) NOT NULL,
    CONSTRAINT UC_Coche UNIQUE (VIN) -- Restricció que garanteix VINs únics (no es permeten duplicats)
);

-- Crear la taula PropietarioCoche per emmagatzemar les relacions entre persones i cotxes
CREATE TABLE PropietarioCoche (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    PersonaId INT, 
    CocheId INT UNIQUE, -- Identificador del cotxe relacionat (unicitat assegurada)
    CONSTRAINT FK_PropietarioCoche_Persona FOREIGN KEY (PersonaId) REFERENCES Persona(Id) ON DELETE CASCADE, -- Restricció de clau externa que assegura la integritat referencial
    CONSTRAINT FK_PropietarioCoche_Coche FOREIGN KEY (CocheId) REFERENCES Coche(Id) ON DELETE CASCADE, -- Restricció de clau externa que assegura la integritat referencial
    CONSTRAINT UC_PropietarioCoche UNIQUE (PersonaId, CocheId)  -- Restricció que garanteix relacions úniques (no es permeten duplicats)
);
