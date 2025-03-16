using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BGData", menuName = "Data/BG Data")]
public class BGData : ScriptableObject
{
    public List<Sprite> sprites;

    public Sprite RandomSprite()
    {
        return sprites[Random.Range(0, sprites.Count)];
    }
}
