using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int health;
    Rigidbody2D rb2d;
    public float speed;
    public GameObject self;
    private AudioSource audioSource;
    public AudioClip deathSound;
    //private float curSpeed;
    //private float maxSpeed;
    public float maxVelocity;
    SpriteRenderer spriteRenderer;
    float horizontal;
    float vertical;
    public Material matWhite;
    private Material matDefault;
    GameObject[] gameOverText;
    private Timer timer;
    private GameObject timerText;
    private GameObject highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = this.GetComponent<AudioSource>();
        timerText = GameObject.FindGameObjectWithTag("timer");
        timer = timerText.GetComponent<Timer>();
        //matWhite = Resources.Load("LiberationSans SDF Material", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
        gameOverText = GameObject.FindGameObjectsWithTag("showOnGameOver");
        highScoreText = GameObject.FindGameObjectWithTag("highScore");
        foreach (GameObject text in gameOverText)
        {
            text.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 AxisInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb2d.AddForce(AxisInput * speed, ForceMode2D.Impulse);

        //limits velocity
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);

        //slows bird down when no input
        if (AxisInput == Vector2.zero)
        {
            rb2d.velocity /= new Vector2(1.05f, 1.05f);
        }
        if (AxisInput.x > 0)
        {
            self.transform.localScale = new Vector2(-1f, 1f);
        }
        else if (AxisInput.x < 0)
        {
            self.transform.localScale = new Vector2(1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Debug.Log("Hit");
            Destroy(collision.gameObject);
            health--;
            spriteRenderer.material = matWhite;
            Invoke("ResetMaterial", .2f);
            if (health <= 0)
            {
                //Game Over stuff
                Debug.Log("Game Over");
                audioSource.clip = deathSound;
                audioSource.Play();
                transform.position = Camera.main.ViewportToWorldPoint(new Vector2(2, 2));
                Destroy(gameObject, audioSource.clip.length);
                GameObject sword = GameObject.FindGameObjectWithTag("sword");
                sword.transform.position = Camera.main.ViewportToWorldPoint(new Vector2(2, 2));
                Destroy(sword, audioSource.clip.length);
                if (timer.getBirdsSlain() > timer.getHighScore())
                {
                    timer.setHighScore(timer.getBirdsSlain());
                    Debug.Log("New high Score: " + timer.getBirdsSlain());
                }
                foreach (GameObject text in gameOverText)
                {
                    text.SetActive(true);
                }
                TextMeshProUGUI birdCountText = GameObject.Find("BirdCount").GetComponent<TextMeshProUGUI>();
                birdCountText.text = "You cut down " + timer.getBirdsSlain() + " birds!";
                TextMeshProUGUI gameOverHighScoreText = GameObject.Find("GameOverHighScore").GetComponent<TextMeshProUGUI>();
                gameOverHighScoreText.text = "Your record is " + timer.getHighScore() + " birds!";
                timerText.SetActive(false);
                highScoreText.SetActive(false);
            }
            else
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }

    void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }
}
