using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Swiper
{
    public class MainPageViewModel
    {
        public Command<int> SwipedLeftCommand;
        public Command<int> SwipedRightCommand;

        public MyModel TopMyModel { get; set; }

        public ObservableCollection<MyModel> MyList { get; set; }
        public ObservableRangeCollection<ProfileModel> ProfileList { get; set; }

        public MainPageViewModel()
        {
            try
            {
                SwipedLeftCommand = new Command<int>((index) => SwipeLeft(index));
                SwipedRightCommand = new Command<int>((index) => SwipeRight(index));
                MyList = new ObservableCollection<MyModel>();
                MyList.Add(new MyModel { Name = "Tiger", ImageUrl = "https://images.pexels.com/photos/39629/tiger-tiger-baby-tigerfamile-young-39629.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Cat", ImageUrl = "https://images.pexels.com/photos/236230/pexels-photo-236230.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Monkey Selfie", ImageUrl = "https://images.pexels.com/photos/60023/baboons-monkey-mammal-freeze-60023.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Antelope", ImageUrl = "https://images.pexels.com/photos/52961/antelope-nature-flowers-meadow-52961.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Autralian Parrot", ImageUrl = "https://images.pexels.com/photos/37833/rainbow-lorikeet-parrots-australia-rainbow-37833.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Sheep", ImageUrl = "https://images.pexels.com/photos/288621/pexels-photo-288621.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Rabbit", ImageUrl = "https://images.pexels.com/photos/33152/european-rabbits-bunnies-grass-wildlife.jpg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "Shark", ImageUrl = "https://images.pexels.com/photos/726478/pexels-photo-726478.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" });
                MyList.Add(new MyModel { Name = "React Native", ImageUrl = "https://facebook.github.io/react-native/docs/assets/favicon.png" });

                TopMyModel = MyList[0];

                ProfileList = new ObservableRangeCollection<ProfileModel>();
                FetchUsers();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }

        void SwipeRight(int index)
        {

        }

        void SwipeLeft(int index)
        {

        }

        async Task FetchUsers()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://randomuser.me/api");
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var rootModel = JsonConvert.DeserializeObject<RootModel>(responseString);
                    ProfileList.Clear();
                    ProfileList.AddRange(rootModel.Profiles);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - " + ex.Message);
            }
        }
    }
}
