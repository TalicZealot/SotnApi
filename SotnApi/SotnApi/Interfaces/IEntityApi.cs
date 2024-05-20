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
        /// Scans memory for an enemy that matches the hp range specified.
        /// </summary>
        /// <param name="bannedHpValues">Exclude actors with these hp values.</param>
        /// <param name="minHp">Minimum allowed actor hp.</param>
        /// <param name="maxHp">Maximum allowed actor hp.</param>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEnemyEntity(int minHp, int maxHp, int[]? bannedHpValues = null);
        /// <summary>
        /// Scans memory for an enemy that matches the hp range specified.
        /// </summary>
        /// <param name="bannedActors">Exclude actors with these values.</param>
        /// <param name="minHp">Minimum allowed actor hp.</param>
        /// <param name="maxHp">Maximum allowed actor hp.</param>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEnemyEntity(int minHp, int maxHp, List<Entity> bannedActors);
        /// <summary>
        /// Scans memory for an enemy from a list of accepted actor property values.
        /// </summary>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEntityFrom(List<Entity> actors, bool enemy = true);
        /// <summary>
        /// Scans memory for all active entities.
        /// </summary>
        /// <returns>
        /// A list of addresses where the enemy entities start.
        /// </returns>
        List<long> GetAllEntities();
        /// <summary>
        /// Scans memory for all active entities, that match <paramref name="actors"/>.
        /// </summary>
        /// <returns>
        /// A list of addresses where the enemy entities start.
        /// </returns>
        public List<long> GetAllEntities(List<Entity> actors);
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
    }
}