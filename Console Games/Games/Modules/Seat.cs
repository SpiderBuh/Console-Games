using InventorySystem.Items.Coin;
using Mirror;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Console_Games.Games.Modules
{
    public abstract class Seat : MonoBehaviour // Would be 'Player' instead but that would be confusing
    {
        private ReferenceHub plrHub;
        public Gamemaster.games CurrentGame { get; set; } = Gamemaster.games.none;
        public Seat(Player plr)
        {
            plrHub = plr.ReferenceHub;
        }
        public bool SendConsoleMessage(string message) { return SendGameState(message); }
        public bool SendGameState(string board)
        {
            try
            {
                plrHub.gameConsoleTransmission.SendMessage(board);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public abstract bool RecieveCommand(string[] args);
    }
}
