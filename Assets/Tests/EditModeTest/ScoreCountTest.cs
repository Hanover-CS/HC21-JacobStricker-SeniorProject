using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreCountTest
    {
        [Test]
        public void testScoreCount()
        {
            //needed classes
            var player = new PlayerShip();
            //Test that counter starts at 0
            Assert.AreEqual(0, player.getScore());
            //function being tested
            player.ScorePoints(100);
            //check that score updated
            Assert.AreEqual(100, player.getScore());
        }
    }
}
