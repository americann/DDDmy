using System;
using System.Data;
using DDD.Domain.Entity;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestVIewModelTest
    {
        //メソッド名を日本語で記述してもOK、他から呼び出されるものではないので
        [TestMethod]
        public void シナリオ()
        {
            var viewModel = new WeatherLatestViewModel(new WeatherMock());
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
            Assert.AreEqual("2", viewModel.ConditionText);
            Assert.AreEqual("12.00 ℃", viewModel.TemperatureText);


        }
    }

    //internalはテスト内でしか使わないから
    internal class WeatherMock : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            var entity = new WeatherEntity(1,Convert.ToDateTime("2018/01/01 12:34:56"),2,12.3f);

            return entity;
        }
    }

}

