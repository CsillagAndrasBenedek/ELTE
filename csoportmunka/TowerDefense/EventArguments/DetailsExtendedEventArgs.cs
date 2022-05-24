using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.EventArguments
{
    public class DetailsExtendedEventArgs
    {
        public List<GameObject> ChosenField { get; set; }
        public int CurrentPlayer { get; set; }

        public DetailsExtendedEventArgs(List<GameObject> chosenField, int currentPlayer)
        {
            ChosenField = chosenField;
            CurrentPlayer = currentPlayer;
        }
    }
}
