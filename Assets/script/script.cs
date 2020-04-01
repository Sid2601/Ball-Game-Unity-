using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class script : MonoBehaviour {

    Rigidbody rb;
    
    private bool onground = false;
    
    public float forwardspeed;
    public float jumpspeed;
    public float sidespeed;
    public float initialforwardspeed;
    public float initialsidespeed;
    public GameObject gamepanel;
    public GameObject gamepanel1;
  
    // Use this for initialization
    void Start () {
        
       gamepanel.SetActive(false);
       gamepanel1.SetActive(false);
       rb = GetComponent<Rigidbody>();
        
        initialforwardspeed = forwardspeed;
        initialsidespeed = sidespeed;
	}

    private void OnCollisionEnter(Collision data)
    {
           if(data.collider.tag=="obstacles")
        {
           
           gameover(); 

            Debug.Log("game over");           
        }
            if (data.collider.name == "Plane")
            {
            onground = true;
            forwardspeed = initialforwardspeed;
            sidespeed = initialsidespeed;
            }        
            if(data.collider.name == "finishing")
        {
            finish();
        }
            

    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y < -0.25)
        {
            gameover();
        }
        
        rb.AddForce(Vector3.forward*forwardspeed*Time.deltaTime,ForceMode.Force);

        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector3.left*sidespeed*Time.deltaTime,ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right * sidespeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Space) && onground)
        {
            onground = false;
            forwardspeed /= 2;
            sidespeed /= 2;
            rb.AddForce(Vector3.up * jumpspeed * Time.deltaTime, ForceMode.Impulse);
        }
    }
    private void gameover()
    {
        gamepanel.SetActive(true);
        forwardspeed = 0;
        sidespeed = 0;
        jumpspeed = 0;
        initialforwardspeed = 0;
        initialsidespeed = 0;
    }
    
    private void finish()
    {
        gamepanel1.SetActive(true);
        forwardspeed = 0;
        sidespeed = 0;
        jumpspeed = 0;
        initialforwardspeed = 0;
        initialsidespeed = 0;
    }
}
