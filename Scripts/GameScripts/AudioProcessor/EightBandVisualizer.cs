using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightBandVisualizer : MonoBehaviour {

    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPlayer._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else transform.localScale = new Vector3(transform.localScale.x, (AudioPlayer._frequencyBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
