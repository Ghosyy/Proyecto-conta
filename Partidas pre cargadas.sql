-- 1. LIMPIEZA DE DATOS (Orden correcto para no romper las llaves foráneas)
DELETE FROM Detalle_Partidas;
DELETE FROM Partidas;

-- 2. INSERCIÓN DE 25 PARTIDAS (Copia y pega este bloque)
-- NOTA: Este script inserta la cabecera y el detalle de una vez.
-- Asumo que tu base de datos tiene IDENTITY en IdPartida, si no, debes ajustar los IDs.

-- TRANSACTIONS 1-5: Constitución y Compras iniciales
INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (1, '2026-06-01', 'Aporte Capital Inicial', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '1.1.01', 50000, 0), (SCOPE_IDENTITY(), '3.1.01', 0, 50000);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (2, '2026-06-02', 'Compra Harina al contado', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '1.1.05', 5000, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 5000);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (3, '2026-06-03', 'Compra Azúcar al contado', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '1.1.05', 3000, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 3000);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (4, '2026-06-04', 'Pago de Renta del local', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '6.1.03', 2500, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 2500);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (5, '2026-06-05', 'Compra Levadura', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '1.1.05', 1500, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 1500);

-- TRANSACTIONS 6-20: Ventas diarias (Representando rotación de panadería)
-- He simplificado estos bloques para que tengas 15 ventas rápidas
DECLARE @i INT = 6;
WHILE @i <= 20
BEGIN
    INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (@i, '2026-06-06', 'Venta Panadería #'+CAST(@i AS VARCHAR), 'Diario');
    INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '1.1.01', 1200, 0), (SCOPE_IDENTITY(), '4.1.01', 0, 1200);
    SET @i = @i + 1;
END

-- TRANSACTIONS 21-24: Gastos y otros
INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (21, '2026-06-07', 'Pago Recibo Luz', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '6.1.03', 400, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 400);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (22, '2026-06-07', 'Pago Recibo Agua', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '6.1.03', 150, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 150);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (23, '2026-06-07', 'Pago Teléfono/Internet', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '6.1.03', 300, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 300);

INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (24, '2026-06-07', 'Pago Fletes', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '6.1.03', 600, 0), (SCOPE_IDENTITY(), '1.1.01', 0, 600);

-- TRANSACTION 25: Regularización IVA (La que cierra el ciclo)
INSERT INTO Partidas (NumeroPartida, FechaTransaccion, Descripcion, TipoPartida) VALUES (25, '2026-06-07', 'Regularización IVA', 'Diario');
INSERT INTO Detalle_Partidas (IdPartida, CodigoCuenta, CargoDebe, AbonoHaber) VALUES (SCOPE_IDENTITY(), '2.1.02', 150, 0), (SCOPE_IDENTITY(), '1.1.04', 0, 150);

PRINT 'Base de datos limpia y 25 partidas cargadas exitosamente.';