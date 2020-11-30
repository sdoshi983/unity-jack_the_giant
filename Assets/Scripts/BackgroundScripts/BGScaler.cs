using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        // sprites' height and width
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        // camera's height and width;
        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        tempScale.x = worldWidth / width;
        tempScale.y = worldHeight / height;
        transform.localScale = tempScale;
    }
}
