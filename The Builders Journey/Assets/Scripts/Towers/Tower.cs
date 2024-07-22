using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3f;
    public float fireRate;
    public LayerMask whatIsEnemy;

    private Collider[] colliderInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    public float checkTime = .2f;

    [HideInInspector]
    public bool enemiesUpdated;

    public GameObject PlacementModel;
    public GameObject SelectedModel; // Zweites Range Model

    public int cost = 100;

    public int isTower = 0;
    /* Tower Index:
     * 0 = Canon Tower default
     * 1 = Bomb Tower
     * 2 = Slow Tower
     * 3 = Triple Shot Tower
     */

    [HideInInspector]
    public TowerUpgradeController upgrader;

    // Start is called before the first frame update
    void Start()
    {
        checkCounter = checkTime;

        upgrader = GetComponent<TowerUpgradeController>();
        SelectedModel.SetActive(false); // Zweites Range Model ausblenden
    }

    // Update is called einmal pro frame
    void Update()
    {
        enemiesUpdated = false;

        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            colliderInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            enemiesInRange.Clear();
            foreach (Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            enemiesUpdated = true;
        }

        if (TowerManager.instance.selectedTower == this)
        {
            PlacementModel.SetActive(false);
            SelectedModel.SetActive(true); // Zweites Range Model anzeigen
            PlacementModel.transform.localScale = new Vector3(range, 1f, range);
            SelectedModel.transform.localScale = new Vector3(range, 1f, range);
        }
        else
        {
            PlacementModel.SetActive(false);
            SelectedModel.SetActive(false); // Zweites Range Model ausblenden
        }
    }

    private void OnMouseDown()
    {
        if (LevelManager.instance.levelActive)
        {
            if (TowerManager.instance.selectedTower != null)
            {
                TowerManager.instance.selectedTower.PlacementModel.SetActive(false);
                TowerManager.instance.selectedTower.SelectedModel.SetActive(false); // Zweites Range Model des vorherigen Turms ausblenden
            }

            TowerManager.instance.selectedTower = this;

            UIController.instance.OpenTowerUpgradePanel();

            TowerManager.instance.MoveTowerSelectionEffect();
        }
    }
}
