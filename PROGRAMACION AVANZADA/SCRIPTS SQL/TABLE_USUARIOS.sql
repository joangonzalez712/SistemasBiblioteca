CREATE TABLE Usuarios
(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(100) NOT NULL,

    Apellido VARCHAR(100) NOT NULL,

    Documento VARCHAR(20) NOT NULL UNIQUE,

    Telefono VARCHAR(20),

    Correo VARCHAR(100)
);
GO

