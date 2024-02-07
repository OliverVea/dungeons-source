# nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using UnityEngine;

namespace Runtime.Game.Services
{
    public class ColorService : IColorService
    {
        private readonly HashSet<ColorModifier> _colorModifiers = new();
        private readonly Renderer _renderer;
        
        internal ColorService(Renderer renderer)
        {
            _renderer = renderer;

            var existingColor = renderer.material.color;
            var colorModifier = new ColorModifier.FromColor(existingColor);
            _colorModifiers.Add(colorModifier);
        }

        // IRendererService
        public void AddModifier(ColorModifier colorModifier)
        {
            _colorModifiers.Add(colorModifier);
            Update();
        }

        public void RemoveModifier(ColorModifier colorModifier)
        {
            _colorModifiers.Remove(colorModifier);
            Update();
        }

        private void Update()
        {
            var showModel = _colorModifiers.All(x => x.ShowModel);

            ShowModel(showModel);
            if (showModel) UpdateColor();
        }

        private void ShowModel(bool showModel)
        {
            _renderer.enabled = showModel;
        }

        private void UpdateColor()
        {
            var weight = 0f;
            var color = new Color();

            foreach (var colorModifier in _colorModifiers)
            {
                weight += colorModifier.Weight;
                color += colorModifier.Color * colorModifier.Weight;
            }
            
            _renderer.material.color = color / weight; 
        }
    }
}