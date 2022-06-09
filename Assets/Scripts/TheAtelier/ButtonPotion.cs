using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPotion : MonoBehaviour
{
    public Vector3 initialPos;
    public string color;

    private void Start()
    {
        initialPos = transform.position;
    }
}
