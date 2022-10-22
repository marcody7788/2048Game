using _2048Game.Models;
using System.Windows.Input;

namespace _2048Game.ViewModels
{
    public class GameViewModel
    {
        readonly GameManager _gameManager;
        public Game Game { get; }

        public GameViewModel()
        {
            Game = new Game();
            _gameManager = new GameManager(Game);
        }

        public ICommand MoveUp => _gameManager.MoveUp;
        public ICommand MoveLeft => _gameManager.MoveLeft;
        public ICommand MoveDown => _gameManager.MoveDown;
        public ICommand MoveRight => _gameManager.MoveRight;
        public ICommand StartGame => _gameManager.StartGame;

        public void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    MoveLeft.Execute(sender);
                    break;
                case SwipeDirection.Right:
                    MoveRight.Execute(sender);
                    break;
                case SwipeDirection.Up:
                    MoveUp.Execute(sender);
                    break;
                case SwipeDirection.Down:
                    MoveDown.Execute(sender);
                    break;
            }
        }
    }
}