using UnityEngine;
using System.Collections;

public class WorldLoader : MonoBehaviour {

    // static loader...
    public void World_One_Load()
    {
        Application.LoadLevel("level");
    }
}
