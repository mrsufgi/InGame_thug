 using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class JsonLevelLoader : MonoBehaviour {

    // Use this for initialization

    Dictionary<string, string> d = new Dictionary<string, string>();

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("file.json"))
        {
            string json = r.ReadToEnd();
            JSONObject j = new JSONObject(json);
            BuildLevel(j);
        }
    }

    public static Vector3 ToVector3(JSONObject obj)
    {
        float x = obj["x"] ? obj["x"].f : 0;
        float y = obj["y"] ? obj["y"].f : 0;
        float z = obj["z"] ? obj["z"].f : 0;
        return new Vector3(x, y, z);
    }

    //access data (and print it)
    void BuildLevel(JSONObject obj){

        LevelConfi c = new LevelConfi();
        c.gameLevel = (int) obj["gameLevel"].n;
        JSONObject vector = obj["spawnValues"];
       c.spawnValues = ToVector3(vector);
       // c.creatures = 
       // c.spawnValues = new Vector3((float) vector.list[0].n, (float) vector.list[1].n, (float) vector.list[2].n);
        
        //   for (int i = 0; i < obj.Count; i++)
        //   {
        //       if (obj.keys[i] != null)
        //       {
        //           switch ((string)obj.keys[i])
        //           {
        //               case "gameLevel":
        //                   c.gameLevel = (int) obj.list[i].n;
        //                   break;
        //               case "spawnValues":
        //                   if (obj.list[i].Count > 0)
        //                   {
        //                       JSONObject vector = obj.list[i].list[0];
        //                       c.spawnValues = new Vector3((float)vector.list[0].n, (float)vector.list[1].n, (float)vector.list[2].n);
        //                   }
        //           break;
        //           }
        //       }
        //   }
        //   //switch (obj.type) {
        //   //    case JSONObject.Type.OBJECT:
        //   //        for (int i = 0; i < obj.list.Count; i++) {
        //   //            string key = (string)obj.keys[i];
        //   //            JSONObject j = (JSONObject)obj.list[i];
        //   //            Debug.Log(key);

        //   //            accessData(j);
        //   //        }
        //   //        break;
        //   //    case JSONObject.Type.ARRAY:
        //   //        foreach (JSONObject j in obj.list) {
        //   //            accessData(j);
        //   //        }
        //   //        break;
        //   //    case JSONObject.Type.STRING:
        //   //        Debug.Log(obj.str); 
        //   //        break;
        //   //    case JSONObject.Type.NUMBER:
        //   //        Debug.Log(obj.n);
        //   //        break;
        //   //    case JSONObject.Type.BOOL:
        //   //        Debug.Log(obj.b);
        //   //        break;
        //   //    case JSONObject.Type.NULL:
        //   //        Debug.Log("NULL");
        //   //        break;

        //   //}
    }

    void Start()
    {
        LoadJson();
        foreach(KeyValuePair<string, string> s in d)
        {
            print(s.Key);
        }
    }

    public class LevelConfi
    {
        public int gameLevel;
        public Vector3 spawnValues;
        public List<Creature> creatures;
    }

}
