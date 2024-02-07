#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Helpers;
using UnityEngine;

namespace Runtime.Game.Helpers
{
    public class CharacterComponentManagementHelper : ICharacterComponentManagementHelper
    {
        public void SetPlayerComponentSettings(Character character, bool isPlayer)
        {
            character.Rigidbody.isKinematic = !isPlayer;
            character.Rigidbody.interpolation = isPlayer ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None;
            character.BehaviorTree.enabled = !isPlayer;
            character.NavMeshMovementService.SetNavigationEnabled(!isPlayer);
            character.Collider.enabled = isPlayer;
        }
    }
}