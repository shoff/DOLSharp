/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

using System;
using System.Collections;
using System.Reflection;

using DOL.GS.PacketHandler;
using DOL.Database;

using log4net;

namespace DOL.GS.Housing
{

	public enum ePermsTypes
	{
		Player = 0x01,
		Guild = 0x02,
		GuildRank = 0x03,
		Account = 0x04,
		All = 0x05,
		Class = 0x06,
		Race = 0x07
	}

	public class House : IPoint3D
	{
		#region Properties
		public int HouseNumber
		{
			get { return m_databaseItem.HouseNumber; }
			set { m_databaseItem.HouseNumber = value; }
		}

		public int X
		{
			get { return m_databaseItem.X; }
			set { m_databaseItem.X = value; }
		}

		public int Y
		{
			get { return m_databaseItem.Y; }
			set { m_databaseItem.Y = value; }
		}

		public int Z
		{
			get { return m_databaseItem.Z; }
			set { m_databaseItem.Z = value; }
		}

		public ushort RegionID
		{
			get { return m_databaseItem.RegionID; }
			set { m_databaseItem.RegionID = value; }
		}

		public int Heading
		{
			get { return m_databaseItem.Heading; }
			set { m_databaseItem.Heading = value; }
		}

		public string Name
		{
			get { return m_databaseItem.Name; }
			set { m_databaseItem.Name = value; }
		}

		public string OwnerIDs
		{
			get { return m_databaseItem.OwnerIDs; }
			set { m_databaseItem.OwnerIDs = value; }
		}

		public int Model
		{
			get { return m_databaseItem.Model; }
			set { m_databaseItem.Model = value; }
		}

		public int Emblem
		{
			get { return m_databaseItem.Emblem; }
			set { m_databaseItem.Emblem = value; }
		}

		public int PorchRoofColor
		{
			get { return m_databaseItem.PorchRoofColor; }
			set { m_databaseItem.PorchRoofColor = value; }
		}

		public int PorchMaterial
		{
			get { return m_databaseItem.PorchMaterial; }
			set { m_databaseItem.PorchMaterial = value; }
		}

		public bool Porch
		{
			get { return m_databaseItem.Porch; }
			set { m_databaseItem.Porch = value; }
		}

		public bool IndoorGuildBanner
		{
			get { return m_databaseItem.IndoorGuildBanner; }
			set { m_databaseItem.IndoorGuildBanner = value; }
		}

		public bool IndoorGuildShield
		{
			get { return m_databaseItem.IndoorGuildShield; }
			set { m_databaseItem.IndoorGuildShield = value; }
		}

		public bool OutdoorGuildBanner
		{
			get { return m_databaseItem.OutdoorGuildBanner; }
			set { m_databaseItem.OutdoorGuildBanner = value; }
		}

		public bool OutdoorGuildShield
		{
			get { return m_databaseItem.OutdoorGuildShield; }
			set { m_databaseItem.OutdoorGuildShield = value; }
		}

		public int RoofMaterial
		{
			get { return m_databaseItem.RoofMaterial; }
			set { m_databaseItem.RoofMaterial = value; }
		}

		public int DoorMaterial
		{
			get { return m_databaseItem.DoorMaterial; }
			set { m_databaseItem.DoorMaterial = value; }
		}

		public int WallMaterial
		{
			get { return m_databaseItem.WallMaterial; }
			set { m_databaseItem.WallMaterial = value; }
		}

		public int TrussMaterial
		{
			get { return m_databaseItem.TrussMaterial; }
			set { m_databaseItem.TrussMaterial = value; }
		}

		public int WindowMaterial
		{
			get { return m_databaseItem.WindowMaterial; }
			set { m_databaseItem.WindowMaterial = value; }
		}

		public int Rug1Color
		{
			get { return m_databaseItem.Rug1Color; }
			set { m_databaseItem.Rug1Color = value; }
		}

		public int Rug2Color
		{
			get { return m_databaseItem.Rug2Color; }
			set { m_databaseItem.Rug2Color = value; }
		}

		public int Rug3Color
		{
			get { return m_databaseItem.Rug3Color; }
			set { m_databaseItem.Rug3Color = value; }
		}

		public int Rug4Color
		{
			get { return m_databaseItem.Rug4Color; }
			set { m_databaseItem.Rug4Color = value; }
		}

		public DateTime LastPaid
		{
			get { return m_databaseItem.LastPaid; }
			set { m_databaseItem.LastPaid = value; }
		}

		public long KeptMoney
		{
			get { return m_databaseItem.KeptMoney; }
			set { m_databaseItem.KeptMoney = value; }
		}

		private int m_uniqueID;

		public int UniqueID
		{
			get { return m_uniqueID; }
			set { m_uniqueID = value; }
		}

		Hashtable m_indooritems;

		public Hashtable IndoorItems
		{
			get { return m_indooritems; }
			set { m_indooritems = value; }
		}

		Hashtable m_outdooritems;

		public Hashtable OutdoorItems
		{
			get { return m_outdooritems; }
			set { m_outdooritems = value; }
		}

		Hashtable m_housepointitems;

		public Hashtable HousepointItems
		{
			get { return m_housepointitems; }
			set { m_housepointitems = value; }
		}

		public DBHouse DatabaseItem
		{
			get { return m_databaseItem; }
		}

		ArrayList m_charspermissions;
		public ArrayList CharsPermissions
		{
			get { return m_charspermissions; }
			set { m_charspermissions = value; }
		}

		DBHouse m_databaseItem;

		DBHousePermissions[] m_houseAccess;

		public DBHousePermissions[] HouseAccess
		{
			get { return m_houseAccess; }
		}
		#endregion

		/// <summary>
		/// Sends a update of the house and the garden to all players in range
		/// </summary>
		public void SendUpdate()
		{
			foreach (GamePlayer player in WorldMgr.GetPlayersCloseToSpot((ushort)this.RegionID, this.X, this.Y, this.Z, HouseMgr.HOUSE_DISTANCE))
			{
				player.Out.SendHouse(this);
				player.Out.SendGarden(this);
			}
		}

		public bool EditPorch(bool add_porch)
		{
			if (Porch == add_porch) //we cannot remove if removed, or add if added
				return false;
			Porch = add_porch;
			this.SendUpdate();

			return true;
		}

		public bool IsInPerm(string name, ePermsTypes type, int lvl)
		{
			// todo modify when type is account, to check if name == one of charnames on the account
			foreach (DBHouseCharsXPerms perm in CharsPermissions)
				if (perm.Name == name && perm.Type == (byte)type && perm.PermLevel == lvl)
					return true;
			return false;
		}

		public bool CanPayRent(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if (perm.PayRent == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}

		public bool CanEnter(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if (perm.Enter == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}

		public bool CanAddInterior(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if ((perm.Interior & 0x01) == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}

		public bool CanRemoveInterior(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if ((perm.Interior & 0x02) == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}

		public bool CanAddGarden(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if ((perm.Garden & 0x01) == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}

		public bool CanRemoveGarden(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if ((perm.Garden & 0x02) == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}

		public bool CanEditAppearance(GamePlayer p)
		{
			if (IsOwner(p) || p.Client.Account.PrivLevel > 1)
				return true;
			foreach (DBHousePermissions perm in HouseAccess)
			{
				if (perm.Appearance == 0)// optim
					continue;
				if (IsInPerm(p.Name, ePermsTypes.Player, perm.PermLevel))
					return true;
				if (IsInPerm(p.Name, ePermsTypes.Account, perm.PermLevel))
					return true;
			}
			return false;
		}



		public void RemoveFromPerm(int slot)
		{
			DBHouseCharsXPerms todel = null;
			foreach (DBHouseCharsXPerms perm in CharsPermissions)
				if (perm.Slot == slot)
				{
					todel = perm;
					break;
				}
			if (todel == null)
				return;
			CharsPermissions.Remove(todel);
			GameServer.Database.DeleteObject(todel);
		}

		public void ChangePerm(int slot, int nlvl)
		{
			foreach (DBHouseCharsXPerms perm in CharsPermissions)
				if (perm.Slot == slot)
				{
					perm.PermLevel = nlvl;
					GameServer.Database.SaveObject(perm);
					break;
				}
		}

		public bool AddToPerm(GamePlayer p, ePermsTypes type, int lvl)
		{
			if (IsInPerm(p.Name, type, lvl))
				return false;
			DBHouseCharsXPerms perm = new DBHouseCharsXPerms();
			perm.HouseNumber = HouseNumber;
			perm.Type = (byte)type;
			perm.Name = p.Name;
			perm.PermLevel = lvl;
			int slot = 0;
			bool ok = false;
			while (!ok)
			{
				ok = true;
				foreach (DBHouseCharsXPerms pe in CharsPermissions)
				{
					if (pe.Slot == slot)
					{
						ok = false;
						slot++;
						break;
					}
				}
			}
			if (!ok)
				return false;
			perm.Slot = slot;
			CharsPermissions.Add(perm);
			GameServer.Database.AddNewObject(perm);
			return true;
		}

		/// <summary>
		/// Used to get into a house
		/// </summary>
		/// <param name="player">the player who wants to get in</param>
		public void Enter(GamePlayer player)
		{

			GameClient client = player.Client;
			client.Out.SendEnterHouse(this);
			client.Out.SendFurniture(this);
			client.Out.SendRemoveGarden(this);
			client.Player.InHouse = true;
			client.Player.CurrentHouse = this;

			switch (this.Model)
			{
				//thx to sp4m
				default:
					client.Player.MoveTo((ushort)this.RegionID, this.X, this.Y, 25022, client.Player.Heading);
					break;

				case 1:
					client.Player.MoveTo((ushort)this.RegionID, this.X + 80, this.Y + 100, ((ushort)(25025)), client.Player.Heading);
					break;

				case 2:
					client.Player.MoveTo((ushort)this.RegionID, this.X - 260, this.Y + 100, ((ushort)(24910)), client.Player.Heading);
					break;

				case 3:
					client.Player.MoveTo((ushort)this.RegionID, this.X - 200, this.Y + 100, ((ushort)(24800)), client.Player.Heading);
					break;

				case 4:
					client.Player.MoveTo((ushort)this.RegionID, this.X - 350, this.Y - 30, ((ushort)(24660)), client.Player.Heading);
					break;

				case 5:
					client.Player.MoveTo((ushort)this.RegionID, this.X + 230, this.Y - 480, ((ushort)(25100)), client.Player.Heading);
					break;

				case 6:
					client.Player.MoveTo((ushort)this.RegionID, this.X - 80, this.Y - 660, ((ushort)(24700)), client.Player.Heading);
					break;

				case 7:
					client.Player.MoveTo((ushort)this.RegionID, this.X - 80, this.Y - 660, ((ushort)(24700)), client.Player.Heading);
					break;

				case 8:
					client.Player.MoveTo((ushort)this.RegionID, this.X - 90, this.Y - 625, ((ushort)(24670)), client.Player.Heading);
					break;

				case 9:
					client.Player.MoveTo((ushort)this.RegionID, this.X + 400, this.Y - 160, ((ushort)(25150)), client.Player.Heading);
					break;

				case 10:
					client.Player.MoveTo((ushort)this.RegionID, this.X + 400, this.Y - 80, ((ushort)(25060)), client.Player.Heading);
					break;

				case 11:
					client.Player.MoveTo((ushort)this.RegionID, this.X + 400, this.Y - 60, ((ushort)(24900)), client.Player.Heading);
					break;

				case 12:
					client.Player.MoveTo((ushort)this.RegionID, this.X, this.Y - 620, ((ushort)(24595)), client.Player.Heading);
					break;
			}

			client.Out.SendMessage("You have entered house number " + this.HouseNumber + ".", eChatType.CT_System, eChatLoc.CL_SystemWindow);
		}

		/// <summary>
		/// Used to leave a house
		/// </summary>
		/// <param name="player">the player who wants to get in</param>
		/// <param name="silent">text or not</param>
		public void Exit(GamePlayer player, bool silent)
		{
			double angle = Heading * ((Math.PI * 2) / 360); // angle*2pi/360;
			int x = (int)(X + (0 * Math.Cos(angle) + 500 * Math.Sin(angle)));
			int y = (int)(Y - (500 * Math.Cos(angle) - 0 * Math.Sin(angle)));
			ushort heading = (ushort)((Heading < 180 ? Heading + 180 : Heading - 180) / 0.08789);
			player.MoveTo(RegionID, x, y, Z, heading);
			if (!silent)
			{
				player.Out.SendMessage("You have left house number " + HouseNumber + ".", eChatType.CT_System, eChatLoc.CL_SystemWindow);
				GSTCPPacketOut pak = new GSTCPPacketOut(player.Client.Out.GetPacketCode(ePackets.HouseEnter));

				pak.WriteShort((ushort)this.HouseNumber);
				pak.WriteShort((ushort)25000);         //constant!
				pak.WriteInt((uint)this.X);
				pak.WriteInt((uint)this.Y);
				pak.WriteShort(0x00); //useless/ignored by client.
				pak.WriteByte(0x00);
				pak.WriteByte(0x00); //emblem style
				pak.WriteShort(0x00);	//emblem
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);
				pak.WriteByte(0x00);

				player.Client.Out.SendTCP(pak);
			}

		}


		/// <summary>
		/// Sends the house info window to a player
		/// </summary>
		/// <param name="player">the player</param>
		public void SendHouseInfo(GamePlayer player)
		{
			ArrayList text = new ArrayList();
			text.Add("Owner: " + this.Name);
			text.Add("Lotnum: " + HouseNumber);
			int level = Model - (int)((Model - 1) / 4) * 4;
			text.Add("Level: " + level);
			text.Add(" ");
			text.Add("Porch: ");
			text.Add("-Enabled: " + (Porch ? "Y" : "N"));
			text.Add("-Color: " + PorchRoofColor);
			text.Add(" ");
			text.Add("Exterior Materials:");
			text.Add("-Roof: " + RoofMaterial);
			text.Add("-Wall: " + WallMaterial);
			text.Add("-Door: " + DoorMaterial);
			text.Add("-Support: " + TrussMaterial);
			text.Add("-Porch: " + PorchMaterial);
			text.Add("-Shutter: " + WindowMaterial);
			text.Add(" ");
			text.Add("Exterior Upgrades:");
			text.Add("-Banner: " + ((OutdoorGuildBanner) ? "Y" : "N"));
			text.Add("-Shield: " + ((OutdoorGuildShield) ? "Y" : "N"));
			text.Add(" ");
			text.Add("Interior Upgrades:");
			text.Add("-Banner: " + ((IndoorGuildBanner) ? "Y" : "N"));
			text.Add("-Shield: " + ((IndoorGuildShield) ? "Y" : "N"));
			text.Add(" ");
			text.Add("Interior Carpets:");
			text.Add("-First Color: " + Rug1Color);
			text.Add("-Second Color: " + Rug2Color);
			text.Add("-Third Color: " + Rug3Color);
			text.Add("-Fourth Color: " + Rug4Color);
			text.Add(" ");
			text.Add("Lockbox: " + Money.GetString(KeptMoney));
			text.Add("Rental Price: " + Money.GetString(HouseMgr.GetRentByModel(Model)));
			text.Add("Max in Lockbox: " + Money.GetString(HouseMgr.GetRentByModel(Model) * 4));
			TimeSpan due = (LastPaid.AddDays(7).AddHours(1) - DateTime.Now);
			text.Add("Rent due in: " + due.Days + " days, " + due.Hours + " hours");
			text.Add(" ");
			text.Add("Owners:");
			foreach (Character character in HouseMgr.GetOwners(this.m_databaseItem))
			{
				text.Add("-" + character.Name);
			}
			player.Out.SendCustomTextWindow(this.Name + " 's house", text);

		}

		/// <summary>
		/// Returns true if the player is a owner of the house
		/// </summary>
		/// <param name="player">the player to check</param>
		public bool IsOwner(GamePlayer player)
		{
			return HouseMgr.IsOwner(m_databaseItem, player);
		}

		/// <summary>
		/// Saves this house into the database
		/// </summary>
		public void SaveIntoDatabase()
		{
			GameServer.Database.SaveObject(m_databaseItem);
		}

		public int GetPorchAndGuildEmblemFlags()
		{
			int flag = 0;
			if (Porch)
				flag |= 1;
			if (OutdoorGuildBanner)
				flag |= 2;
			if (OutdoorGuildShield)
				flag |= 4;
			return flag;
		}

		public int GetGuildEmblemFlags()
		{
			int flag = 0;
			if (IndoorGuildBanner)
				flag |= 1;
			if (IndoorGuildShield)
				flag |= 2;
			return flag;
		}

		/// <summary>
		/// Returns a ArrayList with all players in the house
		/// </summary>
		public ArrayList GetAllPlayersInHouse()
		{
			ArrayList ret = new ArrayList();
			foreach (GamePlayer player in WorldMgr.GetPlayersCloseToSpot((ushort)this.RegionID, this.X, this.Y, 25000, WorldMgr.VISIBILITY_DISTANCE))
			{
				if (player.CurrentHouse == this && player.InHouse)
				{
					ret.Add(player);
				}
			}
			return ret;
		}

		public void Edit(GamePlayer player, ArrayList changes)
		{
			if (!CanEditAppearance(player))
				return;

			MerchantTradeItems items;

			if (player.InHouse)
			{
				items = HouseTemplateMgr.IndoorMenuItems;
			}
			else
			{
				items = HouseTemplateMgr.OutdoorMenuItems;
			}

			if (items == null)
				return;

			long price = 0;

			foreach (int slot in changes)
			{
				int page = slot / 30;
				int pslot = slot % 30;
				ItemTemplate item = items.GetItem(page, (eMerchantWindowSlot)pslot);
				if (item != null)
				{
					price += Money.GetMoney(0, 0, item.Gold, item.Silver, item.Copper);
				}
			}

			if (!player.RemoveMoney(price, "You pay " + Money.GetString(price) + " for your changes."))
			{
				player.Out.SendMessage("You don't have enough money to do that!", eChatType.CT_Merchant, eChatLoc.CL_SystemWindow);
				return;
			}

			foreach (int slot in changes)
			{
				int page = slot / 30;
				int pslot = slot % 30;

				ItemTemplate item = items.GetItem(page, (eMerchantWindowSlot)pslot);

				if (item != null)
				{
					switch ((eObjectType)item.Object_Type)
					{
						case eObjectType.HouseInteriorBanner:
							IndoorGuildBanner = (item.DPS_AF == 1 ? true : false);
							break;
						case eObjectType.HouseInteriorShield:
							IndoorGuildShield = (item.DPS_AF == 1 ? true : false);
							break;
						case eObjectType.HouseCarpetFirst:
							Rug1Color = item.DPS_AF;
							break;
						case eObjectType.HouseCarpetSecond:
							Rug2Color = item.DPS_AF;
							break;
						case eObjectType.HouseCarpetThird:
							Rug3Color = item.DPS_AF;
							break;
						case eObjectType.HouseCarpetFourth:
							Rug4Color = item.DPS_AF;
							break;
						case eObjectType.HouseTentColor:
							PorchRoofColor = item.DPS_AF;
							break;
						case eObjectType.HouseExteriorBanner:
							OutdoorGuildBanner = (item.DPS_AF == 1 ? true : false);
							break;
						case eObjectType.HouseExteriorShield:
							OutdoorGuildShield = (item.DPS_AF == 1 ? true : false);
							break;
						case eObjectType.HouseRoofMaterial:
							RoofMaterial = item.DPS_AF;
							break;
						case eObjectType.HouseWallMaterial:
							WallMaterial = item.DPS_AF;
							break;
						case eObjectType.HouseDoorMaterial:
							DoorMaterial = item.DPS_AF;
							break;
						case eObjectType.HousePorchMaterial:
							PorchMaterial = item.DPS_AF;
							break;
						case eObjectType.HouseWoodMaterial:
							TrussMaterial = item.DPS_AF;
							break;
						case eObjectType.HouseShutterMaterial:
							WindowMaterial = item.DPS_AF;
							break;
						default:
							break; //dirty work a round - dont know how mythic did it, hardcoded? but it works
					}
				}
			}

			GameServer.Database.SaveObject(m_databaseItem);

			if (player.InHouse)
			{
				foreach (GamePlayer p in this.GetAllPlayersInHouse())
				{
					p.Out.SendEnterHouse(this); //update rugs.
				}
			}
			else
			{
				foreach (GamePlayer p in WorldMgr.GetPlayersCloseToSpot((ushort)this.RegionID, this.X, this.Y, this.Z, HouseMgr.HOUSE_DISTANCE))
				{
					p.Out.SendHouse(this); //update wall look
					p.Out.SendGarden(this);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void FillHookpoint(ItemTemplate item, uint position, string templateID)
		{
			if (item == null)
			{
				item = (ItemTemplate)GameServer.Database.SelectObject(typeof(ItemTemplate), "Id_nb = '" + templateID + "'");
				if (item == null)
					return;
			}

			HouseMgr.Logger.Debug("item is not null");

			//get location from slot
			IPoint3D location = GetHookpointLocation(position);
			int x = location.X;
			int y = location.Y;
			int z = location.Z;
			ushort heading = GetHookpointHeading(position);

			switch ((eObjectType)item.Object_Type)
			{
				case eObjectType.HouseNPC:
					{
						//store npc template id somewhere on the db item?
						break;
					}
				case eObjectType.HouseBindstone:
					{
						GameStaticItem sItem = new GameStaticItem();
						sItem.CurrentHouse = this;
						sItem.InHouse = true;
						sItem.X = x;
						sItem.Y = y;
						sItem.Z = z;
						sItem.Heading = heading;
						sItem.CurrentRegionID = RegionID;
						sItem.Name = item.Name;
						sItem.Model = (ushort)item.Model;
						sItem.AddToWorld();
						//0:07:45.984 S=>C 0xD9 item/door create v171 (oid:0x0DDB emblem:0x0000 heading:0x0DE5 x:596203 y:530174 z:24723 model:0x05D2 health:  0% flags:0x04(realm:0) extraBytes:0 unk1_171:0x0096220C name:"Hibernia bindstone")
						//add bind point
						break;
					}
				case eObjectType.HouseInteriorObject:
					{
						GameStaticItem sItem = new GameStaticItem();
						sItem.CurrentHouse = this;
						sItem.InHouse = true;
						sItem.X = x;
						sItem.Y = y;
						sItem.Z = z;
						sItem.Heading = heading;
						sItem.CurrentRegionID = RegionID;
						sItem.Name = item.Name;
						sItem.Model = (ushort)item.Model;
						sItem.AddToWorld();
						break;
					}
				case eObjectType.HouseVault:
					{
						//todo vault class of item
						GameStaticItem sItem = new GameStaticItem();
						sItem.CurrentHouse = this;
						sItem.InHouse = true;
						sItem.X = x;
						sItem.Y = y;
						sItem.Z = z;
						sItem.Heading = heading;
						sItem.CurrentRegionID = RegionID;
						sItem.Name = item.Name;
						sItem.Model = (ushort)item.Model;
						sItem.AddToWorld();
						break;
					}
			}
		}

		public void EmptyHookpoint(int slot)
		{ }

		public House(DBHouse house)
		{
			m_databaseItem = house;
			m_houseAccess = new DBHousePermissions[10];
			m_indooritems = new Hashtable();
			m_outdooritems = new Hashtable();
			m_housepointitems = new Hashtable();
			m_charspermissions = new ArrayList();
		}

		#region Housepoint location
		protected static readonly int[][][] RELATIVE_HOOKPOINTS_COORDS = new int[][][]
			{
				// NOTHING : Lot
				null,
				// ALB Cottage (model 1)
				new int[19][]
					{
	/* Position 0 */	new int[4] {-196, -858, -305, -105}, 
						null,
						null,
						null,
						null,
	/* Position 5 */	new int[4] {349, 430, 30, 858},
						null,
						null,
						null,
	/* Position 9 */	new int[4] {-163, 166, 30, 3246},
	/* Position 10 */	new int[4] {306, 249, -307, 1310},
	/* Position 11 */	new int[4] {-218, 299, 30, 3068},
						null,
						null,
						null,
	/* Position 15 */	new int[4] {369, -9040, -306, 910},
						null,
						null,
	                	null
					},
				// ALB (model 2)
				new int[19][]
					{
	/* Position 0 */	new int[4] {7, -855, -429, 3837}, 
						null,
						null,
						null,
						null,
	/* Position 5 */	new int[4] {-542, 437, -95, 2877},
						new int[4] {-518, 175, 175, 3584},
						null,
						null,
	/* Position 9 */	new int[4] {-27, 166, -95, 708},
	/* Position 10 */	new int[4] {-496, 250, -432, 2696},
	/* Position 11 */	new int[4] {-19, 684, 173, 1419},
						new int[4] {17, 320, -90, 744},
						null,
						null,
	/* Position 15 */	new int[4] {327, -106, -430, -166},
						new int[4] {469, -108, -431, 3826},
						null, 
	                	null
					},
				// ALB Villa(model 3)
				new int[19][]
					{
	/* Position 0 */	new int[4] {68, -850, -542, 3886}, 
						null,
						null,
						null,
						null,
	/* Position 5 */	new int[4] {88, 687, -209, 1661},
						new int[4] {89, 836, 60, 1926},
						new int[4] {-432, 920, 318, 2896},
						null,
	/* Position 9 */	new int[4] {-462, 144, -208, 3399},
	/* Position 10 */	new int[4] {-489, -9092, -542, 3350},
	/* Position 11 */	new int[4] {-620, 980, 60, 2350},
						new int[4] {-479, 131, 320, 3252},
						new int[4] {-490, 955, -202, 2402},
						null,
	/* Position 15 */	new int[4] {377, -98, -541, -143},
						new int[4] {574, 121, -541, 845},
						new int[4] {558, 321, -540, 1232},
	                	null
					},
				// ALB Mansion(model 4)
				new int[19][]
					{
	/* Position 0 */	new int[4] {-2058, -868, -1065, 2924}, 
						null,
						null,
						null,
						null,
	/* Position 5 */	new int[4] {-31, 967, 750, 1204},
						new int[4] {-591, 807, -76, 2511},
						new int[4] {-616, 107, 198, 3310},
						null,
	/* Position 9 */	new int[4] {-102, 44, -344, 755},
	/* Position 10 */	new int[4] {-579, 127, -680, 2540},
	/* Position 11 */	new int[4] {-211, -102, -74, 3819},
						new int[4] {-87, 568, 199, 1414},
						new int[4] {-41, 382, 749, 236},
						new int[4] {-600, 318, -345, 2896},
	/* Position 15 */	new int[4] {246, -225, -679, 3859},
						new int[4] {389, -232, -679, 4141},
						new int[4] {245, 185, -680, 1882},
	                	new int[4] {389, 186, -679, 1968}
					},
				
			};

		Point3D GetHookpointLocation(uint n)
		{
			Point3D p = new Point3D(X + RELATIVE_HOOKPOINTS_COORDS[Model][n][0], Y + RELATIVE_HOOKPOINTS_COORDS[Model][n][1], 25000 + RELATIVE_HOOKPOINTS_COORDS[Model][n][2]);
			return p;
		}

		ushort GetHookpointHeading(uint n)
		{
			return (ushort)(Heading + RELATIVE_HOOKPOINTS_COORDS[Model][n][3]);
		}
		#endregion

		public void LoadFromDatabase()
		{
			int i = 0;
			foreach (DBHouseIndoorItem dbiitem in GameServer.Database.SelectObjects(typeof(DBHouseIndoorItem), "HouseNumber = '" + this.HouseNumber + "'"))
			{
				IndoorItem iitem = new IndoorItem();
				iitem.CopyFrom(dbiitem);
				this.IndoorItems.Add(i++, iitem);
			}
			i = 0;
			foreach (DBHouseOutdoorItem dboitem in GameServer.Database.SelectObjects(typeof(DBHouseOutdoorItem), "HouseNumber = '" + this.HouseNumber + "'"))
			{
				OutdoorItem oitem = new OutdoorItem();
				oitem.CopyFrom(dboitem);
				this.OutdoorItems.Add(i++, oitem);
			}

			foreach (DBHouseCharsXPerms d in GameServer.Database.SelectObjects(typeof(DBHouseCharsXPerms), "HouseNumber = '" + this.HouseNumber + "'"))
			{
				this.CharsPermissions.Add(d);
			}

			foreach (DBHousePermissions dbperm in GameServer.Database.SelectObjects(typeof(DBHousePermissions), "HouseNumber = '" + this.HouseNumber + "'"))
			{
				this.HouseAccess[dbperm.PermLevel] = dbperm;
			}

			foreach (DBHousepointItem item in GameServer.Database.SelectObjects(typeof(DBHousepointItem), "HouseID = '" + this.HouseNumber + "'"))
			{
				FillHookpoint(null, item.Position, item.ItemTemplateID);
				this.HousepointItems[item.Position] = item;
			}
		}
	}
}