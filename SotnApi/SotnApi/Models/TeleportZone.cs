﻿namespace SotnApi.Models
{
    public sealed class TeleportZone
    {
        public ushort Zone { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public uint Room { get; set; }
    }
}