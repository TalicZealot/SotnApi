using SotnApi.Constants.Values.Game;
using System.Collections.Generic;

namespace SotnApi.Models
{
	/// <summary>
	/// A live entity object rendered in-game. Enemies, projectiles, items, hitboxes, interactable objects.
	/// </summary>
	public class Actor
	{
		public Actor(List<byte>? entity = null)
		{
			if (entity != null)
			{
				this.Value = entity;
			}
			else
			{
				Value = new List<byte>();
				for (int i = 0; i <= Actors.Size; i++)
				{
					Value.Add(0);
				}
			}
		}
		public List<byte> Value { get; set; }

		public uint Xpos {
			get
			{
				return Value[Actors.XposOffset];
			}
			set
			{
				Value[Actors.XposOffset] = (byte) value;
			}
		}

		public uint Ypos
		{
			get
			{
				return Value[Actors.YposOffset];
			}
			set
			{
				Value[Actors.YposOffset] = (byte) value;
			}
		}

		public uint AutoToggle
		{
			get
			{
				return Value[Actors.HitboxAutoToggleOffset];
			}
			set
			{
				Value[Actors.HitboxAutoToggleOffset] = (byte) value;
			}
		}

		public uint Hp
		{
			get
			{
				return Value[Actors.HpOffset];
			}
			set
			{
				Value[Actors.HpOffset] = (byte) value;
			}
		}

		public uint Damage
		{
			get
			{
				return Value[Actors.DamageOffset];
			}
			set
			{
				Value[Actors.DamageOffset] = (byte) value;
			}
		}

		public uint DamageTypeA
		{
			get
			{
				return Value[Actors.DamageTypeAOffset];
			}
			set
			{
				Value[Actors.DamageTypeAOffset] = (byte) value;
			}
		}

		public uint DamageTypeB
		{
			get
			{
				return Value[Actors.DamageTypeBOffset];
			}
			set
			{
				Value[Actors.DamageTypeBOffset] = (byte) value;
			}
		}

		public uint HitboxWidth
		{
			get
			{
				return Value[Actors.HitboxWidthOffset];
			}
			set
			{
				Value[Actors.HitboxWidthOffset] = (byte) value;
			}
		}

		public uint HitboxHeight
		{
			get
			{
				return Value[Actors.HitboxHeightOffset];
			}
			set
			{
				Value[Actors.HitboxHeightOffset] = (byte) value;
			}
		}
	}
}
