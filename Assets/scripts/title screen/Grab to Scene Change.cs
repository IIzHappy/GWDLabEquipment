using UnityEngine;
using UnityEngine.SceneManagement;
public class GrabtoSceneChange : MonoBehaviour
{


    public string SceneToGoTo;


    //input some kind of way to tell if the player grabbed this thing
    /**
     * 
     * if (grabbed)
     * {
     * 
     *      ChangeScene();
     * 
     * }
     * 
     * 
     * */


    public void ChangeScene() {

        SceneManager.LoadScene(SceneToGoTo);



    }

}
