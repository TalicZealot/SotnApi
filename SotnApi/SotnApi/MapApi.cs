using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using System;

namespace SotnApi
{
    public sealed class MapApi : IMapApi
    {
        private const int Height = 207;
        private const int Width = 255;
        private const int MaximumColorValue = 0xF;

        private readonly IMemoryApi memAPI;
        public MapApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) throw new ArgumentNullException(nameof(memAPI));

            this.memAPI = memAPI;
        }

        public void ColorMapRoom(uint x, uint y, uint color, uint borderColor)
        {
            if (y > Height || y < 0) throw new ArgumentOutOfRangeException(nameof(y));
            if (x > Width || x < 0) throw new ArgumentOutOfRangeException(nameof(x));
            if (color > MaximumColorValue) throw new ArgumentOutOfRangeException(nameof(color));
            if (borderColor > MaximumColorValue) throw new ArgumentOutOfRangeException(nameof(borderColor));
            x /= 2;

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;

            memAPI.WriteByte(start + ((y - 1) * rowOffset) + x, borderColor * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((y - 1) * rowOffset) + x + 1, borderColor * 0x10 + borderColor, "GPURAM");
            byte rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y - 1) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y - 1) * rowOffset) + x + 2, rightPixelColor + borderColor, "GPURAM");

            memAPI.WriteByte(start + (y * rowOffset) + x, color * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + (y * rowOffset) + x + 1, color * 0x10 + color, "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + (y * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + (y * rowOffset) + x + 2, rightPixelColor + borderColor, "GPURAM");

            memAPI.WriteByte(start + ((y + 1) * rowOffset) + x, color * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((y + 1) * rowOffset) + x + 1, color * 0x10 + color, "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y + 1) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y + 1) * rowOffset) + x + 2, rightPixelColor + borderColor, "GPURAM");

            memAPI.WriteByte(start + ((y + 2) * rowOffset) + x, color * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((y + 2) * rowOffset) + x + 1, color * 0x10 + color, "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y + 2) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y + 2) * rowOffset) + x + 2, rightPixelColor + borderColor, "GPURAM");

            memAPI.WriteByte(start + ((y + 3) * rowOffset) + x, borderColor * 0x10 + borderColor, "GPURAM");
            memAPI.WriteByte(start + ((y + 3) * rowOffset) + x + 1, borderColor * 0x10 + borderColor, "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y + 3) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y + 3) * rowOffset) + x + 2, rightPixelColor + borderColor, "GPURAM");
        }

        public void ColorMapLocation(uint x, uint y, uint color)
        {
            if (y > Height || y < 0) throw new ArgumentOutOfRangeException(nameof(y));
            if (x > Width || x < 0) throw new ArgumentOutOfRangeException(nameof(x));
            if (color > MaximumColorValue) throw new ArgumentOutOfRangeException(nameof(color));
            bool even = x % 2 == 0;
            x /= 2;

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;

            if (even)
            {
                memAPI.WriteByte(start + (y * rowOffset) + x, color * 0x10 + color, "GPURAM");
                memAPI.WriteByte(start + ((y + 1) * rowOffset) + x, color * 0x10 + color, "GPURAM");
            }
            else
            {
                uint adjusted = color * 0x10 + (byte)((byte)memAPI.ReadByte(start + (y * rowOffset) + x, "GPURAM") & 0x0F);
                memAPI.WriteByte(start + (y * rowOffset) + x, adjusted, "GPURAM");
                adjusted = (byte)((byte)memAPI.ReadByte(start + (y * rowOffset) + x + 1, "GPURAM") & 0xF0) + color;
                memAPI.WriteByte(start + (y * rowOffset) + x + 1, adjusted, "GPURAM");

                adjusted = color * 0x10 + (byte)((byte)memAPI.ReadByte(start + ((y + 1) * rowOffset) + x, "GPURAM") & 0x0F);
                memAPI.WriteByte(start + ((y + 1) * rowOffset) + x, adjusted, "GPURAM");
                adjusted = (byte)((byte)memAPI.ReadByte(start + ((y + 1) * rowOffset) + x + 1, "GPURAM") & 0xF0) + color;
                memAPI.WriteByte(start + ((y + 1) * rowOffset) + x + 1, adjusted, "GPURAM");
            }
        }

        public bool RoomIsRendered(uint x, uint y, uint color)
        {
            if (y > Height) throw new ArgumentOutOfRangeException(nameof(y));
            if (x > Width) throw new ArgumentOutOfRangeException(nameof(x));
            x /= 2;

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;
            uint value = memAPI.ReadByte(start + (y * rowOffset) + x + 1, "GPURAM");
            return value == color;
        }
    }
}
