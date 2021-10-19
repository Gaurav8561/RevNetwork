using UIEntityMap;

namespace General
{
    public struct EntityUIParameter
    {
        public string StrEntityClassName { get; set; }
        public string StrParameter { get; set; }
        public BaseUIEntityMap.UIEntityPropertyMap.PageModes EUIMRequestMode { get; set; }
    }
}
