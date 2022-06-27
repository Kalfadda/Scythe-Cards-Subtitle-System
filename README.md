# Scythe Cards | Subtitle System for Unity3D
![image](https://user-images.githubusercontent.com/38150569/175878182-e126dc06-4562-4494-b54b-7d3e58c0f203.png)

Created in Unity 2021.3.4f1<br>
Compatible with Unity 5+

Scythe Cards is a *simple* and *barebones* subtitle system that takes advantage of Unity's Scriptable Object Workflow to allow game developers of all skill levels to add accessibility options to their games quickly, easily and efficiently.

**Requirements:**
- <a href="https://learn.unity.com/tutorial/working-with-textmesh-pro#5f86410eedbc2a00249a4927">TextMesh Pro</a>

**Instructions:**
- Extract the Unity Package into your game
- Open the 'Example Scene' (Scythe Cards>Scenes>Example Scene)
- Press Play

**Breakdown:**<br>
'Prefab Manager' must exist in any scene requiring subtitles (drag it in from the prefabs folder).<br>
In any script of your own you can now define a reference to SubtitleCard:
```cs
public SubtitleCard _shopKeeperDialogue;
```
and from that very same script (or others) simply call
```cs
SubtitleManager.instance.CueSubtitle(_shopKeeperDialogue);
```
I.E.
```cs
using Scythe.Accessibility;

public SubtitleCard _shopKeeperDialogue;

void Start()
{
    SubtitleManager.instance.CueSubtitle(_shopKeeperDialogue);
}
```
Subtitle Cards reference the ***Subtitle Card Data*** Scriptable Objects. You can easily create those
by right clicking in your project folder (Right Click > Create > Subtitle Card Data). Just add your dialogue and timing.


For a full explanation please see the barebones 'Example Scene' and review the code and tooltips to understand better.
Scythe Cards was kept as minimal as possible to allow flexibility and extension however you see fit. Some examples
of different applications could be:
- Creating an array of SubtitleCards[], to control an entire conversation in an easy sequence.
- Queueing audioclips in addition to the subtitle card execution for an all-in-one dialogue system.
- Overloading with languange varations and using a switch case to determine which array to use.
- Use multiple text objects to control many worldspace text elements for localization.

MIT License
Copyright (c) 2022 Kaleb Alfadda
