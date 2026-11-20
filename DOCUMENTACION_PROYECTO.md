# PausasActivasApp — Documentación Completa del Proyecto

Aplicación de escritorio desarrollada en **C# con Windows Forms sobre .NET 8**, diseñada para la gestión, control y ejecución interactiva de pausas activas en entornos laborales corporativos.

---

## 1. Arquitectura y Tecnologías

* **Plataforma:** .NET 8 (Windows Forms - SDK Style).
* **Motor de Base de Datos:** Microsoft SQL Server (Localhost / SQLEXPRESS).
* **Acceso a Datos:** ADO.NET puro con `Microsoft.Data.SqlClient` (consultas 100% parametrizadas, prevención de SQL Injection y gestión con bloques `using`).
* **Seguridad:** Encriptación de contraseñas mediante **SHA-256** (representación hexadecimal en mayúsculas de 64 caracteres, compatible con `HASHBYTES('SHA2_256', ...)` de SQL Server).
* **Diseño UI:** Componentes estándar WinForms organizados en vistas modulares (`UserControls`) y ventanas modales, compatibles con el diseñador visual de Visual Studio.

---

## 2. Estructura del Proyecto

```text
PausasActivasApp/
├── App.config                            # Cadena de conexión centralizada
├── Program.cs                            # Punto de entrada de la aplicación
├── PausasActivasApp.csproj               # Configuración de compilación y paquetes NuGet
│
├── Database/
│   └── schema_y_semilla.sql              # Script DDL + DML completo e idempotente
│
├── Modelos/                              # Clases POCO representativas de las tablas
│   ├── Usuario.cs
│   ├── Ejercicio.cs
│   ├── ConfiguracionPausa.cs
│   ├── RutinaEjercicio.cs
│   └── HistorialPausa.cs
│
├── Datos/                                # Capa de Acceso a Datos (DAL)
│   ├── Conexion.cs                       # Conexión centralizada y diagnóstico
│   ├── UsuarioDAL.cs                     # CRUD y autenticación de usuarios
│   ├── EjercicioDAL.cs                   # CRUD de ejercicios y recursos
│   ├── PausaDAL.cs                       # Gestión de configuraciones y rutinas
│   └── HistorialDAL.cs                   # Registro de eventos y consultas de auditoría
│
├── Utilidades/                           # Servicios transversales
│   ├── Seguridad.cs                      # Algoritmo de Hashing SHA-256
│   └── SesionActual.cs                   # Estado global en memoria del usuario activo
│
├── Recursos/
│   └── Imagenes/                         # GIFs animados y fotos demostrativas
│
└── Formularios/
    ├── FrmLogin.cs                       # Inicio de sesión y redirección por rol
    ├── Admin/                            # Módulo Administrador
    │   ├── FrmAdminPrincipal.cs          # Ventana maestra con navegación sidebar
    │   ├── UcEjercicios.cs               # Gestión de catálogo de ejercicios
    │   ├── FrmEjercicioDetalle.cs        # Modal de creación/edición con preview de GIFs
    │   ├── UcConfigPausas.cs             # Configuración de horarios y orden de rutinas
    │   ├── UcUsuarios.cs                 # Administración de cuentas y estados
    │   ├── FrmUsuarioDetalle.cs          # Modal de alta y edición de usuarios
    │   ├── FrmRestablecerPassword.cs     # Cambio asistido de claves
    │   └── UcReportes.cs                 # Métricas de cumplimiento y exportador CSV
    │
    └── Empleado/                         # Módulo Empleado
        ├── FrmEmpleadoBandeja.cs         # Agente silencioso en System Tray (NotifyIcon)
        └── FrmPausaActiva.cs             # Ventana emergente interactiva TopMost
```

---

## 3. Modelo de Datos (SQL Server)

Base de datos: `PausasActivasDB`

1. **`usuarios`**:
   * `id_usuario` (INT IDENTITY, PK)
   * `nombre` (NVARCHAR(100))
   * `usuario` (NVARCHAR(50), UNIQUE)
   * `password_hash` (NVARCHAR(64))
   * `rol` (NVARCHAR(10), CHECK: `'ADMIN'`, `'EMPLEADO'`)
   * `activo` (BIT)
   * `fecha_creacion` (DATETIME2)

2. **`ejercicios`**:
   * `id_ejercicio` (INT IDENTITY, PK)
   * `titulo` (NVARCHAR(150))
   * `descripcion` (NVARCHAR(MAX))
   * `duracion_segundos` (INT, CHECK > 0)
   * `imagen_ruta` (NVARCHAR(500), almacena ruta relativa a `Recursos/Imagenes/`)
   * `activo` (BIT)

3. **`configuracion_pausas`**:
   * `id_config` (INT IDENTITY, PK)
   * `intervalo_minutos` (INT, frecuencia en minutos)
   * `hora_inicio` (TIME(0), inicio jornada laboral)
   * `hora_fin` (TIME(0), fin jornada laboral)
   * `permitir_posponer` (BIT)
   * `minutos_posponer` (INT)
   * `activo` (BIT, solo una fila activa a la vez)
   * `ultima_actualizacion` (DATETIME2)

4. **`rutina_ejercicios`**:
   * `id_rutina` (INT IDENTITY, PK)
   * `id_config` (INT, FK -> configuracion_pausas ON DELETE CASCADE)
   * `id_ejercicio` (INT, FK -> ejercicios ON DELETE CASCADE)
   * `orden` (INT, posición secuencial en la rutina)
   * Restricción de unicidad: `UNIQUE(id_config, orden)`

5. **`historial_pausas`**:
   * `id_historial` (INT IDENTITY, PK)
   * `id_usuario` (INT, FK -> usuarios ON DELETE CASCADE)
   * `fecha_hora` (DATETIME2)
   * `estado` (NVARCHAR(12), CHECK: `'COMPLETADA'`, `'POSPUESTA'`, `'OMITIDA'`)
   * `duracion_total_segundos` (INT)

---

## 4. Funcionalidades del Sistema

### A. Autenticación y Control de Acceso
* Pantalla de Login única que valida credenciales hasheadas en SHA-256.
* Verificación de cuentas activas (`activo = 1`). Si la cuenta fue desactivada por un Administrador, deniega el acceso informando al usuario.
* Redirección automática según el rol (`ADMIN` -> Panel Maestro, `EMPLEADO` -> Bandeja del Sistema).

### B. Módulo Administrador (`ADMIN`)
* **Panel Maestro:** Navegación por barra lateral (sidebar oscuro) que carga submódulos en un contenedor dinámico sin abrir múltiples ventanas desordenadas.
* **Gestión de Ejercicios:** CRUD completo. Carga imágenes y archivos GIF animados copiándolos automáticamente al directorio del sistema con previsualización en vivo.
* **Configuración de Pausas y Rutinas:**
  * Parámetros operativos: intervalo de pausa, jornada laboral (hora inicio y fin) y opción de posponer.
  * Múltiples configuraciones permitidas con activación exclusiva.
  * Editor interactivo de rutinas con asignación y ordenamiento (`Agregar`, `Quitar`, `Subir`, `Bajar`) y cálculo en tiempo real de la duración total.
* **Gestión de Empleados:** Creación y modificación de usuarios, validación de nombres de usuario únicos, restricción de seguridad que impide al Administrador desactivar su propia cuenta en sesión y diálogo independiente para restablecer contraseñas.
* **Reportes y Auditoría:**
  * Filtros combinados por rango de fechas (`Desde` / `Hasta`), empleado y estado.
  * Tarjetas de resumen estadístico: Total de pausas, % Completadas, % Pospuestas, % Omitidas y Tiempo total invertido en salud.
  * Exportador nativo a formato **CSV compatible con Excel** con codificación UTF-8.

### C. Módulo Empleado (`EMPLEADO`)
* **Ejecución Silenciosa:** Al iniciar sesión, la aplicación se minimiza y oculta de la barra de tareas, ubicándose exclusivamente en la bandeja del sistema (`NotifyIcon` junto al reloj de Windows).
* **Menú Contextual Inteligente:** Muestra el tiempo restante en vivo para la próxima pausa, opción para iniciar la pausa inmediatamente, ver datos de sesión, cerrar sesión o salir.
* **Sincronización en Segundo Plano:** Timer periódico cada 60 segundos que consulta la BD para reflejar cambios en la configuración (intervalos, horarios o rutinas) sin requerir reinicio por parte del empleado.
* **Ventana Emergente (`FrmPausaActiva`):**
  * Se proyecta por encima de cualquier otra aplicación (`TopMost = true`).
  * Secuencia automática ejercicio por ejercicio con cuenta regresiva segundo a segundo.
  * Reproducción nativa de imágenes o GIFs demostrativos en bucle.
  * Botón opcional para posponer (si el Administrador lo habilitó).
  * Registro automático en `historial_pausas` con el tiempo exacto ejecutado (`COMPLETADA`, `POSPUESTA` u `OMITIDA`).

---

## 5. Guía de Instalación y Puesta en Marcha

### Requisitos Previos
1. Visual Studio 2022 con soporte para cargas de trabajo de escritorio .NET.
2. SDK de .NET 8.
3. Microsoft SQL Server (LocalDB, Express o superior).

### Pasos de Configuración
1. **Creación de la Base de Datos:**
   * Abrir SQL Server Management Studio (SSMS) o Azure Data Studio conectado a `localhost` (Windows Authentication).
   * Abrir y ejecutar el archivo: `PausasActivasApp/Database/schema_y_semilla.sql`.
2. **Revisión de Conexión:**
   * Verificar en `PausasActivasApp/App.config` que la cadena apunte a tu instancia:
     ```xml
     <add name="PausasActivasDB"
          connectionString="Server=localhost;Database=PausasActivasDB;Integrated Security=True;TrustServerCertificate=True;"
          providerName="Microsoft.Data.SqlClient" />
     ```
3. **Compilación y Ejecución:**
   * Abrir la solución o carpeta en Visual Studio 2022.
   * Restaurar paquetes NuGet (`dotnet restore`).
   * Compilar (`Ctrl+Shift+B`) y presionar `F5`.

### Credenciales Semilla de Prueba
* **Administrador:**
  * Usuario: `admin_pa`
  * Contraseña: `admin123`
* **Empleado:**
  * Usuario: `jperez`
  * Contraseña: `empleado1`
