using _2048Game.Models.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _2048Game.Models
{
    internal class MoveManager
    {
        public static bool Move(Game game, Direction direction)
        {
            var orderedCells = GetOrderedCellsAccordingToDirection(game.GameCells, direction);
            var cellLooper = new CellLooper(orderedCells, direction);
            var sumHappened = cellLooper.LoopCellsAndSumIfPossible();
            var stackHappened = cellLooper.LoopCellsAndStackIfPossible();

            return sumHappened || stackHappened;
        }

        private static IEnumerable<GameCell> GetOrderedCellsAccordingToDirection(IEnumerable<GameCell> gameCells, Direction direction)
        {
            return direction switch
            {
                Direction.Up => gameCells.OrderBy(cell => cell.Row).ThenBy(cell => cell.Column),
                Direction.Left => gameCells.OrderBy(cell => cell.Column).ThenBy(cell => cell.Row),
                Direction.Down => gameCells.OrderByDescending(cell => cell.Row).ThenBy(cell => cell.Column),
                Direction.Right => gameCells.OrderByDescending(cell => cell.Column).ThenBy(cell => cell.Row),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
