using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject target;
    public int maxZ = 10;
    Ray ray;
    RaycastHit rayHit;
    Vector3 Pos;
    [SerializeField] public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        target = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out rayHit, 30f, ~layermask))
        { transform.position = rayHit.point; }
        else
        {
            Vector3 p = Input.mousePosition;
            p.z = maxZ;
            Pos = Camera.main.ScreenToWorldPoint(p);
            transform.position = Pos;
            Debug.Log(Pos);
        }

    }
}
