CREATE TABLE Libros
(
    IdLibro INT IDENTITY(1,1) PRIMARY KEY,

    Codigo VARCHAR(20) NOT NULL UNIQUE,

    ISBN VARCHAR(20) NOT NULL UNIQUE,

    Titulo VARCHAR(200) NOT NULL,

    Stock INT NOT NULL CHECK (Stock >= 0),

    IdAutor INT NOT NULL,

    IdEditorial INT NOT NULL,

    FOREIGN KEY (IdAutor)
        REFERENCES Autores(IdAutor),

    FOREIGN KEY (IdEditorial)
        REFERENCES Editoriales(IdEditorial)
);




