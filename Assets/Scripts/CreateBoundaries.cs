using UnityEngine;

public class CreateBoundaries : MonoBehaviour
{
    public GameObject objBoundaryTopRightCorner;
    public GameObject objBoundaryBottomLeftCorner;

    void Start()
    {
        SetupBoundaries();
    }

    void Update()
    {

    }

    public void SetupBoundaries()
    {
        // Setting top right border.
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        objBoundaryTopRightCorner.transform.position = new Vector3(topRight.x, topRight.y, 0);

        // Setting bottom left border.
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        objBoundaryBottomLeftCorner.transform.position = new Vector3(bottomLeft.x, bottomLeft.y, 0);
    }
}
