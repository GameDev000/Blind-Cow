using UnityEngine;

public class Bourders : MonoBehaviour
{
    [SerializeField] public Transform FrontWall; //parmeters ofr bounderies
    [SerializeField] public Transform BackWall;
    [SerializeField] public Transform LeftWall; //parmeters ofr bounderies
    [SerializeField] public Transform RightWall;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] float padding = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxY = FrontWall.position.y - padding; //update values
        minY = BackWall.position.y + padding;
        maxX = RightWall.position.x - padding; //update values
        minX = LeftWall.position.x + padding;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mov = transform.position; //get the actual position
        mov.y = Mathf.Clamp(mov.y, minY, maxY); //lock the val
        mov.x = Mathf.Clamp(mov.x, minX, maxX); //lock the val
        transform.position = mov;//updating

    }
}
