using MohawkGame2D;

namespace Assignment_4
{
    internal class BGM
    {
        public static Music bgm1 = Audio.LoadMusic("../../../assest/Music/BGM1.mp3");
        public static Music bgm2 = Audio.LoadMusic("../../../assest/Music/BGM2.mp3");
        public static Music bgm3 = Audio.LoadMusic("../../../assest/Music/BGM3.mp3");
        public float bgm1Length = Audio.GetMusicLength(bgm1);
        public float bgm2lenght = Audio.GetMusicLength(bgm2);

        public void BGMPlay()
        {
            if (Time.SecondsElapsed <= bgm1Length && Audio.IsPlaying(bgm1) == false)
            {
                Audio.Play(bgm1);
            }
            else if (Time.SecondsElapsed > bgm1Length && Time.SecondsElapsed < bgm1Length + bgm2Length && Audio.IsPlaying(bgm2) == false)
            {
                Audio.Pause(bgm1);
                Audio.Play(bgm2);
            }
            else if (Time.SecondsElapsed > bgm1Length + bgm2Length && Audio.IsPlaying(bgm3) == false)
            {
                Audio.Pause(bgm2);
                Audio.Play(bgm3);
            }
        }
    }

}