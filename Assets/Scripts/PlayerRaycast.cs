using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{

    [SerializeField] LineRenderer lineRenderer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            //Cast ray
            RaycastHit result;
            bool thereWasHit = Physics.Raycast(transform.position, transform.forward, out result, Mathf.Infinity);

            Vector3 start = transform.position;
            Vector3 end = transform.position + transform.forward * 50f;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);

            if (thereWasHit)
            {
                if (result.collider.gameObject.name == "Player Two")
                {

                    result.collider.gameObject.GetComponent<MeshRenderer>().material.color = GetRandomColor();
                }

                
            }
        }
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        return color;
    }
}
