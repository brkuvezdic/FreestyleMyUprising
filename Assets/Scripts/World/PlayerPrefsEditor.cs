using UnityEngine;
using UnityEditor;

public class PlayerPrefsEditor : EditorWindow
{
    [MenuItem("Window/PlayerPrefs Editor")]
    public static void ShowWindow()
    {
        GetWindow<PlayerPrefsEditor>("PlayerPrefs Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("PlayerPrefs Keys and Values", EditorStyles.boldLabel);

        // CoinManager PlayerPrefs
        GUILayout.Label("CoinManager PlayerPrefs", EditorStyles.boldLabel);
        GUILayout.Label("CoinCount: " + PlayerPrefs.GetInt("CoinCount"));

        // PlayerStats PlayerPrefs
        GUILayout.Label("PlayerStats PlayerPrefs", EditorStyles.boldLabel);
        GUILayout.Label("MaxHealth: " + PlayerPrefs.GetInt("MaxHealth"));
        GUILayout.Label("CurrentHealth: " + PlayerPrefs.GetInt("CurrentHealth"));

        // ShopManagerScript PlayerPrefs
        GUILayout.Label("ShopManagerScript PlayerPrefs", EditorStyles.boldLabel);
        for (int i = 1; i < 5; i++)
        {
            GUILayout.Label("Item" + i + ": " + PlayerPrefs.GetInt("Item" + i));
        }
    }
}
