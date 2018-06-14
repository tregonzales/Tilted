using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController: MonoBehaviour
{

    public GameObject target;

    public float offsetY;

    public float targetHeight;

    public float targetWidth;

    private float t = 0;

    public float duration;

    Color nextColor;

    Color curColor;

    Camera cam;

    // Use this for initialization
    void Start(){

        cam = GetComponent<Camera>();
        
        float targetAspect = targetWidth/targetHeight;

        float screenAspect = (float)Screen.width / (float)Screen.height;

        Rect camRect = cam.rect;

        float scaleHeight = screenAspect / targetAspect;

        if (scaleHeight < 1.0f) {
            camRect.width = 1.0f;
            camRect.height = scaleHeight;
            camRect.x = 0;
            camRect.y = (1.0f - scaleHeight) / 2.0f;
        }
        else {

            float scaleWidth = 1.0f / scaleHeight;

            camRect.height = 1.0f;
            camRect.width = scaleWidth;
            camRect.y = 0;
            camRect.x = (1.0f - scaleWidth) / 2.0f;
        }

        cam.rect = camRect;
        curColor = cam.backgroundColor;
        nextColor = Random.ColorHSV(0, 1, .5f, 1, .5f, 1, 1, 1);
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
       
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, -10);

        t += Time.deltaTime/duration;
        cam.backgroundColor = Color.Lerp(curColor, nextColor, t);

        if (t >= 1) {
            t = 0;
            //set current color and the former next color bc that is now what the camera background is
            curColor = nextColor;
            //create a new color to lerp towards
            nextColor = Random.ColorHSV(0, 1, .5f, 1, .5f, 1, 1, 1);
        }
    }

}
