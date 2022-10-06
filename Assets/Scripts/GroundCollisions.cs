using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisions : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    private void OnCollisionEnter(Collision collision)
    {
        meshRenderer.material.color = GetRandomColor();
    }

    private void OnCollisionExit(Collision collision)
    {
        meshRenderer.material.color = GetRandomColor();
    }

    private Color GetRandomColor()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        return color;
    }
}
