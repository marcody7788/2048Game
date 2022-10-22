using _2048Game.Models.Enums;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2048Game.Models
{
    public class Game : INotifyPropertyChanged
    {
        private const int DEFAULT_GAME_SIZE = 4;
        private const int WIN_NUMBER = 2048;
        internal static int[] STARTING_NUMBERS = { 2, 4 };

        public ObservableCollection<GameCell> GameCells { get; private set; } = new ObservableCollection<GameCell>();
        public int Size { get; private set; }

        public Game(int gameSize = DEFAULT_GAME_SIZE)
        {
            Size = gameSize;
        }

        internal bool IsWin => GameCells.Any(cell => cell.Number == WIN_NUMBER);
        internal bool IsAnyCellEmpty() => GameCells.Any(cell => cell.IsEmpty);


        private GameState state = 0;

        public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };

        public GameState State
        {
            get { return state; }
            internal set
            {
                this.state = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(State)));
            }
        }

    }
}