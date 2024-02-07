#nullable enable

using EPOOutline;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Components
{
    public class OutlineComponent : MonoBehaviour, IOutlineComponent
    {
        private const string ColorProperty = "_PublicColor";
        
        [SerializeField] private Outlinable _outlinable = null!;

        private bool _hover;
        private bool _selected;
        
        public void SetColor(Color borderColor, Color fillColor)
        {
            _outlinable.OutlineParameters.Color = borderColor;
            _outlinable.FrontParameters.Color = borderColor;
            _outlinable.BackParameters.Color = borderColor;
            
            _outlinable.OutlineParameters.FillPass?.SetColor(ColorProperty, fillColor);
            _outlinable.FrontParameters.FillPass?.SetColor(ColorProperty, fillColor);
            _outlinable.BackParameters.FillPass?.SetColor(ColorProperty, fillColor);
        }

        public void SetHover(bool state)
        {
            _hover = state;
            Update();
        }

        public void SetSelected(bool state)
        {
            _selected = state;
            Update();
        }

        private void Update()
        {
            if (_selected) SetOutlineSetting(OutlineSetting.Selected);
            else if (_hover) SetOutlineSetting(OutlineSetting.Hover);
            else SetOutlineSetting(OutlineSetting.Unselected);
        }

        private void SetOutlineSetting(OutlineSetting outlineSetting)
        {
            _outlinable.enabled = outlineSetting.ShowFront | outlineSetting.ShowBack;

            _outlinable.OutlineParameters.Enabled = outlineSetting.ShowFront | outlineSetting.ShowBack;
            _outlinable.FrontParameters.Enabled = outlineSetting.ShowFront;
            _outlinable.BackParameters.Enabled = outlineSetting.ShowBack;
        }

        public void Show() => SetHover(true);
        public void Hide() => SetHover(false);
    }
}