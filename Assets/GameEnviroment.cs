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

    private List<GameObject> goals = new List<GameObject>();
    public List<GameObject> Goals { get { return goals; } }

    public GameObject[] goalLocations;

    public static GameEnviroment Instance {
        get
        {
            // This part is equivalent to a constructor of your singleton
            if (instance == null)
            {
                instance = new GameEnviroment();
                instance.Goals.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }
            return instance;
        }
    }

    // For the methods is neccessary to use "Instance" instead of "instance"
    // to initialize instance

    public static GameObject GetRandomGoal()
    {
        int index = Random.Range(0, Instance.goals.Count);
        return Instance.goals[index];
    }

    public static void AddObstacles(GameObject go)
    {
        Instance.obstacles.Add(go);
    }

    public static void RemoveObstacles(GameObject go)
    {
        int index = Instance.obstacles.IndexOf(go);
        Instance.obstacles.RemoveAt(index);
        GameObject.Destroy(go);
    }
}
