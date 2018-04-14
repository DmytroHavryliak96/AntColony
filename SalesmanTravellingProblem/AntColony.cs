using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class AntColony
    {
        private Random random;

        // вплив феромону на певний напрямок
        private const int alpha = 3;

        // вплив відстані між сусідніми вузлами (містами)
        private const int beta = 2;

        // коефіцінт випаровування феромону 
        private const double rho = 0.01;

        // коефіцінт збільшення феромону
        private const double Q = 2.0;

        // кількість міст у графі
        private int numCities;
        // кількість мурах в алгоритмі
        private int numAnts;
        // скільки разів буде запущений алгоритм пошуку найменшого шляху
        private const int maxTime = 100;  
        // відстані між містами(вершинами графа - ребра), де [1] - перше місто, [2] - друге
        private double[][] dists;
        // масив мурах-агентів, де [1] - порядковий номер мурахи, [2] - маршрут, який мураха буде проходити
        private int[][] ants;
        // найкоротший маршрут
        private int[] bestTrail;
        // довжина найкоротшого маршруту
        public double bestLength;
        // масив феромонів (на ребрах між містами), де [1] - перше місто, [2] - друге
        private double[][] pheromones;
        public List<int[]> allTrails;
        public List<int> bestIterations;
        public List<double> bestLengths;
        public int bestIteration;



        public AntColony(int numCities, int numAnts, double[][] dists)
        {
            this.numCities = numCities;
            this.numAnts = numAnts;
            random = new Random(0);
            this.dists = dists;//MakeGraphDistances();
            ants = initAnts();
            pheromones = InitPheromones();
            allTrails = new List<int[]>();
            bestIterations = new List<int>();
            bestLengths = new List<double>();
        }

        // запуск основного алгоритму
        public int[] FindBestTrail()
        {
            int[] bestTrail = BestTrail();
            this.bestLength = Length(bestTrail);
            double bestLength = Length(bestTrail);

            allTrails.Add(bestTrail);
            bestIterations.Add(-1);
            bestLengths.Add(bestLength);
            this.bestIteration = -1;

            int time = 0;

            while(time < maxTime)
            {
                UpdateAnts();
                UpdatePheromones();

                int[] currBestTrail = BestTrail();
                double currBestLength = Length(currBestTrail);


                allTrails.Add(currBestTrail);
                bestIterations.Add(time);
                bestLengths.Add(currBestLength);
                

                if (currBestLength < bestLength)
                {
                    bestLength = currBestLength;
                    bestTrail = currBestTrail;
                    this.bestIteration = time;
                }
                time += 1;

            }
            this.bestLength = Length(bestTrail);
            //  this.bestTrail = bestTrail;
            return bestTrail;
        }

        // присвоєння кожній мурасі випадкового маршруту
        private int[][] initAnts()
        {
            int[][] ants = new int[numAnts][];
            for(int k = 0; k < numAnts; k++)
            {
                int start = random.Next(0, numCities);
                ants[k] = RandomTrail(start);
            }

            return ants;
        }

        // функція, яка формує випадковий початковий маршрут для мурахи
        private int[] RandomTrail(int start)
        {
            // маршрут (або слід)
            int[] trail = new int[numCities];
            for (int i = 0; i < numCities; i++)
                trail[i] = i;

            // перемішумоємо порядок міст у маршруті
            for(int i = 0; i < numCities; i++)
            {
                int r = random.Next(i, numCities);
                int tmp = trail[r];
                trail[r] = trail[i];
                trail[i] = tmp;
            }

            int idx = IndexOfTarget(trail, start);
            // встановлюємо стартове місто на початок маршруту
            int temp = trail[0];
            trail[0] = trail[idx];
            trail[idx] = temp;

            return trail;
        }

        // Повертає індекс шуканого вузла (target) в конкретному шляху (trail)
        private int IndexOfTarget(int[] trail, int target)
        {
            for(int i = 0; i < trail.Length; i++)
            {
                if (trail[i] == target)
                    return i;
            }
            throw new Exception("Target not found in IndexOfTraget");
        }

        // функція знаходить довжину шляху
        private double Length(int[] trail)
        {
            // загальна довжина шляху
            double result = 0.0;
            for (int i = 0; i < trail.Length - 1; i++)
                result += Distance(trail[i], trail[i + 1]);
            return result;
        }

       /* ------------------------------------------------------------*/
       // функція для знаходження найкоротшого шляху
        private int[] BestTrail()
        {
            bestLength = Length(ants[0]);
            int idxBestLength = 0;
            for(int k = 1; k < ants.Length; k++)
            {
                double len = Length(ants[k]);
                if(len < bestLength)
                {
                    bestLength = len;
                    idxBestLength = k;
                }
            }
            int[] bestTrail = new int[numCities];
            ants[idxBestLength].CopyTo(bestTrail, 0);
            return bestTrail;
        }

        /* -----------------------------------------------------------*/
        // функція ініціалізації початкового значення феромону на всіх ребрах
        private double[][] InitPheromones()
        {
            double[][] pheromones = new double[numCities][];
            for (int i = 0; i < numCities; i++)
                pheromones[i] = new double[numCities];

            for(int i  = 0; i < pheromones.Length; i++)
                for (int j = 0; j < pheromones[i].Length; j++)
                    pheromones[i][j] = 0.01;

            return pheromones;
        }

        /* -----------------------------------------------------------*/
        // оновлення агентів (присвоєння їм нового маршруту)
        private void UpdateAnts()
        {
            for(int k  = 0; k < ants.Length; k++)
            {
                int start = random.Next(0, numCities);
                int[] newTrail = BuildTrail(k, start);
                ants[k] = newTrail;
            }
        }

        // створення нового маршруту для агента
        private int[] BuildTrail(int k, int start)
        {
            // новий маршрут
            int[] trail = new int[numCities];
            // місто відвідане чи ще ні (для задачі Комівояжера)
            bool[] visited = new bool[numCities];
            // початкове місто нового маршруту
            trail[0] = start;
            // відмічаємо, що початкове місто у маршруті вже відвідане
            visited[start] = true;
            for(int i = 0; i < numCities - 1; i++)
            {
                int cityX = trail[i];
                int next = NextCity(k, cityX, visited);
                trail[i + 1] = next;
                visited[next] = true;
            }
            return trail;
        }

        // функція, яка поверта наступне місто в новому маршруті мурахи
        private int NextCity(int k, int cityX, bool[] visited)
        {
            // для мурахи k (з відвіданими містами visited[]), в місті cityX, яким є наступне місто в маршруті?
            double[] probs = MoveProbs(k, cityX, visited);

            // кумулятива ймовірностей
            double[] cumul = new double[probs.Length + 1];
            cumul[0] = 0.0;
            for (int i = 0; i < probs.Length; i++)
                cumul[i + 1] = cumul[i] + probs[i];
            cumul[cumul.Length - 1] = 1.00;

            // випадково згенерована ймовірність
            double p = random.NextDouble();

            for (int i = 0; i < cumul.Length - 1; i++)
            {
                if (p >= cumul[i] && p < cumul[i + 1])
                    return i;
            }
            throw new Exception("Failure to return valid city in NextCity");
            
        }

        // функція, яка повертає ймовірності руху мурахи до доступних на даний момент вузлів
        private double[] MoveProbs(int k, int cityX, bool[] visited)
        {
            // для мурахи k, розташованої у вузлі cityX, з відвіданими вузлами visited[], 
            // повернути ймовірність руху до кожного міста
            // враховуємо cityX та відвідані міста
            double[] taueta = new double[numCities];
            // сума всіх елементів taueta[]
            double sum = 0.0;
            // i - сусідні міста
            for(int i =  0; i < taueta.Length; i++)
            {
                if (i == cityX)
                    taueta[i] = 0.0; // ймовірність руху в поточне положення нульова
                else if (visited[i] == true)
                    taueta[i] = 0.0; // ймовірність руху у вже відвідане місто нульова
                else
                {
                    taueta[i] = Math.Pow(pheromones[cityX][i], alpha) * Math.Pow(1.0 / Distance(cityX, i), beta);
                    // знач. taueta[i] може бути завелике, якщо pheromone[][] значний
                    if (taueta[i] < 0.0001)
                        taueta[i] = 0.0001;
                    else if(taueta[i] > (double.MaxValue / (numCities * 100)))
                        taueta[i] = double.MaxValue / (numCities * 100);
                    
                }
                sum += taueta[i];
            }

            double[] probs = new double[numCities];
            for(int i = 0; i < probs.Length; i++)
                probs[i] = taueta[i] / sum;
            return probs;

        }

        /* -----------------------------------------------------------*/
        // функція оновлення феромону
        private void UpdatePheromones()
        {
            for(int i  = 0; i < pheromones.Length; i++)
            {
                for(int j = i + 1; j < pheromones[i].Length; j++)
                {
                    for(int k = 0; k < ants.Length; k++)
                    {
                        double length = Length(ants[k]);
                        double decrease = (1.0 - rho) * pheromones[i][j];
                        double increase = 0.0;
                        if (EdgeInTrail(i, j, ants[k]) == true)
                            increase = (Q / length);

                        pheromones[i][j] = decrease + increase;

                        if (pheromones[i][j] < 0.0001)
                            pheromones[i][j] = 0.0001;
                        else if (pheromones[i][j] > 100000.0)
                            pheromones[i][j] = 100000.0;

                        pheromones[j][i] = pheromones[i][j]; 
                    }
                }
            }
        }

        // чи cityX та cityY сусіди в маршруті trail[]
        private bool EdgeInTrail(int cityX, int cityY, int[] trail)
        {
            int lastIndex = trail.Length - 1;
            int idx = IndexOfTarget(trail, cityX);

            if (idx == 0 && trail[1] == cityY)
                return true;
            else if (idx == 0 && trail[lastIndex] == cityY)
                return true;
            else if (idx == 0)
                return false;
            else if (idx == lastIndex && trail[lastIndex - 1] == cityY)
                return true;
            else if (idx == lastIndex && trail[0] == cityY)
                return true;
            else if (idx == lastIndex)
                return false;
            else if (trail[idx - 1] == cityY)
                return true;
            else if (trail[idx + 1] == cityY)
                return true;
            else return false;
        }


       /* ------------------------------------------------------------*/
        // функція для створення випадкових відстаней між вузлами графа
        private int[][] MakeGraphDistances()
        {
            int[][] dists = new int[numCities][];
            for (int i = 0; i < dists.Length; i++)
                dists[i] = new int[numCities];

            for(int i = 0; i < numCities; i++)
            {
                for(int j = i+1; j < numCities; j++)
                {
                    int d = random.Next(1, 9);
                    dists[i][j] = d;
                    dists[j][i] = d;
                }
            }
            return dists;
        }

        // визначає відстань між двома вузлами графа (містами)
        private double Distance(int cityX, int cityY)
        {
            return dists[cityX][cityY];
        }

        // конвертує список шляхів в рядок
        public List<string> ConvertTrails()
        {
            List<string> strTrails = new List<string>();

            int k = 0;
            foreach (int[] trail in allTrails)
            {
                string str = "";
                for (int i = 0; i < trail.Length; i++)
                    str += trail[i].ToString() + " -> ";
                str += (bestLengths[k] * 100).ToString(); 
                strTrails.Add(str);
                k++;
            }
            return strTrails;
        }

        // конвертує список ітерацій в рядок
        public List<string> ConvertIter()
        {
            List<string> strIter = new List<string>();
            foreach (int iter in bestIterations)
            {
                strIter.Add(iter.ToString());
            }
            return strIter;
        }
    }
}
