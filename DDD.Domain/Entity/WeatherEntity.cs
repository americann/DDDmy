using System;
using System.Security.Cryptography.X509Certificates;

namespace DDD.Domain.Entity
{
    public sealed class WeatherEntity
    {
        //完全コンストラクタパターン
        public WeatherEntity(int areaId,DateTime dataDate,
            int condition, float temperature)
        {
            AreaId = areaId;
            DataDate = dataDate;
            Condition = condition;
            Temperature = temperature;
            

            //dt.Columns.Add("AreaId", typeof(int));
            //dt.Columns.Add("DataDate", typeof(DateTime));
            //dt.Columns.Add("Condition", typeof(int));
            //dt.Columns.Add("Temperature", typeof(int));
        }


        public int AreaId { get;  }
        public DateTime DataDate { get; }
        public int Condition { get; }
        public float Temperature { get; }

        public bool IsOK()
        {
            if (DataDate<DateTime.Now.AddMinutes(-1))
            {
                if (Temperature < 10)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
//ct tab tab でコンストラクタ
