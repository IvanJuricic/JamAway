using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BeatQueueController{

    private static readonly Queue<int> myQueue = new Queue<int>();
    public int returnedVariable;

    public void SendToQueue(int _value)
    {
        lock (myQueue)
        {
            myQueue.Enqueue(_value);
        }  
    }

    public int ReturnQueueMember()
    {
        lock (myQueue)
        {
            return myQueue.Dequeue();
        }
    }

}