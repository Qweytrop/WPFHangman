using Forca.Controller;
using Forca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forca.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController controller;
        bool alreadyDead = false;

        public MainWindow()
        {
            InitializeComponent();
            
            // Tela
            KeyboardButtons();

            // Controller
            controller = new GameController();

            // New Game
            NewGameBtn_Click(null , null);
        }
        
        private void NewGameBtn_Click(object sender, RoutedEventArgs e)
        {
            GameState gameState = controller.NewGame();
            GameStateUpdater(gameState);
            alreadyDead = false;
        }
        
        private void KeyboardButtons() // faz botão
        {
            for (int i = 0; i <= 6; i++)
            {
                if (i <= 4)
                {
                    keyboardMenu.RowDefinitions.Add(new());
                }
                keyboardMenu.ColumnDefinitions.Add(new());
            }


            for (int i = (int)'A', j = 0; i <= (int)'Z'; i++, j++)
            {
                Button botoes = new();
                botoes.Style = (Style)this.FindResource("KeyboardButton");
                char btnContent = (char)i;
                botoes.Content = btnContent;
                botoes.Click += (object sender, RoutedEventArgs args) => { Click(botoes, btnContent); };

                if (j == 24)
                {
                    Grid.SetRow(botoes, 4);
                    Grid.SetColumn(botoes, 2);
                    keyboardMenu.Children.Add(botoes);
                    continue;
                }

                if (j == 25)
                {
                    Grid.SetRow(botoes, 4);
                    Grid.SetColumn(botoes, 3);
                    keyboardMenu.Children.Add(botoes);
                    break;
                }

                Grid.SetRow(botoes, j / 6);
                Grid.SetColumn(botoes, j % 6);

                keyboardMenu.Children.Add(botoes);
            }
        }

        public void Click(Button btn, char guess)
        {
            if (alreadyDead)
                return;

            GameState gameState = controller.Guess(guess);
            GameStateUpdater(gameState);
            if (!gameState.IsAlive)
                alreadyDead = true;

        }

        public void GameStateUpdater(GameState gamestate)
        {
            myDude.Source = (ImageSource)FindResource(gamestate.Health.ToString() + "hp");
            guessWord.Text = gamestate.VeiledWord;
            guessList.Text = gamestate.WrongGuesses;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
