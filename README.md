## Introduction

This is a sparse checkout of a Unity RPG, trying to implement a single-player game, inspired by World of Warcraft.

## Standards

Due to the complex interactions between subsystems in the game, I've made several architectural decision.

### Entity naming

To help the understanding of entities in the game, I've stuck to a strict naming scheme:

- `Controller` contains the business logic of it's domain. For example, [`IThreatController`](Assets/Scripts/Runtime/Abstractions/Controller/IThreatController.cs) will be the entry point of any logic interacting with threat. Controllers are game-wide (globally scoped). They are not character-specific and do not contain state.

- `Service` contains data and behavior of some domain for each character. For example, [`IThreatService`](Assets/Scripts/Runtime/Abstractions/Services/IThreatService.cs) will have methods to get and modify the threat table of a single character. Services are scoped such that there is one for each character. They may contain state.

- `Manager` is the only globally scoped entities that can contain state. For example, the [`IPlayerCharacterManager`](Assets/Scripts/Runtime/Abstractions/Managers/IPlayerCharacterManager.cs) has the current player character. Managers are globally scoped and can contain state.

- `Component` are `MonoBehavior` derivatives. They are the entities that have interactions with Unity as e.g. serialized fields. For example, [`IMouseComponent`](Assets/Scripts/Runtime/Abstractions/Components/IOutlineComponent.cs) is an interface that is requested when raycasting for the mouse pointer, see [`MouseController`](Assets/Scripts/Runtime/Game/Controllers/MouseController.cs). Components are scoped based on unity entity. There will be some in the scene and each character will have some. They can contain state.

### Entity registration

Entities are registered to zenject in two installers, depending on the scope of the entity.

[`GlobalInstaller`](Assets/Scripts/Runtime/DI/Installers/GlobalInstaller.cs) contains the registration for entities that are globally scoped, ie. not by character.

[`CharacterInstaller`](Assets/Scripts/Runtime/DI/Installers/CharacterInstaller.cs) contains the registration for entities for each character, ie. services and character components.

### Project structure

Generally, the core mechanics are available next to eachother as controller interfaces in `Abstractions.Controllers`. The `Game` namespace has implementations for interfaces. In addition, there are namespaces that sit "on top" of the core modules, to enable maximum flexibility for these systems. These systems are `Game.Effects`, `Game.Spells` which also has a dependency on the effects, and `Game.Tasks` which has the tasks for the AI behavior tree.

The `DI` namespace sits on top again and is the only project allowed to interact with the IOC container. This is done in installers but it is sometimes necessary to inject into newly created entities. This is done in `DI.Factories`, e.g. [SpellFactory](Assets/Scripts/Runtime/DI/Factories/SpellFactory.cs), which resolves a spell from the IOC, allowing the spell to utilize dependency injection while being initialized at runtime.
