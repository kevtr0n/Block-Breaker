using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	// Use this for initialization
	void Start () 
	{
		paddle = FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity += tweak;
        }
    }
	// Update is called once per frame
	void Update () 
	{
		if (!hasStarted)
		{
			// Locks the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			// Wait for a left-click to launch.
			if(Input.GetMouseButtonDown(0))
			{
				print ("Mouse Clicked, Launch Ball!");
				hasStarted = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
			}
		}
	}
}