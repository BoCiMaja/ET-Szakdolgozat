using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager
{
    private static string path = "path/player/";
    private static byte saveNumber = 1;

    private static GameData[] gameDatas;

    static GameSessionManager()
    {
        gameDatas = new GameData[GameSessionManager.saveNumber];
    }

    public static void NewGame()
    {
        GameSession.NewSession("playerTime.save");
        string savePath = "playerTime.save";
        SaveSystem.SaveSettings(new GameData(GameSession.Instance), savePath);
    }

    public static void Load(string fileName)
    {
        //GameSession[] ... 

        string loadPath = "playerTime.save";

        GameData data = SaveSystem.LoadSettings<GameData>(loadPath);

        GameSession session = new GameSession(data);

        GameSession.ChangeInstance(session);
    }

    public static void Save(GameSession session)
    {
        string savePath = "playerTime.save";
        SaveSystem.SaveSettings(new GameData(session), savePath);
    }
}
