namespace MigracionLegacy.Domain;

public sealed record LegacyRequestItemDto(
    int Id,
    string Number,
    string Title,
    string Description,
    string State,
    string Priority,
    DateTimeOffset UpdatedAt
);

public sealed record MigrationModuleDto(
    string Name,
    string Status,
    int ProgressPercent,
    string Notes
);

public sealed record CharacterizationResultDto(
    string Input,
    string LegacyOutput,
    string ModernOutput,
    bool Matches,
    string ExecutionTime
);

public sealed record ChangeDecisionDto(
    int Id,
    string Module,
    string Change,
    string Risk,
    string Rollback,
    string Actor,
    DateTimeOffset At
);
