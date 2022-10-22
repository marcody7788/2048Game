using _2048Game.Models.Enums;

namespace _2048Game.Models
{
    public static class GameStateHelper
    {
        public static string GetText(GameState state)
        {
            return state switch
            {
                GameState.Win => "You win 😀",
                GameState.Lost => "You lost 😭",
                GameState.NotStarted or GameState.Started => string.Empty,
                _ => null,
            };
        }

        internal static object GetStartGameText(GameState state)
        {
            return state switch
            {
                GameState.Started => "Restart game",
                GameState.Lost => "Try again",
                GameState.NotStarted or GameState.Win => "Start game",
                _ => null,
            };
        }

        internal static bool MoveEnabled(GameState gameState) => gameState == GameState.Started;
    }
}