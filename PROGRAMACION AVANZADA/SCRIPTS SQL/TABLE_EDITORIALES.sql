

CREATE TABLE Editoriales
(
    IdEditorial INT IDENTITY(1,1) PRIMARY KEY,

    Nombre VARCHAR(150) NOT NULL UNIQUE
);
