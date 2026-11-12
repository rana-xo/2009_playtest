using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IObjectInteract{
    public void Interact();
}

public class PickUpObject : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IObjectInteract inteObj))
                {
                    inteObj.Interact();
                }
            }
        }
    }


}

/*    //Los objetos se agarran, rotan y sueltan.
{
    public GameObject player;
    public Transform holdPos;
    public float throwForce = 5f; 
    public float pickUpRange = 5f; 
    private float rotationSensitivity = 1f; 
    private GameObject heldObj;
    private Rigidbody heldObjRb; 
    private bool canDrop = true; 
    private int LayerNumber; 

    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (heldObj == null) 
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.gameObject.TryGetComponent(out IObjectInteract pickUpObj))
                    {
                        ObjectPickUp(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if (canDrop == true)
                {
                    StopClipping(); 
                    DropObject();
                }
            }
        }
        if (heldObj != null) 
        {
            MoveObject(); 
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Q) && canDrop == true) 
            {
                StopClipping();
                ThrowObject();
            }

        }
    }
    public void ObjectPickUp(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            //make sure object doesnt collide with player, it can cause weird bugs
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
    void DropObject()
    {
        //re-enable collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
    }
    void MoveObject()
    {
        //keep object position the same as the holdPosition position
        heldObj.transform.position = holdPos.transform.position;
    }
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R)) //hold R key to rotate
        {
            canDrop = false; 

            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
            canDrop = true;
        }
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object before undefining it
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the cliprange
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }
}*/
