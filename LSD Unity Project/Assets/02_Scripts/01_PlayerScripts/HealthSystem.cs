using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Text livestext;
    private bool gameOver;
    private int numofLives;

    public 
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        numofLives = System.Convert.ToInt32(livestext.text);
    }
    public void PlayerDied(int deathcount)
    {
        if(gameOver == false)
        {
            numofLives--;
            livestext.text = numofLives.ToString();
        }
        if (numofLives == 0)
        {
            gameOver = true;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.gameObject.tag == "Enemy")
        {
            PlayerDied(1);

        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}

