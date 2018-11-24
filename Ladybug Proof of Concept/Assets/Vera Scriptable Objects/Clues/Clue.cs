using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clue", menuName = "Dialogue/Clue")]
public class Clue : ScriptableObject {

    [Header("What is the clue about?")]
    public string clueDescription; //what does the clue entail?

}
