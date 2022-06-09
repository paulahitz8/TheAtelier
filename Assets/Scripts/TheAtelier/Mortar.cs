using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : MonoBehaviour
{
    public int impactTimesMin;
    public int impactTimesMax;
    public List<Herb> cutHerbs;
    private int counter;
    public GameObject spawnPos;

    public AudioClip impact;

    private void Start()
    {
        counter = 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Herb" && collision.gameObject.GetComponent<Herb>() != null)
        {
            if (collision.gameObject.GetComponent<Herb>().onPlate)
            {
                AudioSource.PlayClipAtPoint(impact, transform.position);
                if (counter == impactTimesMax)
                {
                    ManageHerb(collision.gameObject);
                    counter = 0;
                }
                counter++;
            }
        }
    }

    private void ManageHerb(GameObject herb)
    {
        var type = herb.GetComponent<Herb>().type;
        if (type == "Rosemary")
        {
            Instantiate(FindCutHerb("CutRosemary"), spawnPos.transform.position, spawnPos.transform.rotation);
            Destroy(herb);
        }
        else if (type == "Sunflower")
        {
            Instantiate(FindCutHerb("CutSunflower"), spawnPos.transform.position, spawnPos.transform.rotation);
            Destroy(herb);
        }
    }

    private GameObject FindCutHerb(string type)
    {
        for (int i = 0; i < cutHerbs.Count; i++)
        {
            if (cutHerbs[i].type == type)
            {
                return cutHerbs[i].gameObject;
            }
        }
        return null;
    }
}
