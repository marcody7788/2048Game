using _2048Game.Views;

namespace _2048Game;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new GameView();
	}
}
