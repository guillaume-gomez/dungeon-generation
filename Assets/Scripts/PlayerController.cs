using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  private float moveLimiter = 0.7f;

  private Rigidbody2D rb;
  private float horizontal;
  private float vertical;

  void Start()
  {
      rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    horizontal = Input.GetAxis("Horizontal");
    vertical = Input.GetAxis("Vertical");
  }

  void FixedUpdate()
  {
    if(horizontal != 0 && vertical != 0) {
      horizontal *= moveLimiter;
      vertical *= moveLimiter;
    }
    rb.velocity = new Vector2(horizontal * speed, vertical * speed);
  }
}
