#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Game.Effects;

namespace Runtime.Game.Controllers
{
    public class HealthController : IHealthController
    {
        private readonly IDeathController _deathController;
        private readonly IThreatController _threatController;
        private readonly IEffectController _effectController;

        public HealthController(IDeathController deathController,
            IThreatController threatController,
            IEffectController effectController)
        {
            _deathController = deathController;
            _threatController = threatController;
            _effectController = effectController;
        }

        public void DoDamage(Character source, Character target, float amount)
        {
            if (amount == 0 || target.HealthService.Current == 0) return;
            
            var damageDone = Math.Max(0, -ChangeHealthAndReturnDelta(target, -amount));

            if (target.HealthService.Current <= 0f)
            {
                _deathController.Kill(target);
                return;
            }
            
            var threat = damageDone * Constants.Threat.DamageScalar;
            
            if (threat > 0) _threatController.AddThreat(target, source, threat);

            var colorEffect = new DamageColorEffect(source, target);
            _effectController.ApplyEffect(colorEffect);
        }

        public void DoHealing(Character source, Character target, float amount)
        {
            if (amount == 0 || target.HealthService.Current == 0) return;
            
            var healingDone = Math.Max(0, ChangeHealthAndReturnDelta(target, amount));
            
            var threat = healingDone * Constants.Threat.HealingScalar;
            
            if (threat > 0) _threatController.AddThreatToEnemies(target, source, threat);

            var colorEffect = new HealingColorEffect(source, target);
            _effectController.ApplyEffect(colorEffect);
        }

        private float ChangeHealthAndReturnDelta(Character target, float change)
        {
            var healthBefore = target.HealthService.Current;
            
            var value = healthBefore + change;
            
            target.HealthService.SetCurrent(value);

            return target.HealthService.Current - healthBefore;
        }
    }
}