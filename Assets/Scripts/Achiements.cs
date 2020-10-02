using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Scripts
{
    public class Achiements : MonoBehaviour
    {
        public Tamagochi Tamagochi;

        [NonSerialized] public int EatCount = 0;
        [NonSerialized] public int SleepCount = 0;
        [NonSerialized] public int PlayCount = 0;

        public Text AchievementText;
        // Start is called before the first frame update

        void Awake()
        {


            Tamagochi.OnAte += delegate ()
            {
                EatCount++;
                if (EatCount == 10)
                {
                    AchievementText.text = "Congrats ! Your tamagotchi ate " + EatCount + " times !";
                }
            };

            Tamagochi.OnPlayed += delegate ()
            {
                PlayCount++;
                if (PlayCount == 10)
                {
                    AchievementText.text = "Congrats ! Your tamagotchi played " + PlayCount + " times !";
                }
            };

            Tamagochi.OnSleep += delegate ()
            {
                SleepCount++;
                if (SleepCount == 10) 
                {
                    AchievementText.text = "Congrats ! Your tamagotchi sleeped " + SleepCount + " times !";
                }
            };

        }
    }
}
