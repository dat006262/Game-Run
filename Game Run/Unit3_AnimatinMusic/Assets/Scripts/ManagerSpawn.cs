using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public GameObject obstanceprefabs;
    private Vector3 spawn = new Vector3(25,1,0);
    private float startDelay=2;
    private float repeatRate=2;
    private Player_Controler player_ControlerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnOpstacle", startDelay, repeatRate);
        player_ControlerScript = GameObject.Find("SimplePeople_Man_Punk_Black").GetComponent<Player_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnOpstacle()
    {
        if (player_ControlerScript.gameOver == false)
        {
            Instantiate(obstanceprefabs, spawn, obstanceprefabs.transform.rotation);
        }
    }
}
