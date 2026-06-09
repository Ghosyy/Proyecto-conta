-- =======================================================
-- SCRIPT MAESTRO: MODELO FÍSICO FINAL (ESTRUCTURA + DATOS)
-- =======================================================
USE PanaderiaIxtapan;
GO

-- 1. TABLAS
CREATE TABLE dbo.Catalogo_Cuentas (
    CodigoCuenta VARCHAR(20) PRIMARY KEY,
    NombreCuenta VARCHAR(100) NOT NULL,
    Clasificacion VARCHAR(50),
    AceptaMovimientos BIT DEFAULT 1
);

CREATE TABLE dbo.Inventario_Productos (
    Sku VARCHAR(20) PRIMARY KEY,
    Descripcion VARCHAR(100),
    TipoItem VARCHAR(50),
    CostoUnitario DECIMAL(18,2),
    PrecioVenta DECIMAL(18,2),
    Existencia DECIMAL(18,2)
);

CREATE TABLE dbo.Partidas (
    IdPartida INT IDENTITY(1,1) PRIMARY KEY,
    NumeroPartida INT,
    FechaTransaccion DATE,
    Descripcion VARCHAR(255),
    TipoPartida VARCHAR(50)
);

CREATE TABLE dbo.Detalle_Partidas (
    IdDetalle INT IDENTITY(1,1) PRIMARY KEY,
    IdPartida INT,
    CodigoCuenta VARCHAR(20),
    CargoDebe DECIMAL(18,2),
    AbonoHaber DECIMAL(18,2),
    FOREIGN KEY (IdPartida) REFERENCES dbo.Partidas(IdPartida),
    FOREIGN KEY (CodigoCuenta) REFERENCES dbo.Catalogo_Cuentas(CodigoCuenta)
);

CREATE TABLE dbo.Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto VARCHAR(100),
    Username VARCHAR(50),
    PasswordTexto VARCHAR(100),
    Rol VARCHAR(50),
    Activo BIT DEFAULT 1
);

-- 2. INYECCIÓN DE CATÁLOGO (24 CUENTAS)
INSERT INTO dbo.Catalogo_Cuentas (CodigoCuenta, NombreCuenta, Clasificacion, AceptaMovimientos) VALUES
('1', 'Activo', 'Activo', 0), ('1.1', 'Activo Corriente', 'Activo', 0), ('1.1.01', 'Caja', 'Activo', 1),
('1.1.02', 'Bancos', 'Activo', 1), ('1.1.03', 'Clientes', 'Activo', 1), ('1.1.04', 'IVA por Cobrar', 'Activo', 1),
('1.1.05', 'Inventario de Materia Prima', 'Activo', 1), ('1.1.06', 'Inventario de Producto Terminado', 'Activo', 1),
('2', 'Pasivo', 'Pasivo', 0), ('2.1', 'Pasivo Corriente', 'Pasivo', 0), ('2.1.01', 'Proveedores', 'Pasivo', 1),
('2.1.02', 'IVA por Pagar', 'Pasivo', 1), ('3', 'Capital', 'Capital', 0), ('3.1', 'Capital Contable', 'Capital', 0),
('3.1.01', 'Capital Social', 'Capital', 1), ('3.1.02', 'Utilidad o Pérdida del Ejercicio', 'Capital', 1),
('4', 'Ingresos', 'Ingreso', 0), ('4.1', 'Ingresos de Operación', 'Ingreso', 0), ('4.1.01', 'Ventas', 'Ingreso', 1),
('5', 'Egresos', 'Gasto', 0), ('5.1', 'Gastos de Operación', 'Gasto', 0), ('5.1.01', 'Energía Eléctrica', 'Gasto', 1),
('5.1.02', 'Sueldos', 'Gasto', 1), ('5.1.03', 'Alquileres', 'Gasto', 1);

-- 3. INYECCIÓN DE INVENTARIO INICIAL
INSERT INTO dbo.Inventario_Productos (Sku, Descripcion, TipoItem, CostoUnitario, PrecioVenta, Existencia) VALUES
('MAT-001', 'Harina Dura', 'Insumo', 350.00, 0.00, 20.00),
('MAT-002', 'Azúcar', 'Insumo', 400.00, 0.00, 10.00),
('PROD-001', 'Pan Francés', 'Producto', 0.50, 1.00, 500.00),
('PROD-002', 'Pan Dulce', 'Producto', 1.00, 2.50, 200.00);

-- 4. USUARIOS
INSERT INTO dbo.Usuarios (NombreCompleto, Username, PasswordTexto, Rol, Activo) VALUES
('Administrador del Sistema', 'admin', 'admin123', 'Administrador', 1),
('Contador General', 'contador', 'conta2026', 'Contador', 1);

PRINT 'Base de datos, catálogo y usuarios cargados. ¡Todo listo para el éxito!';