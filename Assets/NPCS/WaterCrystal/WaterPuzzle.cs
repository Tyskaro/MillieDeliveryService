using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuzzle : NPC
{
    public PuzzleOne puzzle;
    public override void EndDialogEvent()
    {
        base.EndDialogEvent();
        puzzle.PuzzleStart();
    }
}
