using NUnit.Framework;

namespace Tests
{

    [TestFixture]
    class TestCases
    {
        private GuiToyApp _guiToyApp;

        [SetUp]
        public void SetUp()
        {
            _guiToyApp = new GuiToyApp();
            _guiToyApp.Start();
        }

        [TearDown]
        public void TearDown()
        {
            _guiToyApp.Close();
        }


        [Test]
        public void CheckboxesAreIndicatedAsChecked()
        {
            _guiToyApp.Checkbox3.Click();
            _guiToyApp.Checkbox2.Click();
            _guiToyApp.CheckboxSetButton.Click();
            var result = _guiToyApp.CheckboxLabelText;
            Assert.AreEqual("Check 2,3 selected", result);
        }


        [Test]
        public void RadioButtonIsIndicatedAsSelected()
        {
            _guiToyApp.RadioButton1.Click();
            _guiToyApp.RadioButton3.Click();
            _guiToyApp.RadioSetButton.Click();
            var result = _guiToyApp.RadioLabelText;
            Assert.AreEqual("Radio 3 selected", result);
        }


        [Test]
        public void ListItemsAreIndicatedAsSelected()
        {
            _guiToyApp.ListBoxItem("list 1").Click();
            _guiToyApp.ListBoxItem("list 2").Click();
            _guiToyApp.ListBoxItem("list 3").Click();
            _guiToyApp.ListBoxItem("list 2").Click();
            _guiToyApp.ListSetButton.Click();
            var result = _guiToyApp.ListLabelText;
            Assert.AreEqual("List 1,3 selected", result);
        }


        [Test]
        public void ComboboxItemIsIndicatedAsSelected()
        {
            _guiToyApp.ComboBox.Select("combo 1");
            _guiToyApp.ComboBox.Select("combo 2");
            _guiToyApp.ComboBox.Select("combo 3");
            _guiToyApp.ComboSetButton.Click();
            var result = _guiToyApp.ComboLabelText;
            Assert.AreEqual("Combo 3 selected", result);
        }


        [Test]
        public void OpenModalDialog()
        {
            _guiToyApp.MenuOptions.Click();
            _guiToyApp.MenuOptions_OpenTestWindow.Click();
            var result = _guiToyApp.TestWindowText;
            Assert.AreEqual("This is a test window.", result);
            _guiToyApp.TestWindow_CloseButton.Click();
        }


    }
}
