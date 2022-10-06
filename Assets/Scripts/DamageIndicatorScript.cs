using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicatorScript : MonoBehaviour
{
    private int timer;
    void Update()
    {
        timer += 1;
        if (timer >= 500)
        {
            Destroy(this.gameObject);
        }

    }
}
