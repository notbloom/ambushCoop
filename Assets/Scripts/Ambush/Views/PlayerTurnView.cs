using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public class PlayerTurnView : MonoBehaviour
    {
        public static PlayerTurnView instance;
        public AreaView areaView;
        public List<Color> tileColors;
        //private Board board;

        //public static Map MainMap => instance.board.map;


        [Header("Actions")]
        [SerializeField] private Transform actionParentTransform;
        [SerializeField] private GameObject actionViewPrefab;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void Load(PlayerBehaviour playerBehaviour)
        {
            // REGISTER ON UI
            areaView.playerBehaviour = playerBehaviour;

            //TODO use a pool or delete old Actions UI
            CreateActionUI(playerBehaviour, playerBehaviour.actions);
        }

        private void CreateActionUI(PlayerBehaviour playerBehaviour,  List<IActionController> actionControllers) {
            foreach (var actionController in actionControllers)
            {
                GameObject go = Instantiate(actionViewPrefab, Vector3.zero, Quaternion.identity);
                go.transform.parent = actionParentTransform;

                ActionView actionView = go.GetComponent<ActionView>();
                actionView.Populate(playerBehaviour, actionController);
                
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
      
    }

}


