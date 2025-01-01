namespace SotnApi.Interfaces
{
    /// <summary>
    /// Manipulates VRAM elements.
    /// </summary>
    public interface IMapApi
    {
        /// <summary>
        /// Colors a room on the map as a 3x3 square with borders.
        /// </summary>
        void ColorMapRoom(byte x, byte y, byte color, byte borderColor);
        /// <summary>
        /// Clears non-vanilla colors from a room.
        /// </summary>
        void ClearMapRoom(byte x, byte y, byte color, byte borderColor);
        /// <summary>
        /// Colors a location on the map as a 2x2 square.
        /// </summary>
        void ColorMapLocation(byte x, byte y, byte color);
        /// <summary>
        /// Checks if a room on the minimap is rendered.
        /// </summary>
        bool RoomIsRendered(byte x, byte y, byte color);
    }
}