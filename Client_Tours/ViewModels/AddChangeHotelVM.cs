using Client_Tours.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using API_Tours.Models;

namespace Client_Tours.ViewModels
{
    public class AddChangeHotelVM : ViewModelBase
    {
        Hotel? _newHotel;
        List<Country> _allCountry;
        List<Hotel> _allHotels;
        public Hotel? NewHotel { get => _newHotel; set => this.RaiseAndSetIfChanged( ref _newHotel, value); }
        
        //разворачивающийся список звезд
        List<int> _stars = new List<int>() { 0, 1, 2, 3, 4, 5};
        public List<int> Stars { get => _stars; set => this.RaiseAndSetIfChanged(ref _stars, value); }
        
        int _selectedStas = 0;
        public int SelectedStas { get => _selectedStas; set { NewHotel.CountOfStars = value; this.RaiseAndSetIfChanged(ref _selectedStas, value);  } }
        

        //cписок стран
        List<Country> countries;
        public List<Country> Countries { get => countries; set => this.RaiseAndSetIfChanged(ref countries, value); }
        
        Country _selectedCountry ;
        public Country SelectedCountry { get => _selectedCountry; set { NewHotel.CountryCodeNavigation = value; this.RaiseAndSetIfChanged(ref _selectedCountry, value); } }

        public AddChangeHotelVM() {
            _newHotel = new Hotel();
            GetCountries("");
        }
        public AddChangeHotelVM(int idHotel) {
            GetData(idHotel);
        }

        async Task GetData(int idHotel) {
            await GetHotels(idHotel);
            await GetCountries(_newHotel.CountryCode);
        }

        async Task GetHotels(int idHotel) {
            string result = await MainWindowViewModel.Instance.api.GetHotels();
            _allHotels = JsonConvert.DeserializeObject<List<Hotel>>(result);
            NewHotel = _allHotels.FirstOrDefault(x => x.Id == idHotel);
        }
        async Task GetCountries(string code) {
            string result = await MainWindowViewModel.Instance.api.GetCountries();
            Countries = JsonConvert.DeserializeObject<List<Country>>(result);
            if ( code != "")
            {
                Country country = Countries.FirstOrDefault(x => x.Code == NewHotel.CountryCode);
                SelectedCountry = country;
                NewHotel.CountryCode = country.Code;
            }
            SelectedStas = NewHotel.CountOfStars;
            
        }

        

        public void GoBack() {
            MainWindowViewModel.Instance.PageContent = new ShowHotels();
        }

        public async Task SaveChange() {
            if (NewHotel.Description != "" && NewHotel.Name != "")
            {
                if (NewHotel.Id != 0)
                {//change
                    MainWindowViewModel.Instance.api.PutHotels(NewHotel);
                    MainWindowViewModel.Instance.PageContent = new ShowTours();
                }
                else
                {//add
                    HotelDto newHotel = new HotelDto
                    {
                        Name = NewHotel.Name,
                        CountOfStars = NewHotel.CountOfStars,
                        CountryCode = NewHotel.CountryCodeNavigation.Code,
                        Description = NewHotel.Description
                    };
                    MainWindowViewModel.Instance.api.PostHotels(newHotel);
                    MainWindowViewModel.Instance.PageContent = new ShowTours();
                }
            }
            else
            {
                await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Не все поля заполнены", ButtonEnum.Ok).ShowAsync();
            }
        }
    }
}
