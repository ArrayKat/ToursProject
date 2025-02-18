using Client_Tours.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tours.ViewModels
{
    public class ShowToursVM: ViewModelBase
    {
        List<Tour> _tours;
        List<Tour> tourList;
        public List<Tour> TourList { get => tourList; set => this.RaiseAndSetIfChanged(ref tourList, value); }
        List<TypeLocal> typeList;
        public List<TypeLocal> TypeList { get => typeList; set => this.RaiseAndSetIfChanged(ref typeList , value); }



        public ShowToursVM()
        {
            GetTourList();
            InitialAsync();
        }
        
        private async Task InitialAsync()
        {
            string result = await MainWindowViewModel.Instance.api.GetTours();
            TourList = JsonConvert.DeserializeObject<List<Tour>>(result);
            result = await MainWindowViewModel.Instance.api.GetTypes();
            TypeList = [new TypeLocal() { Id =0, Type1 = "Все типы туров" }, .. JsonConvert.DeserializeObject<List<TypeLocal>>(result)];
            TourList.ForEach(x => AllCostTours += x.Price * x.TicketCount);
            TourList.ForEach(x => AllCountTours++);
            TourList.ForEach(x => CurrentCountTours++);

        }
        private async Task GetTourList()
        {
            string result = await MainWindowViewModel.Instance.api.GetTours();
            _tours = JsonConvert.DeserializeObject<List<Tour>>(result);
            TourList = _tours;
        }

        //checkBox - только актуальные туры
        bool _checkIsActual = false;
        public bool CheckIsActual { get => _checkIsActual; set{ this.RaiseAndSetIfChanged( ref _checkIsActual ,value); AllFilters(); } }

        //поисковая строка по названию и описанию
        string _searchTour;
        public string SearchTour { get => _searchTour; set { this.RaiseAndSetIfChanged(ref _searchTour, value); AllFilters(); } }

        //фильтрация по типу тура:
        TypeLocal _selectType;
        public TypeLocal SelectType { get =>_selectType; set { this.RaiseAndSetIfChanged(ref _selectType, value); AllFilters(); } }

        //сортировка по убыванию/возрастанию цены
        private List<string> _sortValue = new List<string>()
        {
            "Без сортировки",
            "По возрастанию",
            "По убыванию"
        };
        public List<string> SortValue { get => _sortValue; set => _sortValue = value; }
        
        int _sortValueID = 0;
        public int SortValueID { get => _sortValueID; set { this.RaiseAndSetIfChanged(ref _sortValueID, value); AllFilters(); } }


        //общая стоимость туров:
        int _allCostTours = 0;
        public int AllCostTours { get => _allCostTours; set => this.RaiseAndSetIfChanged(ref _allCostTours, value); }
        


        // общее и текущее количество туров на странице
        int _allCountTours = 0;
        public int AllCountTours { get => _allCountTours; set => this.RaiseAndSetIfChanged(ref _allCountTours, value); }
       

        int _currentCountTours = 0;
        public int CurrentCountTours { get => _currentCountTours; set => this.RaiseAndSetIfChanged(ref _currentCountTours, value); }

        public void AllFilters() {
            TourList = _tours;

            AllCountTours = 0;
            TourList.ForEach(x => AllCountTours++);

            //checkBox - только актуальные туры
            if (_checkIsActual) TourList = TourList.Where(x => x.IsActual == 1).ToList();

            //поисковая строка по названию и описанию
            if (!string.IsNullOrWhiteSpace(SearchTour))
            {
                TourList = TourList.Where(x => (x.Name.ToLower().Contains(_searchTour.ToLower())) ||
                (x.Description.ToLower().Contains(_searchTour.ToLower()))).ToList();
            }

            //фильтрация по типу тура:
            if (_selectType != null && _selectType.Id != 0)
            {
                TourList = TourList.Where(x => x.ToursTypes.Any(y => y.TypeId == _selectType.Id)).ToList();
            }
            //сортировка по убыванию/возрастанию цены
            if (_sortValueID != 0) {
                if (_sortValueID == 1) TourList = TourList.OrderBy(x => x.Price).ToList();
                if (_sortValueID == 2) TourList = TourList.OrderByDescending(x => x.Price).ToList();
            }
            AllCostTours = 0;
            TourList.ForEach(x => AllCostTours += x.Price * x.TicketCount);

            CurrentCountTours = 0;
            TourList.ForEach(x => CurrentCountTours++);
        }
        public void GoToHotels() {
            MainWindowViewModel.Instance.PageContent = new ShowHotels();
        }

    }
}
