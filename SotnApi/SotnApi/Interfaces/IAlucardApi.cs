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
        uint Def { get; }
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
        /// <summary> Index of the currently equipped item in the Right Hand slot.</summary>
        uint RightHand { get; set; }
        /// <summary> Index of the currently equipped item in the Left Hand slot.</summary>
        uint LeftHand { get; set; }
        /// <summary> Index of the currently equipped item in the Armor slot.</summary>
        uint Armor { get; set; }
        /// <summary> Index of the currently equipped item in the Helm slot.</summary>
        uint Helm { get; set; }
        /// <summary> Index of the currently equipped item in the Cloak slot.</summary>
        uint Cloak { get; set; }
        /// <summary> Index of the currently equipped item in the first Accessory slot.</summary>
        uint Accessory1 { get; set; }
        /// <summary> Index of the currently equipped item in the second Accessory slot.</summary>
        uint Accessory2 { get; set; }
        /// <summary>Slot of the cursor in the hand equip menu.</summary>
        uint HandCursor { get; set; }
        /// <summary>Slot of the cursor in the helm equip menu.</summary>
        uint HelmCursor { get; set; }
        /// <summary>Slot of the cursor in the armor equip menu.</summary>
        uint ArmorCursor { get; set; }
        /// <summary>Slot of the cursor in the cloak equip menu.</summary>
        uint CloakCursor { get; set; }
        /// <summary>Slot of the cursor in the accessory equip menu.</summary>
        uint AccessoryCursor { get; set; }

        /// <summary> Index of the held subweapon.</summary>
        Subweapon Subweapon { get; set; }
        /// <summary> Real-time horizontal speed in pixels per frame. </summary>
        public int CurrentHorizontalSpeedWhole { get; set; }
        /// <summary> Real-time horizontal fractional speed.</summary>
        public int CurrentHorizontalSpeedFractional { get; set; }
        uint State { get; set; }
        uint Action { get; set; }
        /// <summary>Horizontal coordinate of Alucard on the screen.</summary>
        uint ScreenX { get; }
        /// <summary>Vertical coordinate of Alucard on the screen.</summary>
        uint ScreenY { get; }
        /// <summary>Horizontal position of the blinking indicator on the map.</summary>
        uint MapX { get; }
        /// <summary>Vertical position of the blinking indicator on the map.</summary>
        uint MapY { get; }
        /// <returns> True if Alucard is facing left.</returns>
        bool FacingLeft { get; set; }
        uint DarkMetamorphasisTimer { get; set; }
        uint AttackPotionTimer { get; set; }
        uint DefencePotionTimer { get; set; }
        uint InvincibilityTimer { get; set; }
        uint ShineTimer { get; set; }
        uint CurseTimer { get; set; }
        uint PoisonTimer { get; set; }
        /// <summary>Damage dealt to enemies when Alucard touches them.</summary>
        uint ContactDamage { get; set; }
        /// <summary>
        /// Reduces the count of all owned items to 0.
        /// </summary>
        void ClearInventory();
        /// <returns>The item at the cursor position in the equip submenu.</returns>
        string GetSelectedItemName();
        /// <returns>The relic at the cursor position in the relics submenu.</returns>
        Relic GetSelectedRelic();
        /// <summary>
        /// Increases the count of held items of the type by one.
        /// </summary>
        /// <param name="name">Item name acording to the list at SotnApi.Constants.Values.Alucard.Equipment.Items</param>
        void GrantItemByName(string name);
        /// <summary>
        /// Reduces the count of held items of the type by one.
        /// </summary>
        /// <param name="name">Item name acording to the list at SotnApi.Constants.Values.Alucard.Equipment.Items</param>
        void TakeOneItemByName(string name);
        /// <summary>
        /// Grants relic and turns it on it if is not a familiar card. Allow spawn will make the normal relics still spawn where they were supposed to.
        /// </summary>
        void GrantRelic(Relic name, bool allowSpawn = false);
        /// <summary>
        /// Takes relic away.
        /// </summary>
        void TakeRelic(Relic name);
        void GrantFirstCastleWarp(Warp warp);
        void GrantSecondCastleWarp(Warp warp);
        bool HasItemInInventory(string name);
        bool HasRelic(Relic name);
        bool IsInvincible();
        bool HasControl();
        bool HasHitbox();
        void Heal(uint ammount);
        void ActivateStopwatch();
        void ActivatePotion(Potion potion);
    }
}