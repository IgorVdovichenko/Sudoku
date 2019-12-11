using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Saver<T>
{
	private string saveFileName = "save.dat";
	private string fileName;
	private FileStream fileStream;
	private BinaryFormatter formatter = new BinaryFormatter();

	public Saver()
	{
		fileName = string.Format("{0}/{1}", Application.persistentDataPath, saveFileName);
        Debug.Log(fileName);
    }

	public void SaveData(T data)
	{
		fileStream = new FileStream(fileName, FileMode.Create);
		formatter.Serialize(fileStream, data);
		fileStream.Close();
        Debug.Log("Saved!");
	}

	public T GetData()
	{
        fileStream = new FileStream(fileName, FileMode.Open);
        T data = (T)formatter.Deserialize(fileStream);
        fileStream.Close();
		return data;
	}

    public bool FileExists()
    {
        FileInfo fileInfo = new FileInfo(fileName);
        return fileInfo.Exists;
    }
}
