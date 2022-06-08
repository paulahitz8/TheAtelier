using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : Ingredient
{
    public bool onPlate;

    private void Start()
    {
        onPlate = false;
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Plate")
            onPlate = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Plate")
            onPlate = false;
    }
}
