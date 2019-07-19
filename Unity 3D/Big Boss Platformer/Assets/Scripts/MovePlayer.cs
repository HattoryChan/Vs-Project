using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public Transform BigBoss;
    public SpriteRenderer BigBossSprite;
    
    [SerializeField]    
    private float speedNormal = 1f;    

    private void OnMouseDrag() {
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x = mousePos.x >= 3f ? 3f : mousePos.x;
        mousePos.x = mousePos.x < -3f ? -3f : mousePos.x;

        BigBossSprite.flipX = mousePos.x >= BigBoss.position.x;
        BigBoss.position = Vector2.MoveTowards(BigBoss.position, new Vector2(mousePos.x, BigBoss.position.y), speedNormal * Time.deltaTime);
    }

}
