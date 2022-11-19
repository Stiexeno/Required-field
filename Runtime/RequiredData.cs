using UnityEditor;
using UnityEngine;
using SF = UnityEngine.SerializeField;

[CreateAssetMenu(menuName = "CustomEditor/RequiredData", fileName = "RequiredData")]
public class RequiredData : ScriptableObject
{
    private static RequiredData data;

    public bool showIcon;
    public bool showBorder;
    
    public static RequiredData Data
    {
        get
        {
            if (data == null)
                data = (RequiredData)AssetDatabase.LoadAssetAtPath("Assets/RequiredAttribute/Data/RequiredData.asset", typeof(RequiredData));

            return data;
        }
    }
}