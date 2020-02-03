using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private bool failed = false;
    private bool started = false;
    private Color[] colors = { new Color (1, 0.25f, 0.25f), new Color (0.25f, 0.25f, 1), new Color (0.25f, 1, 0.25f), new Color (1, .5f, 0) };
    private int previousRound;
    private int riff;
    private int round;
    private int step = 0;
    private int[] pressed = new int[8];
    private int buttonsPushed = 0;
    private int[] sequence;
    public AudioClip[] bars;
    public AudioClip[] barsMissed;
    public AudioClip failure;
    public AudioClip victory;
    public AudioSource audio;
    public AudioSource[] speakers;
    public SpriteRenderer[] skulls;
    public bool playerWon;
    public bool gameFinished;

    void Start () {
        StartBattle ();
    }

    // Update is called once per frame
    void Update () {
        // print ("Step: " + step + " | Round:" + round + " | Riff:" + riff);
        if (!audio.isPlaying) {
            if (riff == round) {
                step++;
                riff = 0;
            } else if (step == 1) {
                ResetSkulls ();
                PlayPart (sequence);
            } else if (step == 2) {
                RepeatPart ();
            } else if (step == 3) {
                PlaybackPart ();
            }
        }
    }

    public void ClickButton (int b) {
        pressed[buttonsPushed] = b;
        buttonsPushed++;
        if (buttonsPushed == pressed.Length) {
            step++;
        }
        // PrintSequences ();
    }

    public void StartBattle () {
        sequence = GetSequence ();
        step = 1;
        round = 8;
        riff = 0;
    }

    private void PlayPart (int[] sequence) {
        ResetSkulls ();
        var b = sequence[riff];
        // print (b + " | " + colors[b]);
        SpriteRenderer skull = skulls[b];
        skull.color = colors[b];
        audio.clip = bars[riff];
        audio.Play ();
        riff++;
    }

    private void RepeatPart () {
        LightUpSkulls (true);
        int[] fpressed = { 1, 0, 1, 0, 0, 2, 1, 2 };
        pressed = fpressed;
        buttonsPushed = 8;
        if (buttonsPushed == bars.Length) {
            step++;
        }
    }

    private void PlaybackPart () {
        var l = 1.86;
        int y = 0;
        int n = 0;
        LightUpSkulls (false);
        for (var i = 0; i < bars.Length; i++) {
            AudioSource speaker = speakers[i];
            var delay = i * l;
            if (pressed[i] == sequence[i]) {
                speaker.clip = bars[i];
                y++;
            } else {
                speaker.clip = barsMissed[i];
                n++;
            }
            speaker.PlayScheduled (AudioSettings.dspTime + delay);
        }

        if (n <= 1) {
            audio.clip = victory;
            playerWon = true;
        } else {
            audio.clip = failure;
            playerWon = false;
            audio.PlayScheduled (AudioSettings.dspTime + (l * bars.Length));
        }
        step = 0;
        Invoke ("Done", 17);
    }

    private void Done () {

        gameFinished = true;
    }

    private void ResetSkulls () {
        for (var i = 0; i < skulls.Length; i++) {
            skulls[i].color = new Color (0.25f, 0.25f, 0.25f);
        }
    }

    private void LightUpSkulls (bool colored) {
        if (colored) {
            for (var i = 0; i < skulls.Length; i++) {
                skulls[i].color = colors[i];
            }
        } else {
            for (var i = 0; i < skulls.Length; i++) {
                skulls[i].color = new Color (1, 1, 1, 1);
            }
        }
    }

    private int[] GetSequence () {
        int[] fakes = { 1, 0, 1, 3, 0, 2, 1, 2 }; //override for demo
        return fakes;
        // int[] s = new int[10];
        // for (int i = 0; i < bars.Length; i++) {
        //     s[i] = Random.Range (0, skulls.Length);
        // }
        // return s;
    }

    private void PrintSequences () {
        string correct = "";
        string picked = "";

        for (var i = 0; i < sequence.Length; i++) {
            correct = correct + sequence[i];
        }
        for (var i = 0; i < pressed.Length; i++) {
            picked = picked + pressed[i];
        }
        print (correct + " | " + picked);
    }

}