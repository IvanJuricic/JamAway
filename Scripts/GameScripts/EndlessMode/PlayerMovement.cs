using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private BeatQueueController queueController=new BeatQueueController();
    public Transform _targetM, _targetR, _targetL;
    public AudioSource audioSource;
    private int previousValue,currentValue=0;
    private float minDistance, playerSpeed=200f;
    

    void Update () {
        if (transform.position.x == 0)
        {
            
            //if (minDistance > Vector3.Distance(_targetM.position, transform.position))
            //    playerSpeed -= 20f;
            //else if (minDistance < Vector3.Distance(_targetM.position, transform.position) && playerSpeed < 200)
            //    playerSpeed += 10f;
            transform.position = Vector3.MoveTowards(transform.position, _targetM.position, playerSpeed*Time.deltaTime);
            //transform.position += (_targetM.position - transform.position) * playerSpeed;
        }
        else if (transform.position.x == 100)
        {
            //if (minDistance > Vector3.Distance(_targetR.position, transform.position))
            //    playerSpeed -= 20f;
            //else if (minDistance < Vector3.Distance(_targetR.position, transform.position) && playerSpeed < 200)
            //    playerSpeed += 10f;
            transform.position = Vector3.MoveTowards(transform.position, _targetR.position, playerSpeed * Time.deltaTime);
        }

        else
        {
            //if (minDistance > Vector3.Distance(_targetL.position, transform.position))
            //    playerSpeed -= 20f;
            //else if (minDistance < Vector3.Distance(_targetL.position, transform.position) && playerSpeed < 200)
            //    playerSpeed += 10f;
            transform.position = Vector3.MoveTowards(transform.position, _targetL.position, playerSpeed * Time.deltaTime);
        }

        //transform.Translate(0, 0, Time.deltaTime*playerSpeed);
    }

    public void ShiftPlayer()
    {
        previousValue = currentValue;
        
        currentValue = queueController.ReturnQueueMember();

        //Debug.Log("Dohvacena " + currentValue.ToString());

        if (currentValue > 0)
        {
            switch (currentValue)
            {
                case (1):
                    if (currentValue != previousValue)
                    {
                        //Debug.Log("Skreni desno za 100");
                        transform.position = new Vector3(100f, transform.position.y, transform.position.z);
                    }
                    break;
                case (2):
                    if (currentValue != previousValue)
                    {
                        //Debug.Log("Otidi u sredinu");
                        transform.position = new Vector3(0, transform.position.y, transform.position.z);
                    }
                    break;
                case (3):
                    if (currentValue != previousValue)
                    {
                        //Debug.Log("Skreni lijevo za 100");
                        transform.position = new Vector3(-100f, transform.position.y, transform.position.z);
                    }
                    break;
            }
        }
        else Debug.Log("Krivi podatak");

    }
}
