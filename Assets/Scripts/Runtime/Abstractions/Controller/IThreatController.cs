#nullable enable

namespace Runtime.Abstractions.Controller
{
    public interface IThreatController
    {
        void AddThreat(Character character, Character toAdd, float threat);
        void AddThreatToEnemies(Character target, Character source, float threat);
        void DropThreat(Character character, Character toDrop);
        Character? GetTargetFromThreat(Character character);
        bool IsInCombat(Character character);
        Character[] ListTargets(Character character);
    }
}