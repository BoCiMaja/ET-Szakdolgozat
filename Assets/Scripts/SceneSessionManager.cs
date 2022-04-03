using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneSessionManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    private static SceneSessionManager Instance;

    private PlayerDataController playerController;
    public PlayerDataController PlayerController
    {
        private set 
        { 
            playerController = value;
            GameSession.Instance.PlayerContr = playerController;
        }
        get { return playerController; }
    }

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
                GameSessionManager.NewGame(SceneManager.GetActiveScene().name);
            }
            GameSession.Instance.PlayerPrefab = playerPrefab;
        }
    }

    private void Start()
    {
        GameSession.OnSavedSessionReload += ReloadSession;
        SceneLoader.OnLoadNextScene += OnNextSceneLoaded;
        SceneLoader.OnLoadMainMenu += LoadMainMenu;
        ReloadSession(new GameData(GameSession.Instance));
        //LoadSession(new GameData(GameSession.Instance));
    }

    private void OnDestroy()
    {
        GameSession.OnSavedSessionReload -= ReloadSession;
        SceneLoader.OnLoadNextScene -= OnNextSceneLoaded;
        SceneLoader.OnLoadMainMenu -= LoadMainMenu;
    }

    private void LoadMainMenu()
    {
        Destroy(gameObject);
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
        ReloadCharacter(data.SavePosition, data.PlayerData);
        ReloadLights(data.LightsDatas);
        RealoadCamera(data);
    }

    private static void RealoadCamera(GameData data)
    {
        Vector3 cameraPosition =
                    new Vector3(data.SavePosition.x, data.SavePosition.y, Camera.main.transform.position.z);
        Camera.main.transform.position = cameraPosition;
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
        light.transform.position = data.position;
    }

    private static void ReloadCharacter(Vector3 position, PlayerData data)
    {
        GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");
        Destroy(playerInScene);

        GameObject player = Instantiate(Instance.playerPrefab, position, new Quaternion());
        PlayerDataController controller = player.GetComponent<PlayerDataController>();
        controller.SetPlayerData(data);
        Instance.PlayerController = controller;

        Camera.main.GetComponent<CameraMovement>().character = player.transform;
    }


    private void OnNextSceneLoaded()
    {
        GameObject playerInScene = GameObject.FindGameObjectWithTag("Player");
        playerInScene.GetComponent<PlayerDataController>().SetPlayerData(GameSession.Instance.PlayerData);
        Instance.PlayerController = playerInScene.GetComponent<PlayerDataController>();

        GameSession.SaveAtPosition(playerInScene.transform.position);
    }

    internal static void OnPlayerDestroyed(PlayerDataController controller)
    {
        GameSession.Instance.PlayerData = new PlayerData(controller);
    }
}
