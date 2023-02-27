using BizHawk.Client.Common;
using System;

namespace SotnApi.Models
{
    public sealed class ZoneTransition
    {
        private readonly IMemoryApi memAPI;
        private long address;

        public ZoneTransition(long address, IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
            this.address = address;
        }

        public uint Xpos
        {
            get
            {
                return memAPI.ReadU16(this.address);
            }
            set
            {
                memAPI.WriteU16(this.address, value);
            }
        }
        public uint Ypos
        {
            get
            {
                return memAPI.ReadU16(this.address + 2);
            }
            set
            {
                memAPI.WriteU16(this.address + 2, value);
            }
        }
        public uint Room
        {
            get
            {
                return memAPI.ReadU16(this.address + 4);
            }
            set
            {
                memAPI.WriteU16(this.address + 4, value);
            }
        }
        public uint OriginZone
        {
            get
            {
                return memAPI.ReadU16(this.address + 6);
            }
            set
            {
                memAPI.WriteU16(this.address + 6, value);
            }
        }
        public uint DestinationZone
        {
            get
            {
                return memAPI.ReadU16(this.address + 8);
            }
            set
            {
                memAPI.WriteU16(this.address + 8, value);
            }
        }
    }
}
