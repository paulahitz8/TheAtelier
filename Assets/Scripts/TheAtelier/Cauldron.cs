using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public List<Potion> allPotions;
    private List<Ingredient> ingredients;
    public Transform newPotionPos;

    private void Start()
    {
        ingredients = new List<Ingredient>();
    }

    private void Update()
    {
        CheckIngredients();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Potion")
        {
            if (collision.gameObject.GetComponent<Potion>() != null)
            {
                ingredients.Add(collision.gameObject.GetComponent<Potion>());
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "CutHerb")
        {
            if (collision.gameObject.GetComponent<Herb>() != null)
            {
                ingredients.Add(collision.gameObject.GetComponent<Herb>());
                Destroy(collision.gameObject);
            }
        }
    }

    private void CheckIngredients()
    {
        if (ingredients.Count != 2)
            return;
        else
        {
            if (ingredients[0].type == "Red" || ingredients[1].type == "Red")
            {
                // purple
                if (ingredients[0].type == "Blue" || ingredients[1].type == "Blue")
                    Instantiate(FindBrew("Purple"), newPotionPos.position, newPotionPos.rotation);

                // orange
                else if (ingredients[0].type == "Purple" || ingredients[1].type == "Purple")
                    Instantiate(FindBrew("Orange"), newPotionPos.position, newPotionPos.rotation);

                // dark red
                else if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    Instantiate(FindBrew("DarkRed"), newPotionPos.position, newPotionPos.rotation);

                // light red
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    Instantiate(FindBrew("LightRed"), newPotionPos.position, newPotionPos.rotation);
            }
            else if (ingredients[0].type == "Blue" || ingredients[1].type == "Blue")
            {
                // green
                if (ingredients[0].type == "Purple" || ingredients[1].type == "Purple")
                    Instantiate(FindBrew("Green"), newPotionPos.position, newPotionPos.rotation);

                // dark blue
                else if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    Instantiate(FindBrew("DarkBlue"), newPotionPos.position, newPotionPos.rotation);

                // light blue
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    Instantiate(FindBrew("LightBlue"), newPotionPos.position, newPotionPos.rotation);
            }
            else if (ingredients[0].type == "Purple" || ingredients[1].type == "Purple")
            {
                // dark purple
                if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    Instantiate(FindBrew("DarkPurple"), newPotionPos.position, newPotionPos.rotation);

                // light purple
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    Instantiate(FindBrew("LightPurple"), newPotionPos.position, newPotionPos.rotation);
            }
            else if (ingredients[0].type == "Green" || ingredients[1].type == "Green")
            {
                // dark green
                if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    Instantiate(FindBrew("DarkGreen"), newPotionPos.position, newPotionPos.rotation);

                // light green
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    Instantiate(FindBrew("LightGreen"), newPotionPos.position, newPotionPos.rotation);
            }
            else if (ingredients[0].type == "Orange" || ingredients[1].type == "Orange")
            {
                // dark orange
                if (ingredients[0].type == "CutRosemary" || ingredients[1].type == "CutRosemary")
                    Instantiate(FindBrew("DarkOrange"), newPotionPos.position, newPotionPos.rotation);

                // light orange
                else if (ingredients[0].type == "CutSunflower" || ingredients[1].type == "CutSunflower")
                    Instantiate(FindBrew("LightOrange"), newPotionPos.position, newPotionPos.rotation);
            }

            ingredients.Clear();
        }
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
