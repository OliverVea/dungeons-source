# nullable enable

using System;
using UnityEngine;

namespace Runtime.Abstractions.Models
{
    [Serializable]
    public struct Angle
    {
        [Range(-360, 360)] public float _deactivated;
        [Range(-360, 360)] public float _activated;
    }
}