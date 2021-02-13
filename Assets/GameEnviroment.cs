using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sealed class means that you can't can't inherit from this class
public sealed class GameEnviroment
{
    // points to the single instance of this singleton
    private static GameEnviroment instance;
    private List<GameObject> obstacles = new List<GameObject>();

    public List<GameObject> Obstacles {  get { return obstacles; } }

    public static GameEnviroment Instance {
        get
        {
            if (instance == null)
            {
                instance = new GameEnviroment();
            }
            return instance;
        }
    }

    public void AddObstacles(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacles(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
    }
}
