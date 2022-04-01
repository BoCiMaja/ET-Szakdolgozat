using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneSessionManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    private static SceneSessionManager Instance;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);

            if (!Instance.playerPrefab.Equals(this.playerPrefab))
            {
                Instance.playerPrefab = this.playerPrefab;
                GameSession.Instance.PlayerPrefab = playerPrefab;
            }

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            try
            {
                GameSession.Instance.PlayerPrefab = playerPrefab;
            }
            catch
            {
                if (Application.isEditor)
                    GameSessionManager.NewGame(SceneManager.GetActiveScene().name);
            }
            GameSession.Instance.PlayerPrefab = playerPrefab;
        }
    }

    private void Start()
    {
        GameSession.OnSavedSessionReload += ReloadSession;
        SceneLoader.OnLoadNextScene += OnNextSceneLoaded;
        //LoadSession(new GameData(GameSession.Instance));
    }

    private void OnDestroy()
    {
        GameSession.OnSavedSessionReload -= ReloadSession;
        SceneLoader.OnLoadNextScene -= OnNextSceneLoaded;
    }

    public static Light2D[] LightsInScene
    {
        get
        {
            Light2D[] lights = FindObjectsOfType<Light2D>();
            return lights;
        }
    }

    public static void ReloadSession(GameData data)
    {
        ReloadLights(data.LightsDatas);
    }

    private static void ReloadLights(Light2dData[] lightData)
    {
        foreach (Light2D light in LightsInScene)
            foreach (Light2dData data in lightData)
                if (data.Equals(light))
                {
                    LoadLight(light, data);
                    break;
                }
    }

    private static void LoadLight(Light2D light, Light2dData data)
    {
        light.enabled = data.enabled;
        //light.transform.position = data.position;
    }

    public void OnNextSceneLoaded()
    {
        //Get Player
        GameSession.SetSceneData(SceneManager.GetActiveScene().name/*, player*/);
    }
}
