using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using SotnApi.Models;
using System;
using System.Collections.Generic;

namespace SotnApi
{
    public class EntityApi : IEntityApi
    {
        private readonly IMemoryApi memAPI;

        public EntityApi(IMemoryApi? memAPI)
        {
            if (memAPI == null) { throw new ArgumentNullException("Memory API is null"); }
            this.memAPI = memAPI;
        }

        public long FindEnemyEntity(int minHp, int maxHp, int[]? bannedHpValues = null)
        {
            if (minHp < 1) { throw new ArgumentOutOfRangeException(nameof(minHp), "minHp must be greater than 0"); }
            if (maxHp < 1) { throw new ArgumentOutOfRangeException(nameof(maxHp), "maxHp must be greater than 0"); }

            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                LiveEntity actor = GetLiveEntity(start);
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
                start += Entities.Offset;
            }

            return 0;
        }

        public long FindEnemyEntity(int minHp, int maxHp, List<SearchableActor> bannedActors)
        {
            if (minHp < 1) { throw new ArgumentOutOfRangeException(nameof(minHp), "minHp must be greater than 0"); }
            if (maxHp < 1) { throw new ArgumentOutOfRangeException(nameof(maxHp), "maxHp must be greater than 0"); }

            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                LiveEntity actor = GetLiveEntity(start);
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
                start += Entities.Offset;
            }

            return 0;
        }

        public long FindEntityFrom(List<SearchableActor> actors, bool enemy = true)
        {
            if (actors.Count < 1) { throw new ArgumentOutOfRangeException(nameof(actors), "actors count must be greater than 0"); }

            long start = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;

            for (int i = 0; i < count; i++)
            {
                LiveEntity currentActor = GetLiveEntity(start);
                bool match = false;

                foreach (var actor in actors)
                {
                    if (((actor.HitboxWidth > 0 && currentActor.HitboxWidth == actor.HitboxWidth) || currentActor.HitboxWidth > 1) &&
                        ((actor.HitboxHeight > 0 && currentActor.HitboxHeight == actor.HitboxHeight) || currentActor.HitboxHeight > 1) &&
                        ((actor.Xpos > 0 && currentActor.Xpos == actor.Xpos) || actor.Xpos == 0) &&
                        ((actor.Ypos > 0 && currentActor.Ypos == actor.Ypos) || actor.Ypos == 0) &&
                        ((actor.Damage > 0 && currentActor.Damage == actor.Damage) || actor.Damage == 0) &&
                        ((actor.Hp > 0 && currentActor.Hp == actor.Hp) || actor.Hp == 0) &&
                        currentActor.Sprite == actor.Sprite)
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
                    start += Entities.Offset;
                }
            }

            return 0;
        }

        public List<long> GetAllActors()
        {
            List<long> ActorAddresses = new();
            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Entities.HitboxWidthOffset);
                long hitboxHeight = memAPI.ReadByte(start + Entities.HitboxHeightOffset);
                long hp = memAPI.ReadU16(start + Entities.HpOffset);
                long damage = memAPI.ReadU16(start + Entities.DamageOffset);
                long sprite = memAPI.ReadU16(start + 22);

                if (hitboxWidth > 0 || hitboxHeight > 0 || hp > 0 || damage > 0 || sprite > 0)
                {
                    ActorAddresses.Add(start);
                }
                start += Entities.Offset;
            }

            return ActorAddresses;
        }

        public List<long> GetAllActors(List<SearchableActor> actors)
        {
            List<long> ActorAddresses = new();
            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                LiveEntity currentActor = GetLiveEntity(start);

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

                start += Entities.Offset;
            }

            return ActorAddresses;
        }

        public List<byte> GetEntity(long address)
        {
            return memAPI.ReadByteRange(address, Entities.Size);
        }

        public LiveEntity GetLiveEntity(long address)
        {
            return new LiveEntity(address, memAPI);
        }

        /// <summary>
        /// Scans memory for an empty actor slot.
        /// </summary>
        /// <returns>
        /// The address where the slot starts. Or 0 if a free slot was not found.
        /// </returns>
        private long FindAvailableEntitySlot(bool enemy = true)
        {
            long start = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;
            for (int i = 0; i < count; i++)
            {
                LiveEntity entity = GetLiveEntity(start);
                bool reserved = false;

                foreach (var slot in Entities.ReservedSlots)
                {
                    if (start == slot)
                    {
                        reserved = true;
                    }
                }

                if (entity.HitboxWidth == 0 && entity.HitboxHeight == 0 && entity.Hp == 0 && entity.Damage == 0 && entity.Sprite == 0 && !reserved)
                {
                    return start;
                }
                start += Entities.Offset;
            }

            return 0;
        }

        public long SpawnEntity(Entity actor, bool enemy = true)
        {
            long slot = FindAvailableEntitySlot(enemy);

            if (slot > 0)
            {
                memAPI.WriteByteRange(slot, actor.Value);
            }

            return slot;
        }
    }
}
