namespace MigracionLegacy.Services;

public interface ICharacterizationEngine
{
    (string Legacy, string Modern, bool Matches) RunCharacterization(string input);
    IReadOnlyList<(string Module, string Status, int Progress)> GetRoadmap();
}

public sealed class CharacterizationEngine : ICharacterizationEngine
{
    public (string Legacy, string Modern, bool Matches) RunCharacterization(string input)
    {
        var raw = input ?? "";
        // Synthetic legacy logic: trim and uppercase invariant
        var legacy = raw.Trim().ToUpperInvariant();
        // Modern ASP.NET Core logic preserving legacy contract
        var modern = raw.Trim().ToUpperInvariant();

        return (legacy, modern, legacy == modern);
    }

    public IReadOnlyList<(string Module, string Status, int Progress)> GetRoadmap()
    {
        return new[]
        {
            ("Módulo 01: Solicitudes y Órdenes", "Baseline documentado", 100),
            ("Módulo 02: Persistencia EF Core InMemory", "Migrado con éxito", 100),
            ("Módulo 03: Endpoints RESTful .NET 10", "Implementado y verificado", 90),
            ("Módulo 04: Base de Datos Relacional SQL", "En preparación", 40),
            ("Módulo 05: Pipeline CI/CD y Reversión", "Planificado", 20)
        };
    }
}
