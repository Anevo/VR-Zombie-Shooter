using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;
using UnityEngine.SceneManagement; // neded in order to load scenes

public class menuScriptTerrain : MonoBehaviour
{
    public Button enterText;
    public Button exitText;

    void Awake()

    {
        enterText = GetComponent<Button>();
        exitText = GetComponent<Button>();
    }

    public void StartNextLevel() //this function will be used on our Play button

    {
        SceneManager.LoadScene("VRZombieLevel"); //this will load our first level from our build settings. "1" is the second scene in our game

    }

    public void ReturnMenu() //This function will be used on our "Yes" button in our Quit menu

    {
        SceneManager.LoadScene("VRMainMenu"); //this will quit our game. Note this will only work after building the game

    }

}