namespace MigracionLegacy.UI.Components;

public static class CreateChangeModal
{
    public const string Html = """
    <div id="changeModal" class="modal-overlay">
        <div class="modal">
            <div class="modal-header">
                <h3 style="color:#fff; font-size:14px;">Registrar Decisión Arquitectural y Cambio</h3>
                <button type="button" class="btn btn-outline" onclick="closeModal('changeModal')">✕</button>
            </div>
            <form id="changeForm" onsubmit="handleCreateChange(event)">
                <div class="modal-body">
                    <div class="form-group">
                        <label for="changeModule">Módulo Afectado *</label>
                        <select id="changeModule" name="module" required>
                            <option value="Solicitudes y Órdenes">Solicitudes y Órdenes</option>
                            <option value="Persistencia EF Core">Persistencia EF Core</option>
                            <option value="Endpoints RESTful">Endpoints RESTful</option>
                            <option value="Base de Datos SQL">Base de Datos SQL</option>
                            <option value="Autenticación">Autenticación</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="changeDescription">Descripción del Cambio *</label>
                        <input id="changeDescription" name="change" required placeholder="Ej: Separar capa de aplicación e introducir DTOs">
                    </div>
                    <div class="form-group">
                        <label for="changeRisk">Nivel de Riesgo Evaluado *</label>
                        <select id="changeRisk" name="risk" required>
                            <option value="Bajo" selected>Bajo (Reversible de inmediato)</option>
                            <option value="Medio">Medio (Requiere validación de integración)</option>
                            <option value="Alto">Alto (Cambio estructural mayor)</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="changeRollback">Estrategia de Reversión (Rollback) *</label>
                        <input id="changeRollback" name="rollback" required placeholder="Ej: Revertir commit git y restaurar snapshot">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline" onclick="closeModal('changeModal')">Cancelar</button>
                    <button type="submit" class="btn btn-primary" id="btnSubmitChange">Registrar Decisión</button>
                </div>
            </form>
        </div>
    </div>

    <div id="createRequestModal" class="modal-overlay">
        <div class="modal">
            <div class="modal-header">
                <h3 style="color:#fff; font-size:14px;">Nueva Solicitud en Baseline Legado</h3>
                <button type="button" class="btn btn-outline" onclick="closeModal('createRequestModal')">✕</button>
            </div>
            <form id="createRequestForm" onsubmit="handleCreateRequest(event)">
                <div class="modal-body">
                    <div class="form-group">
                        <label for="reqTitle">Título de la Solicitud *</label>
                        <input id="reqTitle" name="title" required maxlength="180" placeholder="Ej: Actualizar datos de cliente">
                    </div>
                    <div class="form-group">
                        <label for="reqPriority">Prioridad</label>
                        <select id="reqPriority" name="priority">
                            <option value="Normal" selected>Normal</option>
                            <option value="Alta">Alta</option>
                            <option value="Baja">Baja</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="reqDescription">Descripción del Caso Sintético *</label>
                        <textarea id="reqDescription" name="description" rows="3" required placeholder="Describe las precondiciones y resultado esperado..."></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline" onclick="closeModal('createRequestModal')">Cancelar</button>
                    <button type="submit" class="btn btn-primary" id="btnSubmitReq">Registrar Solicitud</button>
                </div>
            </form>
        </div>
    </div>
    """;
}
