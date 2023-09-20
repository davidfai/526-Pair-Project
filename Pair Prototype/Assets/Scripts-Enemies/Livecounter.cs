using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Livecounter : MonoBehaviour
{
    public GameObject h1, h2, h3;
    public SceneLoader sceneLoader;
    public int lives;
    public Scene losescreen;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        h1.gameObject.SetActive(true);
        h2.gameObject.SetActive(true);
        h3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (lives)
        {
            case 3:
                h1.gameObject.SetActive(true);
                h2.gameObject.SetActive(true);
                h3.gameObject.SetActive(true);
                break;
            case 2:
                h1.gameObject.SetActive(true);
                h2.gameObject.SetActive(true);
                h3.gameObject.SetActive(false);
                break;
            case 1:
                h1.gameObject.SetActive(true);
                h2.gameObject.SetActive(false);
                h3.gameObject.SetActive(false);
                break;
            case 0:
                SceneManager.LoadScene(sceneLoader.sceneName);
                break;

        }
        
    }
}
