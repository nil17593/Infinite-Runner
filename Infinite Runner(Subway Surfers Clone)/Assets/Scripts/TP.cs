using System.Collections;
using UnityEngine;

namespace IMPLIEDSOULS.InfiniteRunner
{
    public class TP : MonoBehaviour
    {

        //public enum ActiveSide { Left,Mid,Right,}

        //[SerializeField] private ActiveSide side = ActiveSide.Mid;
        //private Rigidbody rigidbody;
        //[SerializeField] private float speed;
        ////[SerializeField] private Transform transform;
        //private float newXPos = 0f;
        //private bool leftSwipe;
        //private bool rightSwipe;
        //[SerializeField] private float valueOnXaxis;
        ////private CharacterController characterController;

        //private void Start()
        //{
        //    //characterController = GetComponent<CharacterController>();
        //    rigidbody = GetComponent<Rigidbody>();
        //    //transform.position = new Vector3(0f,3f,15f);
        //}

        //private void FixedUpdate()
        //{
        //    rigidbody.AddForce(Vector3.forward * speed);
        //}

        //private void Update()
        //{
        //    //transform.Translate(Vector3.forward*speed* Time.deltaTime);
        //    leftSwipe = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        //    rightSwipe = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        //    Movement();
        //    //rigidbody.AddForce(0f,0f,speed);
        //}


        //void Movement()
        //{
        //    if (leftSwipe)
        //    {
        //        Debug.Log("leftswipe");
        //        if (side == ActiveSide.Mid)
        //        {
        //            newXPos = -valueOnXaxis;
        //            side = ActiveSide.Left;
        //        }else if (side == ActiveSide.Right)
        //        {
        //            newXPos = 0f;
        //            side = ActiveSide.Mid;
        //        }
        //    }

        //    if (rightSwipe)
        //    {
        //        Debug.Log(rightSwipe);
        //        if (side == ActiveSide.Mid)
        //        {
        //            newXPos = valueOnXaxis;
        //            side = ActiveSide.Right;
        //        }
        //        else if (side == ActiveSide.Left)
        //        {
        //            newXPos = 0f;
        //            side = ActiveSide.Mid;
        //        }
        //    }

        //    //rigidbody.MovePosition((newXPos-transform.position.x)*Vector3.right);
        //    //if (Input.GetKeyDown(KeyCode.RightArrow))
        //    //{
        //    //    transform.Translate(Vector3.right);
        //    //}


        //}


        [SerializeField] private Rigidbody rb;
        [SerializeField] private float xAxisForce, yAxisForce, downyAxis;
        [SerializeField] private float speed;
        Vector3 forwardMove;
        //[SerializeField] GameObject gameOver;
        bool leftKey, rightKey;


        private void Update()
        {
            leftKey = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            rightKey = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        }
        void FixedUpdate()
        {
            forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMove);
            //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            //Movement();
            Jump();
        }
        //void Movement()
        //{
        //    if (rightKey)
        //    {
        //        //rb.AddForce(xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //        if (side == ActiveSide.Mid)
        //        {
        //            newXPos = -valueOnXaxis;
        //            side = ActiveSide.Left;
        //        }
        //        else if (side == ActiveSide.Right)
        //        {
        //            newXPos = 0f;
        //            side = ActiveSide.Mid;
        //        }
        //    }

        //    else if (leftKey)
        //    {
        //        //rb.AddForce(-xAxisForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //        if (side == ActiveSide.Mid)
        //        {
        //            newXPos = valueOnXaxis;
        //            side = ActiveSide.Right;
        //        }
        //        else if (side == ActiveSide.Left)
        //        {
        //            newXPos = 0f;
        //            side = ActiveSide.Mid;
        //        }
        //    }
        //    //else if (rb.position.y < -1)
        //    //{
        //    //  gameOver.SetActive(true);
        //    //}
        //}

        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, yAxisForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(0, downyAxis * Time.deltaTime, 0, ForceMode.Impulse);
            }
        }

    }
}