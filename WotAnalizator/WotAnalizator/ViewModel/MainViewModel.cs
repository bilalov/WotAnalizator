using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WotAnalizator.Model;


namespace WotAnalizator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {  
        public PlayerStat PlayerStat { get; set; }

        public MainViewModel()
        {
            PlayerStat = new PlayerStat();
        }
    }
}
