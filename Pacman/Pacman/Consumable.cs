using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Consumable
    {
        public bool collected;

        Random rnd = new Random();

        protected bool type;

        string[] consumables = new string[2] { @"card", @"book" };

        public string RandomConsumable()
        {
            int randomConsumable = rnd.Next(consumables.Length);
            collected = false;
            return
                consumables[randomConsumable];


        }
    }
}
