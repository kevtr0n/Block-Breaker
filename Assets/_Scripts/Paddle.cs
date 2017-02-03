using UnityEngine;
using System.Collections;
public class Paddle : MonoBehaviour {
    // Use this for initialization
    public bool autoPlay = false;
    private Ball ball;
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	void MoveWithMouse () 
	{
        Vector3 paddlePos = new Vector3(1f, this.transform.position.y, this.transform.position.z);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.9f, 15.1f);
        this.transform.position = paddlePos;
    }
    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(1f, this.transform.position.y, this.transform.position.z);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.9f, 15.1f);
        this.transform.position = paddlePos;
    }
	// Update is called once per frame
	void Update () 
	{
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }
}