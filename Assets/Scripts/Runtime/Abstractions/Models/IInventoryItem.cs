#nullable enable

namespace Runtime.Abstractions.Models
{
    public interface IInventoryItem
    {
        public string Name { get; }

        void Use(Character user);
    }
}