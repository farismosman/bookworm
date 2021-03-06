﻿using System.Configuration;
using BookWorm.Tests.Specs.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BookWorm.Tests.Specs
{
    [Binding]
    internal class CreateBookSteps : BaseSteps
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            if (ConfigurationManager.AppSettings["Environment"] == "Test")
                Assert.Inconclusive("Skipping test on AppHarbor");
        }

        [Given(@"I am logged in as an admin")]
        public void IAmLoggedInAsAnAdmin()
        {
            var homePage = HomePage.NavigateTo(Driver);
            homePage = homePage.ClickOnLogin().LoginAdmin();
            ScenarioContext.Current.Set(homePage);
        }

        [When(@"I go to Create New Book page")]
        public void IGoToCreateNewBookPage()
        {
            var homePage = ScenarioContext.Current.Get<HomePage>();
            var createBookPage = homePage.NavigateToCreateBookPage();
            ScenarioContext.Current.Set(createBookPage);
        }

        [Then(@"I see Create New Book page")]
        public void ISeeCreateNewBookPage()
        {
            var createBookPage = ScenarioContext.Current.Get<CreateBookPage>();
            var homePage = ScenarioContext.Current.Get<HomePage>();
            Assert.IsTrue(createBookPage.IsCurrentPage());
            homePage.LogOut();
        }

        [When(@"I click create after filling the form")]
        public void IClickSaveAfterFillingTheForm()
        {
            var createBookPage = ScenarioContext.Current.Get<CreateBookPage>();
            var bookDetailsPage = createBookPage.FillForm("My new title").ClickSaveButton();
            ScenarioContext.Current.Set(bookDetailsPage);
        }

        [Then(@"I see the details of the newly created book")]
        public void ISeeTheDetailsOfTheNewlyCreatedBook()
        {
            var bookDetailsPage = ScenarioContext.Current.Get<BookDetailsPage>();
            var homePage = ScenarioContext.Current.Get<HomePage>();
            Assert.IsTrue(bookDetailsPage.IsCurrentPage("My new title"));
            homePage.LogOut();
        }

        [Given(@"I am on Create New Book page")]
        public void IAmOnCreateNewBookPage()
        {
            IAmLoggedInAsAnAdmin();
            IGoToCreateNewBookPage();
        }
    }
}