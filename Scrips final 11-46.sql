CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Contrase�a NVARCHAR(256),
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

INSERT INTO Usuarios (Nombre, Email, Contrase�a, Rol)
VALUES 
('Ana Rodr�guez', 'ana.estudiante@ejemplo.com', '1234', 'Estudiante'),
('Carlos M�ndez', 'carlos.profesor@ejemplo.com', '1234', 'Profesor'),
('Laura G�mez', 'laura.coordinador@ejemplo.com', '1324', 'Coordinador');

INSERT INTO Proyectos (Titulo, Descripcion, FechaCreacion, IdEstudiante)
VALUES (
    'Sistema de Gesti�n Acad�mica',
    'Aplicaci�n web para gestionar proyectos, entregas y observaciones en un entorno acad�mico.',
    GETDATE(),
    1 -- Id del estudiante
)
Select * from Proyectos
SELECT Id, Rol FROM Usuarios WHERE Email = 'laura.coordinador@ejemplo.com' AND Contrase�a = 1234