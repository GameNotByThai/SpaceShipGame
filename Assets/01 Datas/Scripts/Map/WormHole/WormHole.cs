using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : GameMonoBehaviour
{
    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
        Debug.Log("Galaxy Demo: OnMouseDown");
    }

    private void LoadGalaxy()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}
