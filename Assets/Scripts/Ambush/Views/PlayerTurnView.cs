using System.Collections.Generic;
using UnityEngine;

namespace Ambush
{
    public class PlayerTurnView : MonoBehaviour
    {
        public static PlayerTurnView instance;
        //private Board board;

        //public static Map MainMap => instance.board.map;


        [Header("Actions")] [SerializeField] private Transform actionParentTransform;

        [SerializeField] private GameObject actionViewPrefab;
        public AreaView areaView;
        public List<Color> tileColors;

        private void Awake()
        {
            if (instance == null) instance = this;
        }

        public void Load(PlayerBehaviour playerBehaviour)
        {
            // REGISTER ON UI
            areaView.playerBehaviour = playerBehaviour;

            //TODO use a pool or delete old Actions UI
            CreateActionUI(playerBehaviour, playerBehaviour.actions);
        }

        private void CreateActionUI(PlayerBehaviour playerBehaviour, List<IActionController> actionControllers)
        {
            foreach (var actionController in actionControllers)
            {
                var go = Instantiate(actionViewPrefab, Vector3.zero, Quaternion.identity);
                go.transform.parent = actionParentTransform;

                var actionView = go.GetComponent<ActionView>();
                actionView.Populate(playerBehaviour, actionController);
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}