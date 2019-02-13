using UnityEngine;
using Utility;

namespace Tests
{
    public class SaveLoadTest : MonoBehaviour
    {
        private void Start()
        {
            var originalData = new SongData();
            print($"{originalData.artistName} - {originalData.songName}");
            SaveUtil.SaveData("file1", originalData);

            var loadedData = SaveUtil.LoadData<SongData>("file1");
            print($"{originalData.artistName} - {originalData.songName}");
        }
    }

}
