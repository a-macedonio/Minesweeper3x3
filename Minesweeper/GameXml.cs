using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Minesweeper
{
    class GameXml
    {
        private readonly XmlDocument gameXml;
        private readonly XmlElement game;
        private readonly XmlElement move;
        private int stepId;

        public GameXml()
        {
            gameXml = new XmlDocument();
            game = gameXml.CreateElement("Game");
            move = gameXml.CreateElement("Move");
            gameXml.AppendChild(game);
            game.AppendChild(move);
            stepId = 1;
        }

        public void AppendStep(string column_row, UserType userType, string time) 
        {
            XmlElement step = gameXml.CreateElement("Step");
            step.SetAttribute("id", stepId++.ToString());
            step.SetAttribute("time", time);

            XmlElement player = gameXml.CreateElement("Player");
            player.SetAttribute("type", userType.ToString());

            XmlElement play = gameXml.CreateElement("Play");
            play.SetAttribute("sign", (userType.Equals("user")?"X":"0"));
            XmlText playText = gameXml.CreateTextNode(column_row);

            step.AppendChild(player);
            step.AppendChild(play);
            play.AppendChild(playText);
            move.AppendChild(step);
        }

        public XDocument GetxmlGame()
        {
            return XDocument.Parse(gameXml.OuterXml);
        }

        public enum UserType
        {
            user,computer
        }
    }
}
