using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SceneSessionManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            try
            {
                GameSession.Instance.PlayerPrefab = playerPrefab;
            }
            catch
            {
                if (Application.isEditor)
                    GameSessionManager.NewGame();
            }
            GameSession.Instance.PlayerPrefab = playerPrefab;
        }
    }

    public static Light2D[] LightsInScene
    {
        get
        {
            Light2D[] lights = FindObjectsOfType<Light2D>();
            return lights;
        }
    }

    public static void LoadSession(GameData data)
    {
        Debug.Log(data.Path);
    }
}
