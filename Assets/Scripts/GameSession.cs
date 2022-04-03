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
        this.path = path;
        this.profile = profile;
        this.ActualScene = scene;
    }

    public GameSession(GameData data)
    {
        this.profile = new Profile(data.ProfileData);
        this.path = data.Path;
        this.ActualScene = data.ActualScene;
        this.SavePosition = data.SavePosition;
        this.PlayerData = data.PlayerData;
    }

    public GameSession(GameSession session)
    {
        this.Path = session.path;
        this.ActualScene = session.actualScene;
        this.SavePosition = session.savePosition;
        this.Profile = session.profile;
        this.PlayerData = session.playerData;
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
            instance = value;
            instance.lastChangeInSession = DateTime.Now;
            instance.savedSession = new GameData(instance);
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
        set 
        {
            try
            {
                SceneManager.GetSceneByName(value);
                actualScene = value; 
            }
            catch
            {
                throw new Exception("Scene does not exist.");
            }
            
        }
    }

    private Vector3 savePosition;
    public Vector3 SavePosition
    {
        private set
        {
            savePosition = value;
        }
        get { return savePosition; }
    }
    internal static void SaveAtPosition(Vector3 position)
    {
        Instance.savePosition = position;
        GameSessionManager.Save();
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

    private PlayerDataController playerContr;
    public PlayerDataController PlayerContr
    {
        get { return playerContr; }
        set 
        {
            if (value == null && playerContr != null)
            {
                PlayerData = new PlayerData(playerContr);
            }
            playerContr = value;
        }
    }

    private PlayerData playerData;
    public PlayerData PlayerData
    {
        get
        {
            return playerData; 
        }
        set { playerData = value; }
    }

    private GameData savedSession;
    private DateTime lastChangeInSession;

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

    #region Methods

    private GameData Save()
    {
        if (PlayerContr != null)
        {
            PlayerData = new PlayerData(playerContr);
            //SavePosition = playerContr.transform.position;
        }
        savedSession = new GameData(this);

        profile.GameTime += (DateTime.Now - lastChangeInSession).TotalSeconds;

        profile.LastSave = DateTime.Now;
        return savedSession;
    }

    #endregion

    #region Static Methods

    public static void NewSession(string path, Profile profile, string firstScene)
    {
        Instance = new GameSession(path, profile, firstScene);
    }

    public static void LoadSession(GameData data)
    {
        Instance = new GameSession(data);
        Instance.savedSession = data;
        OnSavedSessionReload?.Invoke(data);
    }

    internal static void ReloadSavedSession()
    {
        Instance.Profile.GameTime += (DateTime.Now - Instance.lastChangeInSession).TotalSeconds;
        LoadSession(Instance.savedSession);
    }


    public static void ChangeInstance(GameSession newInstance)
    {
        Instance = new GameSession(newInstance);
    }

    public static void ChangeInstance(GameData data)
    {
        Instance = new GameSession(data);
    }

    public static GameData SaveSession()
    {
        return Instance.Save();
    }

    internal static void SetSceneData(string sceneName)
    {
        instance.ActualScene = sceneName;
    }

    #endregion
}
