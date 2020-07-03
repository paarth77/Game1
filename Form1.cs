using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class form1 : Form
    {
        public class RussainRoulette
        {

            //global variable declaration
            public int save;
            public int hit;
            public bool enableDisableFB;
            public bool enableDisablePAB;
            public bool enableDisableFAB;
            public int counterVariable = 0;
            public int clickCountVariable = 0;
            public int fireAwayVariable = 0;
            public int[] gunChamberArr = new int[5] { 0,0,0,0,0 };
            
            //class Method

            public bool fireAwayButton()
            {
                return enableDisableFAB;        //this function make button Enable/Disable.
            }
            public int hitBullet()
            {
                return hit;                     //returns whether hit has value or not
            }

            public int saveBullet()
            {
                return save;                    //returns whether save has value or not
            }
             public bool FireButtonAvailable()
            {

                return enableDisableFB;           //this function make button enable/disable.
            }

            public bool PAButtonEnabledFalse()
            {

                return enableDisablePAB;          //this function make button Enable/Disable.

            }
            public  bool AmmoLoadedInGun(Label label1)
            {

                label1.Enabled = true;          //this function is accessing Form properties.
                return true;

            }

            public void loadBulletInGun()
            {

                Array.Resize(ref gunChamberArr, gunChamberArr.Length + 1);
                gunChamberArr[5] = 1;                                      //Add Bullet into Gun Chamber.
                Console.WriteLine(gunChamberArr[5]);

            }

            public int spinGunChamber()
            {

                Random rd = new Random();
                int randomIndex = rd.Next(0, gunChamberArr.Length);          // This function spins the chamber of gun.
                int randomNumber = gunChamberArr[randomIndex];
                Console.WriteLine(randomNumber);
                
                return randomNumber;
                
            }

            public void Fireaway( int randNumber1)
            {

                if (clickCountVariable >= 0 && clickCountVariable <= 1)
                {

                    save++;
                    System.Media.SoundPlayer playerr = new System.Media.SoundPlayer("Properties.Resources.GunEmpty");
                    playerr.Play();
                    enableDisableFB = true;
                    enableDisableFAB = true;
                    enableDisablePAB = false;
                    PAButtonEnabledFalse();
                    fireAwayButton();
                    FireButtonAvailable();

                    if (randNumber1 == gunChamberArr[5])
                    {

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.revolver");
                        player.Play();
                        save++;
                        save -= 1;
                        enableDisableFB = false;
                        enableDisableFAB = false;
                        enableDisablePAB = true;
                        string message = "You Win The Game :)";
                        string title = "You Survived!!";
                        MessageBox.Show(message, title);

                    }
                }

                else
                {

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.revolver");
                    player.Play();
                    hit++;
                    enableDisableFB = false;
                    enableDisableFAB = false;
                    enableDisablePAB = true;
                    PAButtonEnabledFalse();
                    fireAwayButton();
                    FireButtonAvailable();
                    string message = "You Loose The Game :(";
                    string title = "You Are Dead!!";
                    MessageBox.Show(message, title);

                }

                
            }

            public void triggerGunFunc(int randomnumber)                        //This function Fires the Bullet.
            {

                if (randomnumber == gunChamberArr[5] || counterVariable == 5)                        //In this if/else we are checking that bullet hits or not
                {

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.revolver");
                    player.Play();
                    hit++;
                    enableDisableFB = false;
                    enableDisableFAB = false;
                    enableDisablePAB = true;
                    PAButtonEnabledFalse();
                    FireButtonAvailable();
                    fireAwayButton();
                    string message = "You Loose The Game :(";
                    string title = "You Are Dead!!";
                    MessageBox.Show(message, title);

                }
                else if(clickCountVariable == 2)
                {

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.revolver");
                    player.Play();
                    hit++;
                    enableDisableFB = false;
                    enableDisableFAB = false;
                    enableDisablePAB = true;
                    PAButtonEnabledFalse();
                    FireButtonAvailable();
                    fireAwayButton();
                    string message = "You Loose The Game :(";
                    string title = "You Are Dead!!";
                    MessageBox.Show(message, title);

                }
                else
                {

                    save++;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Revolver.GunEmpty");
                    player.Play();
                    enableDisableFB = true;
                    enableDisableFAB = true;
                    enableDisablePAB = false;                //If bullet is not fired then random number function will fire Again.
                    PAButtonEnabledFalse();
                    FireButtonAvailable();
                    fireAwayButton();

                }
            }

        }
        public form1()
        {

            InitializeComponent();
            loadBullet.Enabled = true;
            spinChambers.Enabled = false;
            fireGun.Enabled = false;                        //Initial running component.
            playAgain.Enabled = false;
            fireaway.Enabled = false;
            label1.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;

        }

        RussainRoulette obj = new RussainRoulette();
        int SCnum;

        private void loadBullet_Click(object sender, EventArgs e)
        {

            obj.loadBulletInGun();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.GunEmpty");
            player.Play();
            loadBullet.Enabled = false;                        //This click Function calls load bullet function.
            spinChambers.Enabled = true;
            bool v = obj.AmmoLoadedInGun(label1);
            label1.Visible = v;

        }

        private void spinChambers_Click(object sender, EventArgs e)
        {

            SCnum = obj.spinGunChamber();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.mag");
            player.Play();
            spinChambers.Enabled = false;                     //This click function will call spin Chamber function.
            fireaway.Enabled = true;
            fireGun.Enabled = true;
            label1.Visible = false;
            bool v = obj.AmmoLoadedInGun(label6);
            label6.Visible = v;

        }

        private void fireGun_Click(object sender, EventArgs e)
        {

            SCnum = obj.spinGunChamber();
            obj.triggerGunFunc(SCnum);                                //it passes random value to fireGun Function.
            bool enableVar = obj.fireAwayButton();
            fireaway.Enabled = enableVar;    
            bool w = obj.PAButtonEnabledFalse();              //It will disable play Again button.
            playAgain.Enabled = w;
            label6.Visible = false;                         
            bool x = obj.FireButtonAvailable();                 //It will enable fire button.
            fireGun.Enabled = x;
            bool v = obj.AmmoLoadedInGun(label7);
            label7.Visible = v;
            int d = obj.hitBullet();
            label13.Text = d.ToString();
            int f = obj.saveBullet();
            label12.Text = f.ToString();
            obj.counterVariable++;

        }

        private void playAgain_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer player = new System.Media.SoundPlayer("Properties.Resources.GameOver");
            player.Play();
            string message = "Game Is Over ";
            string title = "Russian Roulette";
            MessageBox.Show(message, title);
            spinChambers.Enabled = false;
            fireGun.Enabled = false;                                   //all buttons will become disable
            playAgain.Enabled = false;
            loadBullet.Enabled = true;
            label7.Visible = false;
            
            obj.gunChamberArr = new int[5] { 0,0,0,0,0 };                    //reset game.
            obj.save = 0;
            obj.hit = 0;
            label12.Text = "0";
            label13.Text = "0";
            obj.counterVariable = 0;
            obj.clickCountVariable = 0;

        }

        private void fireaway_Click(object sender, EventArgs e)
        {

            SCnum = obj.spinGunChamber();
            obj.Fireaway(SCnum);
            obj.counterVariable++;
            obj.clickCountVariable++;
            bool w = obj.PAButtonEnabledFalse();              //It will disable play Again button.
            playAgain.Enabled = w;
            bool enableVar = obj.fireAwayButton();
            fireaway.Enabled = enableVar;
            label6.Visible = false;
            bool x = obj.FireButtonAvailable();                 //It will enable fire button.
            fireGun.Enabled = x;
            bool v = obj.AmmoLoadedInGun(label7);
            label7.Visible = v;
            int f = obj.saveBullet();
            label12.Text = f.ToString();
            int d = obj.hitBullet();
            label13.Text = d.ToString();

        }
    }
}
