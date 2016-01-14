using UnityEngine;
using System.Collections;

public class PlayerBehaiviouc : MonoBehaviour {
    public MoveSettings moveSettings;
    public InputSettings inputSettings;
    public Transform spawnPoint;
    private Rigidbody player1Rigidbody, player2Rigidbody;
    private Vector3 p1velocity, p2velocity;
    private float p1SidewaysInput, p2SidewaysInput, p1JumpInput, p2JumpInput;
    public LayerMask Layers;

    private void Awake()
    {
        player1Rigidbody = GameObject.FindGameObjectWithTag("Owl").GetComponent<Rigidbody>();
        player2Rigidbody = GameObject.FindGameObjectWithTag("Lemur").GetComponent<Rigidbody>();
        p1velocity = Vector3.zero;
        p1SidewaysInput = p1JumpInput = 0;
        p2velocity = Vector3.zero;
        p2SidewaysInput = p2JumpInput = 0;
    }

    void GetPlayer1Input()
    {
        p1SidewaysInput = Input.GetAxis(inputSettings.PLAYER1_SIDEWAYS_AXIS);
        p1JumpInput = Input.GetAxisRaw(inputSettings.PLAYER1_JUMP_AXIS);
    }
    void GetPlayer2Input()
    {
        p2SidewaysInput = Input.GetAxis(inputSettings.PLAYER2_SIDEWAYS_AXIS);
        p2JumpInput = Input.GetAxisRaw(inputSettings.PLAYER2_JUMP_AXIS);
    }

    void Run()
    {
        p1velocity = new Vector2(p1SidewaysInput * moveSettings.RunVelocity, player1Rigidbody.velocity.y);
        p2velocity = new Vector2(p2SidewaysInput * moveSettings.RunVelocity, player2Rigidbody.velocity.y);
        player1Rigidbody.velocity = transform.TransformDirection(p1velocity);
        player2Rigidbody.velocity = transform.TransformDirection(p2velocity);
    }

    void Jump()
    {
        if (p1JumpInput != 0 && OwlPlayer())
        {
            player1Rigidbody.velocity = new Vector2(player1Rigidbody.velocity.x, moveSettings.JumpVelocity);
        }
        if (p2JumpInput != 0 && LemurGrounded())
        {
            player2Rigidbody.velocity = new Vector2(player2Rigidbody.velocity.x, moveSettings.JumpVelocity);
        }
    }

    bool LemurGrounded()
    {

        return Physics.Raycast(GameObject.FindGameObjectWithTag("ShadowPlayer").transform.position, Vector3.down, moveSettings.DistanceToGround, moveSettings.Ground);
    }

    bool OwlPlayer()
    {

        return Physics.Raycast(GameObject.FindGameObjectWithTag("LightPlayer").transform.position, Vector3.down, moveSettings.DistanceToGround, moveSettings.Ground);
    }

    public void Spawn()
    {
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update () {
        GetPlayer1Input();
        GetPlayer2Input();
        Run();
        Jump();
    }


}

[System.Serializable]
public class MoveSettings
{
    public float RunVelocity = 12;
    public float JumpVelocity = 8;
    public float DistanceToGround = 1.3f;
    public LayerMask Ground;
}

[System.Serializable]
public class InputSettings
{
    public string PLAYER1_SIDEWAYS_AXIS = "Player1Horizontal";
    public string PLAYER1_JUMP_AXIS = "Player1Jump";
    public string PLAYER1_FLY_AXIS = "Player1Fly";
    public string PLAYER2_SIDEWAYS_AXIS = "Player2Horizontal";
    public string PLAYER2_JUMP_AXIS = "Player2Jump";
    public string PLAYER2_CROUCH_AXIS = "Player2Crouch";
}