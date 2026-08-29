using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float range = 100f;   // 射程距離

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        GameManager gm = FindAnyObjectByType<GameManager>();
        if (gm != null && (!gm.isStarted || gm.isGameOver || gm.isPaused)) return;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 画面中央から前方にレイを飛ばす
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            // 当たったものがTargetHitを持っていれば命中処理
            TargetHit target = hit.collider.GetComponent<TargetHit>();
            if (target != null)
            {
                target.Hit();
            }
        }
    }
}
