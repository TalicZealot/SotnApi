using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using System;

namespace SotnApi
{
    public class RenderingApi : IRenderingApi
    {
        private const int MaximumMapRows = 255;
        private const int MaximumMapCols = 255;
        private const int MaximumColorValue = 0xF;

        private readonly IMemoryApi memAPI;
        public RenderingApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) throw new ArgumentNullException(nameof(memAPI));

            this.memAPI = memAPI;
        }

        public void ColorMapRoom(uint row, uint col, uint color, uint borderColor)
        {
            if (row > MaximumMapRows) throw new ArgumentOutOfRangeException(nameof(row));
            if (col > MaximumMapCols) throw new ArgumentOutOfRangeException(nameof(col));
            if (color > MaximumColorValue) throw new ArgumentOutOfRangeException(nameof(color));
            if (borderColor > MaximumColorValue) throw new ArgumentOutOfRangeException(nameof(borderColor));

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;

            memAPI.WriteByte(start + ((row - 3) * rowOffset) + col, borderColor * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((row - 3) * rowOffset) + col + 1, borderColor * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((row - 3) * rowOffset) + col + 2, borderColor, "GPURAM");

            memAPI.WriteByte(start + ((row - 2) * rowOffset) + col, color * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((row - 2) * rowOffset) + col + 1, color * 0x10 + color, "GPURAM");
            memAPI.WriteByte(start + ((row - 2) * rowOffset) + col + 2, borderColor, "GPURAM");

            memAPI.WriteByte(start + ((row - 1) * rowOffset) + col, color * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((row - 1) * rowOffset) + col + 1, color * 0x10 + color, "GPURAM");
            memAPI.WriteByte(start + ((row - 1) * rowOffset) + col + 2, borderColor, "GPURAM");

            memAPI.WriteByte(start + (row * rowOffset) + col, color * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + (row * rowOffset) + col + 1, color * 0x10 + color, "GPURAM");
            memAPI.WriteByte(start + (row * rowOffset) + col + 2, borderColor, "GPURAM");

            memAPI.WriteByte(start + ((row + 1) * rowOffset) + col, borderColor * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((row + 1) * rowOffset) + col + 1, borderColor * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((row + 1) * rowOffset) + col + 2, borderColor, "GPURAM");
        }

        public void ColorMapLocation(uint row, uint col, uint color)
        {
            if (row > MaximumMapRows) throw new ArgumentOutOfRangeException(nameof(row));
            if (col > MaximumMapCols) throw new ArgumentOutOfRangeException(nameof(col));
            if (color > MaximumColorValue) throw new ArgumentOutOfRangeException(nameof(color));

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;

            memAPI.WriteByte(start + ((row - 1) * rowOffset) + col + 1, color * 0x10 + color, "GPURAM");
            memAPI.WriteByte(start + (row * rowOffset) + col + 1, color * 0x10 + color, "GPURAM");
        }

        public bool RoomIsRendered(uint row, uint col)
        {
            if (row > MaximumMapRows) throw new ArgumentOutOfRangeException(nameof(row));
            if (col > MaximumMapCols) throw new ArgumentOutOfRangeException(nameof(col));

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;
            uint value = memAPI.ReadByte(start + ((row - 3) * rowOffset) + col + 1, "GPURAM");
            return value > 0;
        }
    }
}
