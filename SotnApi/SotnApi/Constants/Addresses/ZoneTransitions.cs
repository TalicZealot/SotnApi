using SotnApi.Constants.Values.Game.Enums;
using System.Collections.Generic;

namespace SotnApi.Constants.Addresses
{
    public static class ZoneTransitionAddresses
    {
        public static readonly Dictionary<Zone, long> CastleEntrance = new Dictionary<Zone, long>
        {
            { Zone.MarbleGallery, 0x0A268C },
            { Zone.UndergroundCaverns, 0x0A2696 },
            { Zone.AlchemyLaboratory, 0x0A26A0 },
            { Zone.Warp, 0x0A26AA },
        };
        public static readonly Dictionary<Zone, long> AlchemyLaboratory = new Dictionary<Zone, long>
        {
            { Zone.CastleEntrance, 0x0A252E },
            { Zone.MarbleGallery, 0x0A2538 },
            { Zone.RoyalChapel, 0x0A2542 },
        };
        public static readonly Dictionary<Zone, long> Colosseum = new Dictionary<Zone, long>
        {
            {Zone.RoyalChapel, 0x0A2664},
            {Zone.OlroxsQuarters, 0x0A266E},
        };
        public static readonly Dictionary<Zone, long> OlroxsQuarters = new Dictionary<Zone, long>
        {
            { Zone.MarbleGallery, 0x0A254C },
            { Zone.RoyalChapel, 0x0A2556 },
            { Zone.Colosseum, 0x0A2560 },
            { Zone.Warp, 0x0A256A },
        };
        public static readonly Dictionary<Zone, long> RoyalChapel = new Dictionary<Zone, long>
        {
            { Zone.OlroxsQuarters, 0x0A25A6 },
            { Zone.Colosseum, 0x0A25B0 },
            { Zone.AlchemyLaboratory, 0x0A25BA },
            { Zone.CastleKeep, 0x0A25C4 },
        };
        public static readonly Dictionary<Zone, long> Warp = new Dictionary<Zone, long>
        {
            { Zone.CastleKeep, 0x0A2574 },
            { Zone.OuterWall, 0x0A257E },
            { Zone.OlroxsQuarters, 0x0A2588 },
            { Zone.CastleEntrance, 0x0A2592 },
            { Zone.AbandonedMine, 0x0A259C },
        };
        public static readonly Dictionary<Zone, long> MarbleGallery = new Dictionary<Zone, long>
        {
            { Zone.AlchemyLaboratory, 0x0A245C },
            { Zone.OlroxsQuarters, 0x0A2466 },
            { Zone.OuterWall, 0x0A2470 },
            { Zone.CastleEntrance, 0x0A247A },
            { Zone.UndergroundCaverns, 0x0A2484 },
            { Zone.CenterCube, 0x0A248E },
        };
        public static readonly Dictionary<Zone, long> LongLibrary = new Dictionary<Zone, long>
        {
            { Zone.OuterWall, 0x0A2498 },
        };
        public static readonly Dictionary<Zone, long> ClockTower = new Dictionary<Zone, long>
        {
            { Zone.CastleKeep, 0x0A24B6 },
            { Zone.OuterWall, 0x0A24C0 },
        };
        public static readonly Dictionary<Zone, long> CastleKeep = new Dictionary<Zone, long>
        {
            { Zone.ClockTower, 0x0A261E },
            { Zone.Warp, 0x0A2628 },
            { Zone.RoyalChapel, 0x0A2632 },
        };
        public static readonly Dictionary<Zone, long> UndergroundCaverns = new Dictionary<Zone, long>
        {
            { Zone.AbandonedMine, 0x0A2650 },
            { Zone.MarbleGallery, 0x0A2646 },
            { Zone.Nightmare, 0x0A265A },
            { Zone.CastleEntrance, 0x0A263C },
        };
        public static readonly Dictionary<Zone, long> AbandonedMine = new Dictionary<Zone, long>
        {
            { Zone.UndergroundCaverns, 0x0A251A },
            { Zone.Warp, 0x0A2524 },
            { Zone.Catacombs, 0x0A2510 },
        };
        public static readonly Dictionary<Zone, long> Catacombs = new Dictionary<Zone, long>
        {
            { Zone.AbandonedMine, 0x0A24FC },
        };
        public static readonly Dictionary<Zone, long> OuterWall = new Dictionary<Zone, long>
        {
            { Zone.MarbleGallery, 0x0A25EC },
            { Zone.LongLibrary, 0x0A25F6 },
            { Zone.Warp, 0x0A2600 },
            { Zone.ClockTower, 0x0A260A },
        };
    }
}
