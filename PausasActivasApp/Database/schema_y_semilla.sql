-- ============================================================
--  PausasActivasDB — Script completo de creación y semilla
--  Motor    : SQL Server (Express / LocalDB / Developer)
--  Proyecto : PausasActivasApp (.NET 8 — Windows Forms)
--  Fase     : 1
-- ============================================================

-- ─────────────────────────────────────────────
-- 0. Crear la base de datos si no existe
-- ─────────────────────────────────────────────
USE master;
GO

IF NOT EXISTS (
    SELECT name FROM sys.databases WHERE name = N'PausasActivasDB'
)
BEGIN
    CREATE DATABASE PausasActivasDB;
END
GO

USE PausasActivasDB;
GO

-- ─────────────────────────────────────────────
-- 1. Tabla: usuarios
--    Almacena tanto administradores como empleados.
--    rol acepta únicamente 'ADMIN' o 'EMPLEADO'.
-- ─────────────────────────────────────────────
IF OBJECT_ID('dbo.usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.usuarios (
        id_usuario      INT             NOT NULL IDENTITY(1,1),
        nombre          NVARCHAR(100)   NOT NULL,
        usuario         NVARCHAR(50)    NOT NULL,
        password_hash   NVARCHAR(64)    NOT NULL,   -- SHA-256 → 64 hex chars
        rol             NVARCHAR(10)    NOT NULL
                            CONSTRAINT chk_rol CHECK (rol IN ('ADMIN','EMPLEADO')),
        activo          BIT             NOT NULL DEFAULT 1,
        fecha_creacion  DATETIME2       NOT NULL DEFAULT SYSUTCDATETIME(),

        CONSTRAINT pk_usuarios          PRIMARY KEY (id_usuario),
        CONSTRAINT uq_usuarios_usuario  UNIQUE      (usuario)
    );
END
GO

-- ─────────────────────────────────────────────
-- 2. Tabla: ejercicios
--    imagen_ruta guarda la ruta relativa desde
--    la raíz del proyecto, p. ej.:
--    "Recursos/Imagenes/estiramiento_cuello.gif"
-- ─────────────────────────────────────────────
IF OBJECT_ID('dbo.ejercicios', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.ejercicios (
        id_ejercicio        INT             NOT NULL IDENTITY(1,1),
        titulo              NVARCHAR(150)   NOT NULL,
        descripcion         NVARCHAR(MAX)   NOT NULL,
        duracion_segundos   INT             NOT NULL
                                CONSTRAINT chk_duracion CHECK (duracion_segundos > 0),
        imagen_ruta         NVARCHAR(500)   NULL,     -- NULL si no tiene imagen
        activo              BIT             NOT NULL DEFAULT 1,

        CONSTRAINT pk_ejercicios PRIMARY KEY (id_ejercicio)
    );
END
GO

-- ─────────────────────────────────────────────
-- 3. Tabla: configuracion_pausas
--    Solo se espera UNA fila activa (id_config=1).
--    intervalo_minutos : frecuencia de pausa.
--    hora_inicio/fin   : jornada laboral activa.
--    permitir_posponer : habilita el botón Posponer.
--    minutos_posponer  : minutos que retrasa la pausa.
-- ─────────────────────────────────────────────
IF OBJECT_ID('dbo.configuracion_pausas', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.configuracion_pausas (
        id_config           INT         NOT NULL IDENTITY(1,1),
        intervalo_minutos   INT         NOT NULL DEFAULT 60
                                CONSTRAINT chk_intervalo CHECK (intervalo_minutos >= 1),
        hora_inicio         TIME(0)     NOT NULL DEFAULT '08:00:00',
        hora_fin            TIME(0)     NOT NULL DEFAULT '17:00:00',
        permitir_posponer   BIT         NOT NULL DEFAULT 1,
        minutos_posponer    INT         NOT NULL DEFAULT 10
                                CONSTRAINT chk_posponer CHECK (minutos_posponer >= 1),
        activo              BIT         NOT NULL DEFAULT 1,
        ultima_actualizacion DATETIME2  NOT NULL DEFAULT SYSUTCDATETIME(),

        CONSTRAINT pk_configuracion PRIMARY KEY (id_config)
    );
END
GO

-- ─────────────────────────────────────────────
-- 4. Tabla: rutina_ejercicios
--    Define qué ejercicios forman la rutina de
--    una configuración y en qué orden se ejecutan.
-- ─────────────────────────────────────────────
IF OBJECT_ID('dbo.rutina_ejercicios', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.rutina_ejercicios (
        id_rutina       INT NOT NULL IDENTITY(1,1),
        id_config       INT NOT NULL,
        id_ejercicio    INT NOT NULL,
        orden           INT NOT NULL,   -- 1 = primero

        CONSTRAINT pk_rutina            PRIMARY KEY (id_rutina),
        CONSTRAINT uq_rutina_orden      UNIQUE (id_config, orden),
        CONSTRAINT fk_rutina_config     FOREIGN KEY (id_config)
                                            REFERENCES dbo.configuracion_pausas (id_config)
                                            ON DELETE CASCADE,
        CONSTRAINT fk_rutina_ejercicio  FOREIGN KEY (id_ejercicio)
                                            REFERENCES dbo.ejercicios (id_ejercicio)
                                            ON DELETE CASCADE
    );
END
GO

-- ─────────────────────────────────────────────
-- 5. Tabla: historial_pausas
--    Registra cada evento de pausa por empleado.
--    estado acepta: 'COMPLETADA', 'POSPUESTA', 'OMITIDA'
-- ─────────────────────────────────────────────
IF OBJECT_ID('dbo.historial_pausas', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.historial_pausas (
        id_historial            INT             NOT NULL IDENTITY(1,1),
        id_usuario              INT             NOT NULL,
        fecha_hora              DATETIME2       NOT NULL DEFAULT SYSUTCDATETIME(),
        estado                  NVARCHAR(12)    NOT NULL
                                    CONSTRAINT chk_estado CHECK (estado IN ('COMPLETADA','POSPUESTA','OMITIDA')),
        duracion_total_segundos INT             NOT NULL DEFAULT 0,

        CONSTRAINT pk_historial         PRIMARY KEY (id_historial),
        CONSTRAINT fk_historial_usuario FOREIGN KEY (id_usuario)
                                            REFERENCES dbo.usuarios (id_usuario)
                                            ON DELETE CASCADE
    );
END
GO

-- ─────────────────────────────────────────────
-- 6. Índices de apoyo para consultas frecuentes
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'ix_historial_usuario_fecha')
    CREATE NONCLUSTERED INDEX ix_historial_usuario_fecha
        ON dbo.historial_pausas (id_usuario, fecha_hora DESC);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'ix_rutina_config_orden')
    CREATE NONCLUSTERED INDEX ix_rutina_config_orden
        ON dbo.rutina_ejercicios (id_config, orden);
GO

-- ============================================================
--  DATOS SEMILLA
--  Contraseñas (SHA-256 en MAYÚSCULAS):
--    admin123  → 240BE518FABD2724DDB6F04EEB1DA5967448D7E831186905CF49A4D2B4B9C4A1  (NOTA: calcular real abajo)
--    empleado1 → se calcula en la app; aquí usamos los hashes reales.
--
--  Hash real de "admin123"   (SHA-256):
--    240BE518FABD2724DDB6F04EEB1DA5967448D7E831186905CF49A4D2B4B9C4A1  ← INCORRECTO de ejemplo
--  Usamos los valores correctos calculados externamente:
--    "admin123"    → 240BE518FABD2724DDB6F04EEB1DA5967448D7E831186905CF49A4D2B4B9C4A1
--  IMPORTANTE: en Fase 2 la clase Seguridad.cs calculará el hash real.
--  Los hashes de abajo son los CORRECTOS para las contraseñas indicadas.
-- ============================================================

-- ─────────────────────────────────────────────
-- 6.1 Usuarios semilla
--     Contraseñas en texto plano (solo referencia):
--       admin_pa   → "admin123"
--       empleado1  → "empleado1"
--     Hashes SHA-256 (UTF-8, uppercase hex):
--       "admin123"   = 240BE518FABD2724DDB6F04EEB1DA5967448D7E831186905CF49A4D2B4B9C4A1
--                      ← VERIFICAR con: SELECT CONVERT(VARCHAR(64),HASHBYTES('SHA2_256','admin123'),2)
--       "empleado1"  = 2b4c9b4b8e8a3f4c0d1e2f3a4b5c6d7e8f9a0b1c2d3e4f5a6b7c8d9e0f1a2b3  ← placeholder
-- ─────────────────────────────────────────────

-- Hash correcto calculado por SQL Server:
-- EXEC sp_executesql N'SELECT CONVERT(VARCHAR(64),HASHBYTES(''SHA2_256'',''admin123''),2)'
-- Para que el script sea autocontenido usamos HASHBYTES directamente:

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE usuario = 'admin_pa')
BEGIN
    INSERT INTO dbo.usuarios (nombre, usuario, password_hash, rol, activo)
    VALUES (
        'Administrador Principal',
        'admin_pa',
        CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2),  -- hash en tiempo de ejecución
        'ADMIN',
        1
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE usuario = 'jperez')
BEGIN
    INSERT INTO dbo.usuarios (nombre, usuario, password_hash, rol, activo)
    VALUES (
        'Juan Pérez',
        'jperez',
        CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'empleado1'), 2),
        'EMPLEADO',
        1
    );
END
GO

-- ─────────────────────────────────────────────
-- 6.2 Ejercicios semilla (3 ejercicios de prueba
--     con duraciones cortas para facilitar testing)
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM dbo.ejercicios WHERE titulo = 'Estiramiento de cuello')
BEGIN
    INSERT INTO dbo.ejercicios (titulo, descripcion, duracion_segundos, imagen_ruta, activo)
    VALUES (
        'Estiramiento de cuello',
        '1. Siéntate derecho con la espalda apoyada.' + CHAR(13)+CHAR(10) +
        '2. Inclina lentamente la cabeza hacia la derecha, acercando la oreja al hombro.' + CHAR(13)+CHAR(10) +
        '3. Mantén 5 segundos y regresa al centro.' + CHAR(13)+CHAR(10) +
        '4. Repite hacia el lado izquierdo.' + CHAR(13)+CHAR(10) +
        '5. Realiza 3 repeticiones por cada lado.',
        20,          -- 20 segundos para pruebas
        NULL,        -- sin imagen inicial; se asigna desde el CRUD
        1
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.ejercicios WHERE titulo = 'Rotación de hombros')
BEGIN
    INSERT INTO dbo.ejercicios (titulo, descripcion, duracion_segundos, imagen_ruta, activo)
    VALUES (
        'Rotación de hombros',
        '1. Mantente sentado o de pie con los brazos relajados a los costados.' + CHAR(13)+CHAR(10) +
        '2. Eleva los hombros hacia las orejas y dibuja círculos hacia atrás.' + CHAR(13)+CHAR(10) +
        '3. Realiza 5 rotaciones hacia atrás.' + CHAR(13)+CHAR(10) +
        '4. Luego 5 rotaciones hacia adelante.' + CHAR(13)+CHAR(10) +
        '5. Mantén la respiración pausada durante todo el ejercicio.',
        15,
        NULL,
        1
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.ejercicios WHERE titulo = 'Estiramiento de muñecas')
BEGIN
    INSERT INTO dbo.ejercicios (titulo, descripcion, duracion_segundos, imagen_ruta, activo)
    VALUES (
        'Estiramiento de muñecas',
        '1. Extiende el brazo derecho al frente con la palma mirando hacia arriba.' + CHAR(13)+CHAR(10) +
        '2. Con la mano izquierda, jala suavemente los dedos hacia abajo.' + CHAR(13)+CHAR(10) +
        '3. Mantén el estiramiento 10 segundos.' + CHAR(13)+CHAR(10) +
        '4. Cambia de mano y repite.' + CHAR(13)+CHAR(10) +
        '5. Luego gira ambas muñecas en círculos, 5 veces en cada dirección.',
        25,
        NULL,
        1
    );
END
GO

-- ─────────────────────────────────────────────
-- 6.3 Configuración de pausas semilla
--     Intervalo de 2 minutos para facilitar pruebas.
--     En producción el Admin lo cambia desde la UI.
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM dbo.configuracion_pausas)
BEGIN
    INSERT INTO dbo.configuracion_pausas
        (intervalo_minutos, hora_inicio, hora_fin, permitir_posponer, minutos_posponer, activo)
    VALUES
        (2, '08:00:00', '17:00:00', 1, 5, 1);
        -- ↑ 2 min para pruebas → cambiar a 60 en producción
END
GO

-- ─────────────────────────────────────────────
-- 6.4 Rutina semilla: los 3 ejercicios en orden
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM dbo.rutina_ejercicios)
BEGIN
    -- Tomamos los IDs dinámicamente para no hardcodear
    INSERT INTO dbo.rutina_ejercicios (id_config, id_ejercicio, orden)
    SELECT
        c.id_config,
        e.id_ejercicio,
        ROW_NUMBER() OVER (ORDER BY e.id_ejercicio) AS orden
    FROM dbo.configuracion_pausas c
    CROSS JOIN dbo.ejercicios e
    WHERE c.id_config = 1
      AND e.activo = 1;
END
GO

-- ============================================================
--  VERIFICACIÓN RÁPIDA
--  Ejecuta este bloque después del script para confirmar
--  que todo quedó creado correctamente.
-- ============================================================
SELECT 'usuarios'              AS tabla, COUNT(*) AS filas FROM dbo.usuarios           UNION ALL
SELECT 'ejercicios'            AS tabla, COUNT(*) AS filas FROM dbo.ejercicios          UNION ALL
SELECT 'configuracion_pausas'  AS tabla, COUNT(*) AS filas FROM dbo.configuracion_pausas UNION ALL
SELECT 'rutina_ejercicios'     AS tabla, COUNT(*) AS filas FROM dbo.rutina_ejercicios   UNION ALL
SELECT 'historial_pausas'      AS tabla, COUNT(*) AS filas FROM dbo.historial_pausas;
GO

-- ============================================================
--  Credenciales de acceso para pruebas:
--
--    ROL ADMIN    → usuario: admin_pa   / contraseña: admin123
--    ROL EMPLEADO → usuario: jperez     / contraseña: empleado1
-- ============================================================
