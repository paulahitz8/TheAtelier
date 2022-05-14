using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public List<Potion> potions;
    private List<Potion> potionsInCauldron;
    public GameObject potionCreated;
    public Transform newPotionPos;


    private void Start()
    {
        potionsInCauldron = new List<Potion>();
    }

    private void Update()
    {
        CheckPotions();
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Potion")
        {
            if (collision.gameObject.GetComponent<Potion>() != null)
            {
                potionsInCauldron.Add(collision.gameObject.GetComponent<Potion>());
                DestroyPotion(collision.gameObject);
            }
            
        }
    }

    private void CheckPotions()
    {
        if (potionsInCauldron.Count == 2)
        {
            if (potionsInCauldron[0].color == "Red" && potionsInCauldron[1].color == "Blue")
            {
                Debug.Log("Purple");
                Instantiate(potionCreated, newPotionPos.position, newPotionPos.rotation);
                potionsInCauldron.Clear();
            }
            else if (potionsInCauldron[0].color == "Blue" && potionsInCauldron[1].color == "Red")
            {
                Debug.Log("Purple");
                Instantiate(potionCreated, newPotionPos.position, newPotionPos.rotation);
                potionsInCauldron.Clear();
            }
        }
    }
    private void DestroyPotion(GameObject potion)
    {
        Destroy(potion);
    }
}
