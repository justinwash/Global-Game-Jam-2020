using UnityEngine;
using Fluent;

public class Cutscene5 : MyFluentDialogue
{
  public GameObject drummer;
  public GameObject guitarist;
  public GameObject vocalist;
  public GameObject van;

  public override FluentNode Create()
  {
    return
        Show() *
        Do(() => gameObject.GetComponent<SphereCollider>().enabled = false) *
        Write(0, "Drummer: *Vocalist*, hey, sorry for calling you a knuckle-dragging, mouth-breathing, " +
          "close-talking, club-foot-piece-of-trash earlier.").WaitForButton() *
        Hide() *
        Yell(vocalist, "????") *
        Show() *
        Write(0, "Vocalist: I… don’t remember that. But yeah water under the bridge. " +
          "Sometimes I’m not the sharpest tool. ").WaitForButton() *
        Write(0, "Drummer: No, it's not OK. I'm gonna work on that.").WaitForButton() *
        Write(0, "Guitarist: Hey *Drummer* I was thinking. *Dissolving in Satan’s Bile* might need " +
          "some heavier drums.").WaitForButton() *
        Hide() *
        Yell(van, "*happy van noises*") *
        Yell(van, "*unhappy van noises*") *
        Show() *
        Write(0, "The Van: *engine failing noises*") *
          Options
          (
            Option("End") *
            End()
          );
  }
}