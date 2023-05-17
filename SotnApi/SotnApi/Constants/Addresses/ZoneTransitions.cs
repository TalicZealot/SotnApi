using SotnApi.Constants.Values.Game.Enums;
using System.Collections.Generic;

namespace SotnApi.Constants.Addresses
{
    public static class ZoneTransitionAddresses
    {
        public static readonly Dictionary<Stage, long> CastleEntrance = new Dictionary<Stage, long>
        {
            { Stage.MarbleGallery, 0x0A268C },
            { Stage.UndergroundCaverns, 0x0A2696 },
            { Stage.AlchemyLaboratory, 0x0A26A0 },
            { Stage.Warp, 0x0A26AA },
        };
        public static readonly Dictionary<Stage, long> AlchemyLaboratory = new Dictionary<Stage, long>
        {
            { Stage.CastleEntrance, 0x0A252E },
            { Stage.MarbleGallery, 0x0A2538 },
            { Stage.RoyalChapel, 0x0A2542 },
        };
        public static readonly Dictionary<Stage, long> Colosseum = new Dictionary<Stage, long>
        {
            {Stage.RoyalChapel, 0x0A2664},
            {Stage.OlroxsQuarters, 0x0A266E},
        };
        public static readonly Dictionary<Stage, long> OlroxsQuarters = new Dictionary<Stage, long>
        {
            { Stage.MarbleGallery, 0x0A254C },
            { Stage.RoyalChapel, 0x0A2556 },
            { Stage.Colosseum, 0x0A2560 },
            { Stage.Warp, 0x0A256A },
        };
        public static readonly Dictionary<Stage, long> RoyalChapel = new Dictionary<Stage, long>
        {
            { Stage.OlroxsQuarters, 0x0A25A6 },
            { Stage.Colosseum, 0x0A25B0 },
            { Stage.AlchemyLaboratory, 0x0A25BA },
            { Stage.CastleKeep, 0x0A25C4 },
        };
        public static readonly Dictionary<Stage, long> Warp = new Dictionary<Stage, long>
        {
            { Stage.CastleKeep, 0x0A2574 },
            { Stage.OuterWall, 0x0A257E },
            { Stage.OlroxsQuarters, 0x0A2588 },
            { Stage.CastleEntrance, 0x0A2592 },
            { Stage.AbandonedMine, 0x0A259C },
        };
        public static readonly Dictionary<Stage, long> MarbleGallery = new Dictionary<Stage, long>
        {
            { Stage.AlchemyLaboratory, 0x0A245C },
            { Stage.OlroxsQuarters, 0x0A2466 },
            { Stage.OuterWall, 0x0A2470 },
            { Stage.CastleEntrance, 0x0A247A },
            { Stage.UndergroundCaverns, 0x0A2484 },
            { Stage.CenterCube, 0x0A248E },
        };
        public static readonly Dictionary<Stage, long> LongLibrary = new Dictionary<Stage, long>
        {
            { Stage.OuterWall, 0x0A2498 },
        };
        public static readonly Dictionary<Stage, long> ClockTower = new Dictionary<Stage, long>
        {
            { Stage.CastleKeep, 0x0A24B6 },
            { Stage.OuterWall, 0x0A24C0 },
        };
        public static readonly Dictionary<Stage, long> CastleKeep = new Dictionary<Stage, long>
        {
            { Stage.ClockTower, 0x0A261E },
            { Stage.Warp, 0x0A2628 },
            { Stage.RoyalChapel, 0x0A2632 },
        };
        public static readonly Dictionary<Stage, long> UndergroundCaverns = new Dictionary<Stage, long>
        {
            { Stage.AbandonedMine, 0x0A2650 },
            { Stage.MarbleGallery, 0x0A2646 },
            { Stage.Nightmare, 0x0A265A },
            { Stage.CastleEntrance, 0x0A263C },
        };
        public static readonly Dictionary<Stage, long> AbandonedMine = new Dictionary<Stage, long>
        {
            { Stage.UndergroundCaverns, 0x0A251A },
            { Stage.Warp, 0x0A2524 },
            { Stage.Catacombs, 0x0A2510 },
        };
        public static readonly Dictionary<Stage, long> Catacombs = new Dictionary<Stage, long>
        {
            { Stage.AbandonedMine, 0x0A24FC },
        };
        public static readonly Dictionary<Stage, long> OuterWall = new Dictionary<Stage, long>
        {
            { Stage.MarbleGallery, 0x0A25EC },
            { Stage.LongLibrary, 0x0A25F6 },
            { Stage.Warp, 0x0A2600 },
            { Stage.ClockTower, 0x0A260A },
        };
    }
}
