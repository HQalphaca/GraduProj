using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBManager : MonoBehaviour
{
    [SerializeField] UnitDatabase unitDatabase;
    const string URL = "https://docs.google.com/spreadsheets/d/1HppWWuqxDzBQGk3M8x2Bajp5fspRyXkc2_kq-GT_llk/edit?usp=sharing/export?format=tsv&range=A2:F";

    IEnumerator DownloadData()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        SetUnitDataBase(www.downloadHandler.text);
        
    }

    void SetUnitDataBase(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for(int j = 0; j < columnSize; j++)
            {
                UnitDB targetDB = unitDatabase.udb[i];
                targetDB.name = column[0];
                targetDB.AttackDamage = int.Parse(column[1]);
                targetDB.AttackSpeed = int.Parse(column[2]);
                targetDB.CriticalDamage = int.Parse(column[3]);
                targetDB.CriticalChance = int.Parse(column[4]);
            }
        }
    }
}
