using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	

	void Start ()
	{
		
	}

    public void loadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
