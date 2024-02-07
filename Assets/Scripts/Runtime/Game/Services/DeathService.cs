#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Zenject;

namespace Runtime.Game.Services
{
    public class DeathService : IDeathService, ILateTickable
    {
        private readonly Character _character;
        private readonly IDeathController _deathController;

        public DeathService(Character character,
            IDeathController deathController)
        {
            _character = character;
            _deathController = deathController;
        }

        public bool IsDead { get; private set; }
        
        public void Kill()
        {
            IsDead = true;
        }

        public void LateTick()
        {
            if (!IsDead) return;

            _deathController.DeathCleanup(_character);
        }
    }
}