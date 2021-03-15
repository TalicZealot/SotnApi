using System;
using System.Collections.Generic;
using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using SotnApi.Models;

namespace SotnApi
{
    public class ActorApi : IActorApi
    {
        private readonly IMemoryApi memAPI;

        public ActorApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
        }

        public long FindEnemy(int minHp, int maxHp)
        {
            if (minHp < 0) { throw new ArgumentOutOfRangeException(nameof(minHp), "minHp can't be negative"); }
            if (maxHp < 1) { throw new ArgumentOutOfRangeException(nameof(maxHp),"maxHp must be greater than 0"); }

            long start = Game.ActorsStart;
            for (int i = 0; i < Actors.Count; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Actors.HitboxWidthOffset);
                long hitboxHeight = memAPI.ReadByte(start + Actors.HitboxHeightOffset);
                long hp = memAPI.ReadByte(start + Actors.HpOffset);

                if (hitboxWidth > 2 && hitboxHeight > 2 && hp > minHp && hp <= maxHp)
                {
                    return start;
                }
                start += Actors.Offset;
            }

            return 0;
        }

        public List<byte> GetActor(long address)
        {
            return memAPI.ReadByteRange(address, Actors.Size);
        }

        /// <summary>
        /// Scans memory for an empty actor slot.
        /// </summary>
        /// <returns>
        /// The address where the slot starts. Or 0 if a free slot was not found.
        /// </returns>
        private long FindAvailableActorSlot()
        {
            long start = Game.ActorsStart;
            for (int i = 0; i < Actors.Count; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Actors.HitboxWidthOffset);
                long hitboxHeight = memAPI.ReadByte(start + Actors.HitboxHeightOffset);

                if (hitboxWidth == 0 && hitboxHeight == 0)
                {
                    return start;
                }
                start += Actors.Offset;
            }

            return 0;
        }

        public void SpawnActor(Actor actor)
        {
            long slot = FindAvailableActorSlot();

            if (slot > 0)
            {
                memAPI.WriteByteRange(slot, actor.Value);
            }
        }
    }
}
