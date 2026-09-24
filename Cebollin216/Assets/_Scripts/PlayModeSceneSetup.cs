using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class StartupSceneLoader
{
    static StartupSceneLoader()
    {
        EditorApplication.delayCall += OpenStartupScene;
    }

    private static void OpenStartupScene()
    {
        string scenePath = "Assets/Scenes/Sandbox.Unity";

        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(scenePath);
        }
    }
}

//Alternatively Open the Scene in Unity, then Save Project, Close Unity,
// //the next Unity is Open the 