namespace SotnApi.Interfaces
{
    public interface IRenderingApi
    {
        void ColorMapRoom(uint row, uint col, uint color, uint borderColor);
        bool RoomIsRendered(uint row, uint col);
    }
}