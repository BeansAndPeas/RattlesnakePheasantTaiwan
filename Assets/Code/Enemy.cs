using UnityEngine;

// https://github.com/louisgjohnson/unity3d-a-star-pathfinding
public class Enemy : MonoBehaviour
{
    private Rigidbody rigidbody;
    private readonly AStarPathfinding pathfinding = new AStarPathfinding();

    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }
}