using UnityEngine;
using UnityEngine.SceneManagement;

    /**
     * MainMenu
     * 
     * All the menu functions for the buttons in the main menu go here 
     **/
public class MainMenu : MonoBehaviour {

	

	void Start ()
	{
		
	}

    /**
     * Loads the specified level from the build index.
     * 
     * int i: Build index to load
     **/
    public void loadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
