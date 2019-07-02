using UnityEngine;
using UnityEditor;

public class NewEditorScript : ScriptableObject
{

    [MenuItem("MyGame/Database/Reload")]
    private static void ReloadDatabase()
    {
        s_instance = null;
        Debug.Log("Database was resetted");
    }

    [MenuItem("MyGame/Database/Delete")]
    private static void DeleteDatabase()
    {

    }

    private static NewEditorScript s_instance;
    public static NewEditorScript Instance
    {
        get
        {
            if(s_instance == null)
            {

            }

            return s_instance;
        }
    }

}
