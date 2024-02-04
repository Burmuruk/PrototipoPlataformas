using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCells : MonoBehaviour
{
    [SerializeField] private float velocityM;

    private Vector2 pointM;

    [SerializeField] private Vector2 offsetPointM;
    [SerializeField] private LayerMask obstacles;
    [SerializeField] private float circleRadius;
    private bool movement = false;
    private Vector2 input;



    void Start()
    {
        pointM = transform.position;
    }


    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (movement) 
        {
            transform.position = Vector2.MoveTowards(transform.position, pointM, velocityM * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, pointM) == 0)
            {
                movement = false;
            }
        }

        if((input.x !=0 ||  input.y !=0) && !movement) 
        {
            Vector2 evaluate = new Vector2(transform.position.x, transform.position.y) + offsetPointM + input;

            if(!Physics2D.OverlapCircle(evaluate, circleRadius, obstacles))
            {
                movement = true;
                pointM += input;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointM + offsetPointM, circleRadius);
    }
}
