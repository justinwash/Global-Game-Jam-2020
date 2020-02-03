using UnityEngine;
using Fluent;

/// <summary>
/// This example shows that you can nest branches, effectively creating a dialogue tree.
/// Remember to have a look at this Conversation component in the editor, you'll be able to see what the tree looks like.
/// </summary>
public class MultipleActorsExample : MyFluentDialogue
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
        Write(0, "Drummer: I was thinking we could change some things about *Dissolving in Satan's Bile*").WaitForButton() *
        Hide() *
        Yell(guitarist, "WhAt!") *
        Show() *
        Write(0, "Guitarist: *Dissolving in Satan's Bile* is fine. I'm not changing anything.").WaitForButton() *
        Write(0, "Drummer: Who put you in charge?").WaitForButton() *
        Write(0, "Bassist: Guys, can't we just talk about this?").WaitForButton() *
        Hide() *
        Yell(guitarist, "SHUT UP!") *
        Yell(drummer, "This freaking guy?!") *
        Yell(guitarist, "I know!") *
        Show() *
        Write(0, "Vocalist: Hey I think I hear a *whine*.").WaitForButton() *
        Write(0, "Drummer: I also heard *The Bassist* call his girlfriend.").WaitForButton() *
        Hide() *
        Yell(van, "*sputter*") *
        Show() *
        Write(0, "The Van: *rattles* and *smokes*") *
          Options
          (
            Option("End") *
            End()
          );
  }
}
