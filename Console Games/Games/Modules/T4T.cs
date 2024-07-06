using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games.Games.Modules
{
    public abstract class T4T : Seat //tit for tat
    {
        public T4T Opponent { get; set; }
        public bool IsTurn { get; set; } = false;
        protected T4T(Player plr, T4T opponent) : base(plr)
        {
            Opponent = opponent;
        }

        public bool Send(string state) { 
            if (Opponent == null) return false;
            return Opponent.Recieve(state);
        }
        public abstract bool Recieve(string state);
    }
}
