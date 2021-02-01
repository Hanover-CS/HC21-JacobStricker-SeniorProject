using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerShipTest
    {
        [UnityTest]
        public IEnumerator testPlayerScoreAccumulation()
        {
            //set up
            var gameObjectScoreUI = new GameObject();
            var testScoreUI = gameObjectScoreUI.AddComponent<ScoreUI>();

            //var gameObjectPlayer = new GameObject();
            //var testPlayer = gameObjectPlayer.AddComponent<PlayerShip>();

            //testPlayer.scoreUI = testScoreUI;
            //Assert.AreEqual(0, testPlayer.getScore());

            //function callS
            //testPlayer.ScorePoints(150);
            //testPlayer.ScorePoints(100);
            //testPLayer.ScorePoints(50);
            //testPLayer.ScorePoints(50);

            //Assertion
            //Assert.AreEqual(350, testPlayer.getScore());
            yield return null;
        }
    }
}
