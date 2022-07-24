using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MouseController : MonoBehaviour
{
    public RaycastHit2D? GetFocusOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }
        return null;
    }

    public void Update()
    {
        var focusTile = GetFocusOnTile();

        if (focusTile.HasValue)
        {
            GameObject overlayTile = focusTile.Value.collider.gameObject;
            transform.position = overlayTile.transform.position;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = overlayTile.GetComponent<SpriteRenderer>().sortingOrder;
        }

        if (Input.GetMouseButtonDown(0) && focusTile.HasValue)
        {

            var target = focusTile.Value.collider;

            if (target != GameManager.instance.overlayTile.GetComponent<Collider2D>())
                Attack(target);
        }
    }

    private void Attack(Collider2D target)
    {
        Debug.Log("it's " + target.name);
    }
}
