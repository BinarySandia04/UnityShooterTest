using UnityEngine;
using System;

public class UserAccountDataTranslator : MonoBehaviour {

	public static int GetTranslatedData(string data, string tag)
    {
        string[] values = data.Split('/');
        foreach(string piece in values)
        {
            if (piece.StartsWith(tag))
            {
                return int.Parse(piece.Substring(tag.Length));
            }
        }

        Debug.LogError("No se ha encontrado " + tag + " en " + data);
        return -1;
    }

}
