using UnityEngine;

namespace BGGames_Test
{
    public class LabirynthDataGenerator
    {
        private LabirynthSettings _labirinthSettings;

        public LabirynthDataGenerator(LabirynthSettings labirynthSettings)
        {
            _labirinthSettings = labirynthSettings;
        }

        public int[,] GenerateData()
        {
            var size = _labirinthSettings.Size;
            int[,] labirynth = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || j == 0 || i == size - 1 || j == size - 1)
                    {
                        labirynth[i, j] = 1;
                    }
                    else if (i == 1 && j == 1 || i == size - 2 && j == size - 2)
                    {
                        labirynth[i, j] = 0;
                    }
                    else if (i % 2 == 0 && j % 2 == 0)
                    {
                        if (Random.value > _labirinthSettings.EmptySpaceTreshold)
                        {
                            labirynth[i, j] = 1;

                            int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                            int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                            labirynth[i + a, j + b] = 1;
                        }
                    }
                }
            }

            return labirynth;
        }
    }
}