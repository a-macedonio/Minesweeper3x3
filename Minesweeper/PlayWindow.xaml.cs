using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml;
using static Minesweeper.GameXml;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for PlayWindow.xaml
    /// </summary>
    public partial class PlayWindow : Window
    {
        private string xmlSource;
        private GameXml gameXml;
        DateTime startTime;

        //Boolean array representing the game board.
        //if a location is true, it means that a mine is active in this location
        private readonly bool[,] board = new bool[3, 3];

        public PlayWindow()
        {
            InitializeComponent();
        }

        public void YouLose()
        {
            RevealMinedFields();
            MessageBox.Show("Better luck next time", "You lose", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void YouWin()
        {
            RevealMinedFields();
            MessageBox.Show("You Win", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Btn0_0_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[0, 0]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss"));
            if ((board[0, 0]))
            {
                btn0_0.FontSize = 40;
                YouLose();
            }
            else
            {
                btn0_0.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_0_0);
                btn0_0.IsHitTestVisible = false;
                btn0_0.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn0_1_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[0, 1]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss"));
            if ((board[0, 1]))
            {
                btn0_1.FontSize = 40;
                YouLose();
            }
            else
            {
                btn0_1.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_0_1);
                btn0_1.IsHitTestVisible = false;
                btn0_1.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn0_2_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[0, 2]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss")); 
            if ((board[0, 2]))
            {
                btn0_2.FontSize = 40;
                YouLose();
            }
            else
            {
                btn0_2.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_0_2);
                btn0_2.IsHitTestVisible = false;
                btn0_2.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn1_0_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[1, 0]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss"));
            if ((board[1, 0]))
            {
                btn1_0.FontSize = 40;
                YouLose();
            }
            else
            {
                btn1_0.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_1_0);
                btn1_0.IsHitTestVisible = false;
                btn1_0.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn1_1_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[1, 1]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss"));
            if ((board[1, 1]))
            {
                btn1_1.FontSize = 40;
                YouLose();
            }
            else
            {
                btn1_1.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_1_1);
                btn1_1.IsHitTestVisible = false;
                btn1_1.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn1_2_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[1, 2]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss"));
            if ((board[1, 2]))
            {
                btn1_2.FontSize = 40;
                YouLose();
            }
            else
            {
                btn1_2.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_1_2);
                btn1_2.IsHitTestVisible = false;
                btn1_2.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn2_0_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[2, 0]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss"));
            if ((board[2, 0]))
            {
                btn2_0.FontSize = 40;
                YouLose();
            }
            else
            {
                btn2_0.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_2_0);
                btn2_0.IsHitTestVisible = false;
                btn2_0.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn2_1_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[2, 1]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss")); 
            if ((board[2, 1]))
            {
                btn2_1.FontSize = 40;
                YouLose();
            }
            else
            {
                btn2_1.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_2_1);
                btn2_1.IsHitTestVisible = false;
                btn2_1.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void Btn2_2_Click(object sender, RoutedEventArgs e)
        {
            gameXml.AppendStep("[2, 2]", UserType.user, (DateTime.Now - startTime).ToString(@"mm\:ss")); 
            if ((board[2, 2]))
            {
                btn2_2.FontSize = 40;
                YouLose();
            }
            else
            {
                btn2_2.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_2_2);
                btn2_2.IsHitTestVisible = false;
                btn2_2.Background = Brushes.LightGreen;
                VerifyWin();
            }
        }

        private void BtnLoadMinedFields_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            { 
                xmlSource = File.ReadAllText(openFileDialog.FileName);
                AssignMinedFieldsFromXmlSource();
            }
        }

        private void BtnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML file (*.xml)|*.xml",
                FileName = "game.xml"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, gameXml.GetxmlGame().ToString());
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void AssignMinedFieldsFromXmlSource()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlSource);

            if (!xmlDoc.DocumentElement.ChildNodes[0].Name.Equals("Field"))
            {
                MessageBox.Show("The XML provided is not valid", "Invalid XML", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                int childNodeIndex = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j] = (xmlDoc.DocumentElement.ChildNodes[childNodeIndex].ChildNodes[0].Attributes["active"].Value).Equals("yes");
                        childNodeIndex++;
                    }
                }
                if (Utils.ValidateMinedFields(board))
                {
                    InitializeBoardGame();
                }
                else
                {
                    MessageBox.Show("The number of mined fileds in the minefield.xml file must be between 1 and 8", "Invalid minefield configuration", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void InitializeBoardGame()
        {
            BrushAllBoardFields(Brushes.DodgerBlue);
            SetHitTestVisibleInAllBoardFields(true);
            ClearAllContentBoardFields();
            RestartContentFontSizesInAllBoardFields();
            btnSaveGame.IsEnabled = true;
            btnPassMove.IsEnabled = true;
            gameXml = new GameXml();

            
            startTime = DateTime.Now;
        }


        private void RevealMinedFields()
        {
            if (board[0, 0]) { btn0_0.Content = "M"; btn0_0.Background = Brushes.LightPink; }
            if (board[0, 1]) { btn0_1.Content = "M"; btn0_1.Background = Brushes.LightPink; }
            if (board[0, 2]) { btn0_2.Content = "M"; btn0_2.Background = Brushes.LightPink; }
                                                                                           
            if (board[1, 0]) { btn1_0.Content = "M"; btn1_0.Background = Brushes.LightPink; }
            if (board[1, 1]) { btn1_1.Content = "M"; btn1_1.Background = Brushes.LightPink; }
            if (board[1, 2]) { btn1_2.Content = "M"; btn1_2.Background = Brushes.LightPink; }
                                                                                           
            if (board[2, 0]) { btn2_0.Content = "M"; btn2_0.Background = Brushes.LightPink; }
            if (board[2, 1]) { btn2_1.Content = "M"; btn2_1.Background = Brushes.LightPink; }
            if (board[2, 2]) { btn2_2.Content = "M"; btn2_2.Background = Brushes.LightPink; }

            SetHitTestVisibleInAllBoardFields(false);
            btnPassMove.IsEnabled = false;
        }

        private void SetHitTestVisibleInAllBoardFields(bool value)
        {
            btn0_0.IsHitTestVisible = value;
            btn0_1.IsHitTestVisible = value;
            btn0_2.IsHitTestVisible = value;
                                      
            btn1_0.IsHitTestVisible = value;
            btn1_1.IsHitTestVisible = value;
            btn1_2.IsHitTestVisible = value;
                                      
            btn2_0.IsHitTestVisible = value;
            btn2_1.IsHitTestVisible = value;
            btn2_2.IsHitTestVisible = value;
        }

        private void BrushAllBoardFields(SolidColorBrush color) 
        {
            btn0_0.Background = color;
            btn0_1.Background = color;
            btn0_2.Background = color;
                                 
            btn1_0.Background = color;
            btn1_1.Background = color;
            btn1_2.Background = color;
                                
            btn2_0.Background = color;
            btn2_1.Background = color;
            btn2_2.Background = color;
        }

        private void ClearAllContentBoardFields()
        {
            btn0_0.Content = "";
            btn0_1.Content = "";
            btn0_2.Content = "";
                             
            btn1_0.Content = "";
            btn1_1.Content = "";
            btn1_2.Content = "";
                             
            btn2_0.Content = "";
            btn2_1.Content = "";
            btn2_2.Content = "";
        }

        private void RestartContentFontSizesInAllBoardFields()
        {
            btn0_0.FontSize = 16;
            btn0_1.FontSize = 16;
            btn0_2.FontSize = 16;

            btn1_0.FontSize = 16;
            btn1_1.FontSize = 16;
            btn1_2.FontSize = 16;

            btn2_0.FontSize = 16;
            btn2_1.FontSize = 16;
            btn2_2.FontSize = 16;
        }

        private int PrintNumberOfAdjacentMines(BoardLocation loc)
        {
            int adjacentMines = 0;
            switch(loc)
            {
                case BoardLocation.LOC_0_0:
                    if (board[0, 1]) adjacentMines++;
                    if (board[1, 0]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    break;
                case BoardLocation.LOC_0_1:
                    if (board[0, 0]) adjacentMines++;
                    if (board[0, 2]) adjacentMines++;
                    if (board[1, 0]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    if (board[1, 2]) adjacentMines++;
                    break;
                case BoardLocation.LOC_0_2:
                    if (board[0, 1]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    if (board[1, 2]) adjacentMines++;
                    break;

                case BoardLocation.LOC_1_0:
                    if (board[0, 0]) adjacentMines++;
                    if (board[0, 1]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    if (board[2, 0]) adjacentMines++;
                    if (board[2, 1]) adjacentMines++;
                    break;
                case BoardLocation.LOC_1_1:
                    if (board[0, 0]) adjacentMines++;
                    if (board[0, 1]) adjacentMines++;
                    if (board[0, 2]) adjacentMines++;
                    if (board[1, 0]) adjacentMines++;
                    if (board[1, 2]) adjacentMines++;
                    if (board[2, 0]) adjacentMines++;
                    if (board[2, 1]) adjacentMines++;
                    if (board[2, 2]) adjacentMines++;
                    break;
                case BoardLocation.LOC_1_2:
                    if (board[0, 1]) adjacentMines++;
                    if (board[0, 2]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    if (board[2, 1]) adjacentMines++;
                    if (board[2, 2]) adjacentMines++;
                    break;

                case BoardLocation.LOC_2_0:
                    if (board[1, 0]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    if (board[2, 1]) adjacentMines++;
                    break;
                case BoardLocation.LOC_2_1:
                    if (board[1, 0]) adjacentMines++;
                    if (board[1, 1]) adjacentMines++;
                    if (board[1, 2]) adjacentMines++;
                    if (board[2, 0]) adjacentMines++;
                    if (board[2, 2]) adjacentMines++;
                    break;
                case BoardLocation.LOC_2_2:
                    if (board[1, 1]) adjacentMines++;
                    if (board[1, 2]) adjacentMines++;
                    if (board[2, 1]) adjacentMines++;
                    break;
            }
            return adjacentMines;
        }

        public void VerifyWin()
        {
            int uncoverFields = 0;
            int minedFields = 0;

            if(btn0_0.IsHitTestVisible)
            {
                uncoverFields++;
                if(board[0, 0])
                {
                    minedFields++;
                }
            }

            if (btn0_1.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[0, 1])
                {
                    minedFields++;
                }
            }

            if (btn0_2.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[0, 2])
                {
                    minedFields++;
                }
            }

            if (btn1_0.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[1, 0])
                {
                    minedFields++;
                }
            }

            if (btn1_1.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[1, 1])
                {
                    minedFields++;
                }
            }

            if (btn1_2.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[1, 2])
                {
                    minedFields++;
                }
            }

            if (btn2_0.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[2, 0])
                {
                    minedFields++;
                }
            }

            if (btn2_1.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[2, 1])
                {
                    minedFields++;
                }
            }

            if (btn2_2.IsHitTestVisible)
            {
                uncoverFields++;
                if (board[2, 2])
                {
                    minedFields++;
                }
            }

            if (uncoverFields == minedFields) YouWin();
        }

        enum BoardLocation
        {
            LOC_0_0,
            LOC_0_1,
            LOC_0_2,

            LOC_1_0,
            LOC_1_1,
            LOC_1_2,

            LOC_2_0,
            LOC_2_1,
            LOC_2_2
        }

        private void BtnPassMove_Click(object sender, RoutedEventArgs e)
        {
            //Look for a non-mined field and click it
            if (btn0_0.IsHitTestVisible && !board[0, 0])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_0_0);
            }
            else if (btn0_1.IsHitTestVisible && !board[0, 1])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_0_1);
            }
            else if (btn0_2.IsHitTestVisible && !board[0, 2])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_0_2);
            }
            else if (btn1_0.IsHitTestVisible && !board[1, 0])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_1_0);
            }
            else if (btn1_1.IsHitTestVisible && !board[1, 1])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_1_1);
            }
            else if (btn1_2.IsHitTestVisible && !board[1, 2])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_1_2);
            }
            else if (btn2_0.IsHitTestVisible && !board[2, 0])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_2_0);
            }
            else if (btn2_1.IsHitTestVisible && !board[2, 1])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_2_1);
            }
            else if (btn2_2.IsHitTestVisible && !board[2, 2])
            {
                ClickFieldButtonGivenLocation(BoardLocation.LOC_2_2);
            }
        }

        private void ClickFieldButtonGivenLocation(BoardLocation loc)
        {
            switch (loc)
            {
                case BoardLocation.LOC_0_0:
                    gameXml.AppendStep("[0, 0]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn0_0.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_0_0);
                    btn0_0.IsHitTestVisible = false;
                    btn0_0.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
                case BoardLocation.LOC_0_1:
                    gameXml.AppendStep("[0, 1]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn0_1.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_0_1);
                    btn0_1.IsHitTestVisible = false;
                    btn0_1.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
                case BoardLocation.LOC_0_2:
                    gameXml.AppendStep("[0, 2]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn0_2.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_0_2);
                    btn0_2.IsHitTestVisible = false;
                    btn0_2.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;

                case BoardLocation.LOC_1_0:
                    gameXml.AppendStep("[1, 0]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn1_0.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_1_0);
                    btn1_0.IsHitTestVisible = false;
                    btn1_0.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
                case BoardLocation.LOC_1_1:
                    gameXml.AppendStep("[1, 1]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn1_1.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_1_1);
                    btn1_1.IsHitTestVisible = false;
                    btn1_1.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
                case BoardLocation.LOC_1_2:
                    gameXml.AppendStep("[1, 2]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn1_2.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_1_2);
                    btn1_2.IsHitTestVisible = false;
                    btn1_2.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;

                case BoardLocation.LOC_2_0:
                    gameXml.AppendStep("[2, 0]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn2_0.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_2_0);
                    btn2_0.IsHitTestVisible = false;
                    btn2_0.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
                case BoardLocation.LOC_2_1:
                    gameXml.AppendStep("[2, 1]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn2_1.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_2_1);
                    btn2_1.IsHitTestVisible = false;
                    btn2_1.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
                case BoardLocation.LOC_2_2:
                    gameXml.AppendStep("[2, 2]", GameXml.UserType.computer, (DateTime.Now - startTime).ToString(@"mm\:ss"));
                    btn2_2.Content = PrintNumberOfAdjacentMines(BoardLocation.LOC_2_2);
                    btn2_2.IsHitTestVisible = false;
                    btn2_2.Background = Brushes.LightGreen;
                    VerifyWin();
                    break;
            }
        }
    }
}
