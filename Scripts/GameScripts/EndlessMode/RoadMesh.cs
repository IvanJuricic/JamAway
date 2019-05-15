using UnityEngine;
using SynchronizerData;
using System.Collections.Generic;

public class RoadMesh : MonoBehaviour
{
    private BeatObserver beatObserver;
    private BeatQueueController queueController = new BeatQueueController();
    public GameObject roadGO;
    public Transform _targetM,_targetR,_targetL;
    private System.Random random = new System.Random();
    private int randomNumber, lastAdded=0;
    private GameObject instantiatedGO;
    private Vector3 positionR;
    private float zValue,targetSpeed=100f;
    private bool hasPlayerBeenOn;


    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
    }

    void Update()
    {
       
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
            //Debug.Log("Beat");
            _targetM.transform.Translate(0, 0, targetSpeed);
            _targetL.transform.Translate(0, 0, targetSpeed);
            _targetR.transform.Translate(0, 0, targetSpeed);
            randomNumber = random.Next(1, 4);
            //skipRandom = random.Next(0, 10);
            switch (randomNumber)
            {
                case (1):
                    //if (skipRandom != 1) {
                    zValue += 100f;
                    positionR = new Vector3(100f, 0, zValue);
                    if (lastAdded!=randomNumber)
                    {
                        queueController.SendToQueue(randomNumber); 
                    }
                    lastAdded = randomNumber;
                    instantiatedGO = Instantiate(roadGO, positionR, transform.rotation);
                    instantiatedGO.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    //}
                    //else Debug.Log("Skipped A Beat");
                    break;
                case (2):
                    //if (skipRandom != 1)
                    //{
                    zValue += 100f;
                    positionR = new Vector3(0, 0, zValue);
                    if (lastAdded != randomNumber)
                    {
                        queueController.SendToQueue(randomNumber);
                    }
                    lastAdded = randomNumber;
                    instantiatedGO = Instantiate(roadGO, positionR, transform.rotation);
                    instantiatedGO.GetComponent<MeshRenderer>().material.color = Color.blue;
                    // }
                    //else Debug.Log("Skipped A Beat");
                    break;
                case (3):
                    //if (skipRandom != 1)
                    //{
                    zValue += 100f;
                    positionR = new Vector3(-100f, 0, zValue);
                    if (lastAdded != randomNumber)
                    {
                        queueController.SendToQueue(randomNumber);
                    }
                    lastAdded = randomNumber;
                    instantiatedGO = Instantiate(roadGO, positionR, transform.rotation);
                    instantiatedGO.GetComponent<MeshRenderer>().material.color = Color.red;
                    // }
                    //else Debug.Log("Skipped A Beat");
                    break;

            }
        }

    }
}