#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Factories;
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;

namespace Runtime.Game.Controllers
{
    public class SpellCastingController : ISpellCastingController
    {
        private readonly ISpellFactory _spellFactory;
        
        private readonly INavMeshMovementController _navMeshMovementController;

        public SpellCastingController(
            ISpellFactory spellFactory,
            INavMeshMovementController navMeshMovementController)
        {
            _spellFactory = spellFactory;
            _navMeshMovementController = navMeshMovementController;
        }

        public ISpell CreateSpell(SpellId spellId)
        {
            return _spellFactory.CreateSpell(spellId);
        }

        public void CastSpell(Character caster, SpellId spellId)
        {
            var spell = CreateSpell(spellId);
            CastSpell(caster, spell);
        }

        public void CastSpell(Character caster, ISpell spell)
        {
            _navMeshMovementController.SetNavigationEnabled(caster, false);
            spell.Cast(caster);
        }

        public bool CanCastSpell(Character caster, SpellId spellId)
        {
            var spell = CreateSpell(spellId);
            return CanCastSpell(caster, spell);
        }

        public bool CanCastSpell(Character caster, ISpell spell)
        {
            return spell.CanCastSpell(caster);
        }
    }
}