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
        /// <returns>
        /// The address where the enemy entity starts. Or 0 if the enemy was not found.
        /// </returns>
        long FindEnemy(int minHp, int maxHp);
        /// <returns>
        /// Byte range of the enemy entity.
        /// </returns>
        List<byte> GetActor(long address);
        /// <summary>
        /// Copies the actor data to memory. Spawning it in-game.
        /// </summary>
        void SpawnActor(Actor actor);
    }
}