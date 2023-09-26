using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private int valueToSave;

    private string filePath;

    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gameSave";
    }

    public void SaveValue()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.Create);

        SaveData saveData = new SaveData();
        saveData.CurrentAmmo = InventoryManager.Instance.CurrentAmmo;
        formatter.Serialize(fileStream, saveData); 

        fileStream.Close();
    }

    public void LoadValue()
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            SaveData saveData = (SaveData)formatter.Deserialize(fileStream);
            InventoryManager.Instance.CurrentAmmo = saveData.CurrentAmmo;
            fileStream.Close();
        }
    }


}