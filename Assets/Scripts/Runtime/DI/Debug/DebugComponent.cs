#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Factories;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Models;
using Runtime.Abstractions.Spells;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Runtime.DI.Debug
{
    public class DebugComponent : MonoBehaviour
    {
        [Inject] private readonly Character _character = null!;
        [Inject] private readonly IInputMovementController _inputMovementController = null!;
        [Inject] private readonly IStatsController _statsController = null!;
        [Inject] private readonly IRangeHelper _rangeHelper = null!;
        [Inject] private readonly IScriptableObjectFactory _scriptableObjectFactory = null!;
        [Inject] private readonly IInventoryController _inventoryController = null!;
        [Inject] private readonly IEquipmentController _equipmentController = null!;
        
        
        #region character
        private const string CharacterTab = "Character";
        [TabGroup(CharacterTab), ShowInInspector]
        public string Name => _character.Name;

        [TabGroup(CharacterTab), ShowInInspector]
        public Faction Faction => _character.Faction;

        [TabGroup(CharacterTab), ShowInInspector]
        public Transform Transform => _character.Transform;

        [TabGroup(CharacterTab), ShowInInspector]
        public Animator Animator => _character.Animator;

        [TabGroup(CharacterTab), ShowInInspector]
        public Renderer Renderer => _character.Renderer;

        [TabGroup(CharacterTab), ShowInInspector]
        public Rigidbody Rigidbody => _character.Rigidbody;

        [TabGroup(CharacterTab), ShowInInspector]
        public IMovementService MovementService => _character.MovementService;

        [TabGroup(CharacterTab), ShowInInspector]
        public SpellId[] SpellBook => _character.SpellBook.Spells;
        #endregion
        
        #region movement
        private const string MovementTab = "Movement";
        [TabGroup(MovementTab), ShowInInspector]
        public bool CanJump => _inputMovementController.IsGrounded(_character);

        [TabGroup(MovementTab), ShowInInspector]
        public float CurrentSpeed => _character.MovementService.CurrentSpeed;

        [TabGroup(MovementTab), ShowInInspector]
        public float Speed => _character.MovementService.Speed;

        [TabGroup(MovementTab), ShowInInspector]
        public float BaseSpeed => _character.MovementService.BaseSpeed;

        [TabGroup(MovementTab), ShowInInspector]
        public float Modifier => _character.MovementService.Modifier;

        [TabGroup(MovementTab), ShowInInspector]
        public Vector3 Direction => _character.InputMovementService.RelativeDirection;
        #endregion
        
        #region combat
        private const string CombatTab = "Combat";
        [TabGroup(CombatTab), ShowInInspector]
        public string Health => $"{_character.HealthService.Current}/{_statsController.GetHealth(_character)}";
        
        [TabGroup(CombatTab), ShowInInspector]
        public string Mana => $"{_character.ManaService.Current}/{_statsController.GetMana(_character)}";
        
        [TabGroup(CombatTab), ShowInInspector]
        public string Target => _character.TargetService.Target?.Name ?? string.Empty;
        
        [TabGroup(CombatTab), ShowInInspector]
        public GameObject? TargetGameObject => _character.TargetService.Target?.GameObject;

        [TabGroup(CombatTab), ShowInInspector]
        public bool AutoAttacking => _character.AutoAttackingService.AutoAttacking;

        [TabGroup(CombatTab), ShowInInspector]
        public AutoAttackingState AutoAttackingState => _character.AutoAttackingService.AutoAttackingState;

        [TabGroup(CombatTab), ShowInInspector]
        public float AttackRange => _character.TargetService.Target is not {} target ? float.NaN : _rangeHelper.GetRange(_character, target);

        [TabGroup(CombatTab), ShowInInspector]
        public bool InRange => _character.TargetService.Target is {} target && _rangeHelper.IsInRange(_character, target, Constants.Combat.MeleeRange);
        # endregion
        
        #region threat
        private const string ThreatTab = "Threat";
        [TabGroup(ThreatTab), ShowInInspector]
        public string[] ThreatTable => _character.ThreatService.GetThreatTable().Select(FormatThreat).ToArray();

        private static string FormatThreat(KeyValuePair<Character, float> threatEntry, int index)
        {
            var character = threatEntry.Key;
            var threat = threatEntry.Value;
            
            return $"{index + 1}: {character.Name} ({threat:N})";
        }
        
        #endregion

        #region effects
        private const string EffectsTab = "Effects";

        [TabGroup(EffectsTab), ShowInInspector]
        public string[] Effects => _character.EffectService.ListEffects().Select(FormatEffect).ToArray();

        private static string FormatEffect(IEffect effect, int index)
        {
            var effectType = effect.GetType();
            var effectTypeString = effectType.ToString().Split('.').Last();
            var applicationTime = effect.TimeSinceApplication;
            var duration = effect.Duration;
            
            return $"{index + 1}: {effectTypeString} ({applicationTime.TotalSeconds}/{duration?.TotalSeconds})";
        }
        
        #endregion

        #region concentration
        private const string ConcentrationTab = "Concentration";

        [TabGroup(ConcentrationTab), ShowInInspector]
        public string Concentration => FormatConcentration(_character.ConcentrationService.Concentration);

        private static string FormatConcentration(IConcentration? concentration)
        {
            if (concentration is null) return string.Empty;
            
            var applicationTime = concentration.TimeSinceStarted;
            var duration = concentration.TotalTime;

            return $"{concentration.Text} ({applicationTime.TotalSeconds}/{duration.TotalSeconds})";
        }
        #endregion

        #region inventory
        private const string InventoryTab = "Inventory";

        [TabGroup(InventoryTab), ShowInInspector]
        public ScriptableObject? _item;

        [TabGroup(InventoryTab), Button("Add Item")]
        public void AddItem()
        {
            if (_item is null) return;
            
            var item = _scriptableObjectFactory.CreateObject(_item);
            if (item is not IInventoryItem inventoryItem) return;
            
            _inventoryController.AddItem(_character, inventoryItem);
        }

        private IInventoryItem? GetItemAt(int slot) => _character.InventoryService.ListItems().Skip(slot).FirstOrDefault();
        
        private string Slot1 => GetItemAt(0)?.Name ?? "";
        [Title("Inventory"), TabGroup(InventoryTab), Button("$Slot1")]
        public void UseSlot1() => GetItemAt(0)?.Use(_character);
        
        private string Slot2 => GetItemAt(1)?.Name ?? "";
        [TabGroup(InventoryTab), Button("$Slot2")]
        public void UseSlot2() => GetItemAt(1)?.Use(_character);
        
        private string Slot3 => GetItemAt(2)?.Name ?? "";
        [TabGroup(InventoryTab), Button("$Slot3")]
        public void UseSlot3() => GetItemAt(2)?.Use(_character);
        
        private string Slot4 => GetItemAt(3)?.Name ?? "";
        [TabGroup(InventoryTab), Button("$Slot4")]
        public void UseSlot4() => GetItemAt(3)?.Use(_character);
        
        private string Slot5 => GetItemAt(4)?.Name ?? "";
        [TabGroup(InventoryTab), Button("$Slot5")]
        public void UseSlot5() => GetItemAt(4)?.Use(_character);

        private IEquipment? GetItemAt(EquipmentSlot equipmentSlot) =>
            _equipmentController.GetEquipmentForSlot(_character, equipmentSlot);

        private string GetString(EquipmentSlot equipmentSlot) =>
            $"{equipmentSlot}: {GetItemAt(equipmentSlot)?.Name ?? ""}";

        private string SlotWeaponLeft => GetString(EquipmentSlot.WeaponLeft);
        [Title("Equipment"), TabGroup(InventoryTab), Button("$SlotWeaponLeft")]
        public void LeftWeapon() => _equipmentController.Remove(_character, EquipmentSlot.WeaponLeft);
        
        private string SlotWeaponRight => GetString(EquipmentSlot.WeaponRight);
        [TabGroup(InventoryTab), Button("$SlotWeaponRight")]
        public void RightWeapon() => _equipmentController.Remove(_character, EquipmentSlot.WeaponRight);

        private string SlotRingLeft => GetString(EquipmentSlot.RingLeft);
        [Title("Equipment"), TabGroup(InventoryTab), Button("$SlotRingLeft")]
        public void LeftRing() => _equipmentController.Remove(_character, EquipmentSlot.RingLeft);
        
        private string SlotRingRight => GetString(EquipmentSlot.RingRight);
        [TabGroup(InventoryTab), Button("$SlotRingRight")]
        public void RightRing() => _equipmentController.Remove(_character, EquipmentSlot.RingRight);

        #endregion
        
        [Button]
        public void Kill() => _character.DeathService.Kill();
    }
}