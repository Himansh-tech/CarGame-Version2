using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //variable which will show up in editor and help us set the spped of vehicle
    //just make the variable public to make it visible in editor
    public float Speed = 5.0f;

    //for turning
    public float turnSpeed;

    public float horizontalInput;

    public float boost = 2f;

    public float verticalInput;

    private float originalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //as the name says INPUT it takes input from keyboard(and as defined in edit->project setting-> axis Horizontal is taken bu A and D keys )
        //so it takes the input and according to what we press further it will move 
        horizontalInput = Input.GetAxis("Horizontal");


        verticalInput = Input.GetAxis("Vertical");

        //we will make vehicle move here
        //so we want our vehicle to move along the road and when we just tried it in scene view we noticed only we have to change z-axis value
        //so we have to change transform component of that gameObject along y-axis.

        //transform.Translate(0, 0, 1); //transform is component of vehicle, Translate() is built in function

        //vector3 = (0,0,0) it just represnt three points in 3 Dimension

        //transform.Translate(Vector3.forward); //forward = (0,0,1)

        //here spped is depending on frame, that is update method is called every single frame and it thus spped of vehicle depends on many frames per second your PC is capable of. like some will have 20 frames per second while other will have 60 frames per second
        //we have to change this to time dependent like moving some unit of distance in 1 second

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * Speed); //it is actually multiplying by vector3 coordinate values that is along z axis 1*25 therfore in one second move 25units and 1 second is taken care by Time class

        //for turning
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //above method of turning is bad because it does not act like real vehicle but simply slips vehicle horizontally on road
        //so we have to change it and rotate it

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        //here Vector3.up is direction and Time.deltaTime*turnSpeed*horizontalInput is angle for making the turn



        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = originalSpeed * boost;
        }
        else 
        {
            Speed = originalSpeed;
        }

    }
}
