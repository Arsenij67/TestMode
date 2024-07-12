using TMPro;
using UnityEngine;

public class InstructionView : MovePanelView
{
    [SerializeField] private TextAsset AssetInstruction;
    [SerializeField] private TMP_Text textInstruction;

    private void Awake()
    {
        textInstruction.text = AssetInstruction.text;
    }

}
