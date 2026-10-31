namespace MigracionLegacy.UI.Components;

public static class CharacterizationPlayground
{
    public const string Html = """
    <div style="background:#060a08; border:1px solid var(--panel-border); border-radius:var(--radius); padding:16px; margin-bottom:20px;">
        <div style="display:flex; justify-content:space-between; align-items:center; margin-bottom:10px;">
            <div>
                <strong style="color:#fff; font-size:13px;">▶ Banco de Pruebas de Caracterización en Vivo</strong>
                <p style="font-size:11px; color:var(--muted); margin:2px 0 0;">Ingresa una muestra de datos para comparar la paridad del comportamiento legado vs. moderno.</p>
            </div>
            <span id="charMatchBadge" class="tag tag-risk-bajo">MATCH CONFIRMADO</span>
        </div>
        <div style="display:flex; gap:10px; margin-bottom:10px;">
            <input type="text" id="charInputText" value="  orden demo migracion  " placeholder="Texto de prueba..." oninput="runLiveCharacterization(this.value)" style="flex:1; padding:8px 12px; border:1px solid var(--panel-border); border-radius:6px; background:#0e1711; color:var(--primary); font-family:inherit; font-size:12px;">
            <button type="button" class="btn btn-primary" onclick="runLiveCharacterization(byId('charInputText').value)">Test Baseline</button>
        </div>
        <div class="diff-box">
            <div class="diff-pane">
                <small>01 · Comportamiento Legado (As-Is)</small>
                <pre id="legacyOutputPre">ORDEN DEMO MIGRACION</pre>
            </div>
            <div class="diff-pane">
                <small>02 · Comportamiento Moderno (To-Be)</small>
                <pre id="modernOutputPre">ORDEN DEMO MIGRACION</pre>
            </div>
        </div>
    </div>
    """;

    public const string Script = """
    async function runLiveCharacterization(val) {
        val = val ?? '';
        try {
            const r = await fetch('/api/characterization/run', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ value: val })
            });
            if (r.ok) {
                const d = await r.json();
                byId('legacyOutputPre').textContent = d.legacyOutput;
                byId('modernOutputPre').textContent = d.modernOutput;
                const badge = byId('charMatchBadge');
                if (d.matches) {
                    badge.className = 'tag tag-risk-bajo';
                    badge.textContent = 'MATCH CONFIRMADO (100%)';
                } else {
                    badge.className = 'tag tag-risk-alto';
                    badge.textContent = 'DIVERGENCIA DETECTADA';
                }
            }
        } catch {}
    }
    """;
}
