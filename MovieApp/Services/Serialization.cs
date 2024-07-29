using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MovieApp.Model;
using System.Configuration;

namespace MovieApp.Services
{
    public class Serialization
    {

        string fileNameTry = ConfigurationManager.AppSettings["filepathjson"];

        public  void SerializeData(List<Movie> movieList)
        {
            File.WriteAllText(fileNameTry, JsonConvert.SerializeObject(movieList));
        }

        public List<Movie> DesrializeData()
        {
            List<Movie> movieList = null;
            
            if (File.Exists(fileNameTry))
            {
                string json = File.ReadAllText(fileNameTry);
                movieList = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            else
            {
                movieList = new List<Movie>();
            }
            return movieList;

        }
    }
}
