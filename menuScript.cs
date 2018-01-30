using UnityEngine;
using UnityEngine.UI;// we need this namespace in order to access UI elements within our script
using System.Collections;
using UnityEngine.SceneManagement; // neded in order to load scenes

public class menuScript : MonoBehaviour
{
    public Button startText;
    public Button quitText;

    void Awake()

    {
        startText = GetComponent<Button>();
        quitText = GetComponent<Button>();
    }

    public void StartLevel() //this function will be used on our Play button

    {
        SceneManager.LoadScene("VRTerrainMap"); //this will load our first level from our build settings. "1" is the second scene in our game

    }

    public void ExitGame() //This function will be used on our "Yes" button in our Quit menu

    {
        Application.Quit(); //this will quit our game. Note this will only work after building the game

    }

}