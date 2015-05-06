using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureQueue : MonoBehaviour {
    
    //Queue that holds game object - yet accepts only gameObject with tag = "Creature"
    Queue<GameObject> q;
	void Start () {
        q = new Queue<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public GameObject Dequeue()
    {
        return q.Dequeue();
    }

    public void Enqueue(GameObject obj)
    {
        if (obj.tag == "Creature")
        {
            q.Enqueue(obj);
        }
    }

    public bool isEmpty()
    {
        return (q.Count == 0);
    }
}
