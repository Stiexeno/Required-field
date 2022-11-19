using UnityEditor;
using UnityEngine;
using SF = UnityEngine.SerializeField;

public class RequiredData : ScriptableObject
{
    public enum IconType { Error, Warning, Info }

    private static RequiredData data;

    public bool showIcon = true;
    public bool showBorder = true;
    public IconType iconType = IconType.Error;
    public Color borderColor = Color.red;

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

                    data = (RequiredData) AssetDatabase.LoadAssetAtPath($"{LOCAL_PATH}/RequiredData.asset",
                        typeof(RequiredData));
                }
            }

            return data;
        }
    }

    public string GetIconType()
    {
        return iconType switch
        {
            IconType.Error => "d_console.erroricon",
            IconType.Warning => "d_console.warnicon",
            IconType.Info => "d_console.infoicon",
            _ => ""
        };
    }
}