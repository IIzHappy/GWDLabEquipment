using UnityEngine;
using UnityEngine.SceneManagement;
public class GrabtoSceneChange : MonoBehaviour
{


    public string SceneToGoTo;



    public void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene(SceneToGoTo);


    }

}
