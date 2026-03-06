-- SQL Script to create the database tables for FoodCampus

-- Order of execution: 1. Restaurante, 2. Pedido, 3. DetallePedido

-- 1. Table: Restaurante
CREATE TABLE Restaurante (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Especialidad NVARCHAR(100) NULL,
    HorarioApertura TIME NOT NULL,
    HorarioCierre TIME NOT NULL,
    CONSTRAINT CK_Horario CHECK (HorarioCierre > HorarioApertura)
);

-- 2. Table: Pedido
CREATE TABLE Pedido (
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    IdRestaurante INT NOT NULL,
    IdUsuario INT NOT NULL,
    FechaHora DATETIME NOT NULL DEFAULT GETDATE(),
    CostoEnvio DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Pedido_Restaurante FOREIGN KEY (IdRestaurante) REFERENCES Restaurante(Id),
    CONSTRAINT CK_CostoEnvio CHECK (CostoEnvio >= 0)
);

-- 3. Table: DetallePedido
CREATE TABLE DetallePedido (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),
    IdPedido INT NOT NULL,
    IdPlatillo INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(18, 2) NOT NULL,
    CONSTRAINT FK_Detalle_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
    CONSTRAINT CK_Cantidad CHECK (Cantidad > 0)
);
