using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGuideService.Data.Models
{
    public class DataVersions //Версии данных
    {
        /*Идентификатор*/
        public int id { get; set; }
        /*Наименование*/
        public string Name { get; set; }
        /*Тип версии*/
        public string VersionType { get; set; }
    }
}
