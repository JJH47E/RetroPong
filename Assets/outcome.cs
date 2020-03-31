using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class outcome : MonoBehaviour
{
    public TextMeshProUGUI t;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("endGame") == 1)
        {
            t.text = "you won";
        }
        else
        {
            t.text = "you lost";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }

    void FixedUpdate()
    {
        if(pressed == true)
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }
}
