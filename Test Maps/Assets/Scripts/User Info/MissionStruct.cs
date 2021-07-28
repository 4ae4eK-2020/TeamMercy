using System;
using UnityEngine;

namespace Structs
{
    [Serializable]
    public struct MissionStruct
    {
        [Range(0, 2)] public int Stage;
        public int missionNumber;
    }
}