CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Contraseña NVARCHAR(256),
    Rol NVARCHAR(50) -- Estudiante, Profesor, Coordinador
);

CREATE TABLE Proyectos (
    Id INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(200),
    Descripcion NVARCHAR(MAX),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    IdEstudiante INT FOREIGN KEY REFERENCES Usuarios(Id)
);
CREATE TABLE Comentarios (
    Id INT PRIMARY KEY IDENTITY,
    IdProyecto INT FOREIGN KEY REFERENCES Proyectos(Id),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(Id),
    Texto NVARCHAR(MAX),
    Fecha DATETIME DEFAULT GETDATE()
);

INSERT INTO Usuarios (Nombre, Email, Contraseña, Rol)
VALUES 
('Ana Rodríguez', 'ana.estudiante@ejemplo.com', '1234', 'Estudiante'),
('Carlos Méndez', 'carlos.profesor@ejemplo.com', '1234', 'Profesor'),
('Laura Gómez', 'laura.coordinador@ejemplo.com', '1324', 'Coordinador');

INSERT INTO Proyectos (Titulo, Descripcion, FechaCreacion, IdEstudiante)
VALUES (
    'Sistema de Gestión Académica',
    'Aplicación web para gestionar proyectos, entregas y observaciones en un entorno académico.',
    GETDATE(),
    1 -- Id del estudiante
)
Select * from Proyectos
SELECT Id, Rol FROM Usuarios WHERE Email = 'laura.coordinador@ejemplo.com' AND Contraseña = 1234