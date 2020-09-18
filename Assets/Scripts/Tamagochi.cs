using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class Tamagochi : MonoBehaviour
    {
        public Tamago Tamago = new Tamago(10, 2, 3, 10);
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
                if (Tamago.Tired < 10 && Tamago.Joy > 1)
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
                if (Tamago.Tired < 10 && Tamago.Hungry < 10)
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
                if (Tamago.Hungry < 10 && Tamago.Joy > 1)
                {
                    MainText.text = "ZZzzzzz..";
                }
            }
        }

        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Update is called once per frame
        void Update()
        {
            HP.text = "HP: " + Tamago.Health.ToString();
            JOY.text = "Joy: " + Tamago.Joy.ToString();
            TIR.text = "Tired: " + Tamago.Tired.ToString();
            HUNG.text = "Hungry: " + Tamago.Hungry.ToString();

            if(Tamago.Tired >= 10 && Tamago.Joy >2)
            {
                MainText.text = "I need to sleep !";
            }

            if(Tamago.Joy <= 1)
            {
                MainText.text = "I want to play !";
            }

            if(Tamago.Hungry >= 10)
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
                if (_tired >= 10)
                {
                    if (Joy < 10)
                    {
                        Health--;
                    }
                    Joy--;
                    if (Hungry < 10)
                    {
                        Hungry++;
                    }
                    _tired = 10;
                    Debug.Log("Need to sleep");
                }
                if(_tired <= 0)
                {
                    if (Joy > 1 && Hungry < 10)
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

                if(_joy >= 10)
                {
                    if (Hungry < 10 && Tired < 10)
                    {
                        Health++;
                        Tired++;
                        Hungry++;
                    }
                    
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

                if(_hungry >= 10)
                {
                    if (Joy < 10)
                    {
                        Health--;
                    }
                    Joy--;
                    Tired++;
                    _hungry = 10;
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
