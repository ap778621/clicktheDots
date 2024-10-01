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

    //scale
    private Vector3 scale = Vector3.zero;

    //life time 
    private float time_before_shrink = 0.0f;

    //point value
    [HideInInspector] public int point_value;

    //audio 
    public AudioSource audio_source; 

    // Start is called before the first frame update
    void Start()
    {
        // get components 
        audio_source = GetComponent<AudioSource>();


        //SET DOT COLOR
        sprite_renderer = GetComponent<SpriteRenderer>();
        sprite_renderer.color = colors[Random.Range(0, colors.Length)];

        //set size
        size = Random.Range(0, 3);

        //set values based on size
        switch(size)
        {
            case 0: //for small
                scale = transform.localScale * 0.7f;
                point_value = 20;
                time_before_shrink = 1f;
                audio_source.pitch = Random.Range(1.3f, 1.5f);
                    break;

            case 1: //for med
                scale = transform.localScale * 1.4f;
                point_value = 10;
                time_before_shrink = 1.5f;
                audio_source.pitch = Random.Range(0.9f, 1.2f);
                break;

                case 2: //for lrg
                scale = transform.localScale * 2.1f;
                point_value = 5;
                time_before_shrink = 2f;
                audio_source.pitch = Random.Range(0.5f, 0.7f);
                break;
        }

        //set scale to zero at start 
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //Grow/shrink based on scale 
        transform.localScale = Vector3.MoveTowards(transform.localScale, scale, 3.5f * Time.deltaTime); 

        //Shrinking 
        time_before_shrink -= Time.deltaTime;
        if(time_before_shrink <=0)
        {
            scale = Vector3.zero; 
        }

        //Destroy when dot has shrunk down 
        if(transform.localScale == Vector3.zero)
        {
            Destroy(gameObject);
        }
    }
}
