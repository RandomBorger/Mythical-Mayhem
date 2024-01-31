using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamFollow : MonoBehaviour
{
    public float followspeed = 40.0f;
    public Transform target;
    public float yoffset = 1.0f;
    public float xoffset = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            yoffset = -4;
        } else if (Input.GetKey(KeyCode.W))
        {
            yoffset = 6;
        }  else
        {
            xoffset = 0;
            yoffset = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            back();
        }
        Vector3 newpos = new Vector3(Targetx(), Targety(), -40);
        transform.position = Vector3.Slerp(transform.position, newpos, followspeed * Time.deltaTime);

    }

    private float Targetx()
    {
        return 0.0f + target.position.x/10 + xoffset;
    }
    private float Targety()
    {
        return 0.0f + target.position.y/ 10 + yoffset;
    }

    private void back()
    {
        SceneManager.LoadScene(1);
    }
}
