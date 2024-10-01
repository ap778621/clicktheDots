using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    //Dot collision
    public Camera cam;

    //SpaWNING dOTS
    public GameObject dot;
    public float time_between_spawns = 1f; //In seconds
    private float dot_timer = 0f;

    //score
    private int score = 0; //total score
 // private int points = 10; //

    //UI
    public TMP_Text score_text;
    public TMP_Text timer_text;
    public GameObject restart_button;

    //Game timer
    private float game_timer = 10f; //In seconds.

    // Start is called before the first frame update
    void Start()
    {
        //set timer with delay 
        dot_timer = 0.5f;

        //set default ui.
        score_text.text = "score: 0";

        score_text.text = "Score: 0";

        //Deactivate button
        restart_button .SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        game_timer -= Time.deltaTime;
        if(game_timer <=0) // Timer has fully counted down....
        {
            game_timer = 0;
            timer_text.text = "timer: 0"; //Make Text display at zero.

            //Activate the button
            restart_button.SetActive(true);
            
            return; //halt any other game actions

        }
        //Count game timer down
        timer_text.text = "Time: " + Mathf.Floor(game_timer); //Make timer read off the correct time.

        //If we click the left mouse button.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position and shoot a ray from it.
            Vector2 world_point = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(world_point, Vector2.zero);

            //if something was hit...
            if (hit.collider != null && !hit.collider.gameObject.GetComponent<dot>().audio_source.isPlaying)
            {
                //store the dot we clicked on in a variable 
                GameObject Dot = hit.collider.gameObject;

                //have dot play the sound 
                Dot.GetComponent<SpriteRenderer>().enabled = false;
                Dot.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;





               //Destroy the game object.
               Destroy(hit.collider.gameObject, Dot.GetComponent<dot>().audio_source.clip.length);

                //Add to score
                score += Dot.GetComponent<dot>().point_value;

                //Update score text 
                score_text.text = "Score: " + score;




            }

             
        }

        //spawn Dots
        dot_timer -= Time.deltaTime; //make timer count down. 

        // if timer counts down..
        if (dot_timer <= 0)
        {
            // RESET timer 
            dot_timer = time_between_spawns;

            //spawn dots. 
            SpawnDot();
        }
    }
    private void SpawnDot()
    {
        //Instantiate dot.
        GameObject new_dot = Instantiate(dot);

        //Set position. 
        int x_pos = Random.Range(0, cam.scaledPixelWidth);
        int y_pos = Random.Range(0, cam.scaledPixelHeight);

        //Convert point to world space 
        Vector3 spawn_point = new Vector3(x_pos, y_pos, 0);
        spawn_point = cam.ScreenToWorldPoint(spawn_point);
        spawn_point.z = 0;

        //set position of dot 
        new_dot.transform.position = spawn_point;
    }

    public void RestartGame()
    {
        //Reload the current scene, restarting it. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
