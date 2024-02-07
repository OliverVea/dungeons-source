#nullable enable

using System;
using UnityEngine;

namespace Runtime.Abstractions.Errors
{
    public class MouseOverComponentLookupException : Exception
    {
        public MouseOverComponentLookupException(Collider collider) 
            : base($"Tried to get IMouseOverComponent for collider on game object {collider.gameObject}")
        {
            
        }
    }
}