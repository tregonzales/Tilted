using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController: MonoBehaviour
{

    //game object to follow
    public GameObject target;

    //how much to offset on the y to follow the target
    public float offsetY;

    public float targetHeight;

    public float targetWidth;

    //lerp timer variable
    private float t = 0;

    //how long the lerp should last for one direction
    public float duration;

    //to see if we are in main menu
    public bool mainMenu;

    //first color to lerp from
    Color curColor;

    //next color to lerp to
    Color nextColor;

    Camera cam;

    // Use this for initialization
    void Start(){

        cam = GetComponent<Camera>();

        //scale screen to fit target aspect ratio
        
        float targetAspect = targetWidth/targetHeight;

        float screenAspect = (float)Screen.width / (float)Screen.height;

        Rect camRect = cam.rect;

        float scaleHeight = screenAspect / targetAspect;

        //if screen aspect is skinnier than ours (unlikely), scale their height down to fit our ratio and offset x to center 
        if (scaleHeight < 1.0f) {
            camRect.width = 1.0f;
            camRect.height = scaleHeight;
            camRect.x = 0;
            camRect.y = (1.0f - scaleHeight) / 2.0f;
        }
        //if screen aspect is wider than ours, scale their width down to fit our ration and offset x to center
        else {

            float scaleWidth = 1.0f / scaleHeight;

            camRect.height = 1.0f;
            camRect.width = scaleWidth;
            camRect.y = 0;
            camRect.x = (1.0f - scaleWidth) / 2.0f;
        }

        //set to new rect scaling
        cam.rect = camRect;

        //also scale the ui now
        GameManager.instance.scaleUI();

        //set first color to lerp from default color set by us
        curColor = cam.backgroundColor;
        


        //get the next color to lerp to
        nextColor = Random.ColorHSV(0, 1, .5f, 1, .5f, 1, 1, 1);


    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        if (!mainMenu) {
        //follow the sliding bar at an offset 
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offsetY, -10);
        }

        //t is a blending value to mix the colors
        //set it as a proportion of our duration to smoothly transition from one color to another
        t += Time.deltaTime/duration;
        cam.backgroundColor = Color.Lerp(curColor, nextColor, t);

        //lerp complete
        if (t >= 1) {
            //reset timer t
            t = 0;
            //set current color and the former next color bc that is now what the camera background is
            curColor = nextColor;
            //create a new color to lerp towards
            nextColor = Random.ColorHSV(0, 1, .5f, 1, .5f, 1, 1, 1);
        }
    }
}
