using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private bool isOnGround;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) this.isOnGround = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) this.isOnGround = false;
    }

    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (PressingForward())
        {
            this.rigidbody.AddForce(Vector3.forward * 10);
        }
        else if (PressingBackwards())
        {
            this.rigidbody.AddForce(Vector3.back * 10);
        }

        if (PressingLeft())
        {
            this.rigidbody.AddForce(Vector3.left * 10);
        }
        else if (PressingRight())
        {
            this.rigidbody.AddForce(Vector3.right * 10);
        }

        if (PressingSpace() && this.isOnGround)
        {
            this.rigidbody.AddForce(Vector3.up * 100);
        }
    }

    bool PressingForward() => Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
    bool PressingBackwards() => Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    bool PressingLeft() => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    bool PressingRight() => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
    bool PressingSpace() => Input.GetKey(KeyCode.Space);
}
