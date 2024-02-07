#nullable enable

namespace Runtime.Abstractions
{
    public interface IOutlineService
    {
        void SetHover(bool state);
        void SetSelected(bool state);
    }
}