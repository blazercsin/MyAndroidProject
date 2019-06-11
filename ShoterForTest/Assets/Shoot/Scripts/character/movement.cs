using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{

    public float gravity, speed, rotationSpeed;
    CharacterController chcontroller;
    public Vector3 lookDirection;
    public AnimControl ac;
    public bool isMove;
    public TouchStick ts;
    public bool shooting;
    public ClosestTarget ct;
    public bool pc;
    public GameObject MainCam;
    public ShootStick ss;
    // Use this for initialization
    void Start()
    {
        chcontroller = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;
        Vector3 rotation = Vector3.zero;
        move.y -= gravity;
        if (!pc)
        {
            move.z += (ts.vertical * 2) * speed;
            move.x += (ts.horizontal * 2) * speed;
        }
        else
        {
            move.z += Input.GetAxis("Vertical") * (speed/2);
            move.x += Input.GetAxis("Horizontal") * (speed/2);
        }
        
        move *= Time.deltaTime;
        if (!shooting)
        {
            if (!ss.ONDown)
            {
                lookDirection = move + transform.position;
                transform.LookAt(new Vector3(lookDirection.x, transform.position.y, lookDirection.z));
            }
            else
            {
                
                transform.LookAt(new Vector3(ss.horizontal*2+transform.position.x, transform.position.y, ss.vertical*2+transform.position.z));
            }
        
        }
        else
        {
            if (!ss.ONDown)
            {
                if (ct.closestTarget != null)
                {
                    float dist = Vector3.Distance(transform.position, ct.closestTarget.transform.position);

                    if (dist > 8)
                    {
                        shooting = false;
                        ct.closestTarget.GetComponent<TargetMark>().InTarget = false;
                        MainCam.GetComponent<HPUI>().target = null;
                    }
                    else
                    {
                        transform.LookAt(new Vector3(ct.closestTarget.transform.position.x, transform.position.y, ct.closestTarget.transform.position.z));
                    }
                }
                else
                {
                    shooting = false;
                }
            }
            else
            {
                shooting = false;
            }
        }
        chcontroller.Move(move);
        if (move != Vector3.zero)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        ac.Move(isMove);
    }
}