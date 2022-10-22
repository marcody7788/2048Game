using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _2048Game.Models.Enums;

namespace _2048Game.Models
{
    public class GameManager
    {
        private readonly Game _game;

        public GameManager(Game game)
        {
            _game = game;
            CreateGameCells();
        }

        public ICommand MoveUp => new Command(MoveUpAction);
        public ICommand MoveLeft => new Command(MoveLeftAction);
        public ICommand MoveRight => new Command(MoveRightAction);
        public ICommand MoveDown => new Command(MoveDownAction);
        public ICommand StartGame => new Command(StartGameAction);

        void CreateGameCells()
        {
            for (int rows = 0; rows < _game.Size; rows++)
            {
                for (int cols = 0; cols < _game.Size; cols++)
                {
                    _game.GameCells.Add(new GameCell() { Column = cols, Row = rows });
                }
            }
        }

        private void MoveLeftAction(object obj) => Move(Direction.Left);

        private void MoveRightAction(object obj) => Move(Direction.Right);

        private void MoveDownAction(object obj) => Move(Direction.Down);

        private void MoveUpAction(object obj) => Move(Direction.Up);


        void Move(Direction direction)
        {
            var moveHappened = MoveManager.Move(_game, direction);
            CheckGameFinishedConditions();
            if (!moveHappened) return;
            AssignNewNumberToEmptyCell();
        }

        private void CheckGameFinishedConditions()
        {
            if (_game.IsWin)
            {
                FinishGame();
                return;
            }
            if (!_game.IsAnyCellEmpty())
            {
                FinishGame();
                return;
            }
        }

        void FinishGame()
        {
            if (!_game.IsAnyCellEmpty())
            {
                _game.State = GameState.Lost;
                return;
            }
            if (_game.IsWin)
            {
                _game.State = GameState.Win;
                return;
            }
        }

        void StartGameAction()
        {
            _game.GameCells.Clear();
            CreateGameCells();
            AssignNewNumberToEmptyCell();
            _game.State = GameState.Started;
        }
        private void AssignNewNumberToEmptyCell()
        {
            if (!_game.IsAnyCellEmpty()) return;
            GetRandomEmptyCell().Number = GetRandomStartingNumber(Game.STARTING_NUMBERS);
        }

        private int GetRandomStartingNumber(int[] startingNumbers)
        {
            int randomIndextart2 = new Random().Next(startingNumbers.Length);
            return startingNumbers[randomIndextart2];
        }

        private GameCell GetRandomEmptyCell()
        {
            var emptyCells = _game.GameCells.Where(cell => cell.IsEmpty);
            var cellIndexToReturn = new Random().Next(emptyCells.Count());
            return emptyCells.ElementAt(cellIndexToReturn);
        }

    }
}
