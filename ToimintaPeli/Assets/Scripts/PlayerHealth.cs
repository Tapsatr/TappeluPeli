using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
        public int maxHealth = 100;
        public int curHealth = 100;
        public Slider healthbar;
        public float Timer;
        public float Wait;
       
       // public float healthBarLengh;
       
        // Use this for initialization
        void Start () {
            Timer = 0;
            Wait = 2.0f;
                                    //  healthBarLengh = Screen.width / 2;
        }
       
        // Update is called once per frame
        void Update () {
                AddjustCurrentHealth(0);

                    if (Timer > 0)
                    {
                        Timer -= Time.deltaTime;
                    }
                    if (Timer < 0)
                    {
                        Timer = 0;
                    }
                    if (Timer == 0)
                    {
                        Regen();
                        Timer = Wait;
                    }
        }
       
     /*   void OnGUI() {
                GUI.Box(new Rect(10, 10, healthBarLengh, 20), curHealth + "/" + maxHealth);
        }*/
       
        public void AddjustCurrentHealth(int adj) {
                curHealth += adj;
               // healthbar.value = curHealth;
               
                if(curHealth < 0)
                        curHealth =  0;
                       
                if(curHealth > maxHealth)
                        curHealth = maxHealth;
                       
                if(maxHealth < 1)
                        maxHealth = 1;

                
               
                //healthBarLengh = (Screen.width / 2) * (curHealth / (float)maxHealth);
            if(curHealth ==0)
            {
                SceneManager.LoadScene("level2");
            }
        }
        private void Regen()
        {
            AddjustCurrentHealth(1);
        }
}