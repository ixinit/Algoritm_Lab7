using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ArrsC
{
    class SortsClass
    {
        private static int N, B; // переменные на ввод
        private static int[] A; // массив A
        private static int sum0, sum1, sum2, sum3; // суммы
        Stopwatch timer = new Stopwatch(); // таймер
        public bool Init(string _N, string _B)
        {
            int i;
            if ((Int32.TryParse(_N, out N)) && (Int32.TryParse(_B, out B))) //если спарсил N и B
            {
                A = new int[N]; // массив A размером N             
                Random Aval = new Random();
                for (i = 0; i < N; i++)
                    A[i] = Aval.Next(B);
                return true;
            }
            else
                return false;
        }
        // выводит A[] в DataGridView
        public void Show(DataGridView _dgArr)
        {
            int i;
            _dgArr.RowCount = N + 1;
            for (i = 0; i < N; i++)
                _dgArr.Rows[i].Cells[0].Value = A[i].ToString();
        }
        // так и не понял зачем и куда. Везде меняется A[] и содержимое gv 
        public bool Save(DataGridView _dgArr)
        {
            int i;
            bool tmp;
            tmp = true;
            for (i = 0; i < N; i++)
                tmp = tmp & Int32.TryParse(_dgArr.Rows[i].Cells[0].Value.ToString(), out A[i]);
            return tmp;
        }
        // сортировка вставками
        public void InsertSort()
        {
            int i, j;
            int tmp;
            bool eoc;
            for (i = 1; i < N; i++)
            {
                tmp = A[i];
                j = i - 1;
                eoc = false;
                while (!eoc)
                {
                    if (j < 0)
                        eoc = true;
                    else
                        if (A[j] < tmp)
                        eoc = true;
                    else
                    {
                        A[j + 1] = A[j];
                        j = j - 1;
                    }
                }
                A[j + 1] = tmp;
            }
        }
        // сортировка пузырьком
        public void BubbleSort(int h)
        {
            int i, j, Margin;
            int tmp;
            bool Finish;
            Margin = N - h - 1;
            j = Margin;
            do
            {
                Finish = true;
                for (i = 0; i <= Margin; i++)
                {
                    if (A[i] > A[i + h])
                    {
                        tmp = A[i];
                        A[i] = A[i + h];
                        A[i + h] = tmp;
                        j = i;
                        Finish = false;
                    }
                }
                Margin = j - h;
            }
            while (!Finish);
        }
        // сортировка шеллом
        public void Shell()
        {
            int h;
            h = N / 2;
            while (h > 0)
            {
                BubbleSort(h);
                h = h / 2;
            }
        }
        // поиск первого совпадающего с _SI  элемента
        public int FindFirst(string _SI)
        {
            int SI, i, P;
            P = -1;
            i = 0;
            if (Int32.TryParse(_SI, out SI))
                while ((i < N) && (P == -1))
                    if (A[i] == SI)
                        P = i;
                    else
                        i = i + 1;
            return P;
        }

        // поиск в упорядоченном массиве
        public int DSearch(string _SI)
        {
            int left, middle, right;
            int SI;
            if (Int32.TryParse(_SI, out SI))
            {
                left = 0;
                right = N - 1;
                while (left < right)
                {
                    middle = (left + right) / 2;
                    if (A[middle] < SI)
                        left = middle + 1;
                    else
                        right = middle;
                }
                if (A[right] == SI)
                    return right;
                else
                    return -1;
            }
            return -1;
        }
        // сумма элементов с временем выполнения 
        public void SeqSum(out string _s, out string _dt)
        {
            int i, sum;
            timer.Restart();
            sum = 0;
            for (i = 0; i < N; i++)
                sum = sum + A[i];
            timer.Stop();
            MessageBox.Show(string.Format(@"Time:{0}", timer.Elapsed));
            _s = sum.ToString();
            _dt = string.Format(@"Time:{0}", timer.Elapsed);
        }
        // сумма элементов используя потоки
        public void ParSum(out string _s, out string _dt)
        {
            int i, sum;
            Task[] srAB = new Task[4];
            //Thread thrL = new Thread(sL);
            //Thread thrH = new Thread(sH);
            timer.Restart();
            //thrL.Start();
            //thrH.Start();
            //while (thrL.IsAlive | thrH.IsAlive);
            srAB[0] = Task.Factory.StartNew(
                        () =>
                        {
                            try
                            {
                                s0();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                        );
            srAB[1] = Task.Factory.StartNew(
                    () =>
                    {
                        try
                        {
                            s1();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    );
            srAB[2] = Task.Factory.StartNew(
                    () =>
                    {
                        try
                        {
                            s2();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    );
            srAB[3] = Task.Factory.StartNew(
                    () =>
                    {
                        try
                        {
                            s3();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    );
            Task.WaitAll(srAB);
            sum = sum0 + sum1 + sum2 + sum3;
            timer.Stop();
            MessageBox.Show(string.Format(@"Time:{0}", timer.Elapsed));
            _s = sum.ToString();
            _dt = string.Format(@"Time:{0}", timer.Elapsed);
        }
        static void s0()
        {
            int i;
            sum0 = 0;
            for (i = 0; i < N / 4; i++)
                sum0 = sum0 + A[i];
        }
        static void s1()
        {
            int i;
            sum1 = 0;
            for (i = N / 4; i < N / 2; i++)
                sum1 = sum1 + A[i];
        }
        static void s2()
        {
            int i;
            sum2 = 0;
            for (i = N / 2; i < 3 * N / 4; i++)
                sum2 = sum2 + A[i];
        }
        static void s3()
        {
            int i;
            sum3 = 0;
            for (i = 3 * N / 4; i < N; i++)
                sum3 = sum3 + A[i];
        }
    }
}
