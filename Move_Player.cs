using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour
{

    public float playerspeed = 100f;
    private Vector2 hMovement = new Vector2(0f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMovement = new Vector2(Input.GetAxisRaw("Horizontal"), 0); 
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity =
            hMovement * playerspeed * Time.fixedDeltaTime;
    }
}
