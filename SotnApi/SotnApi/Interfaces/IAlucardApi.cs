using SotnApi.Constants.Values.Alucard.Enums;

namespace SotnApi.Interfaces
{
    public interface IAlucardApi
    {
        uint CurrentHp { get; set; }
        uint MaxtHp { get; set; }
        uint CurrentMp { get; set; }
        uint MaxtMp { get; set; }
        uint CurrentHearts { get; set; }
        uint MaxtHearts { get; set; }
        uint Str { get; set; }
        uint Con { get; set; }
        uint Int { get; set; }
        uint Lck { get; set; }
        uint Gold { get; set; }
        uint Level { get; set; }
        uint Experiecne { get; set; }
        uint Rooms { get; set; }
        uint WarpsFirstCastle { get; set; }
        uint WarpsSecondCastle { get; set; }
        bool WarpEntrance { get; set; }
        bool WarpMines { get; set; }
        bool WarpOuterWall { get; set; }
        bool WarpKeep { get; set; }
        bool WarpOlrox { get; set; }
        bool WarpInvertedEntrance { get; set; }
        bool WarpInvertedMines { get; set; }
        bool WarpInvertedOuterWall { get; set; }
        bool WarpInvertedKeep { get; set; }
        bool WarpInvertedOlrox { get; set; }
        bool OuterWallElevator { get; set; }
        bool EntranceToMarble { get; set; }
        bool AlchemyElevator { get; set; }
        bool ChapelStatue { get; set; }
        bool ColosseumElevator { get; set; }
        bool ColosseumToChapel { get; set; }
        bool MarbleBlueDoor { get; set; }
        bool CavernsSwitchAndBridge { get; set; }
        bool EntranceToCaverns { get; set; }
        bool EntranceWarp { get; set; }
        bool FirstClockRoomDoor { get; set; }
        bool SecondClockRoomDoor { get; set; }
        bool FirstDemonButton { get; set; }
        bool SecondDemonButton { get; set; }
        bool KeepStairs { get; set; }
        /// <summary> Wing Smash speed in pixels per frame. </summary>
        uint WingsmashHorizontalSpeed { get; set; }
        /// <summary> Alucard walking speed in pixels per frame. </summary>
        uint WalkingWholeSpeed { get; set; }
        /// <summary> Alucard walking fractional speed. </summary>
        uint WalkingFractSpeed { get; set; }
        /// <summary> Alucard jumping horizontal speed in pixels per frame. </summary>
        uint JumpingHorizontalWholeSpeed { get; set; }
        /// <summary> Alucard jumping horizontal fractional speed. </summary>
        uint JumpingHorizontalFractSpeed { get; set; }
        /// <summary> Alucard jumping horizontal speed in pixels per frame. </summary>
        uint JumpingAttackLeftHorizontalWholeSpeed { get; set; }
        /// <summary> Alucard jumping horizontal fractional speed. </summary>
        uint JumpingAttackLeftHorizontalFractSpeed { get; set; }
        /// <summary> Alucard jumping horizontal speed in pixels per frame. </summary>
        uint JumpingAttackRightHorizontalWholeSpeed { get; set; }
        /// <summary> Alucard jumping horizontal fractional speed. </summary>
        uint JumpingAttackRightHorizontalFractSpeed { get; set; }

        /// <summary> Alucard falling horizontal speed in pixels per frame. </summary>
        uint FallingHorizontalWholeSpeed { get; set; }
        /// <summary> Alucard falling horizontal fractional speed. </summary>
        uint FallingHorizontalFractSpeed { get; set; }
        /// <summary> Alucard standard wolf dash going left to right maximum speed in pixels per frame. </summary>
        sbyte WolfDashTopRightSpeed { get; set; }
        /// <summary> Alucard standard wolf dash going right to left maximum speed in pixels per frame. </summary>
        sbyte WolfDashTopLeftSpeed { get; set; }
        /// <summary> Alucard backdash deceleration rate. </summary>
        uint BackdashDecel { get; set; }
        uint RightHand { get; set; }
        uint LeftHand { get; set; }
        uint Armor { get; set; }
        uint Helm { get; set; }
        uint Cloak { get; set; }
        uint Accessory1 { get; set; }
        uint Accessory2 { get; set; }
        Subweapon Subweapon { get; set; }
        uint State { get; set; }
        uint Action { get; set; }
        bool FacingLeft { get; set; }
        uint DarkMetamorphasisTimer { get; set; }
        uint AttackPotionTimer { get; set; }
        uint DefencePotionTimer { get; set; }
        uint InvincibilityTimer { get; set; }
        uint ShineTimer { get; set; }
        uint CurseTimer { get; set; }

        void ClearInventory();
        string GetSelectedItemName();
        Relic GetSelectedRelic();
        void GrantItemByName(string name);
        void TakeOneItemByName(string name);
        void GrantRelic(Relic name);
        void TakeRelic(Relic name);
        void GrantFirstCastleWarp(Warp warp);
        void GrantSecondCastleWarp(Warp warp);
        bool HasItemInInventory(string name);
        bool HasRelic(Relic name);
        void Heal(uint ammount);
        void ActivateStopwatch();
        void ActivatePotion(Potion potion);
    }
}