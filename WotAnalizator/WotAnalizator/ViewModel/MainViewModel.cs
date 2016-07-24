using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WotAnalizator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {

                if (Set(() => Count, ref _count, value))
                {
                    if ((TotalTime > 0) && (AverageTime > 0)) FightResult = Calculate();
                }
            }

        }

        private int _averageTime;
        public int AverageTime
        {
            get { return _averageTime; }
            set
            {

                if (Set(() => AverageTime, ref _averageTime, value))
                {
                    if ((Count > 0) && (TotalTime > 0)) FightResult = Calculate();
                }
            }

        }

        private int _totalTime;
        public int TotalTime
        {
            get { return _totalTime; }

            set
            {
                if (Set(() => TotalTime, ref _totalTime, value))
                {
                    if ((Count > 0) && (AverageTime > 0)) FightResult = Calculate();
                }
            }
        }


        public MainViewModel()
        {
            Count = 0;
            AverageTime = 0;
            TotalTime = 0;
        }

        private string _fightResult;
        public string FightResult
        {
            get { return _fightResult; }
            set { Set(() => FightResult, ref _fightResult, value); }
        }

        private string Calculate()
        {
            if ((Count > 0) && (AverageTime > 0) && (TotalTime > 0))
            {
                string resultCalculation = string.Empty;
                double calculation = (double)Count * AverageTime / (60 * 365 * TotalTime);
                if ((calculation > 0) && (calculation < 1)) resultCalculation = "умеренно негативный";
                else
                {
                    if ((calculation > 1) && (calculation < 2)) resultCalculation = "стабильно негативный";
                    else resultCalculation = "катастрофически негативный";
                }
                return
                    string.Format(
                        "Вы потратили {0} час. своей жизни({1} мин.) за {2} дн.. Прогнозирование дальнейшего состояния: {3}",
                        Count * AverageTime / 60, Count * AverageTime, TotalTime * 365, resultCalculation);
            }
            else
            {
                return "";
            }
        }
    }
}
