using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Linq;


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
            string race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            string resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];
            _player.Race = race;
            _player.DamageResistance = Convert.ToInt32(resistance);
        }



    }
}
