using HSS;
using UnityEngine;

public class ObjectReposition : MonoBehaviour
{
    // ----- Param -----

    private Player player;
    private Collider2D coll;

    // ----- Init -----

    private void Start()
    {
        player = GameCore.Instance.player;
        coll = GetComponent<Collider2D>();
    }

    // ----- Set -----

    // ----- Get -----

    // ----- Main -----

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector2 playerPos = player.transform.position;
        Vector2 myPos = transform.position;
        
        float offsetX = Mathf.Abs(playerPos.x - myPos.x);
        float offsetY = Mathf.Abs(playerPos.y - myPos.y);

        //가만히 있으면 방향을 못찾는듯?
        Vector2 playerDir = player.GetInputVector2();

        // 왼쪽 오른쪽 
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (offsetX > offsetY)
                    transform.Translate(Vector2.right * dirX * StaticGameData.mapMaxWidth);
                else
                    transform.Translate(Vector2.up * dirY * StaticGameData.mapMaxWidth);
                break;

            case "Enemy":
                if (coll.enabled)
                    transform.Translate(playerDir * 20 + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                break;
        }
    }

}