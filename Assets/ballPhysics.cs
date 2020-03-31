using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ballPhysics : MonoBehaviour
{
    private float magnitude;
    private float hor;
    private float ver;
    public Rigidbody2D rb;
    private Vector2 vec;
    private Vector3 reset;
    public Transform ball;
    public int myScore, enemyScore;
    private int pick;
    public TextMeshProUGUI playerGoals, enemyGoals;
    public AudioSource goalSource, hitSource;

    // Start is called before the first frame update
    void Start()
    {
        reset = new Vector3(0f, 0f, 0f);
        magnitude = PlayerPrefs.GetFloat("playerMove") * 1f;
        ver = UnityEngine.Random.Range(((magnitude * 0.2f)), ((magnitude * 0.7f)));
        pick = UnityEngine.Random.Range(0, 2);
        Debug.Log(pick);
        if(pick == 1)
        {
            ver = -ver;
        }
        hor = (float) Math.Pow((Math.Pow(magnitude, 2) - Math.Pow(ver, 2)), 0.5);
        pick = UnityEngine.Random.Range(0, 2);
        Debug.Log(pick);
        if(pick == 1)
        {
            hor = -hor;
        }
        vec = new Vector2(hor, ver);
        rb.velocity = vec;
        myScore = 0;
        enemyScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemyGoals.text = enemyScore.ToString();
        playerGoals.text = myScore.ToString();
        if(myScore == 7 || enemyScore == 7)
        {
            if(myScore == 7)
            {
                PlayerPrefs.SetInt("endGame", 1);
            }
            else
            {
                PlayerPrefs.SetInt("endGame", 0);
            }
            SceneManager.LoadScene("EndGame");
        }
    }

    public IEnumerator RestartDelay(float n)
    {
        for(int k = 0; k < 1; n++)
        {
            yield return new WaitForSeconds(n);
            Debug.Log("WaitDone");
            ver = UnityEngine.Random.Range(((magnitude * 0.2f)), ((magnitude * 0.7f)));
            pick = UnityEngine.Random.Range(0, 2);
            Debug.Log(pick);
            if (pick == 1)
            {
                ver = -ver;
            }
            hor = (float)Math.Pow((Math.Pow(magnitude, 2) - Math.Pow(ver, 2)), 0.5);
            pick = UnityEngine.Random.Range(0, 2);
            Debug.Log(pick);
            if (pick == 1)
            {
                hor = -hor;
            }
            vec = new Vector2(hor, ver);
            rb.velocity = vec;
            StopAllCoroutines();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall")
        {
            //play sound
            hitSource.Play();
        }
        if(col.gameObject.tag == "Goal")
        {
            //reset and play sound and add to counter
            goalSource.Play();
            StartCoroutine(RestartDelay(2f));
            ball.position = reset;
            rb.velocity = new Vector2(0f, 0f);
            if(col.gameObject.name == "GoalLeft")
            {
                myScore += 1;
            }
            else
            {
                enemyScore += 1;
            }
            Debug.Log("my " + myScore + " enemy " + enemyScore);
        }
        if(col.gameObject.tag == "Player")
        {
            //play sound
            hitSource.Play();
        }
        if(col.gameObject.tag == "Enemy")
        {
            //play sound
            hitSource.Play();
        }
    }
}
