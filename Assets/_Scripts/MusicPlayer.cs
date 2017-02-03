﻿using UnityEngine;
using System.Collections;
public class MusicPlayer : MonoBehaviour 
{
	// Use this for initialization
	static MusicPlayer instance = null;
	void Awake ()
	{
		if (instance != null)		
		{
			Destroy(gameObject);
		}
		else 
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}