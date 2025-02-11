
using Client_Tours.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tours.ViewModels
{
    public class ShowToursVM: ViewModelBase
    {
        List<Tour> tourList;
        public List<Tour> TourList { get => tourList; set => this.RaiseAndSetIfChanged(ref tourList, value); }
        List<Models.Type> typeList;
        public List<Models.Type> TypeList { get => typeList; set =>  typeList = value; }

        public ShowToursVM()
        {
            InitialAsync();
        }
        
        private async Task InitialAsync()
        {
            string result = await MainWindowViewModel.Instance.api.GetTours();
            TourList = JsonConvert.DeserializeObject<List<Tour>>(result);
            result = await MainWindowViewModel.Instance.api.GetTypes();
            TypeList =  JsonConvert.DeserializeObject<List<Models.Type>>(result);

        }


        //checkBox - только актуальные туры
        bool _checkIsActual = true;
        public bool CheckIsActual { get => _checkIsActual; set{ _checkIsActual = value; AllFilters(); } }

        //поисковая строка по названию и описанию
        string _searchTour;
        public string SearchTour { get => _searchTour; set { _searchTour = value; AllFilters(); } }

        //фильтрация по типу тура:
        Models.Type _selectType;
        public Models.Type SelectType { get =>_selectType; set { _selectType = value; AllFilters(); } }

       

        void AllFilters() {
            InitialAsync();

            //checkBox - только актуальные туры
            if (_checkIsActual) TourList = TourList.Where(x => x.IsActual == 1).ToList();

            //поисковая строка по названию и описанию
            if (!string.IsNullOrWhiteSpace(_searchTour))
            {
                TourList = TourList.Where(x => (x.Name.ToLower().Contains(_searchTour.ToLower())) || 
                (x.Description.ToLower().Contains(_searchTour.ToLower()))).ToList();
            }

            //фильтрация по типу тура:
            if (_selectType != null && _selectType.Id != 0)
            {
                TourList = TourList.Where(x => x.ToursTypes.Any(y => y.Type.Id == _selectType.Id)).ToList();
            }
        }
    }
}
