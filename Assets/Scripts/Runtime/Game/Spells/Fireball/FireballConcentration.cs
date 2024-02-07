#nullable enable

using System;
using System.Collections.Generic;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Spells.Fireball
{
    public class FireballConcentration : SpellConcentration
    {
        public override string Text => FireballStats.Name;
        public override TimeSpan TotalTime => FireballStats.CastTime;
        protected override HashSet<InterruptionSource> InterruptionSources => FireballStats.InterruptionSources;

        public FireballConcentration(ITimeManager timeManager) : base(timeManager)
        {
        }
    }
}