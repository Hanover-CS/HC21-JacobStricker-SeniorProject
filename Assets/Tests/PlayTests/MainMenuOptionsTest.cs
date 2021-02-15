using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MainMenuOptionsTest
    {
        [UnityTest]
        public IEnumerator optionsButtonAndMenuTest()
        {
            //set up
            GameObject  menuOptions = new GameObject();
            var menuScript = menuOptions.AddComponent<MainMenu>();

            GameObject OptionMenu = new GameObject();
            var optionsMenuScript = OptionMenu.AddComponent<OptionsMenu>();
            GameObject MainMenu = new GameObject();

            //sets mainMenu and options menu variables for both active scripts
            menuScript.optionsMenu = OptionMenu;
            //Debug.Log("optionsMenu = " + menuScript.optionsMenu);
            menuScript.mainMenu = MainMenu;
            //Debug.Log("mainMenu = " + menuScript.mainMenu);
            optionsMenuScript.optionsMenu = OptionMenu;
            //Debug.Log("optionsMenu = " + optionsMenuScript.optionsMenu);
            optionsMenuScript.mainMenu = MainMenu;
            //Debug.Log("mainMenu = " + optionsMenuScript.mainMenu);

            //sets starting states
            OptionMenu.SetActive(false);
            MainMenu.SetActive(true);

            //check starting sates
            Assert.IsFalse(OptionMenu.activeSelf);
            Assert.IsTrue(MainMenu.activeSelf);

            //run function to open options menu
            menuScript.options();

            //check that states changed
            Assert.IsTrue(OptionMenu.activeSelf);
            Assert.IsFalse(MainMenu.activeSelf);

            //run function that returns to the main menu
            optionsMenuScript.returnButton();

            //check that states returned
            Assert.IsFalse(OptionMenu.activeSelf);
            Assert.IsTrue(MainMenu.activeSelf);

            yield return null;
        }
    }
}
