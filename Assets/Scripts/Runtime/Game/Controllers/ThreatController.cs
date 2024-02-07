#nullable enable

using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;
using UnityEngine;

namespace Runtime.Game.Controllers
{
    public class ThreatController : IThreatController
    {
        private const string Tag = nameof(ThreatController);
        
        private readonly ILogger _logger;
        private readonly ICharacterListManager _characterListManager;
        private readonly IFactionHelper _factionHelper;

        public ThreatController(ICharacterListManager characterListManager,
            IFactionHelper factionHelper,
            ILogger logger)
        {
            _characterListManager = characterListManager;
            _factionHelper = factionHelper;
            _logger = logger;
        }

        public void AddThreat(Character character, Character toAdd, float threat)
        {
            if (!_factionHelper.AreEnemies(character, toAdd))
            {
                _logger.Log(Tag, $"Did not add threat from {character.Name} to {toAdd} since they are same faction");
            }
            
            character.ThreatService.AddThreat(toAdd, threat);
        }

        public void AddThreatToEnemies(Character target, Character source, float threat)
        {
            var enemies = _characterListManager.ListCharacters()
                .Where(x => x.ThreatService.GetThreatTable().ContainsKey(target));
            
            foreach (var enemy in enemies) AddThreat(source, enemy, threat);
        }

        public void DropThreat(Character character, Character toDrop)
        {
            _logger.Log(Tag, $"{character} dropping threat for {toDrop}");
            
            character.ThreatService.DropThreat(toDrop);
        }

        public Character? GetTargetFromThreat(Character character)
        {
            return character.ThreatService.GetThreatTable()
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .FirstOrDefault();
        }

        public bool IsInCombat(Character character)
        {
            return character.ThreatService.GetThreatTable().Any();
        }

        public Character[] ListTargets(Character character)
        {
            return character.ThreatService.GetThreatTable().Keys.ToArray();
        }
    }
}