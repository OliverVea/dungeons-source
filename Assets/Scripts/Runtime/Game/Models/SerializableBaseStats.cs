#nullable enable

using System;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Models
{
    [Serializable]
    public class SerializableBaseStats : IBaseStats
    {
        [SerializeField] private float _health;
        public float Health => _health;

        [SerializeField] private float _mana;
        public float Mana => _mana;

        [SerializeField] private float _manaPerSecond;
        public float ManaPerSecond => _manaPerSecond;

        [SerializeField] private float _spellPower;
        public float SpellPower => _spellPower;
    }
}