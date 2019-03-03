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

        public List<Weapon> Weapons = new List<Weapon>();

        public int WeaponsValue
        {
            get { return Weapons.Sum(x => x.Value); }
        }

        public CharacterClass CharacterClass { get; set; }

        public DateTime LastSleepTime { get; set; }

        public List<MagicalItem> MagicalItems = new List<MagicalItem>();

        public int MagicalPower
        {
            get { return MagicalItems.Sum(x => x.Power); }
        }

        public void Hit(int damage)
        {
            var raceSpecificDamageResistance = 0;

            if (Race == "Elf")
            {
                raceSpecificDamageResistance = 20;
            }

            var totalDamageTaken = Math.Max(damage - raceSpecificDamageResistance - DamageResistance,0);

            Health -= totalDamageTaken;
            if (Health <= 0)
            {
                isDead = true;
            }
            
        }

        public void CastHealingSpell()
        {
            if (CharacterClass == CharacterClass.Healer)
            {
                Health = 100;
            }
            else
            {
                Health += 10;
            }
        }

        public void ReadHealthScroll()
        {
            var daysSinceLastSleep = DateTime.Now.Subtract(LastSleepTime).Days;
            if (daysSinceLastSleep <= 2)
            {
                Health = 100;
            }
        }

        public void UseMagicalItem(string itemName)
        {
            int powerReduction = 10;

            if (Race == "Elf")
            {
                powerReduction = 0;
            }

            var itemToReduce = MagicalItems.First(item => item.Name == itemName);
            itemToReduce.Power -= powerReduction;
        }

    }
}
