using UnityEditor;

[CustomEditor(typeof(CardView))]
public class CardViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CardView cardView = (CardView)target;
        cardView.PopulateView();
    }
}
