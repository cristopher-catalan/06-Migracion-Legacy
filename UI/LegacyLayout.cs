using MigracionLegacy.UI.Components;

namespace MigracionLegacy.UI;

public static class LegacyLayout
{
    public static string Render()
    {
        return $$"""
        <!doctype html>
        <html lang="es">
        <head>
            <meta charset="utf-8">
            <meta name="viewport" content="width=device-width, initial-scale=1">
            <title>Migración legacy - Modernización con evidencia</title>
            <style>
            {{LegacyStyles.Css}}
            </style>
        </head>
        <body class="app-legacy">
            <header class="top">
                <div class="brand">
                    <span class="mark">&gt;_</span>
                    <div>
                        <h1>Migration Lab &amp; Sandbox</h1>
                        <p>Modernización de software legado, pruebas de caracterización y reversión</p>
                    </div>
                </div>
                <div class="top-right">
                    <span style="font-size:11px; font-weight:700; color:var(--primary); background:#183421; padding:5px 12px; border-radius:50px;" id="currentSessionTag">Sesión no iniciada</span>
                </div>
            </header>

            <main class="page">
                <!-- Session Selector -->
                <section class="session-bar">
                    <form id="loginForm" class="login-controls" onsubmit="handleLogin(event)">
                        <div class="input-group">
                            <label for="selectUser">Perfil Demo</label>
                            <select id="selectUser" required></select>
                        </div>
                        <div class="input-group">
                            <label for="inputPassword">Contraseña</label>
                            <input id="inputPassword" type="password" value="Demo123!" autocomplete="current-password" required>
                        </div>
                        <button type="submit" class="btn btn-primary" style="margin-top:16px;">Iniciar sesión</button>
                        <button type="button" class="btn btn-outline" onclick="handleLogout()" style="margin-top:16px;">Salir</button>
                    </form>
                    <div id="sessionMessage" style="font-size:11px; color:var(--muted);">Inicia sesión como developer o auditor.</div>
                </section>

                <!-- Legacy Hero -->
                <section class="legacy-hero">
                    <div>
                        <small>MIGRATION LAB / SANDBOX</small>
                        <h2>Moderniza con evidencia.</h2>
                        <p>Pruebas de caracterización automatizadas, refactorización controlada y trazabilidad de decisiones con estrategia de reversión (*rollback*).</p>
                    </div>
                    <div style="display:flex; gap:10px;">
                        <button type="button" class="btn btn-primary" onclick="openModal('createRequestModal')">＋ Nueva Solicitud</button>
                        <button type="button" class="btn btn-primary" onclick="openModal('changeModal')">＋ Registrar Decisión</button>
                    </div>
                </section>

                <!-- Terminal Baseline -->
                <section class="terminal">
                    <div class="terminal-top">
                        <span class="terminal-dot" style="background:#ef4444;"></span>
                        <span class="terminal-dot" style="background:#eab308;"></span>
                        <span class="terminal-dot" style="background:#22c55e;"></span>
                        <span style="margin-left:8px; font-weight:700;">baseline-check.cs (Paridad Funcional)</span>
                    </div>
                    <div class="terminal-code">
                        01&nbsp; var legacyOutput = entrada.Trim().ToUpperInvariant();<br>
                        02&nbsp; var modernOutput = entrada.Trim().ToUpperInvariant();<br>
                        03&nbsp; Assert.True(legacyOutput == modernOutput);<br>
                        04&nbsp; <b id="metric-a">—</b> solicitudes en baseline de pruebas
                    </div>
                </section>

                <!-- Live Playground -->
                {{CharacterizationPlayground.Html}}

                <!-- Main Grid: Requests & Architecture Changes -->
                <section class="main-grid">
                    <!-- Left: Synthetic Requests Table -->
                    <article class="panel">
                        <div class="panel-header">
                            <div>
                                <small style="font-size:10px; font-weight:700; color:var(--primary); text-transform:uppercase;">Baseline Sintético</small>
                                <h3>Solicitudes de Referencia</h3>
                            </div>
                            <button type="button" class="btn btn-outline" onclick="loadLegacyData()" style="font-size:11px;">🔄 Consultar</button>
                        </div>
                        <div style="overflow-x:auto;">
                            <table style="width:100%; border-collapse:collapse; font-size:12px;">
                                <thead>
                                    <tr style="border-bottom:1px solid var(--panel-border); text-align:left; color:var(--muted);">
                                        <th style="padding:8px;">Referencia</th>
                                        <th style="padding:8px;">Solicitud</th>
                                        <th style="padding:8px;">Prioridad</th>
                                        <th style="padding:8px;">Estado</th>
                                        <th style="padding:8px; text-align:right;">Acción</th>
                                    </tr>
                                </thead>
                                <tbody id="requestsTbody">
                                    <tr><td colspan="5" style="text-align:center; padding:20px; color:var(--muted);">Inicia sesión para cargar solicitudes.</td></tr>
                                </tbody>
                            </table>
                        </div>
                    </article>

                    <!-- Right: Changes Log -->
                    <aside class="panel">
                        <div class="panel-header">
                            <div>
                                <small style="font-size:10px; font-weight:700; color:var(--primary); text-transform:uppercase;">Trazabilidad</small>
                                <h3>Registro de Cambios y Rollback</h3>
                            </div>
                        </div>
                        <div id="changesListContainer" style="display:flex; flex-direction:column; gap:10px;">
                            <div style="font-size:11px; color:var(--muted); font-style:italic;">Cargando registro de cambios...</div>
                        </div>
                    </aside>
                </section>

                <!-- Hidden elements for test script compatibility -->
                <div style="display:none;">
                    <div id="primary-list"></div>
                    <div id="secondary-list"></div>
                </div>
            </main>

            <!-- Modals -->
            {{CreateChangeModal.Html}}

            <!-- Toast Container -->
            {{ToastSystem.Html}}

            <script>
            const byId = id => document.getElementById(id);
            const esc = v => String(v ?? "").replace(/&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/"/g,"&quot;").replace(/'/g,"&#39;");
            function formatDate(dt) {
                if (!dt) return "—";
                try {
                    const d = new Date(dt);
                    return d.toLocaleDateString('es-PE', { day:'2-digit', month:'short', hour:'2-digit', minute:'2-digit' });
                } catch { return dt; }
            }

            let currentUser = null;
            let currentRole = null;
            let requestsCache = [];

            {{ToastSystem.Script}}
            {{CharacterizationPlayground.Script}}

            function openModal(id) { byId(id).classList.add('open'); }
            function closeModal(id) { byId(id).classList.remove('open'); }

            async function init() {
                try {
                    const r = await fetch('/api/auth/demo-users');
                    const users = await r.json();
                    byId('selectUser').innerHTML = users.map(u => 
                        `<option value="${esc(u.username)}">${esc(u.label)} (${esc(u.username)}) · ${esc(u.role)}</option>`
                    ).join('');

                    const me = await fetch('/api/auth/me');
                    if (me.ok) {
                        const info = await me.json();
                        currentUser = info.username;
                        currentRole = info.role;
                        updateSessionUI();
                        await loadLegacyData();
                    }
                } catch {
                    showToast('Error conectando con el servidor', 'error');
                }
            }

            function updateSessionUI() {
                if (currentUser) {
                    byId('currentSessionTag').textContent = `${currentUser} [${currentRole}]`;
                    byId('sessionMessage').textContent = `Conectado como ${currentUser} [${currentRole}]`;
                    byId('sessionMessage').style.color = 'var(--primary)';
                    byId('selectUser').value = currentUser;
                } else {
                    byId('currentSessionTag').textContent = 'Sesión no iniciada';
                    byId('sessionMessage').textContent = 'Inicia sesión como developer o auditor.';
                    byId('sessionMessage').style.color = 'var(--muted)';
                }
            }

            async function handleLogin(e) {
                e.preventDefault();
                const username = byId('selectUser').value;
                const password = byId('inputPassword').value;
                try {
                    const r = await fetch('/api/auth/login', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ username, password })
                    });
                    if (r.ok) {
                        const d = await r.json();
                        currentUser = d.username;
                        currentRole = d.role;
                        updateSessionUI();
                        showToast(`Bienvenido/a ${currentUser}`, 'success');
                        await loadLegacyData();
                    } else {
                        showToast('Credenciales incorrectas.', 'error');
                    }
                } catch {
                    showToast('Fallo al conectar', 'error');
                }
            }

            async function handleLogout() {
                await fetch('/api/auth/logout', { method: 'POST' });
                currentUser = null;
                currentRole = null;
                updateSessionUI();
                requestsCache = [];
                renderRequestsTable([]);
                renderChangesList([]);
                byId('metric-a').textContent = '—';
                showToast('Sesión finalizada', 'info');
            }

            async function loadLegacyData() {
                try {
                    // 1. Requests
                    const r = await fetch('/api/requests');
                    if (r.ok) {
                        const d = await r.json();
                        requestsCache = d.items || [];
                        renderRequestsTable(requestsCache);
                        byId('metric-a').textContent = requestsCache.length;
                    }

                    // 2. Migration status & changes
                    const mResp = await fetch('/api/migration/status');
                    if (mResp.ok) {
                        const mData = await mResp.json();
                        renderChangesList(mData.changes || []);
                    }
                } catch (e) {
                    console.error(e);
                }
            }

            function renderRequestsTable(items) {
                const tbody = byId('requestsTbody');
                if (!items || items.length === 0) {
                    tbody.innerHTML = '<tr><td colspan="5" style="text-align:center; padding:20px; color:var(--muted);">Baseline vacío o sin solicitudes.</td></tr>';
                    return;
                }

                tbody.innerHTML = items.map(req => {
                    const sCls = req.state === 'Resuelta' ? 'tag-resuelta' : (req.state === 'En proceso' ? 'tag-proceso' : 'tag-abierta');
                    return `
                    <tr style="border-bottom:1px solid #16241a;">
                        <td style="padding:10px; font-weight:700; color:var(--primary);">${esc(req.number)}</td>
                        <td style="padding:10px;">
                            <strong>${esc(req.title)}</strong>
                            <div style="font-size:10px; color:var(--muted);">${esc(req.description)}</div>
                        </td>
                        <td style="padding:10px;">${esc(req.priority)}</td>
                        <td style="padding:10px;"><span class="tag ${sCls}">${esc(req.state)}</span></td>
                        <td style="padding:10px; text-align:right;">
                            <button type="button" class="btn btn-outline" onclick="handleEditRequest(${req.id}, '${esc(req.title)}', '${esc(req.description)}', '${esc(req.state)}', '${esc(req.priority)}')" style="font-size:10px; padding:4px 8px;">
                                Editar
                            </button>
                        </td>
                    </tr>
                    `;
                }).join('');
            }

            function renderChangesList(changes) {
                const container = byId('changesListContainer');
                if (!changes || changes.length === 0) {
                    container.innerHTML = '<div style="font-size:11px; color:var(--muted); font-style:italic;">Sin decisiones de migración registradas.</div>';
                    return;
                }

                container.innerHTML = changes.map(c => {
                    const rCls = c.risk === 'Alto' ? 'tag-risk-alto' : (c.risk === 'Medio' ? 'tag-risk-medio' : 'tag-risk-bajo');
                    return `
                    <div style="background:#090e0b; border:1px solid var(--panel-border); border-radius:6px; padding:10px;">
                        <div style="display:flex; justify-content:space-between; align-items:center;">
                            <strong style="color:#fff; font-size:12px;">${esc(c.module)}</strong>
                            <span class="tag ${rCls}">Riesgo: ${esc(c.risk)}</span>
                        </div>
                        <div style="color:var(--primary); font-size:11px; margin:4px 0;">${esc(c.change)}</div>
                        <div style="font-size:10px; color:var(--muted); border-top:1px dashed #1a2c1f; padding-top:4px;">
                            ↺ Rollback: <strong>${esc(c.rollback)}</strong>
                        </div>
                    </div>
                    `;
                }).join('');
            }

            async function handleCreateRequest(e) {
                e.preventDefault();
                const title = byId('reqTitle').value.trim();
                const priority = byId('reqPriority').value;
                const description = byId('reqDescription').value.trim();

                try {
                    const r = await fetch('/api/requests', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ title, description, priority })
                    });
                    if (r.ok) {
                        showToast('Solicitud creada en el baseline.', 'success');
                        closeModal('createRequestModal');
                        byId('createRequestForm').reset();
                        await loadLegacyData();
                    } else {
                        const err = await r.json();
                        showToast(err.error || 'Error al crear solicitud.', 'error');
                    }
                } catch {
                    showToast('Fallo de conexión', 'error');
                }
            }

            async function handleCreateChange(e) {
                e.preventDefault();
                const module = byId('changeModule').value;
                const change = byId('changeDescription').value.trim();
                const risk = byId('changeRisk').value;
                const rollback = byId('changeRollback').value.trim();

                try {
                    const r = await fetch('/api/migration/changes', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ module, change, risk, rollback })
                    });
                    if (r.ok) {
                        showToast('Decisión de arquitectura registrada.', 'success');
                        closeModal('changeModal');
                        byId('changeForm').reset();
                        await loadLegacyData();
                    } else {
                        const err = await r.json();
                        showToast(err.error || 'Error al registrar cambio.', 'error');
                    }
                } catch {
                    showToast('Fallo de conexión', 'error');
                }
            }

            async function handleEditRequest(id, oldTitle, oldDesc, oldState, oldPriority) {
                const title = prompt('Nuevo título de la solicitud:', oldTitle);
                if (!title) return;
                const state = prompt('Nuevo estado (Abierta, En proceso, Resuelta, Cerrada):', oldState) || oldState;

                try {
                    const r = await fetch(`/api/requests/${id}`, {
                        method: 'PUT',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ title, description: oldDesc, state, priority: oldPriority })
                    });
                    if (r.ok) {
                        showToast('Solicitud actualizada correctamente.', 'success');
                        await loadLegacyData();
                    } else {
                        const err = await r.json();
                        showToast(err.error || 'Error al actualizar solicitud.', 'error');
                    }
                } catch {
                    showToast('Fallo al conectar', 'error');
                }
            }

            init();
            </script>
        </body>
        </html>
        """;
    }
}
