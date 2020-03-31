using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 up_vel, down_vel;
    public bool upKey, downKey;
    //private bool spaceKey;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (!(PlayerPrefs.HasKey("playerMove")))
        {
            PlayerPrefs.SetFloat("playerMove", 4f);
        }
        speed = PlayerPrefs.GetFloat("playerMove");
        up_vel = new Vector2(0, speed);
        down_vel = new Vector2(0, -speed);
        PlayerPrefs.SetFloat("playerMove", speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            upKey = true;
        }
        else
        {
            upKey = false;
        }
        if (Input.GetKey("down"))
        {
            downKey = true;
        }
        else
        {
            downKey = false;
        }
        //if (Input.GetKey("space"))
        //{
        //    spaceKey = true;
        //}
        //else
        //{
        //    spaceKey = false;
        //}
    }

    void FixedUpdate()
    {
        if (upKey == true)
        {
            rb.velocity = up_vel;
        }
        if (downKey == true)
        {
            rb.velocity = down_vel;
        }
        //if (spaceKey == true)
        //{
            //rb.velocity = new Vector2(0f, 0f);
        //}
    }
}
