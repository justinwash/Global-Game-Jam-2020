using UnityEngine;
using Fluent;

public class Cutscene1 : MyFluentDialogue
{
  public GameObject drummer;
  public GameObject guitarist;
  public GameObject bassist;
  public GameObject vocalist;
  public GameObject van;
  public GameObject portrait;

  public override FluentNode Create()
  {
    return
        Show() *
        Do(() => gameObject.GetComponent<SphereCollider>().enabled = false) *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("drummer")) *
        Do(() => portrait.GetComponent<PortraitController>().Show()) *
        Write(1, "Drummer: I was thinking we could change some things about *Dissolving in Satan's Bile*") *
        Hide() *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("guitarist")) *
        Yell(guitarist, "WhAt!") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("guitarist")) *
        Show() *
        Write(1, "Guitarist: *Dissolving in Satan's Bile* is fine. I'm not changing anything.") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("drummer")) *
        Write(1, "Drummer: Who put you in charge?") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("bassist")) *
        Write(1, "Bassist: Guys, can't we just talk about this?") *
        Hide() *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("guitarist")) *
        Yell(guitarist, "SHUT UP!") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("drummer")) *
        Yell(drummer, "This freaking guy?!") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("guitarist")) *
        Yell(guitarist, "I know!") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("singer")) *
        Show() *
        Write(1, "Vocalist: Hey I think I hear a *whine*.") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("drummer")) *
        Write(1, "Drummer: I also heard *The Bassist* call his girlfriend.") *
        Hide() *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("van")) *
        Yell(van, "*sputter*") *
        Do(() => portrait.GetComponent<PortraitController>().SetPortrait("van")) *
        Show() *
        Write(1, "The Van: *rattles* and *smokes*") *
        Hide() *
        Do(() => portrait.GetComponent<PortraitController>().Hide()) *
        Do(() => van.GetComponent<jalopyBusControl>().StartQuest("axe"));
  }
}