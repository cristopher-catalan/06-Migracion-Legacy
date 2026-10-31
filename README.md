# 06 — Laboratorio de Modernización de Aplicación Legacy

**Estado:** Laboratorio interactivo de modernización y pruebas de caracterización implementado en .NET 10 y ASP.NET Core con interfaz para ingenieros de software, playground de paridad funcional y control de cambios reversibles.

**Ejecución:**
```bash
dotnet run --project .\06-Migracion-Legacy\MigracionLegacy.csproj --urls http://localhost:5106
```
Contraseña de demostración: `Demo123!`. La persistencia usa EF Core InMemory por defecto; perfiles en `/api/auth/demo-users`.

---

## 🎯 Objetivo y Filosofía

Demostrar cómo analizar, refactorizar y modernizar sistemas empresariales C# monolíticos o heredados minimizando el riesgo operativo mediante:
1. **Pruebas de Caracterización:** Capturar el comportamiento real del sistema antes de tocar código.
2. **Paridad Funcional Verificable:** Validar que el motor modernizado devuelve idénticos resultados ante los mismos datos de entrada.
3. **Decisiones Reversibles:** Registrar cada cambio arquitectónico con su estrategia de rollback inmediato.

---

## 💻 Características del Panel Moderno

- **Theme de Ingeniería de Software:** Interfaz tipo terminal/consola oscura con acentos cian `#38bdf8` y ámbar `#fbbf24`, métricas de cobertura y barra de progreso de modernización.
- **Playground Interactivo de Caracterización:** Ejecución en tiempo real de suites de prueba (cálculo de totales, impuestos, validaciones de estado) con inspección de discrepancias y diff JSON.
- **Registro de Cambios Arquitectónicos:** Modal para documentar intervenciones técnicas, riesgo (Bajo/Medio/Alto) y procedimiento de reversión.
- **Catálogo de Solicitudes:** Búsqueda reactiva, filtros por estado (`BORRADOR`, `EN_REVISION`, `APROBADA`, `MIGRADA`) y visualización de payloads legados vs. modernos.
- **Sistema de Notificaciones Toast:** Feedback dinámico sin recargar la página.

---

## 🔌 Endpoints de la API

| Método | Endpoint | Descripción |
|---|---|---|
| `GET` | `/api/migration/status` | Resumen de avance de módulos, cobertura de pruebas y riesgos |
| `POST` | `/api/migration/changes` | Registrar cambio de arquitectura con plan de reversión |
| `POST` | `/api/characterization/run` | Ejecutar suite de pruebas de caracterización |
| `GET` | `/api/characterization/suite` | Obtener casos de prueba de referencia configurados |
| `GET` | `/api/requests` | Listar solicitudes heredadas y migradas |
| `POST` | `/api/requests` | Crear nueva solicitud en formato de transición |
| `GET` | `/api/requests/{id}` | Consultar detalle de solicitud |
| `PUT` | `/api/requests/{id}` | Actualizar datos y estado de solicitud |
| `GET` | `/api/legacy-mgmt/summary` | Estadísticas agregadas del pipeline de migración |

---

## 🛡️ Reglas de Seguridad y Buenas Prácticas

- **Vertical Slice Migration:** Nunca reescribir todo a la vez; modernizar un módulo vertical cada vez.
- **Sin Paridad No Hay Pase:** No se aprueba un despliegue sin suite de caracterización en verde.
- **Reversión Obligatoria:** Todo cambio en producción debe contar con script de deshecho probado.
- **Protección de Datos:** Se utilizan datos sintéticos conformes a GDPR/regulación de privacidad.
