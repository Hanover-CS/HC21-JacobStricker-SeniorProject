using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PauseMenuTest
    {
        [UnityTest]
        public IEnumerator PauseMenuTestWithEnumeratorPasses()
        {
            //set up needed objects
            GameObject PauseMenu = new GameObject();
            var PauseMenuScript = PauseMenu.AddComponent<PauseMenu>();

            GameObject PauseMenuUI = new GameObject();

            GameObject GameOverUI = new GameObject();

            //set PauseMenuScript Variables
            PauseMenuScript.pauseMenuUI = PauseMenuUI;
            PauseMenuScript.gameOverUI = GameOverUI;

            //set starting state --Game in progress both menues inactive
            PauseMenuUI.SetActive(false);
            GameOverUI.SetActive(false);

            //pause the game
            PauseMenuScript.Pause();

            //check status
            Assert.IsTrue(PauseMenuUI.activeSelf);
            Assert.IsFalse(GameOverUI.activeSelf);
            //Assert.IsTrue(PauseMenuScript.gamePaused);

            //Resume Game
            PauseMenuScript.Resume();

            //check status
            Assert.IsFalse(PauseMenuUI.activeSelf);
            Assert.IsFalse(GameOverUI.activeSelf);
            //Assert.IsFalse(PauseMenuScript.gamePaused);

            //#######This test is not possible as the function calls and checks are located in the update of the PuaseMenu.cs file######
            //Setting status of game to gameOver screen
            //PauseMenuUI.SetActive(false);
            //GameOverUI.SetActive(true);

            //check status
            //Assert.IsFalse(PauseMenuUI.activeSelf);
            //Assert.IsTrue(GameOverUI.activeSelf);

            //attempt to pause game
            //PauseMenuScript.Pause();

            //check status
            //Assert.IsFalse(PauseMenuUI.activeSelf);
            //Assert.IsTrue(GameOverUI.activeSelf);

            yield return null;
        }
    }
}
