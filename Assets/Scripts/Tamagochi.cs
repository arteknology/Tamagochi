using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Tamagochi : MonoBehaviour
    {
        public Tamago Tamago = new Tamago(10, 1, 2, 5);

        // Start is called before the first frame update
        void Start()
        {
            
        }

        void Feed()
        {
            Tamago.Hungry--;
        }

        void Play()
        {
            Tamago.Joy++;
        }

        void Sleep()
        {
            Tamago.Tired--;
        }

        // Update is called once per frame
        void Update()
        {

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
                if (_health > 0) return;
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
                    Health--;
                    Joy--;
                    Hungry++;
                    _tired--;
                    Debug.Log("Need to sleep");
                }
                if(_tired <= 0)
                {
                    Health++;
                    Hungry--;
                    Joy++;
                    _tired++;
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
                    _joy++;
                    Debug.Log("Play with me");
                }

                if(_joy >= 5)
                {
                    Health++;
                    Tired++;
                    Hungry++;
                    _joy--;
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
                    Health++;
                    Tired--;
                    Joy++;
                    _hungry++;
                }

                if(_hungry >= 5)
                {
                    Health--;
                    Tired++;
                    Joy--;
                    _hungry--;
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
