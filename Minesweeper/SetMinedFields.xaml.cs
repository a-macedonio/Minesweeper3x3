using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SetMinedFields : Window
    {
        private readonly Random rdm = new Random();

        //Boolean array representing the game board.
        //if a location is true, it means that a mine is active in this location
        private readonly bool[,] board = new bool[3, 3];


        public SetMinedFields()
        {
            InitializeComponent();
        }

        private void BtnAutogenerate_Click(object sender, RoutedEventArgs e)
        {
            AutoGenerateMinedFields();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(Utils.ValidateMinedFields(board))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "XML file (*.xml)|*.xml",
                    FileName = "minefield.xml"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, GenerateMineFieldXML().ToString());
                }
            }
            else
            {
                MessageBox.Show("The number of mined fileds must be between 1 and 8", "Invalid minefield configuration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void Btn0_0_Click(object sender, RoutedEventArgs e)
        {
            board[0, 0] = !board[0, 0];
            btn0_0.Content = Utils.AssignMinedOrNonMinedGivenBool(board[0, 0]);
        }

        private void Btn0_1_Click(object sender, RoutedEventArgs e)
        {
            board[0, 1] = !board[0, 1];
            btn0_1.Content = Utils.AssignMinedOrNonMinedGivenBool(board[0, 1]);
        }

        private void Btn0_2_Click(object sender, RoutedEventArgs e)
        {
            board[0, 2] = !board[0, 2];
            btn0_2.Content = Utils.AssignMinedOrNonMinedGivenBool(board[0, 2]);
        }



        private void Btn1_0_Click(object sender, RoutedEventArgs e)
        {
            board[1, 0] = !board[1, 0];
            btn1_0.Content = Utils.AssignMinedOrNonMinedGivenBool(board[1, 0]);
        }

        private void Btn1_1_Click(object sender, RoutedEventArgs e)
        {
            board[1, 1] = !board[1, 1];
            btn1_1.Content = Utils.AssignMinedOrNonMinedGivenBool(board[1, 1]);
        }

        private void Btn1_2_Click(object sender, RoutedEventArgs e)
        {
            board[1, 2] = !board[1, 2];
            btn1_2.Content = Utils.AssignMinedOrNonMinedGivenBool(board[1, 2]);
        }



        private void Btn2_0_Click(object sender, RoutedEventArgs e)
        {
            board[2, 0] = !board[2, 0];
            btn2_0.Content = Utils.AssignMinedOrNonMinedGivenBool(board[2, 0]);
        }

        private void Btn2_1_Click(object sender, RoutedEventArgs e)
        {
            board[2, 1] = !board[2, 1];
            btn2_1.Content = Utils.AssignMinedOrNonMinedGivenBool(board[2, 1]);
        }

        private void Btn2_2_Click(object sender, RoutedEventArgs e)
        {
            board[2, 2] = !board[2, 2];
            btn2_2.Content = Utils.AssignMinedOrNonMinedGivenBool(board[2, 2]);
        }

        private bool AssignRandomBool()
        {

            return rdm.Next(0, 2) > 0;
        }

        private string AssignYesOrNoGivenBool(bool value)
        {
            return value ? "yes" : "no";
        }
        private void AutoGenerateMinedFields()
        {
            board[0, 0] = AssignRandomBool();
            board[0, 1] = AssignRandomBool();
            board[0, 2] = AssignRandomBool();

            board[1, 0] = AssignRandomBool();
            board[1, 1] = AssignRandomBool();
            board[1, 2] = AssignRandomBool();

            board[2, 0] = AssignRandomBool();
            board[2, 1] = AssignRandomBool();
            board[2, 2] = AssignRandomBool();

            PrintMinedoNotMinedInButtonsContent();
        }

        private void PrintMinedoNotMinedInButtonsContent()
        {
            btn0_0.Content = Utils.AssignMinedOrNonMinedGivenBool(board[0, 0]);
            btn0_1.Content = Utils.AssignMinedOrNonMinedGivenBool(board[0, 1]);
            btn0_2.Content = Utils.AssignMinedOrNonMinedGivenBool(board[0, 2]);

            btn1_0.Content = Utils.AssignMinedOrNonMinedGivenBool(board[1, 0]);
            btn1_1.Content = Utils.AssignMinedOrNonMinedGivenBool(board[1, 1]);
            btn1_2.Content = Utils.AssignMinedOrNonMinedGivenBool(board[1, 2]);

            btn2_0.Content = Utils.AssignMinedOrNonMinedGivenBool(board[2, 0]);
            btn2_1.Content = Utils.AssignMinedOrNonMinedGivenBool(board[2, 1]);
            btn2_2.Content = Utils.AssignMinedOrNonMinedGivenBool(board[2, 2]);
        }

        public XDocument GenerateMineFieldXML()
        {
            StringBuilder output = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(output);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Fields");

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "0");
            xmlWriter.WriteAttributeString("column", "0");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[0, 0]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "0");
            xmlWriter.WriteAttributeString("column", "1");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[0, 1]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "0");
            xmlWriter.WriteAttributeString("column", "2");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[0, 2]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "1");
            xmlWriter.WriteAttributeString("column", "0");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[1, 0]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "1");
            xmlWriter.WriteAttributeString("column", "1");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[1, 1]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "1");
            xmlWriter.WriteAttributeString("column", "2");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[1, 2]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "2");
            xmlWriter.WriteAttributeString("column", "0");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[2, 0]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "2");
            xmlWriter.WriteAttributeString("column", "1");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[2, 1]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Field");
            xmlWriter.WriteAttributeString("row", "2");
            xmlWriter.WriteAttributeString("column", "2");
            xmlWriter.WriteStartElement("Mine");
            xmlWriter.WriteAttributeString("active", AssignYesOrNoGivenBool(board[2, 2]));
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            return XDocument.Parse(output.ToString());
        }

    }
}
