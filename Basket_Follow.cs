using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_Follow : MonoBehaviour
{

    public Transform BasketFront;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = BasketFront.position.x;
        float y = BasketFront.position.y;
        transform.position = new Vector2(x, y);
    }
}
