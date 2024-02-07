#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Components
{
    public abstract class MouseComponentBase : MonoBehaviour, IMouseComponent, IInitializable, IDisposable
    {
        [Inject] private IMouseComponentManager _mouseComponentManager = null!;
        
        [Required] [SerializeField] private Collider _collider = null!;
        
        public void Initialize()
        {
            _mouseComponentManager.Register(this, _collider);
        }

        public void Dispose()
        {
            _mouseComponentManager.Unregister(_collider);
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void LeftClick();
        public abstract void RightClick();
        public abstract void MiddleClick();
    }
}