﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour {
    public GameObject _cubePrefab;
    GameObject[] sampleCube = new GameObject[512];
    public float _maxScale;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_cubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "Sample Cube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.70125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            sampleCube[i] = _instanceSampleCube;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 512; i++)
        {
            if (sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(10, (AudioPlayer._samples[i] * _maxScale) + 2, 10);
            }
        }
	}
}
