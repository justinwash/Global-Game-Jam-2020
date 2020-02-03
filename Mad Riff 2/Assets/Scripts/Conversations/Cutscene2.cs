using UnityEngine;
using Fluent;

public class Cutscene2 : MyFluentDialogue
{
    public GameObject drummer;
    public GameObject guitarist;
    public GameObject bassist;
    public GameObject vocalist;
    public GameObject acne;
    public GameObject snot;
    public GameObject badBeard;
    public GameObject van;
    public GameObject player;
    public GameObject portrait;

    public override FluentNode Create()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        Drummercontroller DC = player.GetComponent<Drummercontroller>();
        DC.onQuest = true;

        return
            Show() *
            Do(() => van.GetComponent<jalopyBusControl>().StartQuest("wrench")) *
            Do(() => gameObject.GetComponent<SphereCollider>().enabled = false) *
            Do(() => portrait.GetComponent<PortraitController>().Show()) *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("acne")) *
            Write(1, "Acne: Hey Losers! Looks like your van is as broke as your music.").WaitForButton() *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("snot")) *
            Write(1, "Snot: I know it's the apocalypse but that van really *is* a piece of junk.").WaitForButton() *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("singer")) *
            Write(1, "Vocalist: Oh YeAh!?") *
            Write(1, "Vocalist: Well you... stink!").WaitForButton() *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("badbeard")) *
            Write(1, "Bad Beard: I hope you're not the one that writes the music...?").WaitForButton() *
            Write(1, "Bad Beard: Look, we might be able to get you some help but we're " +
             "gonna need something from you first").WaitForButton() *
             Do(() => portrait.GetComponent<PortraitController>().SetPortrait("bassist")) *
            Write(1, "Bassist: What are you thinking?").WaitForButton() *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("guitarist")) *
            Write(1, "Guitarist: SHUT UP!") *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("drummer")) *
            Write(1, "Drummer: YEAH SHUT UP!") *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("guitarist")) *
            Write(1, "Guitarist: So what are you thinking?").WaitForButton() *
            Do(() => portrait.GetComponent<PortraitController>().SetPortrait("badbeard")) *
            Write(1, "Bad Beard: Since *The Bad Thing* happened the local skate shop has closed down. " +
              "If you could help get us back on our boards we could get you into the " +
              "*High School Shop Room*. There are parts there we can use to fix your car").WaitForButton() *
            Hide() *
            Yell(badBeard, "*flashes keys*") *
            Do(() => portrait.GetComponent<PortraitController>().Hide()) *
            End() *
            Hide();
    }
}