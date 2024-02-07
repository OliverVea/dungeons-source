#nullable enable

using UnityEngine;

namespace Runtime.Abstractions
{
    public abstract class ColorModifier
    {
        public abstract Color Color { get; }
        public abstract float Weight { get; }
        public abstract bool ShowModel { get; }
        
        public class Damage : ColorModifier
        {
            public override Color Color => Color.red;
            public override float Weight => 0.3f;
            public override bool ShowModel => true;
        }
        
        public class Healing : ColorModifier
        {
            public override Color Color => Color.green;
            public override float Weight => 0.2f;
            public override bool ShowModel => true;
        }

        public class FromColor : ColorModifier
        {
            public override Color Color { get; }
            public override float Weight => 1f;
            public override bool ShowModel => true;
            
            public FromColor(Color color)
            {
                Color = color;
            }
        }
    }
}