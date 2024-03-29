﻿using UnityEngine;
using System.Collections;
using SynchronizerData;


public class SphereBehavior : MonoBehaviour {

	public Vector3[] beatPositions;

	private BeatObserver beatObserver;
	private int beatCounter;


	void Start ()
	{
		beatObserver = GetComponent<BeatObserver>();
		beatCounter = 0;
	}

	void Update ()
	{
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			transform.Translate(beatPositions[beatCounter]);
			beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
		}
        transform.Translate(0, 0, 1f);
    }
}
