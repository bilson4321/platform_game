using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void onPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }   
}
