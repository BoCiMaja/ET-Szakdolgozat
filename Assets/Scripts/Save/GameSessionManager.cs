using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager
{
    private static string path = "path/player/";
    private static byte SAVE_NUMBER = 1;

    private static GameData[] gameDatas;

    static GameSessionManager()
    {
        gameDatas = new GameData[GameSessionManager.SAVE_NUMBER];
    }

    public static void NewGame(string firstScene)
    {
        //Több mentésnél megkeresni az elsõ szabad helyet.
        Profile profile = new Profile(string.Format("Profile{0}", 1));

        GameSession.NewSession("playerTime.save", profile, firstScene);

        //string savePath = "playerTime.save";
        //SaveSystem.SaveSettings(new GameData(GameSession.Instance), savePath);
    }

    public static void LoadSaves()
    {
        string loadPath = "playerTime.save";

        gameDatas[0] = SaveSystem.LoadSettings<GameData>(loadPath);
    }

    public static void LoadSessionFromDefaultFile()
    {
        string loadPath = "playerTime.save";

        GameData data = SaveSystem.LoadSettings<GameData>(loadPath);

        GameSession.LoadSession(data);
    }

    public static void Load(string fileName)
    {
        string loadPath = fileName;

        GameData data = SaveSystem.LoadSettings<GameData>(loadPath);

        GameSession.LoadSession(data);
    }

    public static void Load(int index)
    {
        if (gameDatas == null)
            LoadSaves();

        if (index + 1 > gameDatas.Length)
            throw new System.Exception("Save cannot found.");

        GameSession.LoadSession(gameDatas[index]);
    }

    public static void Load()
    {
        if (gameDatas.Length < 0)
            throw new System.Exception("Save not found.");

        Load(0);

        SceneLoader.Continue(gameDatas[0].ActualScene);
    }

    public static void Save()
    {
        string savePath = "playerTime.save";
        GameData dataToStore = GameSession.SaveSession();
        SaveSystem.SaveSettings(dataToStore, savePath);
    }

    public static void ReloadLastSavedSession()
    {
        GameSession.ReloadSavedSession();
        //újratöltés
    }
}
