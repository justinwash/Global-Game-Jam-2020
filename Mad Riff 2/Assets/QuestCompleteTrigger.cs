using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class QuestCompleteTrigger : MonoBehaviour
{
    public GameObject drummer;
    public Inventory inv;
    public Drummercontroller DC;
    // Start is called before the first frame update
    void Start()
    {
        inv = drummer.GetComponent<Inventory>();
        DC = drummer.GetComponent<Drummercontroller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (DC.onQuest)
            {
                if (inv.HasItem("wrench"))
                {
                    //DC.onQuest = false;
                    //inv.TakeItem("wrench");
                    gameObject.AddComponent<CutsceneQuestComplete>();
                }
            }
        }
    }


}
public class CutsceneQuestComplete : MyFluentDialogue
{
    public GameObject acne;
    public GameObject snot;
    public GameObject badBeard;
    public GameObject van;
    public GameObject player;
    public override FluentNode Create()
    {
        return
            Show() *
            Do(() => gameObject.GetComponent<BoxCollider>().enabled = false) *
            Write(0, "Acne: Hey Losers! Looks like you got the wrench!") *
            Write(0, "Snot: You should be able to use this to fix your crappy Van.") *
            Hide() *
            Write(0, "Vocalist: YeAh!? Thanks NERDS") *
            End() *
            Hide() *
            Hide();
    }
}