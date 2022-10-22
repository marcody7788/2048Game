using _2048Game.ViewModels;

namespace _2048Game.Views;

public partial class GameView : ContentPage
{
    public GameView()
    {
        InitializeComponent();
        this.BindingContext = new GameViewModel();
    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        (this.BindingContext as GameViewModel).OnSwiped(sender, e);

    }
}