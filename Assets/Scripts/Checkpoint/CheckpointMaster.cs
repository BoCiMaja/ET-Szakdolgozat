using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMaster : MonoBehaviour
{
    private static CheckpointMaster instance;
    public Vector2 lastCheckPointPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static CheckpointMaster GetInstance()
    {
        return instance;
    }

    public void SetCheckpointPlayerPosition(Transform tr)
    {
        lastCheckPointPos = tr.position;
        Debug.Log(lastCheckPointPos);
    }

    public void ReloadLastCheckpoint()
    {
        SceneLoader.ReloadCurrentScene();
    }
}

