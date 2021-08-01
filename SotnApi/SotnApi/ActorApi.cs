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
                long sprite = memAPI.ReadU16(start + Actors.SpriteOffset);
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

        public long FindEnemy(int minHp, int maxHp, List<SearchableActor> bannedActors)
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
                long sprite = memAPI.ReadU16(start + Actors.SpriteOffset);
                bool notBanned = true;

                foreach (var bannedActor in bannedActors)
                {
                    if (hp <= bannedActor.Hp && sprite == bannedActor.Sprite && damage == bannedActor.Damage)
                    {
                        notBanned = false;
                        break;
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

        public long FindActorFrom(List<SearchableActor> actors)
        {
            if (actors.Count < 1) { throw new ArgumentOutOfRangeException(nameof(actors), "actors count must be greater than 0"); }

            long start = Game.ActorsStart;
            for (int i = 0; i < Actors.Count; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Actors.HitboxWidthOffset);
                long hitboxHeight = memAPI.ReadByte(start + Actors.HitboxHeightOffset);
                long hp = memAPI.ReadU16(start + Actors.HpOffset);
                long damage = memAPI.ReadU16(start + Actors.DamageOffset);
                long sprite = memAPI.ReadU16(start + Actors.SpriteOffset);
                bool match = false;

                foreach (var actor in actors)
                {
                    if (hitboxWidth > 1 && hitboxHeight > 1 && hp == actor.Hp && damage == actor.Damage && sprite == actor.Sprite)
                    {
                        match = true;
                        break;
                    }
                }

                if (match)
                {
                    return start;
                }
                else
                {
                    start += Actors.Offset;
                }
            }

            return 0;
        }

        public List<long> GetAllActors()
        {
            List<long> ActorAddresses = new();
            long start = Game.ActorsStart;
            for (int i = 0; i < Actors.Count; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Actors.HitboxWidthOffset);
                long hitboxHeight = memAPI.ReadByte(start + Actors.HitboxHeightOffset);
                long hp = memAPI.ReadU16(start + Actors.HpOffset);
                long damage = memAPI.ReadU16(start + Actors.DamageOffset);
                long sprite = memAPI.ReadU16(start + 22);

                if (hitboxWidth > 0 || hitboxHeight > 0 || hp > 0 || damage > 0 || sprite > 0)
                {
                    ActorAddresses.Add(start);
                }
                start += Actors.Offset;
            }

            return ActorAddresses;
        }

        public List<byte> GetActor(long address)
        {
            return memAPI.ReadByteRange(address, Actors.Size);
        }

        public LiveActor GetLiveActor(long address)
        {
            return new LiveActor(address, memAPI);
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
                long sprite = memAPI.ReadU16(start + Actors.SpriteOffset);

                if (hitboxWidth == 0 && hitboxHeight == 0 && hp == 0 && damage == 0 && sprite == 0)
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
