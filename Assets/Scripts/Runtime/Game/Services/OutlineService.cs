#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using Runtime.Game.Extensions;
using Zenject;

namespace Runtime.Game.Services
{
    public class OutlineService : IOutlineService, IInitializable
    {
        private readonly Faction _faction;
        private readonly IOutlineComponent _outlineComponent;

        public OutlineService(Faction faction, IOutlineComponent outlineComponent)
        {
            _faction = faction;
            _outlineComponent = outlineComponent;
        }

        public void SetHover(bool state) => _outlineComponent.SetHover(state);
        public void SetSelected(bool state) => _outlineComponent.SetSelected(state);


        public void Initialize()
        {
            var factionColor = _faction.GetColor();

            var borderColor = factionColor.WithAlpha(Constants.Border.BorderAlpha);
            var fillColor = factionColor.WithAlpha(Constants.Border.FillAlpha);
            
            _outlineComponent.SetColor(borderColor, fillColor);
            
            SetHover(false);
            SetSelected(false);
        }
    }
}