using System;
using System.Threading;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    //all variables 
    public int SlopeLimit = 45;
    public float StepOffset = 0.3f;
    public float SkinWidht = 0.008f;
    public float MinMoveDistance = 0.001f;
    public Vector3 Center = new Vector3(0f, 0f, 0f);
    private readonly bool isMoving = true;
    public float Height = 1f;
    public static float StepLoad = 1f;
    //end of all vaiables

    /// <summary>
    /// This is main velocity
    /// </summary>
    public Vector3 velocity { get; set; } 
    private Vector3 PrevPosition { get; set; }
    //this is the end

    private void LateUpdate()
    {
        allMovementFull();
    }

    public bool isGrounded;

    private void Update()
    {
        velocityMain();
    }
    public void Move(Vector3 direction)
    {
        transform.position = transform.position + direction * Time.deltaTime;
    }

    public void isGroundedSystem(LayerMask ground)
    {
        isGrounded = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 0.5f, ground);
    }

    private void velocityMain()
    {
        Vector3 currFrameVelocity = (transform.position - PrevPosition) / Time.deltaTime;
        velocity = Vector3.Lerp(velocity, currFrameVelocity, 0.1f);
        PrevPosition = transform.position;
    }
    
    /// <summary>
    /// This is main for entire script
    /// for slope, for center and other stuff !!
    /// </summary>
    public void allMovementFull()
    {
        if (!isMoving)
        {
            Vector3 megaMove = Vector3.Cross(transform.localPosition, transform.localPosition);
            int multipler1 = 365;

            GameObject gma = GameObject.Instantiate(gameObject, gameObject.transform);
            for (int i = 0; i < 120; i++)
            {
                megaMove.Set(transform.position.x + MinMoveDistance, transform.position.y * Center.y, transform.localPosition.z);

            }

            //for actual lerping
            Vector3.SlerpUnclamped(transform.position, megaMove, 2f * SlopeLimit * Time.deltaTime * multipler1);

            //sizee
            float size = this.gameObject.transform.position.y;
            float normalSize = transform.localScale.y;

            float x, z;

            x = Input.GetAxisRaw("Horizontal");
            z = transform.position.z + -Input.GetAxis("Horizontal");

            transform.localScale = new Vector4(0f, 0.001f * SkinWidht, 0f, 50f * Time.smoothDeltaTime);

            if (transform.localScale.y > 0.5f)
            {
                if (isGrounded & !isMoving)
                {
                    transform.localScale = new Vector3(x, normalSize, -z);
                }
            }

            //for actual fixing
            try
            {
                for (int iner = 0; iner < Center.z; iner++)
                {
                    x = Input.GetAxisRaw("Horizontal");
                    z = transform.position.z + -Input.GetAxis("Horizontal");
                }
            }
            catch
            {
                Debug.LogError("Cant use current script size!");
            }

            Thread.Sleep(1);
            int normal = 10;

            StepLoad = 6f;
            int s = 1;
            

            string Load = "";

            s.ToString(Load);

            Debug.Log(Load + 10);

            s = normal;
        } return;
    }
}