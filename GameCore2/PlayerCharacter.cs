﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class PlayerCharacter
    {

        public int Health { get; private set; } = 100;

        public bool isDead { get; private set; }

        public int DamageResistance { get; set; }

        public string Race { get; set; }


        public void Hit(int damage)
        {
            var raceSpecificDamageResistance = 0;

            if (Race == "Elf")
            {
                raceSpecificDamageResistance = 20;
            }

            var totalDamageTaken = Math.Max(damage - raceSpecificDamageResistance - DamageResistance,0);

            Health -= damage;
            if (Health <= 0)
            {
                isDead = true;
            }
            
        }

    }
}