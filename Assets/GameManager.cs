using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int state;
    private float speed = 0.5f;
    private float scale = 0.999f;
    bool isgrapped = false;
    private float TimeLeft = 0.25f;
    private float TimeLeft_plate = 0.5f;
    private float TimeLeft_scale = 0.5f;
    int count = 0;

    private float nextTime = 0.0f;
    private float timetoeat = 1.0f;
    private string objectName;

    public GameObject blocker;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                objectName = hit.collider.gameObject.transform.name;
                Debug.Log(objectName);
            }
        }

        if (state == 0)
        {
            var chairTransform = GameObject.Find("chair").transform;
            chairTransform.Rotate(0, 0, speed);
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft;
                speed = -speed;
            }

            if(objectName == "chair")
            {
                state = 1;
                speed = 0;
                chairTransform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }   

        if (state == 1)
        {
            var chairTransform = GameObject.Find("chair").transform;
            if (chairTransform.position.x < 7)
            {
                chairTransform.position += new Vector3(1, 0, 0);
            }

            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft_plate;
                state = 2;
            }
        }

        if(state == 2)
        {
            var tableClothTransform = GameObject.Find("tablecloth").transform;
            if (tableClothTransform.position.x < 0)
            {
                tableClothTransform.position += new Vector3(1, 0, 0);
            }

            if(tableClothTransform.position.x > 0)
            {
                tableClothTransform.position = new Vector3(0, 0, tableClothTransform.position.z);
                state = 3;
            }
        }

        if (state == 3)
        {
            var armTransform = GameObject.Find("arm").transform;
            if(armTransform.position.x > 13)
            {
                armTransform.position -= new Vector3(1, 0, 0);
            }

            if (armTransform.position.x < 13)
            {
                armTransform.position = new Vector3(13, -7.5f, armTransform.position.z);
                state = 4;
            }
        }

        if(state == 4)
        {
           

            if(objectName == "spoon")
            {
                GameObject.Find("hand1").transform.position = new Vector3(8 , -3, 0);
                GameObject.Find("hand2").transform.position = new Vector3(8.3f, -3.3f, -0.9f);
                
                if (Time.time > nextTime)
                {
                    nextTime = Time.time + TimeLeft_scale;
                    scale = 1/scale;
                }
                isgrapped = true;
                GameObject.Find("rice").transform.localScale *= scale;
                GameObject.Find("soup").transform.localScale *= scale;
            }   

           if(objectName == "rice" && isgrapped)
           {
                state = 5;
           }

           if (objectName == "soup" && isgrapped)
           {
                GameObject.Find("spoon_soup").transform.position = new Vector3(-6.3f, 17.1f, -2.5f);
                GameObject.Find("spoon_rice").transform.position = new Vector3(-6.3f, 17.1f, -2f);
                state = 6;
           }
        }

        if (state == 5  )
        {

            if(GameObject.Find("background").transform.position.y > 0)
            {
                GameObject.Find("background").transform.position += new Vector3(0, -1, 0);
            }
            if(GameObject.Find("background").transform.position.y < 0)
            {
                GameObject.Find("background").transform.position = new Vector3(0,0,-2);
            }

            if(objectName == "spoon_rice")
            {
                blocker.SetActive(true);
                GameObject.Find("blowing").transform.position = new Vector3(-4.55f, -3.48f, -3);
                count++;
                objectName = "empty";
                blocker.SetActive(false);

            }

            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft_scale;
                GameObject.Find("blowing").transform.position = new Vector3(-4.55f, -3.48f, 1);
            }

            if(count >2)
            {
                state = 7;
            }
        }

        if (state == 6)
        {

            if (GameObject.Find("background").transform.position.y > 0)
            {
                GameObject.Find("background").transform.position += new Vector3(0, -1, 0);
            }
            if (GameObject.Find("background").transform.position.y < 0)
            {
                GameObject.Find("background").transform.position = new Vector3(0, 0, -2);
            }

            if (objectName == "spoon_soup")
            {
                blocker.SetActive(true);
                GameObject.Find("blowing").transform.position = new Vector3(-4.55f, -3.48f, -3);
                count++;
                objectName = "empty";
                if (Time.time > nextTime)
                {
                    nextTime = Time.time + TimeLeft_scale;
                    blocker.SetActive(false);
                }
            }

            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft_scale;
                GameObject.Find("blowing").transform.position = new Vector3(-4.55f, -3.48f, 1);
            }
            Debug.Log(count);
            if(count > 2)
            {
                state = 7;
                Debug.Log(state);
            }
        }

        if (state == 7)  
        {
            GameObject.Find("mouth_mumble").transform.position = new Vector3(0, 0, 0);
            GameObject.Find("mouth_normal").transform.position = new Vector3(0, 0, 0);
            GameObject.Find("mouth_open").transform.position = new Vector3(0, 0, -5);


            if (Time.time > timetoeat)
            {
                //nextTime = Time.time + TimeLeft_scale;
                GameObject.Find("mouth_open").transform.position = new Vector3(0, 0, 0);
                GameObject.Find("mouth_normal").transform.position = new Vector3(0, 0, -5);
                GameObject.Find("eyes_normal1").transform.position = new Vector3(0, 0, 0);
                GameObject.Find("eyes_happy").transform.position = new Vector3(0,0,-5);
                GameObject.Find("spoon_rice").transform.position = new Vector3(0, 0, 0);
                GameObject.Find("spoon_soup").transform.position = new Vector3(0, 0, 0);

                if (Time.time > nextTime)
                {
                    state = 4;
                }
            }


        }
    }
}
