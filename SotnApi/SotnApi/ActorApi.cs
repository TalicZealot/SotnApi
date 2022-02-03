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

            long start = Game.EnemyActorsStart;
            for (int i = 0; i < Actors.EnemiesCount; i++)
            {
                LiveActor actor = GetLiveActor(start);
                bool notBanned = true;

                if (bannedHpValues is not null)
                {
                    foreach (int bannedHp in bannedHpValues)
                    {
                        if (actor.Hp == bannedHp)
                        {
                            notBanned = false;
                            break;
                        }
                    }
                }

                if (actor.HitboxHeight > 1 && actor.HitboxWidth > 1 && actor.Hp >= minHp && actor.Hp <= maxHp && actor.Damage > 0 && notBanned)
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

            long start = Game.EnemyActorsStart;
            for (int i = 0; i < Actors.EnemiesCount; i++)
            {
                LiveActor actor = GetLiveActor(start);
                bool notBanned = true;

                foreach (var bannedActor in bannedActors)
                {
                    if (((bannedActor.Damage > 0 && actor.Damage == bannedActor.Damage) || bannedActor.Damage == 0) &&
                        actor.Sprite == bannedActor.Sprite)
                    {
                        notBanned = false;
                        break;
                    }
                }

                if (actor.HitboxWidth > 1 && actor.HitboxHeight > 1 && actor.Hp >= minHp && actor.Hp <= maxHp && actor.Damage > 0 && notBanned)
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

            long start = Game.EnemyActorsStart;
            for (int i = 0; i < Actors.EnemiesCount; i++)
            {
                LiveActor currentActor = GetLiveActor(start);
                bool match = false;

                foreach (var actor in actors)
                {
                    if (((actor.HitboxWidth > 0 && currentActor.HitboxWidth == actor.HitboxWidth) || currentActor.HitboxWidth > 1) &&
                        ((actor.HitboxHeight > 0 && currentActor.HitboxHeight == actor.HitboxHeight) || currentActor.HitboxHeight > 1) &&
                        ((actor.Xpos > 0 && currentActor.Xpos == actor.Xpos) || actor.Xpos == 0) &&
                        ((actor.Ypos > 0 && currentActor.Ypos == actor.Ypos) || actor.Ypos == 0) &&
                        currentActor.Hp == actor.Hp && currentActor.Damage == actor.Damage && currentActor.Sprite == actor.Sprite)
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
            long start = Game.EnemyActorsStart;
            for (int i = 0; i < Actors.EnemiesCount; i++)
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

        public List<long> GetAllActors(List<SearchableActor> actors)
        {
            List<long> ActorAddresses = new();
            long start = Game.EnemyActorsStart;
            for (int i = 0; i < Actors.EnemiesCount; i++)
            {
                LiveActor currentActor = GetLiveActor(start);

                foreach (var actor in actors)
                {
                    if (((actor.HitboxWidth > 0 && currentActor.HitboxWidth == actor.HitboxWidth) || currentActor.HitboxWidth > 1) &&
                        ((actor.HitboxHeight > 0 && currentActor.HitboxHeight == actor.HitboxHeight) || currentActor.HitboxHeight > 1) &&
                        ((actor.Xpos > 0 && currentActor.Xpos == actor.Xpos) || actor.Xpos == 0) &&
                        ((actor.Ypos > 0 && currentActor.Ypos == actor.Ypos) || actor.Ypos == 0) &&
                        currentActor.Hp == actor.Hp && currentActor.Damage == actor.Damage && currentActor.Sprite == actor.Sprite)
                    {
                        ActorAddresses.Add(start);
                        break;
                    }
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
        private long FindAvailableActorSlot(bool enemy = true)
        {
            long start = enemy ? Game.EnemyActorsStart : Game.FriendlyActorsStart;
            int count = enemy ? Actors.EnemiesCount : Actors.FriendActorsCount;
            for (int i = 0; i < count; i++)
            {
                LiveActor actor = GetLiveActor(start);
                bool reserved = false;

                foreach (var slot in Actors.ReservedSlots)
                {
                    if (start == slot)
                    {
                        reserved = true;
                    }
                }

                if (actor.HitboxWidth == 0 && actor.HitboxHeight == 0 && actor.Hp == 0 && actor.Damage == 0 && actor.Sprite == 0 && !reserved)
                {
                    return start;
                }
                start += Actors.Offset;
            }

            return 0;
        }

        public long SpawnActor(Actor actor, bool enemy = true)
        {
            long slot = FindAvailableActorSlot(enemy);

            if (slot > 0)
            {
                memAPI.WriteByteRange(slot, actor.Value);
            }

            return slot;
        }
    }
}
