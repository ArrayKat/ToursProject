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
    internal class ShowHotelsVM : ViewModelBase
    {
        List<Hotel> hotelList;
        public List<Hotel> HotelList { get => hotelList; set => this.RaiseAndSetIfChanged( ref hotelList, value); }

        public ShowHotelsVM()
        {
            InitialAsync();
        }

        

        private async Task InitialAsync()
        {
            string result = await MainWindowViewModel.Instance.api.GetHotels();
            HotelList = JsonConvert.DeserializeObject<List<Hotel>>(result);
        }
    }
}
