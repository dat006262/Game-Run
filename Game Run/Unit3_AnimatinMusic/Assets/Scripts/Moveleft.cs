using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    public float speed=20;
    private Player_Controler player_ControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        player_ControlerScript = GameObject.Find("SimplePeople_Man_Punk_Black").GetComponent<Player_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_ControlerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x< -15 && gameObject.CompareTag("Obstancles"))
        {
            Destroy(gameObject);
        }    
    }
}
