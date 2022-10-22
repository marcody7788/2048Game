using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048Game.Models.Enums;

namespace _2048Game.Models
{
    internal class CellLooper
    {
        private readonly IEnumerable<GameCell> cells;
        private readonly Direction direction;

        public CellLooper(IEnumerable<GameCell> cells, Direction direction)
        {
            this.cells = cells;
            this.direction = direction;
        }

        internal bool LoopCellsAndStackIfPossible()
        {
            bool stackHappened = false;
            foreach (var cell in cells)
            {
                if (!cell.IsEmpty) continue;
                var nextCellsInSameDirection = GetNextCellsInSameDirection(cell);
                if (nextCellsInSameDirection.All(c => c.IsEmpty)) continue;
                foreach (var nextCell in nextCellsInSameDirection)
                {
                    if (!nextCell.IsEmpty)
                    {
                        cell.Number = nextCell.Number;
                        nextCell.Number = 0;
                        stackHappened = true;
                        break;
                    }
                }
            }
            return stackHappened;
        }

        internal bool LoopCellsAndSumIfPossible()
        {
            bool sumHappened = false;
            foreach (var cell in cells)
            {
                if (cell.IsEmpty) continue;
                var nextCellsInSameDirection = GetNextCellsInSameDirection(cell);
                if (nextCellsInSameDirection.All(c => c.IsEmpty)) continue;
                foreach (var nextCell in nextCellsInSameDirection)
                {
                    if (nextCell.IsEmpty) continue;
                    if (nextCell.Number != cell.Number) break;

                    if (nextCell.Number == cell.Number)
                    {
                        cell.Number += nextCell.Number;
                        nextCell.Number = 0;
                        sumHappened = true;
                        break;
                    }
                }
            }
            return sumHappened;
        }

        private IEnumerable<GameCell> GetNextCellsInSameDirection(GameCell cell)
        {
            switch (direction)
            {
                case Direction.Left: return cells.Where(nextCell => nextCell.Row == cell.Row && nextCell.Column > cell.Column).OrderBy(nextCell => nextCell.Column);
                case Direction.Right: return cells.Where(nextCell => nextCell.Row == cell.Row && nextCell.Column < cell.Column).OrderByDescending(nextCell => nextCell.Column);
                case Direction.Up: return cells.Where(nextCell => nextCell.Column == cell.Column && nextCell.Row > cell.Row).OrderBy(nextCell => nextCell.Column);
                case Direction.Down: return cells.Where(nextCell => nextCell.Column == cell.Column && nextCell.Row < cell.Row).OrderByDescending(nextCell => nextCell.Column);
                default: throw new NotImplementedException();
            }
        }
    }
}
