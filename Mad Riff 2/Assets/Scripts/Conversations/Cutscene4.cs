using UnityEngine;
using Fluent;

public class Cutscene4 : MyFluentDialogue
{
  public GameObject cheech;
  public GameObject shaggy;
  public GameObject vocalist;

  public override FluentNode Create()
  {
    return
        Show() *
        Do(() => gameObject.GetComponent<SphereCollider>().enabled = false) *
        Write(0, "Cheech: Gotta say, this is... disappointing.").WaitForButton() *
        Write(0, "Shaggy: We came over here because we saw that *fat cloud of smoke*.").WaitForButton() *
        Write(0, "Vocalist: Wish it wasn't this way. Van has shot it").WaitForButton() *
        Hide() *
        Yell(shaggy, "*sigh*") *
        Show() *
        Write(0, "Cheech: We, like, might be able to help with that.").WaitForButton() *
        Hide() *
        Yell(vocalist, "????") *
        Show() *
        Write(0, "Shaggy: Yeah, man, we, like, are used to finding creative solutions. " +
          "But first we are gonna need some help.").WaitForButton() *
        Write(0, "Shaggy: The snack situation in this town has gone to hell since The Bad Thing. " +
          "If you could figure out how to get the *Potato Chip Factory* running again we would rig up " +
          "whatever part you need.").WaitForButton() *
          Options
          (
            Option("End") *
            End()
          );
  }
}