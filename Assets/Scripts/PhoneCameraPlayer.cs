using System.Collections;
using UnityEngine;

public class PhoneCameraPlayer : MonoBehaviour
{
    public GameObject background;
    private WebCamTexture cameraTexture;



    // Start is called before the first frame update
    IEnumerator Start() {
        if ( background.activeSelf == false ) {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            cameraTexture = new WebCamTexture();
            background.GetComponent<Renderer>().material.mainTexture = cameraTexture;
            cameraTexture.Play();
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
