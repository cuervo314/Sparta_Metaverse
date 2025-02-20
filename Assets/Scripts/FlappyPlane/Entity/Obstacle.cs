using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 1.5f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    MiniManager1 miniManager1;

    // Start is called before the first frame update
    void Start()
    {
        miniManager1 = MiniManager1.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize + 1f);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize - 1f);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MiniPlayer1 miniPlayer1 = collision.GetComponent<MiniPlayer1>();
        if (miniPlayer1 != null && miniPlayer1.isDead == false)
        {
            miniManager1.AddScore(1);
        }
    }
}
