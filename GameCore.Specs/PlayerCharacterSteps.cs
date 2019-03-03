using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {

        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When("I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(int health)
        {
            Assert.Equal(health, _player.Health);
        }

        [Then(@"I should be dead")]
        public void ThenIShouldBeDead()
        {
            Assert.Equal(true, _player.isDead);
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void GivenIHaveADamageResistanceOf(int damageResistance)
        {
            _player.DamageResistance = damageResistance;
        }

        [Given(@"I'm an Elf")]
        public void GivenIMAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIs(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }

        [When(@"cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _player.CastHealingSpell();
        }

        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {
            // weakly type version 

            //foreach(var row in table.Rows)
            //{
            //var name = row["item"];
            //var value = row["value"];
            //var power = row["power"];
            //_player.MagicalItems.Add(new MagicalItem
            //{
            //    Name = name,
            //    Value = int.Parse(value),
            //    Power = int.Parse(power)
            //});
            //}

            // strong type version

            //IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();
            //_player.MagicalItems.AddRange(items);

            // dynamic version

            IEnumerable<dynamic> items = table.CreateDynamicSet();
            foreach (var magicalItem in items)
            {
                _player.MagicalItems.Add(new MagicalItem
                    {
                    Name = magicalItem.name,
                    Value = magicalItem.value,
                    Power = magicalItem.power
                    }
                );
            }

        }

        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int expectedPower)
        {
            Assert.Equal(expectedPower, _player.MagicalPower);
        }




    }
}
