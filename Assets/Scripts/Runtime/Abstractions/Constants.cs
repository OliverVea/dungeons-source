# nullable enable

using System.Collections.Generic;
using Runtime.Abstractions.Models;

namespace Runtime.Abstractions
{
    public static class Constants
    {
        public static class DI
        {
            public const string Source = "Source";
            public const string Target = "Target";
        }
        
        public static class Movement
        {
            public const float MovementSpellCancellationThreshold = .2f;
            public const float JumpVelocity = 5f;
            public const float FloorDistance = .5f;
            public const float DefaultMovementSpeed = 5f;
        }

        public static class Combat
        {
            public const float MeleeRange = 1.5f;
            public const float MeleeDamage = 1f;
            public const float MeleeSwingRecovery = 1.5f;
            public const float MeleeSwingTime = 0.55f;
            public const float LongRange = 16f;
        }

        public static class AI
        {
            public const float IdleRefreshPeriod = 1f;


            public const float StoppingDistance = Combat.MeleeRange - 0.1f;
            public const double CastingConstant = 5;
            public const float AggroRange = 10f;
        }

        public static class Math
        {
            // ReSharper disable once InconsistentNaming
            public const float g = 9.82f;
        }

        public static class Rage
        {
            public const float DamageScalar = 2f;
        
            public const float AutoAttack = 5f;
        
            public const float CombatLossPerSecond = 0f;
        
            public const float OutOfCombatLossPerSecond = 3f;
        }

        public static class Threat
        {
            public const float DamageScalar = 1f;
            public const float HealingScalar = 0.5f;
            public const float Pull = 10;
        }

        public static class UI
        {
        }

        public static class Camera
        {
            public const float MaxDistance = 12f;
            public const float MinWallDistance = 0.2f;
        }

        public static class Border
        {
            public const float BorderAlpha = 0.7f;
            public const float FillAlpha = 0.15f;
        }

        public static class Spells
        {
            public static readonly HashSet<InterruptionSource> DefaultInterruptionSources = new()
            {
                InterruptionSource.Manual,
                InterruptionSource.Movement,
                InterruptionSource.Stun
            };

            public const float DefaultSpellRange = 12f;
        }

        public static class Stats
        {
            public const float SpellPowerIntellectScaling = 1f;
        }
    }
}