using SotnApi.Models;
using System.Collections.Generic;

namespace SotnApi.Interfaces
{
    /// <summary>
    /// Spawns, finds and edits actor entities in memory.
    /// </summary>
    public interface IEntityApi
    {
        /// <summary>
        /// Scans memory for an entity matching <paramref name="enemyId"/>.
        /// </summary>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEntity(ushort enemyId, bool enemy = true);
        /// <summary>
        /// Scans memory for an entity matching <paramref name="enemyIds"/>.
        /// </summary>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEntityFrom(List<ushort> enemyIds, bool enemy = true);
        /// <summary>
        /// Scans memory for an entity matching EnemyId and ObjectId from <paramref name="entities"/>.
        /// </summary>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEntityFrom(List<Entity> entities, bool enemy = true);
        /// <summary>
        /// Scans memory for all active entities.
        /// </summary>
        /// <returns>
        /// A list of addresses where the enemy entities start.
        /// </returns>
        List<long> GetAllEntities();
        /// <summary>
        /// Scans memory for all active entities matching <paramref name="enemyIds"/>.
        /// </summary>
        /// <returns>
        /// A list of addresses where the enemy entities start.
        /// </returns>
        public List<long> GetAllEntities(List<ushort> enemyIds);
        /// <returns>
        /// Byte range of the enemy entity.
        /// </returns>
        List<byte> GetEntity(long address);
        /// <returns>
        /// A LiveActor instance that can be used to edit the in-game entity.
        /// </returns>
        Entity GetLiveEntity(long address);
        /// <summary>
        /// Copies the actor data to memory. Spawning it in-game.
        /// </summary>
        /// <returns>
        /// The address, where the actor was spawned.
        /// </returns>
        long SpawnEntity(Entity actor, bool enemy = true);
        /// <summary>
        /// Frees entity at address from memory.
        /// </summary>
        void FreeEntity(long address);
    }
}