using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject sword;
    private Dray dray;

    void Start()
    {
        Transform swordT = transform.Find("Sword");
        if (swordT == null)
        {
            Debug.LogError("Could not find Sword shild of SwordController.");
            return;
        }
        sword = swordT.gameObject;
        
        dray = GetComponentInParent<Dray>();
        if (dray == null)
        {
            Debug.LogError("Could not find parent component Dray.");
            return;
        }
        
        sword.SetActive(false);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * dray.facing);
        sword.SetActive(dray.mode == Dray.eMode.attack);
    }
}
