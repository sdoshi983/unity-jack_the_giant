using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX;

    private float lastCloudPositionY;

    private float controlX;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    private void Awake()
    {
        controlX = 0.0f;
        SetMinAndMax();
        CreateClouds();
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        PositionThePlayer();
    }

    // min and max value at which clouds should be arranged in horizontal (x) axis
    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
         
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;


    }

    // shuffles the clouds' positions
    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;

        }
    }

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0f;

        // this loop will change the positions of clouds by assigning the new values to x and y coordinates
        for(int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;

            // set the y coordinate of the clouds
            temp.y = positionY;
            
            // set the x coordinate of the clouds
            if(controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }
            
            lastCloudPositionY = positionY; // at the end of the loop, positionY will be having the y coordinates of the last cloud in the array hence we are assigning it to the lastCloudPositionY variable
            clouds[i].transform.position = temp;    //finally assign the temp to the cloud's position again after setting the new values of x and y of temp Vector3 variable
            
            positionY -= distanceBetweenClouds; // set positionY
        }
    }

    void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        // this loop will swap the darkcloud with a non dark one if the first cloud in the game is a dark one after random shuffling. So as to save the player from dying immediately when the game starts
        for(int i = 0; i < darkClouds.Length; i++)
        {
            
            if(darkClouds[i].transform.position.y == 0f) // the y coordinate of the first cloud is going to be 0 so we are using this condition
            {
                Vector3 t = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x, cloudsInGame[0].transform.position.y, cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = t;
            }
        }

        // to set the player's position to the first cloud in the game
        Vector3 temp = cloudsInGame[0].transform.position;
        for(int i = 0; i < cloudsInGame.Length; i++)
        {
            if(temp.y < cloudsInGame[i].transform.position.y)   // greater than (<) sign is there because the clouds are arranged further on negative y axis so the greatest y position among all clouds will be 0. 
                                                                // So we can even check if cloudsInGame[i].transform.position.y == 0f than assign it to the temp and break the loop
            {
                temp = cloudsInGame[i].transform.position;
            }
        }
        temp.y += 0.8f; // to make player stand above the cloud

        player.transform.position = temp;   // assigning the first cloud's position to the player
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            if(target.transform.position.y == lastCloudPositionY)   // if the cloud spawner gameObject has reached the last cloud
            {
                Shuffle(clouds);                                    // shuffle the position of all clouds
                Shuffle(collectables);
                
                Vector3 temp = target.transform.position;   // storing the position of last cloud as we have to set the y coordinate from the last cloud

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)   // we have to activate the clouds inactivated in the cloudcollector script and set randomzie all of their positions
                                                        // NOTE: when the spawner will touch the last cloud, there will be 4 inactive clouds from total of 8 clouds and which all be activated and randomized 
                    {
                        // setting up the x coordinate
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }
                        
                        temp.y -= distanceBetweenClouds;    // maintaining the distance between the clouds by subtracting it from the previous activated cloud
                        lastCloudPositionY = temp.y;    // at the end of the loop, the 4th (last activated cloud's) y coordinate will be there in lastCloudPositionY variable

                        clouds[i].transform.position = temp;    //finally assigning the temp variable to the cloud after randomizing new values of x and y coordinate of temp Vector3 variable
                        clouds[i].SetActive(true);     // till this step, the inactivated cloud was still inactive
                    }
                }
            }
        }
    }
}
