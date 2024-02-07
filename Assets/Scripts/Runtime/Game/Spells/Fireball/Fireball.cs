#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;
using Zenject;

namespace Runtime.Game.Spells.Fireball
{
    public class Fireball : ISpell
    {
        [Inject] private readonly IAnimationController _animationController = null!;
        [Inject] private readonly ITargetController _targetController = null!;
        [Inject] private readonly IConcentrationController _concentrationController = null!;
        [Inject] private readonly IHealthController _healthController = null!;
        [Inject] private readonly IEffectController _effectController = null!;
        [Inject] private readonly IRangeHelper _rangeHelper = null!;
        [Inject] private readonly ILineOfSightHelper _lineOfSightHelper = null!;
        [Inject] private readonly ITimeManager _timeManager = null!;
        [Inject] private readonly ICharacterListManager _characterListManager = null!;
        [Inject] private readonly ISpellBookController _spellBookController = null!;
        [Inject] private readonly IManaController _manaController = null!;

        public SpellId SpellId => SpellId.Fireball;
        public string Name => FireballStats.Name;
        public TimeSpan Cooldown => FireballStats.Cooldown;
        public SpellStatus SpellStatus { get; private set; } = SpellStatus.Uncast;

        public void Cast(Character caster)
        {
            var alreadyConcentrating = _concentrationController.IsConcentrating(caster);
            if (alreadyConcentrating)
            {
                SpellStatus = SpellStatus.Invalid;
                return;
            }
            
            var target = GetTarget(caster);
            if (target is null)
            {
                SpellStatus = SpellStatus.Invalid;
                return;
            }

            if (!CanCastSpell(caster, target))
            {
                SpellStatus = SpellStatus.Invalid;
                return;
            }
            
            var concentration = new FireballConcentration(_timeManager);
            
            concentration.OnCancelled.AddListener(OnCancelled);
            concentration.OnFinish.AddListener(() => OnFinish(caster, target));
            
            _concentrationController.StartConcentration(caster, concentration);
            
            SpellStatus = SpellStatus.Casting;
        }

        public bool CanCastSpell(Character caster)
        {
            var target = GetTarget(caster);
            if (target is null) return false;
            
            return CanCastSpell(caster, target);
        }

        private bool CanCastSpell(Character caster, Character target)
        {
            return _spellBookController.KnowsSpell(caster, SpellId) &&
                   _characterListManager.ContainsCharacter(target) &&
                   _manaController.HasMana(caster, FireballStats.ManaCost) &&
                   _rangeHelper.IsInRange(caster, target, FireballStats.Range) &&
                   _lineOfSightHelper.HasLineOfSight(caster, target);
        }

        private void OnCancelled(Character? canceller)
        {
            SpellStatus = SpellStatus.Cancelled;
        }

        private void OnFinish(Character caster, Character target)
        {
            if (!CanCastSpell(caster, target))
            {
                SpellStatus = SpellStatus.Cancelled;
                return;
            }
            
            _manaController.Deduct(caster, FireballStats.ManaCost);
            
            _animationController.Trigger(caster, FireballStats.CastAnimation);
            _healthController.DoDamage(caster, target, FireballStats.Damage);

            var effect = new FireballEffect(caster, target);
            _effectController.ApplyEffect(effect);
            
            SpellStatus = SpellStatus.Finished;
        }

        private Character? GetTarget(Character caster) => _targetController.GetTarget(caster);
    }
}