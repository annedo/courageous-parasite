using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class SceneNavigation : MonoBehaviour
{    
    public string SceneToTravelTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("setscene")]
    public void SetScene(string SceneToTravelTo)
    {
        SceneManager.LoadScene(SceneToTravelTo);
    }    

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneToTravelTo);
    }
}
