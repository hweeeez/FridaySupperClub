using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
   // public GameObject lifeGrid;
    public Text livestext;
    private bool gameOver;
    private int numofLives;
    public int numberOfLives = 3;
    [SerializeField]
    private GameObject playerLifeImage;
    private List<GameObject> lifeImages;
    public Sprite emptyLife;
    //public AudioSource deathms;
    public Vector2 gridPos;
    private float invulnerabilityDuration = 2;
    private bool isInvulnerable = false;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject lifeGrid = GameObject.Find("5123Lives");

        this.lifeImages = new List<GameObject>();
        for (int lifeIndex = 0; lifeIndex < this.numberOfLives; ++lifeIndex)
        {
            GameObject lifeImage = Instantiate(playerLifeImage, new Vector2 (gridPos.x + (2*lifeIndex), gridPos.y), Quaternion.identity) as GameObject;
            this.lifeImages.Add(lifeImage);
        }
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

    // Update is called once per frame
    public void LoseLife()
    {
        if (!isInvulnerable)
        {
            this.numberOfLives--;
            GameObject lifeImage = this.lifeImages[this.lifeImages.Count - 1];
            GameObject lastItem = lifeImages.Last();
            lastItem.GetComponent<SpriteRenderer>().sprite = emptyLife;
            if (this.numberOfLives == 0)
            {
                Destroy(this.gameObject);
            }
            this.isInvulnerable = true;
            Invoke("BecomeVulnerable", this.invulnerabilityDuration);
        }
    }
    private void BecomeVulnerable()
    {
        this.isInvulnerable = false;
    }
}

