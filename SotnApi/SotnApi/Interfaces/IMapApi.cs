﻿namespace SotnApi.Interfaces
{
    /// <summary>
    /// Manipulates VRAM elements.
    /// </summary>
    public interface IMapApi
    {
        /// <summary>
        /// Colors a room on the map as a 3x3 square with borders.
        /// </summary>
        void ColorMapRoom(uint x, uint y, uint color, uint borderColor);
        /// <summary>
        /// Colors a location on the map as a 2x2 square.
        /// </summary>
        void ColorMapLocation(uint x, uint y, uint color);
        /// <summary>
        /// Checks if a room on the minimap is rendered.
        /// </summary>
        bool RoomIsRendered(uint x, uint y, uint color);
    }
}