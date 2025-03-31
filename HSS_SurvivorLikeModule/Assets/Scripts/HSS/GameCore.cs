using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace HSS
{
    public class GameCore : SingletonMono<GameCore>
    {
        // ----- Param -----

        public Player player;
        public Enemy enemyPrefab;
        public Projectile projectilePrefab;
        public Transform trEnemySpawnParent;

        [Header("Base Managers")]
        public List<BaseManager> managerList;

        public static ProjectileManager PROJECTILE { get { return Instance.Get<ProjectileManager>(); } }
        public static ResourceManager RSS { get { return Instance.Get<ResourceManager>(); } }

        private Dictionary<Type, BaseManager> dicManagers = new Dictionary<Type, BaseManager>();
        private Vector3 spawnPos = Vector3.zero;
        private Vector3 dirPos = Vector3.zero;

        [HideInInspector]
        public static bool isCoreReady = false;

        // ----- Init -----

        public T Get<T>() where T : BaseManager
        {
            var type = typeof(T);
            return dicManagers.ContainsKey(type) ? dicManagers[type] as T : null;
        }

        public IEnumerator Start()
        {
            // 기본 프로젝트 내부 설정 처리
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            Application.targetFrameRate = 60;
            Time.timeScale = 1f;

            yield return null;

            dicManagers.Clear();
            for (int i = 0; i < managerList.Count; i++)
            {
                yield return StartCoroutine(managerList[i].Co_Init());

                var type = managerList[i].GetType();
                dicManagers.Add(type, managerList[i]);
            }

            isCoreReady = true;
            yield return new WaitUntil(() => isCoreReady);

            ObjectPool.CreatePool(enemyPrefab, 20);
            ObjectPool.CreatePool(projectilePrefab, 20);
        }

        //public IEnumerator Start()
        //{
        //    // 기본 프로젝트 내부 설정 처리
        //    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        //    Application.targetFrameRate = 60;
        //    Time.timeScale = 1f;

        //    yield return null;

        //    dicManagers.Clear();
        //    for (int i = 0; i < managerList.Count; i++)
        //    {
        //        yield return StartCoroutine(managerList[i].Co_Init());

        //        var type = managerList[i].GetType();
        //        dicManagers.Add(type, managerList[i]);
        //    }


        //    isCoreReady = true;
        //    yield return new WaitUntil(() => isCoreReady);

        //    //for (int i = 0; i < managerList.Count; i++)
        //    //    managerList[i].Init();

        //    //UI.OpenUI(UIType.UIPopup_Common, Canvas_SortOrder.POPUP);
        //}

        //public async void Start()
        //{
        //    // 기본 프로젝트 내부 설정 처리
        //    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        //    Application.targetFrameRate = 60;
        //    Time.timeScale = 1f;

        //    dicManagers.Clear();
        //    for (int i = 0; i < managerList.Count; i++)
        //    {
        //        await managerList[i].Task_Init();

        //        var type = managerList[i].GetType();
        //        dicManagers.Add(type, managerList[i]);
        //    }

        //    isCoreReady = true;
        //    await UniTask.WaitUntil(() => isCoreReady);

        //    //for (int i = 0; i < managerList.Count; i++)
        //    //    managerList[i].Init();

        //    //    //UI.OpenUI(UIType.UIPopup_Common, Canvas_SortOrder.POPUP);
        //}

        // ----- Main -----

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dirPos = UnityEngine.Random.insideUnitCircle.normalized;
                spawnPos = player.transform.position + dirPos * StaticGameData.spawnDistance;
                Enemy enemy = enemyPrefab.Spawn(trEnemySpawnParent, spawnPos);
                enemy.Init(player.GetRigid(), 20f);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                player.AddWeapon(WeaponType.Bow);
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                player.AddWeapon(WeaponType.Knife, true);
            }
        }
    }
}
