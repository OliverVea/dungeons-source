#nullable enable

using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Extensions
{
    public static class FactionExtensions
    {
        public static Color GetColor(this Faction faction)
        {
            return faction switch
            {
                Faction.None => Color.yellow,
                Faction.Enemy => Color.red,
                Faction.Player => Color.green,
                _ => Color.clear
            };
        }
    }
}