using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MainManager : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public int currentLevel;

        public SaveData(int currentLevel)
        {
            this.currentLevel = currentLevel;
        }
    }

public class GameManager
{
    private static string saveFileName = "gameSave.dat";

    public static void SaveGame(int currentLevel)
    {
        SaveData saveData = new SaveData(currentLevel);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFileName);
        bf.Serialize(file, saveData);
        file.Close();
    }

    public static int LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/" + saveFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFileName, FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();

            return saveData.currentLevel;
        }
        else
        {
            return 1; // Nível inicial padrão
        }
    }
}

    public class GameLevel
    {
        private int currentLevel;

        public GameLevel()
        {
            currentLevel = GameManager.LoadGame();
        }

        public void SetLevel(int newLevel)
        {
            currentLevel = newLevel;
            GameManager.SaveGame(currentLevel);
        }

        public int GetCurrentLevel()
        {
            return currentLevel;
        }
    }

    public class MainGame
    {
        private GameLevel gameLevel;

        public MainGame()
        {
            gameLevel = new GameLevel();
        }

        public void StartGame()
        {
            int level = gameLevel.GetCurrentLevel();

            // Ao completar o nível:
            level++;
            gameLevel.SetLevel(level);
        }
    }
}
