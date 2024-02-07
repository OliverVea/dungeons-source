#nullable enable

using System;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Runtime.Game.Components
{
    public class ConcentrationComponent : MonoBehaviour, IConcentration
    {
        [Inject] private readonly IConcentrationController _concentrationController = null!;
        [Inject] private readonly IPlayerCharacterManager _playerCharacterManager = null!;
        [Inject] private readonly ITimeManager _timeManager = null!;

        [SerializeField] private string _text = string.Empty;
        [SerializeField] private float _totalTimeInSeconds;
        
        [SerializeField] private UnityEvent _onStart = new();
        [SerializeField] private UnityEvent _onFinished = new();
        [SerializeField] private UnityEvent _onCancelled = new();

        public string Text => _text;
        public TimeSpan TimeSinceStarted => _timeManager.UtcNow - StartTime;
        
        private DateTimeOffset StartTime { get; set; }
        public TimeSpan TotalTime => TimeSpan.FromSeconds(_totalTimeInSeconds);

        public void Trigger()
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return;
            
            _concentrationController.StartConcentration(playerCharacter, this);
        }
        
        public void Start()
        {
            _onStart.Invoke();
            StartTime = _timeManager.UtcNow;
        }

        public void Finish() => _onFinished.Invoke();
        public bool Cancel(InterruptionSource interruptionSource)
        {
            _onCancelled.Invoke();
            return true;
        }

        public bool Cancel(InterruptionSource interruptionSource, Character source) => Cancel(interruptionSource);
    }
}