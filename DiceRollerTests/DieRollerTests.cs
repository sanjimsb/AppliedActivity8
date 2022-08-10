using DiceRoller;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRollerTests
{
    [TestClass]
    public class DieRollerTests
    {
        [TestMethod]
        public void DieNullTest()
        {
            Die d = new Die();
            d.Should().NotBeNull();
        }
    }
}

