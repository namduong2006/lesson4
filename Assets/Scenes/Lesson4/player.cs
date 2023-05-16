using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float Speed = 10f;
    public Vector3[] CheckPoint;
    int target;
    public float angle = -90f;
    public int Mode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mode ==1) 
        {
            MovePlayer();
        }
        else { MoveCom(); }
    }
    void MoveCom()
    {
        Vector3 targetPosition = CheckPoint[target];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            target++;
            transform.Rotate(Vector3.up, angle);
            if (target >= 4)
            {
                target = 0;
            }
        }
        
    }
    void MovePlayer()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        transform.position += v * transform.forward*Speed*Time.deltaTime;
        Vector3 vector3 = transform.eulerAngles;
        vector3.y += h * Speed * Time.deltaTime*4;
        transform.eulerAngles = vector3;
        
    }
    
}
