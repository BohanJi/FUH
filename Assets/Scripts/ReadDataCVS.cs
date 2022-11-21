using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadDataCVS : MonoBehaviour
{
    string datosString;

    public string dataPathAssets;
    public string DialogueDataName = "/Dialogos.csv";
    //private string persistentDataPath;

    [Space]
    public string header;
    public string[] lines;
    public List<DialogueLine> dialogueList = new();

    public List<DialoguePair> activeDialogues = new();

    void Awake()
    {
        DontDestroyOnLoad(this);
        ReadFileData();
        ExtractData();
        InitDialogues();
    }

    [ContextMenu("Read File")]
    void ReadFileData()
    {
        dataPathAssets = Application.dataPath;
        //persistentDataPath = Application.persistentDataPath;
        datosString = "";

        StreamReader sr = new(path: dataPathAssets + DialogueDataName);
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            datosString += line + "\n";
        }
    }

    [ContextMenu("Extract Data")]
    void ExtractData()
    {
        lines = datosString.Split('\n');
        header = lines[0];

        dialogueList.Clear();

        for (int i = 1; i < lines.Length - 1; i++)
        {
            string[] splittedLine = lines[i].Split(';');

            if (splittedLine.Length == header.Split(';').Length)
            {
                dialogueList.Add(new DialogueLine()
                {
                    title = splittedLine[0],
                    dialogueNumber = int.Parse(splittedLine[1]),
                    lineNumber = int.Parse(splittedLine[2]),
                    receptor = splittedLine[3],
                    role = splittedLine[4],
                    text = splittedLine[5]
                });
            }
        }
    }

    public List<DialogueLine> GetDialogueLines() 
    {
        return dialogueList;
    }

    void InitDialogues()
    {
        List<DialogueLine> dialogueLines;
        dialogueLines = GetDialogueLines();
        foreach (DialogueLine line in dialogueLines)
        {
            if (!CompruebaSiYaExiste(line))
            {
                activeDialogues.Add(new DialoguePair()
                {
                    receptor = line.receptor,
                    dialogueNumber = 0
                });
            }
        }
    }

    bool CompruebaSiYaExiste(DialogueLine line)
    {
        foreach (DialoguePair dp in activeDialogues)
        {
            if (dp.receptor == line.receptor)
            { return true; }
        }
        return false;
    }

    public List<DialoguePair> GetActiveDialogeLine()
    {
        return activeDialogues;
    }
}

public struct DialogueLine
{
    public string title;
    public int dialogueNumber;
    public int lineNumber;
    public string receptor;
    public string role;
    public string text;
}

public struct DialoguePair
{
    public string receptor;
    public int dialogueNumber;
}