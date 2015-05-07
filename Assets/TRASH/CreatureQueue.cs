using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureQueue : MonoBehaviour {
    
    //Queue that holds game object - yet accepts only gameObject with tag = "Creature"
    Queue<Creature> q;
	void Start () {
        q = new Queue<Creature>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public Creature Dequeue()
    {
            return q.Dequeue();
    }

    public void Enqueue(Creature obj)
    {
            q.Enqueue(obj);
    }


    public bool isEmpty()
    {
        return (q.Count == 0);
    }
}
