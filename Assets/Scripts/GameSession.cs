using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameSession
{
    public static event Action<GameData> OnSavedSessionReload;

    private GameSession(string path, Profile profile, string scene)
    {
        this.Path = path;
        this.Profile = profile;
        this.ActualScene = scene;
    }

    public GameSession(GameData data)
    {
        //Profile = new Profile(data.Profile);
        this.Path = data.Path;
    }

    public GameSession(GameSession session)
    {
        this.Path = session.Path;
        this.PlayerPrefab = session.PlayerPrefab;
        this.Profile = session.Profile;
    }

    private static GameSession instance;
    public static GameSession Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("Instance does not exist.");
            return instance;
        }
        private set
        {
            instance = new GameSession(value);
            //instance.savedSession = new GameData(instance);
        }
    }

    #region Fields and their properties

    private string path;
    public string Path
    {
        get { return path; }
        private set
        {
            string path;

            if (!value.Contains("."))
                path = string.Format("{0}.dat", value);
            else path = value;

            this.path = path;
        }
    }

    private string actualScene;
    public string ActualScene
    {
        get { return actualScene; }
        set { actualScene = value; }
    }

    private Profile profile;
    public Profile Profile
    {
        get { return profile; }
        private set { profile = value; }
    }

    private GameObject playerPrefab;
    public GameObject PlayerPrefab
    {
        private get { return playerPrefab; }
        set
        {
            //ertekadas utan lehessen valtoztani?
            playerPrefab = value;
        }
    }

    private GameData savedSession;

    #endregion

    #region Properties

    public Light2D[] Lights
    {
        get
        {
            Light2D[] lights;

            try
            {
                lights = SceneSessionManager.LightsInScene;
            }
            catch
            {
                lights = new Light2D[0];
            }

            //Light2D[] tempLights = new Light2D[lights.Length];
            //for (int i = 0; i < lights.Length; i++)
            //    tempLights[i] = lights[i];

            return lights;
        }
    }

    #endregion

    public static void NewSession(string path, Profile profile, string firstScene)
    {
        instance = new GameSession(path, profile, firstScene);
    }

    public static void LoadSession(GameData data)
    {
        ChangeInstance(data);
        Instance.savedSession = data;
        OnSavedSessionReload.Invoke(data);
    }

    public static void ChangeInstance(GameSession newInstance)
    {
        Instance = newInstance;
    }

    public static void ChangeInstance(GameData data)
    {
        Instance = new GameSession(data);
    }

    public static void SaveSession()
    {
        instance.savedSession = new GameData(instance);
    }

    internal static void SetSceneData(string sceneName)
    {
        instance.ActualScene = sceneName;
    }
}
