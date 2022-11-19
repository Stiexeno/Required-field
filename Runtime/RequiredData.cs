using UnityEditor;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class RequiredData : ScriptableObject
{
    private static RequiredData data;

    public bool showIcon = true;
    public bool showBorder = true;
    
    private const string LOCAL_PATH = "Assets/localdev";
    
    public static RequiredData Data
    {
        get
        {
            if (data == null)
            {
                if (data == null)
                {
                    if (AssetDatabase.IsValidFolder(LOCAL_PATH) == false)
                    {
                        AssetDatabase.CreateFolder("Assets", "localdev");
                        
                        RequiredData dataFile = CreateInstance<RequiredData>();
                        string path = $"{LOCAL_PATH}/RequiredData.asset";
                        AssetDatabase.CreateAsset(dataFile, path);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();

                        data = dataFile;
                        return data;
                    }
                    
                    data = (RequiredData)AssetDatabase.LoadAssetAtPath($"{LOCAL_PATH}/RequiredData.asset", typeof(RequiredData));
                }
            }

            return data;
        }
    }
}