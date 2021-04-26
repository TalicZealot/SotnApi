using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using SotnApi.Models;
using System;
using System.Collections.Generic;

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

        public long FindEnemy(int minHp, int maxHp, int[]? bannedHpValues = null)
        {
            if (minHp < 1) { throw new ArgumentOutOfRangeException(nameof(minHp), "minHp must be greater than 0"); }
            if (maxHp < 1) { throw new ArgumentOutOfRangeException(nameof(maxHp), "maxHp must be greater than 0"); }

            long start = Game.ActorsStart;
            for (int i = 0; i < Actors.Count; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Actors.HitboxWidthOffset);
                long hitboxHeight = memAPI.ReadByte(start + Actors.HitboxHeightOffset);
                long hp = memAPI.ReadU16(start + Actors.HpOffset);
                long damage = memAPI.ReadU16(start + Actors.DamageOffset);
                bool notBanned = true;

                if (bannedHpValues is not null)
                {
                    foreach (int bannedHp in bannedHpValues)
                    {
                        if (hp == bannedHp)
                        {
                            notBanned = false;
                            break;
                        }
                    }
                }

                if (hitboxWidth > 1 && hitboxHeight > 1 && hp >= minHp && hp <= maxHp && damage > 0 && notBanned)
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
                long hp = memAPI.ReadU16(start + Actors.HpOffset);
                long damage = memAPI.ReadU16(start + Actors.DamageOffset);

                if (hitboxWidth == 0 && hitboxHeight == 0 && hp == 0 && damage == 0)
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
