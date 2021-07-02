using System;
using System.Collections;
using System.Collections.Generic;
using Characteristics;
using UnityEngine;
/// <summary>
///  базовый класс контроля метода
/// </summary>
namespace ExperienceSystem
{
    public abstract class ExperienceController : MonoBehaviour
    {
        public abstract void AddExperience(int value);
        public abstract void LevelUp();
        public abstract bool IsLevelMax();

    }
}

