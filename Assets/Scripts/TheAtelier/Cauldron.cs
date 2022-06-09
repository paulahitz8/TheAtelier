using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public List<Potion> allPotions;
    private List<Ingredient> ingredients;
    public Transform newPotionPos;
    public GameObject liquidFull;
    public GameObject liquidHalf;
    public int spoonSeconds;

    public AudioClip dropHerb;
    public AudioClip dropPotion;
    public AudioClip brewing;
    public AudioClip spoon;
    public AudioClip tada;

    private bool isPlaying;
    private void Start()
    {
        isPlaying = false;
        ingredients = new List<Ingredient>();
    }

    private void Update()
    {
        if (ingredients.Count > 0)
            LiquidState();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Potion")
        {
            if (collision.gameObject.GetComponent<Potion>() != null)
            {
                AudioSource.PlayClipAtPoint(dropPotion, transform.position);
                ingredients.Add(collision.gameObject.GetComponent<Potion>());
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "CutHerb")
        {
            if (collision.gameObject.GetComponent<Herb>() != null)
            {
                AudioSource.PlayClipAtPoint(dropHerb, transform.position);
                ingredients.Add(collision.gameObject.GetComponent<Herb>());
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Spoon")
        {
            if (ingredients.Count == 2)
            {
                StartCoroutine(CheckIngredients());
            }
        }
    }

    private void LiquidState()
    {
        if (!isPlaying)
        {
            AudioSource.PlayClipAtPoint(brewing, transform.position);
            isPlaying = true;
        }
        if (ingredients.Count == 1)
        {
            liquidHalf.SetActive(true);
        }
        else if (ingredients.Count == 2)
        {
            liquidHalf.SetActive(false);
            liquidFull.SetActive(true);
        }
        else
        {
            liquidFull.SetActive(false);
            isPlaying = false;
        }
    }
    private IEnumerator CheckIngredients()
    {
        AudioSource.PlayClipAtPoint(spoon, transform.position);

        yield return new WaitForSeconds(spoonSeconds);
        
        if (ingredients.Count == 2)
        {
            if (ingredients[0].type == "Red" || ingredients[1].type == "Red")
            {
                // purple
                if (ingredients[0].type == "Blue" || ingredients[1].type == "Blue")
                    BrewPotion("Purple");

                // orange
                else if (ingredients[0].type == "Purple" || ingredients[1].type == "Purple")
                    BrewPotion("Orange");

                // dark red
                else if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    BrewPotion("DarkRed");

                // light red
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    BrewPotion("LightRed");
            }
            else if (ingredients[0].type == "Blue" || ingredients[1].type == "Blue")
            {
                // green
                if (ingredients[0].type == "Purple" || ingredients[1].type == "Purple")
                    BrewPotion("Green");

                // dark blue
                else if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    BrewPotion("DarkBlue");

                // light blue
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    BrewPotion("LightBlue");
            }
            else if (ingredients[0].type == "Purple" || ingredients[1].type == "Purple")
            {
                // dark purple
                if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    BrewPotion("DarkPurple");

                // light purple
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    BrewPotion("LightPurple");
            }
            else if (ingredients[0].type == "Green" || ingredients[1].type == "Green")
            {
                // dark green
                if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    BrewPotion("DarkGreen");

                // light green
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    BrewPotion("LightGreen");
            }
            else if (ingredients[0].type == "Orange" || ingredients[1].type == "Orange")
            {
                // dark orange
                if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    BrewPotion("DarkOrange");

                // light orange
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    BrewPotion("LightOrange");
            }

            ingredients.Clear();
            LiquidState();
        }
    }

    private void BrewPotion(string potion)
    {
        AudioSource.PlayClipAtPoint(tada, newPotionPos.position);
        Instantiate(FindBrew(potion), newPotionPos.position, newPotionPos.rotation);
    }

    private GameObject FindBrew(string type)
    {
        for (int i = 0; i < allPotions.Count; i++)
        {
            if (allPotions[i].type == type)
            {
                return allPotions[i].gameObject;
            }
        }
        return null;
    }
}
