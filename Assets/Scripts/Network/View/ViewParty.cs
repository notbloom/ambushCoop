//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ViewParty : MonoBehaviour
//{
//    public AmbushNetworkManager networkManager;
//    public GameObject viewPrefab;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }
//    public void OnEnable()
//    {
//        networkManager.OnPlayerListUpdated += Populate;
//        Populate();
//    }
//    public void OnDisable()
//    {
//        networkManager.OnPlayerListUpdated -= Populate;
//    }
//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    public void Populate() {
//        foreach (PlayerClient playerClient in networkManager.playerClients) {
//            GameObject go = Instantiate(viewPrefab, Vector3.zero, Quaternion.identity);
//            go.GetComponent<PlayerPortraitView>().Populate(playerClient.player_name, playerClient.avatar);
//            go.transform.parent = transform;
//        }
//    }
//}
