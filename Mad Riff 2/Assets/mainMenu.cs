using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject transition;
    public AudioSource source;
    private float timeToStart = 5f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToStart -= Time.deltaTime;
        if (timeToStart < 0)
        {
            startGame();
        }
    }

    public void startGame() {
        Debug.Log("Starting Game");

        transition.GetComponent<Animator>().SetTrigger("FadeOut");
        SceneManager.LoadScene(1);
    }


    public void quitGame()
    {
        Debug.Log("Quiting Game");
        Application.Quit();
    }
}
