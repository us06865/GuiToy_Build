using System;
using System.Windows.Automation;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowItems;

namespace Tests
{
    public class GuiToyApp
    {
        private const string PathToApp = "GuiToy.exe";
        private const string AppTitle = "GuiToy";
        private Application _app;
        private Window _appWindow;

        public void Start()
        {
            KillAllWindows();
            _app = Application.Launch(PathToApp);
            _appWindow = _app.GetWindow(AppTitle);
            //ItemById<TextBox>("delayTextBox").Text = "1000";
        }

        public void Close()
        {
            _app.Kill();
        }

        private static void KillAllWindows()
        {
            var rootElement = AutomationElement.RootElement;
            var winCollection = rootElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            foreach (AutomationElement element in winCollection)
            {
                Console.WriteLine(element.Current.Name);
                if (element.Current.Name == AppTitle)
                {
                    var id = element.Current.ProcessId;
                    Application.Attach(id).Kill();
                }
            }
        }

        private T ItemById<T>(string id) where T : UIItem
        {
            var searchCriteria = SearchCriteria.ByAutomationId(id);
            var foundItem = _appWindow.Get<T>(searchCriteria);
            if (foundItem == null)
                throw new Exception(string.Format("Unable to find by AutomationId: '{0}'", id));
            return foundItem;
        }

        private T ItemByText<T>(string text) where T : UIItem
        {
            var searchCriteria = SearchCriteria.ByText(text);
            var foundItem = _appWindow.Get<T>(searchCriteria);
            if (foundItem == null)
                throw new Exception(string.Format("Unable to find by Text: '{0}'", text));
            return foundItem;
        }

        public CheckBox Checkbox1
        {
            get { return ItemById<CheckBox>("checkBox1"); }
        }

        public CheckBox Checkbox2
        {
            get { return ItemById<CheckBox>("checkBox2"); }
        }

        public CheckBox Checkbox3
        {
            get { return ItemById<CheckBox>("checkBox3"); }
        }

        public Button CheckboxSetButton
        {
            get { return ItemById<Button>("checkboxSetButton"); }
        }

        public string CheckboxLabelText
        {
            get { return ItemById<Label>("CheckboxLabel").Text; }
        }

        public RadioButton RadioButton1
        {
            get { return ItemById<RadioButton>("radioButton1"); }
        }

        public RadioButton RadioButton2
        {
            get { return ItemById<RadioButton>("radioButton2"); }
        }

        public RadioButton RadioButton3
        {
            get { return ItemById<RadioButton>("radioButton3"); }
        }

        public Button RadioSetButton
        {
            get { return ItemById<Button>("radioSetButton"); }
        }

        public string RadioLabelText
        {
            get { return ItemById<Label>("radioLabel").Text; }
        }

        public ListBox ListBox
        {
            get { return ItemById<ListBox>("listBox1"); }
        }

        public ListItem ListBoxItem(string text)
        {
            return ItemByText<ListItem>(text);
        }

        public Button ListSetButton
        {
            get { return ItemById<Button>("listSetButton"); }
        }

        public string ListLabelText
        {
            get { return ItemById<Label>("listLabel").Text; }
        }

        public ComboBox ComboBox
        {
            get { return ItemById<ComboBox>("comboBox1"); }
        }

        public Button ComboSetButton
        {
            get { return ItemById<Button>("comboSetButton"); }
        }

        public string ComboLabelText
        {
            get { return ItemById<Label>("comboLabel").Text; }
        }

        public Menu MenuOptions
        {
            get { return ItemByText<Menu>("Options"); }
        }

        public Menu MenuOptions_OpenTestWindow
        {
            get { return ItemByText<Menu>("Open Test Window"); }
        }

        public Window TestWindow
        {
            get { return _appWindow.MessageBox("Test Window"); }
        }

        public bool IsTestWindowOpen
        {
            get { return null != TestWindow; }
        }

        public string TestWindowText
        {
            get
            {
                return TestWindow.Get<Label>(SearchCriteria.ByAutomationId("65535")).Text;
            }
        }

        public Button TestWindow_CloseButton
        {
            get { return TestWindow.Get<Button>(SearchCriteria.ByText("Close")); }
        }

    }
}
