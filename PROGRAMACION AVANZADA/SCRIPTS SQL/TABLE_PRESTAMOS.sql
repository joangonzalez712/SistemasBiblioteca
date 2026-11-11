CREATE TABLE Prestamos
(
    IdPrestamo INT IDENTITY(1,1) PRIMARY KEY,

    IdUsuario INT NOT NULL,

    IdLibro INT NOT NULL,

    FechaPrestamo DATE NOT NULL,

    FechaDevolucion DATE NULL,

    Estado VARCHAR(20) NOT NULL,

    FOREIGN KEY (IdUsuario)
        REFERENCES Usuarios(IdUsuario),

    FOREIGN KEY (IdLibro)
        REFERENCES Libros(IdLibro),

    CHECK (Estado IN ('Prestado','Devuelto'))
);
GO


