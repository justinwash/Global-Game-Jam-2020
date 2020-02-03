using UnityEngine;
using Fluent;

public class Cutscene3 : MyFluentDialogue
{
  public GameObject drummer;
  public GameObject guitarist;
  public GameObject bassist;
  public GameObject vocalist;
  public GameObject van;

  public override FluentNode Create()
  {
    return
        Show() *
        Do(() => gameObject.GetComponent<SphereCollider>().enabled = false) *
        Write(0, "Guitarist: Hey *Bassist*, good job with the van.").WaitForButton() *
        Write(0, "Drummer: Yeah that was sicc back there.").WaitForButton() *
        Write(0, "Bassist: Thanks guys, you know I was just telling *Girlfriend* " +
        "I thought you guys weren't all bad").WaitForButton() *
        Hide() *
        Yell(guitarist, "Don't push it.") *
        Show() *
        Write(0, "Vocalist: Hey *Drummer*, quit it with the tapping!").WaitForButton() *
        Write(0, "Drummer: Hey Smooth Brain, I'm not tapping on anything").WaitForButton() *
        Hide() *
        Yell(van, "*TAP TAP TAP TAP*") *
        Show() *
        Write(0, "The Van: *TAPPING INTENSIFIES*") *
          Options
          (
            Option("End") *
            End()
          );
  }
}