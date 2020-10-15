using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public void returnButton()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
}
