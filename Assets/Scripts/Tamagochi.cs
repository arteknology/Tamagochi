using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace Scripts
{
    public class Tamagochi : MonoBehaviour
    {
        public Tamago Tamago = new Tamago(10, 1, 2, 5);
        public TMP_Text MainText;
        public TMP_Text HP;
        public TMP_Text JOY;
        public TMP_Text TIR;
        public TMP_Text HUNG;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void Feed()
        {
            if (!Tamago.IsDead)
            {
                Tamago.Hungry--;
                Tamago.Tired++;
                Tamago.Joy++;
                if (Tamago.Tired < 5 && Tamago.Joy > 1)
                {
                    MainText.text = "Yum yum !";
                }
            }
        }

        public void Play()
        {
            if (!Tamago.IsDead)
            {
                Tamago.Joy++;
                Tamago.Hungry++;
                if (Tamago.Tired < 5 && Tamago.Hungry < 5)
                {
                    MainText.text = "I like this game !";
                }
            }
        }

        public void Sleep()
        {
            if (!Tamago.IsDead)
            {
                Tamago.Tired--;
                if (Tamago.Hungry < 5 && Tamago.Joy > 1)
                {
                    MainText.text = "ZZzzzzz..";
                }
            }
        }

        public void Reset()
        {
            Tamago.Health = 11;
            Tamago.Joy = 2;
            Tamago.Hungry = 5;
            Tamago.Tired = 1;
        }

        // Update is called once per frame
        void Update()
        {
            HP.text = "HP: " + Tamago.Health.ToString();
            JOY.text = "Joy: " + Tamago.Joy.ToString();
            TIR.text = "Tired: " + Tamago.Tired.ToString();
            HUNG.text = "Hungry: " + Tamago.Hungry.ToString();

            if(Tamago.Tired >= 5 && Tamago.Joy >2)
            {
                MainText.text = "I need to sleep !";
            }

            if(Tamago.Joy <= 1)
            {
                MainText.text = "I want to play !";
            }

            if(Tamago.Hungry >= 5)
            {
                MainText.text = "I want to eat !";
            }

            if (Tamago.IsDead)
            {
                MainText.text = "Your Tamagotchi died, try again..";
                Reset();
            }

        }
    }

    public class Tamago
    {
        public bool IsDead { get; private set;}

        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                if (_health > 0)
                {
                    Debug.Log("if (_health > 0)");
                    return;
                }
                _health = 0;
                IsDead = true;
                Debug.Log("Your Tamagochi is dead");
            }
        }

        private int _tired;
        public int Tired
        {
            get
            {
                return _tired;
            }
            set
            {
                _tired = value;
                if (_tired >= 5)
                {
                    if (Joy < 5)
                    {
                        Health--;
                    }
                    Joy--;
                    Hungry++;
                    _tired = 5;
                    Debug.Log("Need to sleep");
                }
                if(_tired <= 0)
                {
                    if (Joy > 1 && Hungry < 5)
                    {
                        Debug.Log("if (Joy > 1)");
                        Health++;
                    }
                    Joy--;
                    _tired = 1;
                    Debug.Log("if(_tired <= 0)");
                }
            }
        }

        private int _joy;
        public int Joy
        {
            get
            {
                return _joy;
            }
            set
            {
                _joy = value;
                if (_joy <= 0)
                {
                    Health--;
                    _joy = 1;
                    Debug.Log("Play with me");
                }

                if(_joy >= 5)
                {
                    if (Hungry < 5 && Tired < 5)
                    {
                        Health++;
                    }
                    Tired++;
                    Hungry++;
                    _joy--;
                    Debug.Log("if(_joy >= 5)");
                }
            }
        }

        private int _hungry;
        public int Hungry
        {
            get
            {
                return _hungry;
            }
            set
            {
                _hungry = value;
                if(_hungry <= 0)
                {
                    if (Joy > 0)
                    {
                        Health++;
                    }
                    Tired--;
                    Joy++;
                    _hungry =1;
                    Debug.Log("if(_hungry <= 0)");
                }

                if(_hungry >= 5)
                {
                    if (Joy < 5)
                    {
                        Health--;
                    }
                    Tired++;
                    _hungry = 5;
                    Debug.Log("Feed Me");
                }
            }
        }

        public Tamago(int health, int tired, int joy, int hungry)
        {
            _health = health;
            _tired = tired;
            _joy = joy;
            _hungry = hungry;
        }
    }
}
