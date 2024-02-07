# nullable enable

namespace Runtime.Abstractions.Models
{
    public class OutlineSetting
    {
        private OutlineSetting() { }
        
        public bool ShowFront { get; private set; }
        public bool ShowBack { get; private set; }
        

        public static readonly OutlineSetting Selected = new()
        {
            ShowFront = true,
            ShowBack = true,
        };


        public static readonly OutlineSetting Hover = new()
        {
            ShowFront = true,
            ShowBack = true,
        };


        public static readonly OutlineSetting Unselected = new()
        {
            ShowFront = false,
            ShowBack = false,
        };
    }
}