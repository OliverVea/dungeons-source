#nullable enable

using System;
using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Spells.Fireball
{
    public static class FireballStats
    {
        public const string Name = "Fireball";
        public const float Range = Constants.Spells.DefaultSpellRange;
        public const float Damage = 15f;
        public const float TickDamage = 1f;
        public const float ManaCost = 10f;
        public const AnimationName CastAnimation = AnimationName.Cast;
        public const DuplicateEffectBehavior DuplicateEffectBehavior =
            Abstractions.Models.DuplicateEffectBehavior.KeepLatestForEachSource;
        
        public static readonly TimeSpan Cooldown = TimeSpan.Zero;
        public static readonly HashSet<InterruptionSource> InterruptionSources = Constants.Spells.DefaultInterruptionSources;
        public static readonly TimeSpan CastTime = TimeSpan.FromSeconds(1.5);
        public static readonly TimeSpan? EffectDuration = TimeSpan.FromSeconds(5);
        public static readonly TimeSpan TickPeriod = TimeSpan.FromSeconds(0.5f);
    }
}