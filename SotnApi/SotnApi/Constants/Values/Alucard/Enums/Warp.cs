using System;

namespace SotnApi.Constants.Values.Alucard.Enums
{
    [Flags]
    public enum Warp
    {
        Entrance = 0b_0000_0001,  // 1
        Mines = 0b_0000_0010,  // 2
        OuterWall = 0b_0000_0100,  // 4
        Keep = 0b_0000_1000,  // 8
        Olrox = 0b_0001_0000,  // 16
    }
}
