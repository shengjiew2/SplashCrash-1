using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.1f;
    public Vector3 offsetFromTarget = new Vector3(0, 3, -4);

    public float xTilt = 10; // How far I want my camera on the x-axis, look downward at our target.(3 person perspective)

    Vector3 destination = Vector3.zero;
    CharacterController charController;
    float rotateVel = 0;

	// Use this for initialization
	void Start () {
        SetCemaraTarget(target);
	}
	void SetCemaraTarget(Transform t)
    {
        target = t;
        
        if (target != null)
        {
            if (target.GetComponentInChildren<CharacterController>())
            {
                charController = target.GetComponentInChildren<CharacterController>();
            }
            else
                Debug.LogError("Char need a Char Controller");
        }
        else
            Debug.LogError("Sorry, There is No target for camera.");
    }
	// Update is called once per frame
    //This updata later basic on character's update
	void LateUpdate () {
        //Moving
        MoveToTarget();

        //Rotating
        LookAtTarget();
	}
    void MoveToTarget()
    {
        destination = charController.TargetRotation * offsetFromTarget;
        destination += target.position;
        transform.position = destination;
    }
    void LookAtTarget()
    {
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }

}
