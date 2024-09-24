using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : MonoBehaviour
{
    //Colors
    public Color[] colors;
    private SpriteRenderer sprite_renderer;

    //size
    private int size = 0;

    //point value
    [HideInInspector] public int point_value;

    // Start is called before the first frame update
    void Start()
    {
        //SET DOT COLOR
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.color = colors[Random.Range(0, colors.Length)];

        //set size
        size = Random.Range(0, 3);

        //set values based on size
        switch(size)
        {
            case 0: //for small
                transform.localScale *= 0.7f;
                point_value = 20;
                    break;

            case 1: //for med
                transform.localScale *= 1.4f;
                point_value = 10;
                break;

                case 2: //for lrg
                transform.localScale *= 2.1f;
                point_value = 20;   
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
