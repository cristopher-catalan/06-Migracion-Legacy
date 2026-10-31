namespace MigracionLegacy.UI;

public static class LegacyStyles
{
    public const string Css = """
    :root {
        --primary: #59e783;
        --primary-glow: rgba(89, 231, 131, 0.3);
        --bg: #090e0b;
        --panel: #111a14;
        --panel-border: #1e3324;
        --ink: #dce9df;
        --muted: #88a08c;
        --warning: #facc15;
        --danger: #f87171;
        --radius: 8px;
    }
    * { box-sizing: border-box; margin: 0; padding: 0; }
    body.app-legacy {
        font-family: 'Cascadia Mono', Consolas, 'Courier New', monospace;
        background: var(--bg); color: var(--ink); line-height: 1.5; min-height: 100vh;
    }
    .top {
        display: flex; justify-content: space-between; align-items: center;
        background: #060907; border-bottom: 1px solid var(--panel-border);
        padding: 14px 28px; position: sticky; top: 0; z-index: 40;
    }
    .brand { display: flex; align-items: center; gap: 14px; }
    .mark {
        width: 42px; height: 42px; border-radius: 6px;
        background: #173b22; color: var(--primary); font-weight: 800;
        display: grid; place-items: center; font-size: 18px; border: 1px solid var(--primary);
    }
    .brand h1 { font-size: 16px; font-weight: 700; color: #fff; }
    .brand p { font-size: 11px; color: var(--muted); }
    .page { max-width: 1360px; margin: 24px auto 60px; padding: 0 24px; }

    /* Session Bar */
    .session-bar {
        background: var(--panel); border: 1px solid var(--panel-border);
        border-radius: var(--radius); padding: 12px 18px;
        display: flex; align-items: center; justify-content: space-between;
        gap: 16px; margin-bottom: 24px;
    }
    .login-controls { display: flex; align-items: center; gap: 10px; flex-wrap: wrap; }
    .input-group { display: flex; flex-direction: column; gap: 2px; }
    .input-group label { font-size: 10px; font-weight: 700; color: var(--muted); text-transform: uppercase; }
    .input-group select, .input-group input {
        padding: 7px 11px; border: 1px solid var(--panel-border); border-radius: 6px;
        font-size: 12px; background: #060a08; color: var(--primary); font-family: inherit;
    }
    .btn {
        padding: 8px 16px; border-radius: 6px; font-weight: 700; font-size: 12px;
        border: 0; cursor: pointer; display: inline-flex; align-items: center; gap: 6px;
        font-family: inherit; transition: all 0.15s ease;
    }
    .btn-primary {
        background: #173b22; color: var(--primary); border: 1px solid var(--primary);
        box-shadow: 0 0 10px var(--primary-glow);
    }
    .btn-primary:hover { background: #225632; }
    .btn-outline { background: transparent; border: 1px solid var(--panel-border); color: var(--muted); }
    .btn-outline:hover { background: #18281d; color: #fff; }

    /* Hero Banner */
    .legacy-hero {
        background: #111e15; border: 1px solid var(--panel-border);
        border-radius: var(--radius); padding: 26px 32px;
        display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px;
    }
    .legacy-hero small { font-size: 11px; font-weight: 800; letter-spacing: 0.12em; color: var(--primary); }
    .legacy-hero h2 { font-size: 26px; font-weight: 800; color: #fff; margin: 4px 0 6px; }
    .legacy-hero p { font-size: 13px; color: var(--muted); max-width: 580px; }

    /* Terminal Window */
    .terminal {
        background: #060a08; border: 1px solid var(--panel-border);
        border-radius: var(--radius); margin-bottom: 24px; overflow: hidden;
    }
    .terminal-top {
        background: #0e1711; padding: 8px 16px; border-bottom: 1px solid var(--panel-border);
        display: flex; align-items: center; gap: 8px; font-size: 11px; color: var(--muted);
    }
    .terminal-dot { width: 8px; height: 8px; border-radius: 50%; display: inline-block; }
    .terminal-code { padding: 18px; font-size: 12px; line-height: 1.8; color: #a4bea8; }
    .terminal-code b { color: var(--primary); }

    /* Main Grid */
    .main-grid { display: grid; grid-template-columns: 1.55fr 0.95fr; gap: 20px; }
    @media(max-width: 960px) { .main-grid { grid-template-columns: 1fr; } }

    .panel {
        background: var(--panel); border: 1px solid var(--panel-border);
        border-radius: var(--radius); padding: 22px;
    }
    .panel-header {
        display: flex; justify-content: space-between; align-items: center;
        margin-bottom: 16px; padding-bottom: 12px; border-bottom: 1px solid var(--panel-border);
    }
    .panel-header h3 { font-size: 15px; font-weight: 700; color: #fff; }

    /* Playground */
    .diff-box {
        display: grid; grid-template-columns: 1fr 1fr; gap: 12px; margin-top: 10px;
    }
    .diff-pane {
        background: #070c09; border: 1px solid var(--panel-border); border-radius: 6px; padding: 12px;
    }
    .diff-pane small { font-size: 10px; text-transform: uppercase; color: var(--muted); display: block; margin-bottom: 4px; }
    .diff-pane pre { font-family: inherit; font-size: 12px; color: var(--primary); white-space: pre-wrap; word-break: break-all; }

    /* Modals */
    .modal-overlay {
        position: fixed; inset: 0; background: rgba(0, 0, 0, 0.8);
        backdrop-filter: blur(4px); z-index: 120; opacity: 0; pointer-events: none;
        transition: opacity 0.2s ease; display: grid; place-items: center; padding: 20px;
    }
    .modal-overlay.open { opacity: 1; pointer-events: auto; }
    .modal {
        background: #101c13; border: 1px solid var(--panel-border); width: 100%;
        max-width: 520px; border-radius: var(--radius); overflow: hidden;
    }
    .modal-header { padding: 16px 20px; border-bottom: 1px solid var(--panel-border); display: flex; justify-content: space-between; align-items: center; }
    .modal-body { padding: 20px; display: flex; flex-direction: column; gap: 12px; }
    .modal-footer { padding: 14px 20px; border-top: 1px solid var(--panel-border); background: #0b140e; display: flex; justify-content: flex-end; gap: 10px; }
    .form-group { display: flex; flex-direction: column; gap: 4px; }
    .form-group label { font-size: 11px; font-weight: 700; color: var(--muted); }
    .form-group input, .form-group select, .form-group textarea {
        padding: 8px 10px; border: 1px solid var(--panel-border); border-radius: 6px; font-size: 12px; background: #070c09; color: var(--primary); font-family: inherit;
    }

    /* Badges */
    .tag { padding: 3px 7px; border-radius: 4px; font-size: 10px; font-weight: 700; }
    .tag-abierta { background: #1c3d25; color: var(--primary); }
    .tag-proceso { background: #3d3417; color: var(--warning); }
    .tag-resuelta { background: #143527; color: #4ade80; }
    .tag-risk-bajo { background: #173822; color: #4ade80; }
    .tag-risk-medio { background: #3b3014; color: var(--warning); }
    .tag-risk-alto { background: #401919; color: var(--danger); }

    /* Toasts */
    .toast-container { position: fixed; bottom: 20px; right: 20px; z-index: 200; display: flex; flex-direction: column; gap: 8px; }
    .toast {
        background: #0f1c13; color: #fff; padding: 12px 18px; border-radius: 6px;
        box-shadow: 0 4px 15px rgba(0,0,0,0.5); font-size: 12px; font-weight: 600;
        border: 1px solid var(--panel-border); display: flex; align-items: center; gap: 10px;
    }
    .toast.success { border-left: 4px solid var(--primary); }
    .toast.error { border-left: 4px solid var(--danger); }
    """;
}
