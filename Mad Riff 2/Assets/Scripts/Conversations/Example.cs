using UnityEngine;
using Fluent;

/// <summary>
/// This example shows that you can nest branches, effectively creating a dialogue tree.
/// Remember to have a look at this Conversation component in the editor, you'll be able to see what the tree looks like.
/// </summary>
public class Example : MyFluentDialogue
{
  public GameObject redGuy;

  public override FluentNode Create()
  {
    return
        Show() *

        Options
        (
            Write(0, "Hey this is an example conversation") *
            Option("Okay next") *
                Write(0, "It has multiple branches defined in script") *
                Options
                (
                    Option("That's cool") *
                        Write(0, "Extremely.") *

                    Option("That's dumb") *
                        Write(0, "No it isn't.") *

                    Option("Whatever") *
                        Back()
                ) *

            Option("Bye") *
                Hide() *
                End()
        );

  }
}