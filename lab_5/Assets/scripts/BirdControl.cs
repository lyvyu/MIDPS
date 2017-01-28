using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdControl : MonoBehaviour {

	Rigidbody2D body;

	public float speed = 3f;
    public Text scoreText;
    public Text gameOverText;
	public Vector3 velocity = Vector3.zero;
	public Vector3 gravity = new Vector3();

	public Vector2 jumpForce = new Vector2 (0, 300);

    private bool gameOver;
	private int score;
	private bool paused;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
        score = 0;
        UpdateScore();
        gameOver = false;
        gameOverText.text = "";
		paused = false;
    }
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;

		if (!gameOver)
		{
			if (Input.GetKeyDown (KeyCode.P)) {
				PauseGame ();
			}

			//kill player if he runs out of bundles
			if (position.y < 0 || position.y > 17)
			{
				KillPlayer();
			}

			velocity += gravity * Time.deltaTime; 
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) 
			{
				body.velocity = Vector2.zero;
				body.AddForce(jumpForce);
				velocity += new Vector3 (0, 3, 0);
			}
			//			velocity = Vector3.ClampMagnitude (velocity, speed);
			float angle = 0;

			//			Debug.Log (velocity);
			if (velocity.y < 0)
			{
				angle = Mathf.Lerp (0, -90, -velocity.y / speed);
				body.transform.rotation = Quaternion.Euler(0, 0, angle); 
			}

			float h = Input.GetAxis ("Horizontal");

			if (h != 0) 
			{
				body.AddForce (Vector2.right * speed * h);
			}
		} else {
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                ReloadGAME();
            }
        }
    }

	void OnCollisionEnter2D ()
	{
        KillPlayer();
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "ScoreChecker")
        {
            score++;
            UpdateScore();
        }
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void KillPlayer ()
    {
        gameOverText.text = "Game Over \nTap to retry";
        //Time.timeScale = 0;
        //ReloadGAME();
        gameOver = true;
//        Destroy(body);
    }

    void ReloadGAME ()
    {
        Time.timeScale = 1;
		SceneManager.LoadScene(1);
		Debug.Log ("input");
    }

	void PauseGame () 
	{
		if (paused) {
			Time.timeScale = 1f;
			paused = false;
			Debug.Log (paused);
			AudioListener.pause = false;
		} else {
			Time.timeScale = 0f;
			paused = true;
			AudioListener.pause = true;
		}
	}
}
