using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Media;

namespace SwordRush
{
    internal class SoundManager
    {
        private static SoundManager instance = null;
        private SoundEffect playerAttackEffect;
        private SoundEffect playerDamagedEffect;
        private SoundEffect playerLevelUpEffect;
        private SoundEffect enemyAttackEffect;
        private SoundEffect enemyDamagedEffect;
        private SoundEffect enemyDeathEffect;
        private SoundEffect gameoverEffect;
        private SoundEffect levelCleardEffect;
        private SoundEffect clickEffect;
        private SoundEffect BGM;
        private SoundEffectInstance bgm;

        //properties
        public SoundEffect PlayerAttackEffect => playerAttackEffect;
        public SoundEffect PlayerDamagedEffect => playerDamagedEffect;
        public SoundEffect PlayerLevelUpEffect => playerLevelUpEffect;
        public SoundEffect EnemyAttackEffect => enemyAttackEffect;
        public SoundEffect EnemyDamagedEffect => enemyDamagedEffect;
        public SoundEffect EnemyDeathEffect => enemyDeathEffect;
        public SoundEffect GameoverEffect => gameoverEffect;
        public SoundEffect LevelCleardEffect => levelCleardEffect;
        public SoundEffect ClickEffect => clickEffect;
        
        public static SoundManager Get
        {
            get
            {
                // Does it exist yet? No? Make it!
                if (instance == null)
                {
                    // Call the default constructor.
                    instance = new SoundManager();
                }

                // Either way, return the (newly made or already made) instance
                return instance;
            }

            // NEVER a set for the instance
        }

        public SoundManager()
        {
            
            playerAttackEffect = GameManager.Get.ContentManager.Load<SoundEffect>("attack2");
            playerDamagedEffect = GameManager.Get.ContentManager.Load<SoundEffect>("hitHurt");
            playerLevelUpEffect = GameManager.Get.ContentManager.Load<SoundEffect>("powerUp");
            enemyAttackEffect = GameManager.Get.ContentManager.Load<SoundEffect>("attack3");
            enemyDamagedEffect = GameManager.Get.ContentManager.Load<SoundEffect>("hitHurt");
            enemyDeathEffect = GameManager.Get.ContentManager.Load<SoundEffect>("death");
            gameoverEffect = GameManager.Get.ContentManager.Load<SoundEffect>("random");
            levelCleardEffect = GameManager.Get.ContentManager.Load<SoundEffect>("clearLevel");
            clickEffect = GameManager.Get.ContentManager.Load<SoundEffect>("click");
            BGM = GameManager.Get.ContentManager.Load<SoundEffect>("BGM");

            //loop the bgm
            bgm = BGM.CreateInstance();
            bgm.IsLooped = true;
            bgm.Play();
            //UpdateVolume();
        }

        public void UpdateVolume()
        {
            SoundEffect.MasterVolume = UI.Get.SfxLevel;
            bgm.Volume = UI.Get.MusicLevel;
        }
    }
}
