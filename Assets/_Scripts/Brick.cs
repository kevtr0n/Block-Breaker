using UnityEngine;
using System.Collections;
public class Brick : MonoBehaviour
{
    public AudioClip crack, crash;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
	private int timesHit;
	private LevelManager levelManager;
    private bool isBreakable;
	// Use this for initialization
	void Start () 
	{
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks.
        if (isBreakable)
        {
            breakableCount++;
        }
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
        AudioSource.PlayClipAtPoint(crack, transform.position, 50f);
        if (isBreakable)
        {
            HandleHits();
        }
	}
    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(crash, transform.position, 50.0f);
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
	// TODO Remove this method once we can actually win.
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
