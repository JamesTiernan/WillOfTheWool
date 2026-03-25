using System;
using UnityEngine;

[ExecuteInEditMode]
public class spotShadow : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject shadowSprite;
    [SerializeField] float shadowSize = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shadowSprite.transform.localScale = new Vector3(shadowSize * 1.3f,shadowSize,shadowSize);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        RaycastHit2D intersect = Physics2D.Raycast(transform.position, Vector2.down, 2.5f, layerMask);

        if (intersect.collider != null)
        {
            shadowSprite.transform.position = intersect.point;

            float alpha = 1f - (intersect.distance / 2.5f);
            shadowSprite.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

            shadowSprite.gameObject.SetActive(true);
        }
        else
        {
            shadowSprite.gameObject.SetActive(false);
        }
    }
}
