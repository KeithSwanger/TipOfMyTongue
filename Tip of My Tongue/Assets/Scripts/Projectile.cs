using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject shadow;


    float shadowOffset;

    float gravityForce;
    float gravity;

    float travelTime;
    float travelTimer;
    float travelProgress;

    float verticalForce;

    float launchHeight;
    float height;

    Vector2 startPos;
    Vector2 endPos;

    bool launchProjectileFlag;


    //Vector2 prevEndPos;
    //float distance;




    bool bounce = false;
    bool canBounce = false;




    // Use this for initialization
    void Start()
    {

        shadow = Instantiate(shadow);




        shadowOffset = -2f;
        gravityForce = -100f;
        gravity = 0f;
        travelTime = 2f;
        travelTimer = 0f;
        launchProjectileFlag = false;
        launchHeight = 100f;
        height = launchHeight;

        transform.position = new Vector2(transform.position.x, transform.position.y + height);
        shadow.transform.position = new Vector2(transform.position.x, transform.position.y - height + shadowOffset);





    }

    // Update is called once per frame
    void Update()
    {
        ;



        if (Input.GetMouseButtonDown(0))
        {
            //prevEndPos = Vector2.zero;
            //endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PrepareProjectileForLaunch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            bounce = !bounce;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            travelTime = 0.25f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            travelTime = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            travelTime = 0.75f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            travelTime = 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            travelTime = 3f;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gravityForce = -20f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            gravityForce = -50f;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gravityForce = -100f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gravityForce = -250f;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            gravityForce = -1000f;
        }



        if (launchProjectileFlag)
        {
            travelProgress = travelTimer / travelTime;
            if (travelProgress > 1f)
            {
                travelProgress = 1f;
                launchProjectileFlag = false;
            }

            gravity = gravityForce * travelTimer * travelTimer;
            height = (verticalForce * travelTimer) + gravity + launchHeight;


            if (height < 0 || travelProgress >= 1f)
            {
                height = 0f;

                /*
                if (bounce)
                {
                    canBounce = true;
                }
                else
                {
                    canBounce = false;
                }
                */

            }


            Vector2 newLocation = Vector2.Lerp(startPos, endPos, travelProgress);
            transform.position = new Vector2(newLocation.x, newLocation.y + height);
            shadow.transform.position = new Vector2(transform.position.x, newLocation.y + shadowOffset);

            /*
            if (canBounce)
            {
                canBounce = false;
                PrepareProjectileForLaunch();
            }
            */








            travelTimer += Time.deltaTime;





        }

    }

    void PrepareProjectileForLaunch(Vector2 endPosition)
    {
        //travelTime = Random.Range(1.5f, 2.4f);
        //travelTime = 1.5f;
        //gravityForce = -Random.Range(20f, 200f);

        endPos = endPosition;



        if (launchProjectileFlag || height < launchHeight)
        {
            launchHeight = height;
        }


        /*
        if (endPos == prevEndPos)
        {
            endPos = new Vector2(Mathf.Clamp(Random.Range(transform.position.x - 100, transform.position.x + 100), -400, 400), Mathf.Clamp(Random.Range(transform.position.y - 100 - height, transform.position.y + 100 - height), -250, 150));
            travelTime = Random.Range(1.0f, 2.5f);

            gravityForce = -Random.Range(20f, 200f);
        }
        */


        //Debug.Log("Preparing for launch!");


        launchProjectileFlag = true;
        travelTimer = 0f;
        travelProgress = travelTimer / travelTime;
        gravity = 0f;

        verticalForce = -((travelTime * travelTime * gravityForce) + launchHeight) / travelTime;

        startPos = new Vector2(transform.position.x, transform.position.y - height);




        //prevEndPos = endPos;

        //distance = Vector2.Distance(startPos, endPos);

    }


    /*
    void PrepareProjectileForLaunchWithHeight(float targetHeight)
    {
        if (launchProjectileFlag || height < launchHeight)
        {
            launchHeight = height;
        }
        //travelTime = Random.Range(1.5f, 2.4f);
        //travelTime = 5f;

        // vvv FAILED
        //gravityForce = ((-2 * targetHeight) + (2 * launchHeight)) / (travelTime * travelTime);
        //Debug.Log(gravityForce);

        //verticalForce = ((3 * targetHeight) - (3 * launchHeight)) / travelTime;
        //Debug.Log(verticalForce);
        // ^^^ FAILED
        
    
        verticalForce = (targetHeight - launchHeight - (travelTime * travelTime * gravityForce / 4f)) / (travelTime / 2);
        Debug.Log(gravityForce);
        Debug.Log(verticalForce);

        //Debug.Log("Preparing for launch!");
        launchProjectileFlag = true;
        travelTimer = 0f;
        travelProgress = travelTimer / travelTime;

        gravity = 0f;
        

        startPos = new Vector2(transform.position.x, transform.position.y - height);
        //endPos = new Vector2(Mathf.Clamp(Random.Range(transform.position.x - 100, transform.position.x + 100), -400, 400), Mathf.Clamp(Random.Range(transform.position.y - 100 - height, transform.position.y + 100 - height), -250, 150));

        if (endPos == prevEndPos)
        {
            endPos = new Vector2(Mathf.Clamp(Random.Range(transform.position.x - 100, transform.position.x + 100), -400, 400), Mathf.Clamp(Random.Range(transform.position.y - 100 - height, transform.position.y + 100 - height), -250, 150));
        }

        prevEndPos = endPos;


        //endPos = new Vector2(transform.position.x + 150f, transform.position.y - height);
    }
    */
}

