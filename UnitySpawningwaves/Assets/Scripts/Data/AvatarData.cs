using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Data", menuName = "Create Avatar Data", order = 51)]
public class AvatarData : ScriptableObject
{
    public List<Avatar> avatars = new List<Avatar>();
}