using UnityEngine;
using System.Collections;

public class ExampleUse : MonoBehaviour {

	public SimpleBeatDetection beatProcessor;

	//private MeshRenderer myMeshRenderer;
	private Color beatedColor;
	public float smoothnessChange;
    public GameObject _player;

	void Start () {
		//beatProcessor.OnBeat += OnBeat;
		//myMeshRenderer = GetComponent<MeshRenderer> ();
		beatedColor = Color.black;
	}

	void Update () {

        
		beatedColor = Color.Lerp (beatedColor, Color.black, smoothnessChange*Time.deltaTime);
        _player.GetComponent<MeshRenderer>().material.color = beatedColor;
        Debug.Log("Random");
        //myMeshRenderer.material.color = beatedColor;
	}

	void OnBeat(){

		beatedColor = Color.yellow;
        Debug.Log("Zuta");
	}
}
