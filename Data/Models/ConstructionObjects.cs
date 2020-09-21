using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGuideService.Data.Models
{
    public class ConstructionObjects // Объекты строительства
    {
        /*Идентификатор объекта*/
        public int id { get; set; }
        /*Наименование объекта*/
        public string Name { get; set; }
        /*Код объекта*/
        public string ObjectCode { get; set; }
        /*Бюджет,млн.руб.*/
        public float Budget { get; set; }
    }
}
