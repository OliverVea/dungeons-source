#nullable enable

using System;
using BehaviorDesigner.Runtime.Tasks;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;
using Zenject;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

namespace Runtime.Game.Tasks.Actions
{
    public class CastSpell : Action
    {
        [Inject] private readonly Character _character = null!;
        [Inject] private readonly ISpellCastingController _spellCastingController = null!;
        
        public SpellId SpellId = SpellId.Fireball;
        public bool CancelImmediately = false;
        
        public override string FriendlyName => "Cast " + SpellId;

        private ISpell? _spell;

        public override void OnStart()
        {
            _spell = null;
            
            var canCastSpell = _spellCastingController.CanCastSpell(_character, SpellId);
            if (!canCastSpell) return;
            
            _spell = _spellCastingController.CreateSpell(SpellId);
            _spellCastingController.CastSpell(_character, _spell);
        }

        public override TaskStatus OnUpdate()
        {
            if (_spell is null) return TaskStatus.Failure;

            if (CancelImmediately && !_spell.CanCastSpell(_character)) return TaskStatus.Failure;
                
            switch (_spell.SpellStatus)
            {
                case SpellStatus.Cancelled:
                case SpellStatus.Invalid:
                    return TaskStatus.Failure;
                case SpellStatus.Casting:
                case SpellStatus.Uncast:
                    return TaskStatus.Running;
                case SpellStatus.Finished:
                    return TaskStatus.Success;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}