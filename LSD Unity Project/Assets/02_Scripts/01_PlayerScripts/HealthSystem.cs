using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    private int numofLives;
    public int numberOfLives = 3;
    [SerializeField]
    private GameObject playerLifeImage;
    private List<GameObject> lifeImages;

    private int health = 3;
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
        this.lifeImages = new List<GameObject>();
        for (int lifeIndex = 0; lifeIndex < this.numberOfLives; ++lifeIndex)
        {
            GameObject lifeImage = Instantiate(playerLifeImage, new Vector2(gridPos.x + (1f * lifeIndex), gridPos.y), Quaternion.identity) as GameObject;
            this.lifeImages.Add(lifeImage);
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

            if (this.health == 0)
            {
                Destroy(this.gameObject);
            }
            this.isInvulnerable = true;
            Invoke("BecomeVulnerable", this.invulnerabilityDuration);
        }
    }
}


