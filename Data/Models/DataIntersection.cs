using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiDataService.Data.Models
{
    public class DataIntersection //модель пересечения данных из сервиса данных
    {
        public int id { get; set; }
        public int Objectindex { get; set; }
        public int Versionindex { get; set; }
        public int Intersection { get; set; }
    }
}
