using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Wcf.DTOs;

namespace Wcf.Interface
{
    [ServiceContract]
    public interface ICityWeather
    {
        [OperationContract]
        List<CityWeatherDTO> Get();

        [OperationContract]
        CityWeatherDTO GetUserById(int Id);

        [OperationContract]
        bool InsertUser(CityWeatherDTO User);

        [OperationContract]
        void UpdateUser(CityWeatherDTO User);

        [OperationContract]
        void DeleteUser(int Id);
    }
}