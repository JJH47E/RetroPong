using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuSelect : MonoBehaviour
{
    public TextMeshProUGUI playButton, optionsButton;
    private Color seeThru;
    private int sel;
    private bool selected;
    public AudioSource menuSource;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("InGame");
        SceneManager.UnloadSceneAsync("OptionSceen");
        seeThru = new Color(0f, 0f, 0f, 0f);
        playButton.color = Color.white;
        optionsButton.color = seeThru;
        sel = 0;
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            sel -= 1;
            menuSource.Play();
        }
        if (Input.GetKeyDown("down"))
        {
            sel += 1;
            menuSource.Play();
        }
        if (Input.GetKeyDown("space"))
        {
            selected = true;
            menuSource.Play();
        }
    }

    void FixedUpdate()
    {
        if(sel == 2)
        {
            sel = 0;
        }
        else if (sel == -2)
        {
            sel = 0;
        }
        if(Mathf.Floor(sel) == 0)
        {
            //underline play
            playButton.color = Color.white;
            optionsButton.color = seeThru;
        }
        else
        {
            //underline options
            playButton.color = seeThru;
            optionsButton.color = Color.white;
        }
        if(selected == true)
        {
            if(Mathf.Floor(sel) == 0)
            {
                //load play scene
                SceneManager.LoadScene("InGame");
            }
            else if(Mathf.Floor(sel) != 0)
            {
                //load options scene
                SceneManager.LoadScene("OptionScreen");
            }
        }
    }
}
