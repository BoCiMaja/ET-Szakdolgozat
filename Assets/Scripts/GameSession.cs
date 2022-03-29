using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameSession
{
    public static event Action<GameData> OnGraphicsChange;

    private GameSession(string path)
    {
        this.Path = path;
    }

    public GameSession(GameData data)
    {
        //Profile = new Profile(data.Profile);
        Path = data.Path;
    }

    public GameSession(GameSession session)
    {
        Path = session.Path;
        PlayerPrefab = session.PlayerPrefab;
        Profile = session.Profile;
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

    private GameData savedSession;

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

    public static void NewSession(string path)
    {
        instance = new GameSession(path);
    }

    public static void ChangeInstance(GameSession newInstance)
    {
        Instance = newInstance;
        SceneSessionManager.LoadSession(instance.savedSession);
    }

    public static void SaveSession()
    //public void SaveSession()
    {
        GameSessionManager.Save(Instance);
        instance.savedSession = new GameData(instance);
        //GameSessionManager.Save(this);
    }

    public static void LoadSession()
    //public void LoadSession()
    {
        GameSessionManager.Load("cica");
    }


    //public void LoadDataInScene()
    //{
    //    throw new System.NotImplementedException();
    //}

}
