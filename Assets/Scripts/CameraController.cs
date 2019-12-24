using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Primitives to add
    public GameObject cube;
    public GameObject sphere;
    public GameObject pyramid;

    public GameObject cameraBackground;

    private Vector3 accelerator = Vector3.zero;
    // Main object parameters
    private GameObject mainObject;
    private string objectType = "";
    private Color objectColor = Color.red;
    private Transform objectTransformData;

    // Flags
    private bool isObjectInit = false;
    private bool isQRcodeScanned = false;



    void InitObject() {
        // This part can be improved by adding figure library
        switch ( objectType ) {
            case "1A":
                mainObject = cube; // GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case "2A":
                mainObject = sphere; // GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case "3A":
                mainObject = pyramid; // ???
                break;
        }

        // Change object color 
        mainObject.GetComponent<SpriteRenderer>().material.color = objectColor;
        // Change object position
        mainObject.transform.position = objectTransformData.position;
        // Change object rotation
        mainObject.transform.rotation = objectTransformData.rotation;
    }

    //Need asset for this function
    void TryToScanQRCode() {
        // When scanning is successfull
        //isQRCodeScanned = true
    }

    // Maybe should look for some asset for this function
    void CalculationOfObjectParameters() {
        // Init object color
        // Init object position
        // Init object rotation
    }

    void MoveCamera() {
        // Using accelerator data to change camera position
        accelerator = new Vector3( Input.acceleration.x, Input.acceleration.y, Input.acceleration.z );
        if ( accelerator.sqrMagnitude > 1 ) accelerator.Normalize();
        transform.Translate(accelerator);
    }



    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    // Consider using FixedUpdate() for greater program stability
    // Update() is done every frame
    // FixedUpdate() is done at regular intervals
    void Update() {
        if ( isQRcodeScanned ) {
            if ( isObjectInit ){
                MoveCamera();
            } else {
                InitObject();
                cameraBackground.SetActive(false);
                isObjectInit = true;
            }
        } else {
            TryToScanQRCode();
            if ( isQRcodeScanned ) CalculationOfObjectParameters();
        }
    }
}
