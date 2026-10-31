# 06 — Laboratorio de modernización de aplicación legacy

**Estado:** MVP local de laboratorio sintético implementado; no se asume ni modifica una aplicación legacy real.  

**Ejecución:** desde la raíz de Preparacion-7-Proyectos-Web-DotNet, ejecuta dotnet run --project .\06-Migracion-Legacy\MigracionLegacy.csproj y abre http://localhost:5106. Contraseña de demostración: Demo123!. La persistencia usa EF Core InMemory por defecto; los perfiles y roles están en /api/auth/demo-users.

**Objetivo:** demostrar cómo analizar, mantener y modernizar un sistema C# empresarial con riesgo controlado y cambios verificables.

## Enfoque

El proyecto se desarrollará en dos etapas futuras:

1. Crear una aplicación de referencia pequeña que represente un sistema legado de solicitudes/órdenes, con reglas documentadas y pruebas de comportamiento.
2. Modernizarla gradualmente hacia una aplicación soportada en .NET 10, ASP.NET Core MVC/Web API y SQL Server, manteniendo la compatibilidad funcional en cada paso.

La documentación deberá declarar qué partes son simuladas. No se presentará una migración real de un cliente o sistema ajeno.

## Alcance técnico

- Inventariar dependencias, módulos, tablas, integraciones y riesgos.
- Registrar el comportamiento actual mediante ejemplos de entrada/salida y pruebas de caracterización.
- Separar responsabilidades por módulos: presentación, aplicación, dominio e infraestructura, manteniendo el tamaño razonable para un proyecto junior.
- Migrar primero una función acotada, por ejemplo búsqueda y actualización de solicitudes.
- Sustituir acceso a datos heredado por EF Core en el módulo migrado, manteniendo consultas parametrizadas.
- Documentar decisiones, limitaciones, regresiones encontradas y reversión.
- Comparar contrato/API y resultados antes/después.

## Entregables futuros

- Diagrama de módulos y mapa de dependencias.
- Inventario de riesgos y plan de secuencia.
- Registro de decisiones técnicas.
- Pruebas de caracterización y regresión.
- Comparación de consultas/modelos y plan de migración de datos.
- API y pantallas para el módulo migrado.
- Guía de despliegue, reversión y soporte.

## Páginas y endpoints posibles

La API implementada incluye GET/POST /api/requests, GET/PUT /api/requests/{id}, GET /api/migration/status, POST /api/migration/changes y POST /api/characterization/run. El panel demo permite ejecutar ejemplos de estas operaciones.

## Reglas de migración

- No reemplazar todo de una vez: migrar un módulo vertical cada vez.
- Mantener respaldo antes de cambiar el esquema y documentar cómo volver atrás.
- Comparar datos y resultados con conteos y consultas conocidas.
- No copiar secretos ni datos personales reales; usar datos sintéticos.
- Mantener trazabilidad de cambios de esquema y de API.
- No llamar “migración” a una reescritura sin evidencia de paridad funcional.

## Criterios de aceptación

Un revisor puede identificar el comportamiento anterior, ejecutar las pruebas de referencia, revisar el módulo migrado y comprobar que sus resultados coinciden para los casos definidos. La guía explica cómo desplegar el cambio, detectar fallos y revertirlo.

## Implementación local actual

MVP disponible: ASP.NET Core + EF Core, panel interactivo y endpoints JSON descritos en el README raíz. El almacenamiento predeterminado es InMemory; SQL Server es configurable. La especificación de este documento sirve como alcance ampliado y backlog.

