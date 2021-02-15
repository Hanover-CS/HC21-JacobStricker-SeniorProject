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
        public IEnumerator testPlayerShipScoreAndDeath()
        {
            //set up
            GameObject gameObjectScoreUI = new GameObject();
            var scoreUI = gameObjectScoreUI.AddComponent<scoreUIStub>();
            gameObjectScoreUI.tag="scoreDisplay1";

            GameObject gameObjectPlayer = new GameObject();
            Rigidbody2D rb = gameObjectPlayer.AddComponent<Rigidbody2D>();
            var testPlayer = gameObjectPlayer.AddComponent<PlayerShip>();
            yield return null; //finishes set up before running scripts

            //Tests that PlayerShip start() initilizes score correctly
            //Debug.Log("Player = " + testPlayer.getScore() + " score UI = " + scoreUI.currentScore);
            Assert.AreEqual(scoreUI.currentScore, testPlayer.getScore());

            //function calls with Tests
            testPlayer.ScorePoints(150);
            Assert.AreEqual(scoreUI.currentScore, testPlayer.getScore());
            //Debug.Log("Player = " + testPlayer.getScore() + "  scoreUI = " + scoreUI.currentScore);

            testPlayer.ScorePoints(100);
            Assert.AreEqual(scoreUI.currentScore, testPlayer.getScore());
            //Debug.Log("Player = " + testPlayer.getScore() + "  scoreUI = " + scoreUI.currentScore);

            testPlayer.ScorePoints(50);
            Assert.AreEqual(scoreUI.currentScore, testPlayer.getScore());
            //Debug.Log("Player = " + testPlayer.getScore() + "  scoreUI = " + scoreUI.currentScore);

            testPlayer.ScorePoints(50);
            Assert.AreEqual(scoreUI.currentScore, testPlayer.getScore());
            //Debug.Log("Player = " + testPlayer.getScore() + "  scoreUI = " + scoreUI.currentScore);     

            //Assert.IsNotNull(gameObjectPlayer);
        }
    }
}
