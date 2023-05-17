using BizHawk.Client.Common;
using SotnApi.Constants.Addresses;
using SotnApi.Constants.Values.Game;
using SotnApi.Interfaces;
using SotnApi.Models;
using System;
using System.Collections.Generic;

namespace SotnApi
{
    public sealed class EntityApi : IEntityApi
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

            long address = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                Entity actor = GetLiveEntity(address);
                bool notBanned = true;

                if (bannedHpValues is not null)
                {
                    for (int j = 0; j < bannedHpValues.Length; j++)
                    {
                        if (actor.Hp == bannedHpValues[j])
                        {
                            notBanned = false;
                            break;
                        }
                    }
                }

                if (actor.HitboxHeight > 1 && actor.HitboxWidth > 1 && actor.Hp >= minHp && actor.Hp <= maxHp && actor.Damage > 0 && notBanned)
                {
                    return address;
                }
                address += Entities.Size;
            }

            return 0;
        }

        public long FindEnemyEntity(int minHp, int maxHp, List<SearchableActor> bannedActors)
        {
            if (minHp < 1) { throw new ArgumentOutOfRangeException(nameof(minHp), "minHp must be greater than 0"); }
            if (maxHp < 1) { throw new ArgumentOutOfRangeException(nameof(maxHp), "maxHp must be greater than 0"); }

            long address = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                Entity actor = GetLiveEntity(address);
                bool notBanned = true;

                for (int j = 0; j < bannedActors.Count; j++)
                {
                    if (((bannedActors[j].Damage > 0 && actor.Damage == bannedActors[j].Damage) || bannedActors[j].Damage == 0) &&
                        actor.UpdateFunctionAddress == bannedActors[j].UpdateFunctionAddress)
                    {
                        notBanned = false;
                        break;
                    }
                }

                if (actor.HitboxWidth > 1 && actor.HitboxHeight > 1 && actor.Hp >= minHp && actor.Hp <= maxHp && actor.Damage > 0 && notBanned)
                {
                    return address;
                }
                address += Entities.Size;
            }

            return 0;
        }

        public long FindEntityFrom(List<SearchableActor> actors, bool enemy = true)
        {
            if (actors.Count < 1) { throw new ArgumentOutOfRangeException(nameof(actors), "actors count must be greater than 0"); }

            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;

            for (int i = 0; i < count; i++)
            {
                Entity currentActor = GetLiveEntity(address);
                bool match = false;

                for (int j = 0; j < actors.Count; j++)
                {
                    SearchableActor? actor = actors[j];
                    if (((actor.HitboxWidth > 0 && currentActor.HitboxWidth == actor.HitboxWidth) || currentActor.HitboxWidth > 1) &&
                        ((actor.HitboxHeight > 0 && currentActor.HitboxHeight == actor.HitboxHeight) || currentActor.HitboxHeight > 1) &&
                        ((actor.Xpos > 0 && currentActor.Xpos == actor.Xpos) || actor.Xpos == 0) &&
                        ((actor.Ypos > 0 && currentActor.Ypos == actor.Ypos) || actor.Ypos == 0) &&
                        ((actor.Damage > 0 && currentActor.Damage == actor.Damage) || actor.Damage == 0) &&
                        ((actor.Hp > 0 && currentActor.Hp == actor.Hp) || actor.Hp == 0) &&
                        currentActor.UpdateFunctionAddress == actor.UpdateFunctionAddress)
                    {
                        match = true;
                        break;
                    }
                }

                if (match)
                {
                    return address;
                }
                else
                {
                    address += Entities.Size;
                }
            }

            return 0;
        }

        public List<long> GetAllEntities()
        {
            List<long> ActorAddresses = new();
            long start = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                long hitboxWidth = memAPI.ReadByte(start + Entities.HitboxWidth);
                long hitboxHeight = memAPI.ReadByte(start + Entities.HitboxHeight);
                long hp = memAPI.ReadU16(start + Entities.Hp);
                long damage = memAPI.ReadU16(start + Entities.Damage);
                long sprite = memAPI.ReadU16(start + 22);

                if (hitboxWidth > 0 || hitboxHeight > 0 || hp > 0 || damage > 0 || sprite > 0)
                {
                    ActorAddresses.Add(start);
                }
                start += Entities.Size;
            }

            return ActorAddresses;
        }

        public List<long> GetAllEntities(List<SearchableActor> actors)
        {
            List<long> ActorAddresses = new();
            long address = Game.EnemyEntitiesStart;
            for (int i = 0; i < Entities.EnemyEntitiesCount; i++)
            {
                Entity currentActor = GetLiveEntity(address);

                for (int j = 0; j < actors.Count; j++)
                {
                    SearchableActor? actor = actors[j];
                    if (((actor.HitboxWidth > 0 && currentActor.HitboxWidth == actor.HitboxWidth) || currentActor.HitboxWidth > 1) &&
                        ((actor.HitboxHeight > 0 && currentActor.HitboxHeight == actor.HitboxHeight) || currentActor.HitboxHeight > 1) &&
                        ((actor.Xpos > 0 && currentActor.Xpos == actor.Xpos) || actor.Xpos == 0) &&
                        ((actor.Ypos > 0 && currentActor.Ypos == actor.Ypos) || actor.Ypos == 0) &&
                        currentActor.Hp == actor.Hp && currentActor.Damage == actor.Damage && currentActor.UpdateFunctionAddress == actor.UpdateFunctionAddress)
                    {
                        ActorAddresses.Add(address);
                        break;
                    }
                }

                address += Entities.Size;
            }

            return ActorAddresses;
        }

        public List<byte> GetEntity(long address)
        {
            return memAPI.ReadByteRange(address, Entities.Size);
        }

        public Entity GetLiveEntity(long address)
        {
            return new Entity(address, memAPI);
        }

        /// <summary>
        /// Scans memory for an empty actor slot.
        /// </summary>
        /// <returns>
        /// The address where the slot starts. Or 0 if a free slot was not found.
        /// </returns>
        private long FindAvailableEntitySlot(bool enemy = true)
        {
            long address = enemy ? Game.EnemyEntitiesStart : Game.FriendlyEntitiesStart;
            int count = enemy ? Entities.EnemyEntitiesCount : Entities.FriendEntitiesCount;
            for (int i = 0; i < count; i++)
            {
                Entity entity = GetLiveEntity(address);
                bool reserved = false;

                for (int j = 0; j < Entities.ReservedSlots.Length; j++)
                {
                    if (address == Entities.ReservedSlots[j])
                    {
                        reserved = true;
                    }
                }

                if (entity.HitboxWidth == 0 && entity.HitboxHeight == 0 && entity.Hp == 0 && entity.Damage == 0 && entity.UpdateFunctionAddress == 0 && !reserved)
                {
                    return address;
                }
                address += Entities.Size;
            }

            return 0;
        }

        public long SpawnEntity(Entity actor, bool enemy = true)
        {
            long slot = FindAvailableEntitySlot(enemy);

            if (slot > 0)
            {
                memAPI.WriteByteRange(slot, actor.Data);
            }

            return slot;
        }
    }
}
