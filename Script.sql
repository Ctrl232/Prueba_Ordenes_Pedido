--Se adjunta diseño de las tablas
--Tabla de Clientes
CREATE TABLE Cliente (
    IdCliente INT PRIMARY KEY IDENTITY(1,1),    
    Identificacion VARCHAR(50) NOT NULL,        
    Nombre VARCHAR(100) NOT NULL,                
    Direccion VARCHAR(200) NOT NULL              
);

--Tabla de Productos
CREATE TABLE Producto (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),    
    Codigo VARCHAR(50) NOT NULL,                
    Nombre VARCHAR(100) NOT NULL,               
    ValorUnitario DECIMAL(18, 2) NOT NULL        
);

--Tabla de Ordenes de Pedido
CREATE TABLE OrdenPedido (
    IdOrden INT PRIMARY KEY IDENTITY(1,1),      
    IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),  
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(), 
    Estado VARCHAR(20) NOT NULL CHECK (Estado IN ('Registrado', 'Confirmado', 'Anulado')),  
    DireccionEntrega VARCHAR(200) NOT NULL,     
    Prioridad VARCHAR(20) NOT NULL,              
    ValorTotal DECIMAL(18, 2) NOT NULL          
);

--Tabla de Detalles de la Orden
CREATE TABLE OrdenDetalle (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),   
    IdOrden INT FOREIGN KEY REFERENCES OrdenPedido(IdOrden), 
    IdProducto INT FOREIGN KEY REFERENCES Producto(IdProducto),  
    Cantidad INT NOT NULL CHECK (Cantidad > 0),  
    ValorUnitario DECIMAL(18, 2) NOT NULL,        
    ValorParcial AS (Cantidad * ValorUnitario) PERSISTED
);



