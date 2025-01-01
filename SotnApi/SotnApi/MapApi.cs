using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using System;
using System.Diagnostics;

namespace SotnApi
{
    public sealed class MapApi : IMapApi
    {
        private readonly IMemoryApi memAPI;
        public MapApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) throw new ArgumentNullException(nameof(memAPI));

            this.memAPI = memAPI;
        }

        public void ColorMapRoom(byte x, byte y, byte color, byte borderColor)
        {
            x /= 2;
            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;

            memAPI.WriteByte(start + ((y - 1) * rowOffset) + x, (uint)(borderColor * 0x10 + borderColor), "GPURAM");
            memAPI.WriteByte(start + ((y - 1) * rowOffset) + x + 1, (uint)(borderColor * 0x10 + borderColor), "GPURAM");
            byte rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y - 1) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y - 1) * rowOffset) + x + 2, (uint)(rightPixelColor + borderColor), "GPURAM");

            memAPI.WriteByte(start + (y * rowOffset) + x, (uint)(color * 0x10 + borderColor), "GPURAM");
            memAPI.WriteByte(start + (y * rowOffset) + x + 1, (uint)(color * 0x10 + color), "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + (y * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + (y * rowOffset) + x + 2, (uint)(rightPixelColor + borderColor), "GPURAM");

            memAPI.WriteByte(start + ((y + 1) * rowOffset) + x, (uint)(color * 0x10 + borderColor), "GPURAM");
            memAPI.WriteByte(start + ((y + 1) * rowOffset) + x + 1, (uint)(color * 0x10 + color), "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y + 1) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y + 1) * rowOffset) + x + 2, (uint)(rightPixelColor + borderColor), "GPURAM");

            memAPI.WriteByte(start + ((y + 2) * rowOffset) + x, (uint)(color * 0x10 + borderColor), "GPURAM");
            memAPI.WriteByte(start + ((y + 2) * rowOffset) + x + 1, (uint)(color * 0x10 + color), "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y + 2) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y + 2) * rowOffset) + x + 2, (uint)(rightPixelColor + borderColor), "GPURAM");

            memAPI.WriteByte(start + ((y + 3) * rowOffset) + x, (uint)(borderColor * 0x10 + borderColor), "GPURAM");
            memAPI.WriteByte(start + ((y + 3) * rowOffset) + x + 1, (uint)(borderColor * 0x10 + borderColor), "GPURAM");
            rightPixelColor = (byte)((byte)memAPI.ReadByte(start + ((y + 3) * rowOffset) + x + 2, "GPURAM") & 0xF0);
            memAPI.WriteByte(start + ((y + 3) * rowOffset) + x + 2, (uint)(rightPixelColor + borderColor), "GPURAM");
        }

        public void ClearMapRoom(byte x, byte y, byte color, byte borderColor)
        {
            x /= 2;
            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;
            byte value;

            for (int i = -1; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    value = (byte)memAPI.ReadByte(start + ((y + i) * rowOffset) + x + j, "GPURAM");
                    byte highNibble = (byte)((value & 0xF0) >> 4);
                    byte lowNibble = (byte)(value & 0x0F);

                    if (highNibble == color || highNibble == borderColor)
                    {
                        value = (byte)(value & 0x0F);
                    }
                    if (lowNibble == color || lowNibble == borderColor)
                    {
                        value = (byte)(value & 0xF0);
                    }

                    memAPI.WriteByte(start + ((y + i) * rowOffset) + x + j, value, "GPURAM");
                }
            }
        }

        public void ColorMapLocation(byte x, byte y, byte color)
        {
            bool even = x % 2 == 0;
            x /= 2;

            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;

            if (even)
            {
                memAPI.WriteByte(start + (y * rowOffset) + x, (uint)(color * 0x10 + color), "GPURAM");
                memAPI.WriteByte(start + ((y + 1) * rowOffset) + x, (uint)(color * 0x10 + color), "GPURAM");
            }
            else
            {
                uint adjusted = (uint)(color * 0x10 + (byte)((byte)memAPI.ReadByte(start + (y * rowOffset) + x, "GPURAM") & 0x0F));
                memAPI.WriteByte(start + (y * rowOffset) + x, adjusted, "GPURAM");
                adjusted = (uint)((byte)((byte)memAPI.ReadByte(start + (y * rowOffset) + x + 1, "GPURAM") & 0xF0) + color);
                memAPI.WriteByte(start + (y * rowOffset) + x + 1, adjusted, "GPURAM");

                adjusted = (uint)(color * 0x10 + (byte)((byte)memAPI.ReadByte(start + ((y + 1) * rowOffset) + x, "GPURAM") & 0x0F));
                memAPI.WriteByte(start + ((y + 1) * rowOffset) + x, adjusted, "GPURAM");
                adjusted = (uint)((byte)((byte)memAPI.ReadByte(start + ((y + 1) * rowOffset) + x + 1, "GPURAM") & 0xF0) + color);
                memAPI.WriteByte(start + ((y + 1) * rowOffset) + x + 1, adjusted, "GPURAM");
            }
        }

        public bool RoomIsRendered(byte x, byte y, byte color)
        {
            x /= 2;
            long start = Game.VramMapStart;
            long rowOffset = Various.RowOffset;
            uint value = memAPI.ReadByte(start + (y * rowOffset) + x + 1, "GPURAM");
            return value == color;
        }
    }
}
