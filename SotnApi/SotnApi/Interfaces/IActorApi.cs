using SotnApi.Models;
using System.Collections.Generic;

namespace SotnApi.Interfaces
{
    /// <summary>
    /// Spawns, finds and edits actor entities in memory.
    /// </summary>
    public interface IActorApi
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
        long FindEnemy(int minHp, int maxHp, int[]? bannedHpValues = null);
        /// <summary>
        /// Scans memory for an enemy that matches the hp range specified.
        /// </summary>
        /// <param name="bannedActors">Exclude actors with these values.</param>
        /// <param name="minHp">Minimum allowed actor hp.</param>
        /// <param name="maxHp">Maximum allowed actor hp.</param>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEnemy(int minHp, int maxHp, List<SearchableActor> bannedActors);
        /// <summary>
        /// Scans memory for an enemy from a list of accepted actor property values.
        /// </summary>
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindActorFrom(List<SearchableActor> actors);
        /// <summary>
        /// Scans memory for all active actors.
        /// </summary>
        /// <returns>
        /// A list of addresses where the enemy entities start.
        /// </returns>
        List<long> GetAllActors();
        /// <returns>
        /// Byte range of the enemy entity.
        /// </returns>
        List<byte> GetActor(long address);
        /// <returns>
        /// A LiveActor instance that can be used to edit the in-game entity.
        /// </returns>
        LiveActor GetLiveActor(long address);
        /// <summary>
        /// Copies the actor data to memory. Spawning it in-game.
        /// </summary>
        void SpawnActor(Actor actor);
    }
}