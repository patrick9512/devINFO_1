using DevInfo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DevInfo.ViewModels
{
    class DevInfoViewModel
    {
        public ObservableCollection<User> Users => LoadUsers();

        public User SelectedUser { get; set; }

        XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<User>), new XmlRootAttribute("ArrayOfUser"));
        XElement UsersFromFile = XElement.Load(@"Users.xml");

        public ICommand SaveCommand { get; set;  }
        public ICommand CreateCommand { get; set;  }

        public DevInfoViewModel()   
        {
            SaveCommand = new RelayCommand(SaveUsers);
            CreateCommand = new RelayCommand(CreateUser);
        }

        public void CreateUser(object obj)
        {
            string txtName, txtlastName;
            
            User newUser = new User(txtName, txtlastName, 0);


        }

        private void SaveUsers(object obj)
        {
            string json = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(@"users.json", json);
        }


        public ObservableCollection<User> LoadUsers()
        {
            // read file into a string and deserialize JSON to a type
            ObservableCollection<User> users = JsonConvert.DeserializeObject<ObservableCollection<User>>(File.ReadAllText(@"users.json"));
            return users;
        }


        public StringReader ReadUsersFromFile()
        {
            //XElement UsersFromFile = XElement.Load(@"Users.xml");
            StringReader stringReader = new StringReader(UsersFromFile.ToString());
            return stringReader;
        }

        private ObservableCollection<User> LoadUser()
        {

            return (ObservableCollection<User>)xs.Deserialize(ReadUsersFromFile());
        }




    }
}
