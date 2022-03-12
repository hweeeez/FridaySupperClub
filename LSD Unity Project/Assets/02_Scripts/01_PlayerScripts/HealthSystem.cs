using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public GameObject playerIcon;
    public Sprite aliveIcon;
    public Sprite deadIcon;
    private int numofLives;
    public int numberOfLives = 3;
    [SerializeField]
    private GameObject playerLifeImage;
    private List<GameObject> lifeImages;

    public int health = 3;
    //public Image[] hearts;
    public Sprite emptyLife;
    public Sprite fillLife;
    //public AudioSource deathms;
    public Vector2 gridPos;
    private float invulnerabilityDuration = 2;
    private bool isInvulnerable = false;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerIcon);
        playerIcon.GetComponent<SpriteRenderer>().sprite = aliveIcon;
        this.lifeImages = new List<GameObject>();
        for (int lifeIndex = 0; lifeIndex < this.numberOfLives; ++lifeIndex)
        {
            GameObject lifeImage = Instantiate(playerLifeImage, new Vector2(gridPos.x + (1f * lifeIndex), gridPos.y), Quaternion.identity) as GameObject;
            this.lifeImages.Add(lifeImage);
        }

    }
    private void Update()
    {
        if (health == 0)
        {
            playerIcon.GetComponent<SpriteRenderer>().sprite = deadIcon;
            Debug.Log("dead");
            foreach (GameObject lifeImage in lifeImages)
            { lifeImage.GetComponent<SpriteRenderer>().sprite = emptyLife; }
            
        }
    }

    // Update is called once per frame
    /* public void LoseLife()
     {
         if (!isInvulnerable)
         {
             this.numberOfLives--;
             GameObject lastItem = lifeImages.Last();
             lastItem.GetComponent<SpriteRenderer>().sprite = emptyLife;
             GameObject lifeImage = this.lifeImages[this.lifeImages.Count - 1];

             if (this.numberOfLives == 0)
             {
                 Destroy(this.gameObject);
             }
             this.isInvulnerable = true;
             Invoke("BecomeVulnerable", this.invulnerabilityDuration);
         }
     }*/
    private void BecomeVulnerable()
    {
        this.isInvulnerable = false;
    }
    public void LoseLife()
    {
        if (!isInvulnerable)
        {
            this.health--;
            if (health > numberOfLives)
            {
                health = numberOfLives;
            }
            for (int i = 0; i < numberOfLives; i++)
            {
                if (i < health)
                {
                    lifeImages[i].GetComponent<SpriteRenderer>().sprite = fillLife;
                }
                else
                {
                    lifeImages[i].GetComponent<SpriteRenderer>().sprite = emptyLife;
                }
                if (i < numberOfLives)
                {
                    lifeImages[i].SetActive(true);
                }
                else
                {
                    lifeImages[i].SetActive(false);
                }
            }


            this.isInvulnerable = true;
            Invoke("BecomeVulnerable", this.invulnerabilityDuration);
        }
    }

}


