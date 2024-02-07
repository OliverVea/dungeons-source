#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;
using UnityEngine;

namespace Runtime.Game.Models
{
    [Serializable]
    public class SerializableSpellBook : ISpellBook
    {
        [SerializeField] private SpellId[] _spells = Array.Empty<SpellId>();
        public SpellId[] Spells => _spells.ToArray();

        private HashSet<SpellId>? _spellLookup;
        
        public bool Contains(SpellId spellId)
        {
            _spellLookup ??= _spells.ToHashSet();

            return _spellLookup.Contains(spellId);
        }
    }
}