namespace SotnApi.Interfaces
{
    public interface IRenderingApi
    {
        void ColorMapRoom(uint row, uint col, uint color, uint borderColor);
        void ColorMapLocation(uint row, uint col, uint color);
        bool RoomIsRendered(uint row, uint col);
    }
}