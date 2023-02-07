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

namespace tik_tak_toe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            label.Content = "Добро пожаловать в игру)))";
        }
        private int Part = 0;
        private int circle = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> ButtonsC = ButtGrid.Children.OfType<Button>().Select(x => x.Content.ToString()).ToList();
            List<Button> Buttons = ButtGrid.Children.OfType<Button>().Select(x => x).ToList();
            switch (Part)
            {
                case 0:
                    sender.GetType().GetProperty("Content").SetValue(sender, "Х");
                    Part = 1;
                    label.Content = "Сейчас ходят нолики";
                    break;
                case 1:
                    sender.GetType().GetProperty("Content").SetValue(sender, "O");
                    Part = 0;
                    label.Content = "Сейчас ходят крестики";
                    break;
            }
            sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
            bool chances = Win(ButtonsC);
            if (chances)
            {
                foreach (Button but in Buttons)
                {
                    but.GetType().GetProperty("IsEnabled").SetValue(but, false);
                }
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            List<Button> Buttons = ButtGrid.Children.OfType<Button>().Select(x => x).ToList();
            List<string> ButtonsC = ButtGrid.Children.OfType<Button>().Select(x => x.Content.ToString()).ToList();
            if (circle == 0)
            {
                foreach (Button but in Buttons)
                {
                    but.IsEnabled = true;
                }
            }
            else
            {
                for (int i = 0; i < Buttons.Count; i++)
                {
                    Buttons[i].IsEnabled = true;
                    MessageBox.Show(ButtonsC[i]);
                    Buttons[i].Content = "\n\n" + i;
                }
                Buttons[9].Content = "Перезапуск";
            }
            circle++;
        }

        private bool Win(List<string> Chance)
        {
            if ((Chance[0] == "X" || Chance[0] == "O") &&    Chance[0] == Chance[1] && Chance[1] == Chance[2])
            {
                MessageBox.Show($"Выиграли {Chance[0]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[0] == "X" || Chance[0] == "O") && Chance[0] == Chance[3] && Chance[3] == Chance[6])
            {
                MessageBox.Show($"Выиграли {Chance[0]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[0] == "X" || Chance[0] == "O") && Chance[0] == Chance[4] && Chance[4] == Chance[8])
            {
                MessageBox.Show($"Выиграли {Chance[0]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[1] == "X" || Chance[1] == "O") && Chance[1] == Chance[4] && Chance[4] == Chance[7])
            {
                MessageBox.Show($"Выиграли {Chance[1]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[2] == "X" || Chance[2] == "O") && Chance[2] == Chance[5] && Chance[5] == Chance[8])
            {
                MessageBox.Show($"Выиграли {Chance[2]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[2] == "X" || Chance[2] == "O") && Chance[2] == Chance[4] && Chance[4] == Chance[6])
            {
                MessageBox.Show($"Выиграли {Chance[2]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[3] == "X" || Chance[3] == "O") && Chance[3] == Chance[4] && Chance[4] == Chance[5])
            {
                MessageBox.Show($"Выиграли {Chance[3]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            else if ((Chance[6] == "X" || Chance[6] == "O") && Chance[6] == Chance[7] && Chance[7] == Chance[8])
            {
                MessageBox.Show($"Выиграли {Chance[6]}");
                label.Content = "Хотите переиграть?";
                return true;
            }
            return false;
        }
    }
}
