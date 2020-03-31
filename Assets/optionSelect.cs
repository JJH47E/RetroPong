using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class optionSelect : MonoBehaviour
{
    public TextMeshProUGUI diffButton, backButton, diffText;
    private Color seeThru;
    private int sel;
    private bool selected;
    public AudioSource menuSource;
    private int diffSel;
    public string[] diffs;
    public float[] speeds;

    // Start is called before the first frame update
    void Start()
    {
        diffSel = 0;
        seeThru = new Color(0f, 0f, 0f, 0f);
        diffButton.color = Color.white;
        backButton.color = seeThru;
        diffText.text = diffs[diffSel];
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
        diffText.text = diffs[diffSel];
    }

    void FixedUpdate()
    {
        if (sel == 2)
        {
            sel = 0;
        }
        else if (sel == -2)
        {
            sel = 0;
        }
        if (Mathf.Floor(sel) == 0)
        {
            //underline play
            diffButton.color = Color.white;
            backButton.color = seeThru;
        }
        else
        {
            //underline options
            diffButton.color = seeThru;
            backButton.color = Color.white;
        }
        if (selected == true)
        {
            if (Mathf.Floor(sel) == 0)
            {
                //cycle difficulties
                if (diffSel == 2)
                {
                    diffSel = 0;
                }
                else
                {
                    diffSel += 1;
                }
                selected = false;
            }
            else if (Mathf.Floor(sel) != 0)
            {
                //load menu scene
                PlayerPrefs.SetFloat("playerMove", speeds[diffSel]);
                SceneManager.LoadScene("MenuScreen");
            }
        }
    }
}
