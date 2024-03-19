using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    Material mat;
    float distance;
    [Range(0f,0.5f)]
    public float speed = .2f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Time.deltaTime * speed;
        mat.mainTextureOffset = Vector2.right * distance;
    }
}
