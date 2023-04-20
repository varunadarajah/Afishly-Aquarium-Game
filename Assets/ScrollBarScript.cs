using UnityEngine.UI;
public class ScrollBarScript : ScrollRect {
   
     override protected void LateUpdate() {
    base.LateUpdate();
    if (this.verticalScrollbar) {
        this.verticalScrollbar.size = 0.1f;
    }
}

override public void Rebuild(CanvasUpdate executing) {
    base.Rebuild(executing);
    if (this.verticalScrollbar) {
        this.verticalScrollbar.size = 0.1f;
    }
}

protected override void Start() {
    base.Start();
    if (this.verticalScrollbar) {
        this.verticalNormalizedPosition = 1.0f;
    }
}
}