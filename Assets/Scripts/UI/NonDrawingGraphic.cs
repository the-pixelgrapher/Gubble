using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonDrawingGraphic : Graphic
{
    public override void SetMaterialDirty() { return; }
    public override void SetVerticesDirty() { return; }
}
