using Console_Games.Games.Modules;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Games.Games
{
    internal class TicTacToe : T4T
    {
        private char[] board = new char[9];
        public bool PlayerX { get; set; }
        public TicTacToe(Player plr, bool first, T4T opponent) : base(plr, opponent)
        {
            CurrentGame = Gamemaster.games.TicTacToe;
            PlayerX = first;
        }

        public override bool RecieveCommand(string[] args)
        {
            if (!IsTurn) { 
                SendConsoleMessage("It's not your turn!"); 
                return false;
            }
            if (!int.TryParse(args.First(), out int i) || i-1 < 0 || i-1 > 9 || board[i-1] != '#') { 
                SendConsoleMessage("Thats not a valid move!"); 
            }
            board[i - 1] = PlayerX ? 'X' : 'O';
            RenderBoard();
            return Send(new string(board));
        }

        public override bool Recieve(string state)
        {
            IsTurn = true;
            board = state.ToCharArray();

            return RenderBoard();
        }
        public bool RenderBoard()
        {
            string grid = "";
            int i = 1;
            foreach (char c in board) {
                if (c == '#') grid += "<color=grey>" + i + "</color>";
                else grid += c;
                if (i % 3 == 0) grid += "\n";
                i++;
            }

            return SendGameState(grid);
        }
    }
}
