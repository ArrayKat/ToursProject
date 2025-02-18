using Client_Tours.Models;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Tours.ViewModels
{
    internal class ShowHotelsVM : ViewModelBase
    {
        List<Hotel> hotelList;
        public List<Hotel> HotelList { get => hotelList; set => this.RaiseAndSetIfChanged( ref hotelList, value); }
        public int AllCountHotel { get => _allCountHotel; set => this.RaiseAndSetIfChanged(ref _allCountHotel, value);  }
        public int CurentCountHotek { get => _curentCountHotek; set => this.RaiseAndSetIfChanged(ref _curentCountHotek, value); }

        int _allCountHotel =0;
        int _curentCountHotek = 0;
        public ShowHotelsVM()
        {
            InitialAsync();
        }

        private async Task InitialAsync()
        {

            string result = await MainWindowViewModel.Instance.api.GetHotels();
            HotelList = JsonConvert.DeserializeObject<List<Hotel>>(result);
            HotelList.ForEach(x => AllCountHotel++);
        }

        public void ToAddHotel() {
            MainWindowViewModel.Instance.PageContent = new AddChangeHotel();
        }
        public void UpdateHotel(int idHotel)
        {
            MainWindowViewModel.Instance.PageContent = new AddChangeHotel(idHotel);
        }
        
        public async void DeleteHotel(int idHotel)
        {
            ButtonResult result = await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Хотите удалить данный отель?", ButtonEnum.YesNo).ShowAsync();
            if (result == ButtonResult.Yes)
            {
                MainWindowViewModel.Instance.api.DeleteHotels(idHotel);
                MainWindowViewModel.Instance.PageContent = new ShowTours();
                await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Отель успешно удален", ButtonEnum.Ok).ShowAsync();
            }
        }
        public void GoBack() {
            MainWindowViewModel.Instance.PageContent = new ShowTours();
        }
    }
}
